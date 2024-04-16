public class Base45Decoder
{
    private const string Base45Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";

    public static byte[] Decode(string input)
    {
        var output = new List<byte>();
        for (int i = 0; i < input.Length; i += 3)
        {
            int chunk = 0;
            if (i + 2 < input.Length)
            {
                chunk = Base45Alphabet.IndexOf(input[i]) + Base45Alphabet.IndexOf(input[i + 1]) * 45 + Base45Alphabet.IndexOf(input[i + 2]) * 45 * 45;
                output.Add((byte)(chunk >> 8));
            }
            else
            {
                chunk = Base45Alphabet.IndexOf(input[i]) + Base45Alphabet.IndexOf(input[i + 1]) * 45;
            }
            output.Add((byte)(chunk & 0xFF));
        }
        return output.ToArray();
    }
}
