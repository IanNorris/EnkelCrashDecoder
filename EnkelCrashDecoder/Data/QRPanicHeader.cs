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

    [StructLayout(LayoutKind.Sequential)]
    public class QRPanicPacketHeader
    {
        public UInt32 Type;
        public UInt32 Size;
    }

    public enum QRPacketType : UInt32
    {
        CPURegs = 0xA3000001,
    }
}
