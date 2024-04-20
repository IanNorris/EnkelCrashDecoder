using System.Runtime.InteropServices;

namespace EnkelCrashDecoder.Data.V0
{
    [StructLayout(LayoutKind.Sequential)]
    public class QRPanicCPURegs
    {
        public UInt64 RAX; //0x00
        public UInt64 RBX; //0x08
        public UInt64 RCX; //0x10
        public UInt64 RDX; //0x18
        public UInt64 RSI; //0x20
        public UInt64 RDI; //0x28

        public UInt64 R8;  //0x30
        public UInt64 R9;  //0x38
        public UInt64 R10; //0x40
        public UInt64 R11; //0x48
        public UInt64 R12; //0x50
        public UInt64 R13; //0x58
        public UInt64 R14; //0x60
        public UInt64 R15; //0x68

        public UInt64 RIP; //0x70
        public UInt64 RSP; //0x78
        public UInt64 RBP; //0x80
        public UInt64 RFLAGS; //0x88

        public UInt64 CR0; //0x90
        public UInt64 CR2; //0x98
        public UInt64 CR3; //0xA0
        public UInt64 CR4; //0xA8

        public UInt64 GDTR; //0xB0
        public UInt64 LDTR; //0xB8
        public UInt64 IDTR; //0xC0
        public UInt64 TR;   //0xC8

        public UInt64 FSBase; //0xD0
        public UInt64 GSBase; //0xD8
        public UInt64 GSBaseOther; //0xE0

        public UInt16 CS; //0xE8
        public UInt16 DS; //0xEA
        public UInt16 SS; //0xEC
        public UInt16 ES; //0xEE

        public UInt16 FS; //0xF0
        public UInt16 GS; //0xF2

        public UInt16 EnkelStateBits; //0xF4
        public byte ISR0; //ISR stack //0xF6,0xF7
        public byte ISR1;
    }
}
