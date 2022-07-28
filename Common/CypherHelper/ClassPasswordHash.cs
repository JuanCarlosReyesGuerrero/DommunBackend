namespace Common.CypherHelper
{
    public class ClassPasswordHash
    {
        public ClassPasswordHash()
        {
        }

        /// <summary>
        ///  Cadena fija para password de usuarios
        /// </summary>
        /// <returns></returns>
        public string GenerarCadenaFijaPassword()
        {
            string cadenaFija = "123";

            return cadenaFija;
        }

        /// <summary>
        /// Generar cadena aleatoria.
        /// </summary>
        /// <returns></returns>
        public string GenerarCadenaAleatoria()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        /// <summary>
        /// Encripta el password de la base de datos
        /// </summary>
        /// <param name="InputTextoDB"></param>
        /// <returns></returns>
        public string EncriptaPassDB(string InputTextoDB)
        {
            try
            {                
                ClassCryptoAux objCrypAux = new ClassCryptoAux();
                string OutputHashDB = objCrypAux.CrearHashDB(InputTextoDB);

                return OutputHashDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Desencripta el password de la base de datos
        /// </summary>
        /// <param name="InputHashDB"></param>
        /// <returns></returns>
        public string DesencriptaPassBD(string InputHashDB)
        {
            try
            {                
                ClassCryptoAux objCrypAux = new ClassCryptoAux();
                string OutPutTextoDB = objCrypAux.DecriptarHashDB(InputHashDB);

                return OutPutTextoDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Genera el Hash para el Usuario
        /// </summary>
        /// <param name="InputTextoUser"></param>
        /// <returns></returns>
        public string getMd5Hash(string InputTextoUser)
        {
            try
            {                
                ClassCryptoAux objCrypAux = new ClassCryptoAux();
                string OutputHashUser = objCrypAux.getMd5Hash(InputTextoUser);

                return OutputHashUser;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// verifica que el texto y el Hash sean iguales
        /// </summary>
        /// <param name="InputTextoUser"></param>
        /// <param name="InputHashUser"></param>
        /// <returns></returns>
        public bool verifyMd5Hash(string InputTextoUser, string InputHashUser)
        {
            try
            {                
                ClassCryptoAux objCrypAux = new ClassCryptoAux();

                if (objCrypAux.verifyMd5Hash(InputTextoUser, InputHashUser))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
