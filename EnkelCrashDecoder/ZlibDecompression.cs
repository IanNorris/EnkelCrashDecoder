using System.IO.Compression;
using System.Text;

public class ZlibDecompression
{
    public static string DeflateByteArrayToString(byte[] compressedBytes)
    {
        // Create a memory stream with the compressed bytes
        using var compressedStream = new MemoryStream(compressedBytes);

        var header = new byte[2];
        compressedStream.Read(header);

        // Create a deflate stream to decompress the data
        using (var deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
        // Create a memory stream for the decompressed data
        using (var decompressedStream = new MemoryStream())
        {
            

            // Copy the decompressed data to the decompressedStream
            deflateStream.CopyTo(decompressedStream);

            // Get the decompressed bytes
            var decompressedBytes = decompressedStream.ToArray();

            // Convert the decompressed bytes to a string
            return Encoding.UTF8.GetString(decompressedBytes);
        }
    }

    public static byte[] DeflateBytes(byte[] compressedBytes)
    {
        // Create a memory stream with the compressed bytes
        using var compressedStream = new MemoryStream(compressedBytes);

        var header = new byte[2];
        compressedStream.Read(header);

        // Create a deflate stream to decompress the data
        using (var deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
        // Create a memory stream for the decompressed data
        using (var decompressedStream = new MemoryStream())
        {


            // Copy the decompressed data to the decompressedStream
            deflateStream.CopyTo(decompressedStream);

            return decompressedStream.ToArray();
        }
    }
}
