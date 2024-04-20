using System.Runtime.InteropServices;

namespace EnkelCrashDecoder.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public class QRPanicHeader
    {
        public byte MagicByte;
        public byte Version;
        public byte Page;
        public byte PageCount;
        public UInt32 Pad;
    }
}
