using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

namespace ApiAmbev.Global
{
    public class Cripto
    {
      

        public string EncryptTripleDES(string text)
        {
            string result;

            string Ckey = Config.key;

            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(Ckey);

            SHA256CryptoServiceProvider HashProvider = new SHA256CryptoServiceProvider();
            byte[] temp = HashProvider.ComputeHash(keyBytes);
            byte[] key = new byte[24];
            Array.Copy(temp, key, 24);

            TripleDESCryptoServiceProvider TripleDesProvider = new TripleDESCryptoServiceProvider();
            TripleDesProvider.Key = key;
            TripleDesProvider.Mode = CipherMode.ECB;
            TripleDesProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = TripleDesProvider.CreateEncryptor();

            byte[] resultBytes = cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

            result = Convert.ToBase64String(resultBytes);

            return result;
        }
        public string DecryptTrypleDES(string text)
        {
            string result = null;

            byte[] textBytes = Convert.FromBase64String(text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(Config.key);

            SHA256CryptoServiceProvider HashProvider = new SHA256CryptoServiceProvider();
            byte[] temp = HashProvider.ComputeHash(keyBytes);
            byte[] key = new byte[24];
            Array.Copy(temp, key, 24);

            TripleDESCryptoServiceProvider TripleDesProvider = new TripleDESCryptoServiceProvider();
            TripleDesProvider.Key = key;
            TripleDesProvider.Mode = CipherMode.ECB;
            TripleDesProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = TripleDesProvider.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

            result = Encoding.UTF8.GetString(resultArray);

            return result;
        }

    }
}
