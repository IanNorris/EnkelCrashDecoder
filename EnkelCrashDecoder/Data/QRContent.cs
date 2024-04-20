namespace EnkelCrashDecoder.Data
{
    public class QRContent
    {
        public QRPanicHeader Header { get; set; }
        public IEnumerable<object> Segments { get; set; }
    }
}
