namespace EnkelCrashDecoder
{
    public class SessionService
    {
        public void InsertScan(string sessionId, string sessionPayload)
        {
            lock (_sessions)
            {
                _sessions[sessionId] = sessionPayload;
            }
        }

        public string GetScan(string sessionId)
        {
            lock (_sessions)
            {
                return _sessions[sessionId];
            }
        }

        private Dictionary<string, string> _sessions { get; set; } = new Dictionary<string, string>();
    }
}
