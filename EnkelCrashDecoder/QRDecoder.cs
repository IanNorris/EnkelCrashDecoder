using System.Runtime.InteropServices;
using EnkelCrashDecoder.Data;
using EnkelCrashDecoder.Data.V0;

namespace EnkelCrashDecoder
{
    public static class QRDecoder
    {

        public static IntPtr GetStruct<T>(IntPtr ptr, out T structOut)
        {
            structOut = (T)Marshal.PtrToStructure(ptr, typeof(T));
            return ptr + Marshal.SizeOf<T>();
        }

        public static QRContent GetContentFromBytes(byte[] data)
        {
            // Allocate unmanaged memory for the struct
            IntPtr bufferPtr = Marshal.AllocHGlobal((int)data.Length);

            try
            {
                // Copy the data to unmanaged memory
                Marshal.Copy(data, 0, bufferPtr, data.Length);

                bufferPtr = GetStruct<QRPanicHeader>(bufferPtr, out var header);

                switch(header.Version)
                {
                    case 0:
                        return QRPanicV0.GetContentFromBytes(header, bufferPtr);

                    default:
                        throw new InvalidDataException($"Unsupported version {header.Version}");
                }
            }
            finally
            {
                // Free the unmanaged memory
                Marshal.FreeHGlobal(bufferPtr);
            }
        }

        public static QRContent GetContent(string inputString)
        {
            try
            {
                var compressedBytes = Base45Decoder.Decode(inputString);
                var bytes = ZlibDecompression.DeflateBytes(compressedBytes);

                return GetContentFromBytes(bytes);
            }
            catch
            {
                return null;
            }
        }
    }
}
