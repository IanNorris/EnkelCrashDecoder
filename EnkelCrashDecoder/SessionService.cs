namespace EnkelCrashDecoder
{
    public class SessionService
    {
        public void InsertScan(string sessionId, string sessionPayload)
        {
            lock (_sessions)
            {
                if (_sessions.TryGetValue(sessionId, out var existingSession))
                {
                    existingSession.Data = sessionPayload;

                    existingSession.SendStateUpdated();
                }
                else
                {
                    _sessions[sessionId] = new SessionState
                    {
                        Data = sessionPayload
                    };
                }
            }
        }

        public SessionState GetScan(string sessionId)
        {
            lock (_sessions)
            {
                return _sessions[sessionId];
            }
        }

        private Dictionary<string, SessionState> _sessions { get; set; } = new Dictionary<string, SessionState>();
    }
}
