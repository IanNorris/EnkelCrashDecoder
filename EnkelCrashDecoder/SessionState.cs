namespace EnkelCrashDecoder
{
    public class SessionState
    {
        public delegate void OnStateUpdatedDelegate();

        public event OnStateUpdatedDelegate OnStateUpdated;

        public string Data { get; set; }

        public void SendStateUpdated()
        {
            OnStateUpdated?.Invoke();
        }
    }
}
