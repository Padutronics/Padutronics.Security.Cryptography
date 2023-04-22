using System.Security.Cryptography;
using System.Text;

namespace Padutronics.Security.Cryptography;

public sealed class MD5StringHasher : IStringHasher
{
    public string Hash(string input)
    {
        byte[] inputHash;
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);

        using (MD5 md5 = MD5.Create())
        {
            inputHash = md5.ComputeHash(inputBytes);
        }

        var stringBuilder = new StringBuilder();
        for (var inputHashIndex = 0; inputHashIndex < inputHash.Length; ++inputHashIndex)
        {
            stringBuilder.Append(inputHash[inputHashIndex].ToString("x2"));
        }

        return stringBuilder.ToString();
    }
}