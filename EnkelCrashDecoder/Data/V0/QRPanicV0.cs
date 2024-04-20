namespace EnkelCrashDecoder.Data.V0
{
    public class QRPanicV0
    {
        public static QRContent GetContentFromBytes(QRPanicHeader header, IntPtr data)
        {
            data = QRDecoder.GetStruct<QRPanicCPURegs>(data, out var regs);

            return new QRContent
            {
                Header = header,
                Segments = new List<object>
                {
                    regs,
                }
            };
        }
    }
}
