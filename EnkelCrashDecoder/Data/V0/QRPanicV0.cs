namespace EnkelCrashDecoder.Data.V0
{
    public class QRPanicV0
    {
        public static QRContent GetContentFromBytes(QRPanicHeader header, IntPtr data)
        {
            data = QRDecoder.GetStruct<QRPanicPacketHeader>(data, out var packetHeader);

            var segmentList = new List<object>();

            var output = new QRContent
            {
                Header = header,
                Segments = segmentList
            };

            if (packetHeader.Type == (UInt32)QRPacketType.CPURegs)
            {
                data = QRDecoder.GetStruct<QRPanicCPURegs>(data, out var regs);
                segmentList.Add(regs);
            }

            return output;
        }
    }
}
