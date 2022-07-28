using System.Security.Cryptography;
using System.Text;

namespace Common.CypherHelper
{
    internal class ClassCryptoAux
    {
        /// <summary>
        /// Clave(key)
        /// </summary>
        private byte[] _key;

        /// <summary>
        /// Desplazamiento(IV)
        /// </summary>
        private byte[] _iv;

        public ClassCryptoAux()
        {
            _key = Encoding.ASCII.GetBytes("}kU*s]hU=YPl6*3s1ARF0R+wc0-SaCgB");
            _iv = Encoding.ASCII.GetBytes("V8i9;~*asuAY-%uT");
        }
        

        /// <summary>
        /// Encripta la clave de la base de datos en el XML del web.config
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string CrearHashDB(string inputText)
        {
            try
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);
                byte[] encripted = null;
                Aes cripto = Aes.Create();

                using (MemoryStream ms = new MemoryStream(inputBytes.Length))
                {

                    using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(_key, _iv), CryptoStreamMode.Write))
                    {
                        objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                        objCryptoStream.FlushFinalBlock();
                        objCryptoStream.Close();
                    }

                    encripted = ms.ToArray();
                }

                return Convert.ToBase64String(encripted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Desencripta la clave de la base de datos en el XML del web.config
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string DecriptarHashDB(string inputText)
        {
            try
            {
                byte[] inputBytes = Convert.FromBase64String(inputText);
                byte[] resultBytes = new byte[inputBytes.Length];
                string textoLimpio = String.Empty;                
                Aes cripto = Aes.Create();                

                using (MemoryStream ms = new MemoryStream(inputBytes))
                {
                    using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(_key, _iv), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(objCryptoStream, true))
                        {
                            textoLimpio = sr.ReadToEnd();
                        }
                    }
                }
                return textoLimpio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hash de una cadena de entrada y devolver el hash como una cadena de caracteres hexadecimales 32.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getMd5Hash(string inputText)
        {
            return CrearHashDB(inputText);          
        }

        /// <summary>
        /// Comprobar un valor hash con una cadena.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool verifyMd5Hash(string input, string hash)
        {

            // Hash la entrada.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
