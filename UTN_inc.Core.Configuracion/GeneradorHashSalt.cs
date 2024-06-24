using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Configuracion
{
    public class GeneradorHashSalt
    {

        private static int salt;

        //private static string hash;
        //public static int salt;

        //public static string GetHash()
        //{
        //    return hash;
        //}

        public static int GetSalt()
        {
            return salt;
        }

        public static void SetSalt(int newSalt)
        {
            salt = newSalt;
        }

        /*
         LOGiN
        Contraseña + traer de bd usuario.salt


         */

        public static string GenerarHash(string contraseñaMasSalt)
        {
            string contraseñaHash;

            byte[] cadenaByte = Encoding.UTF8.GetBytes(contraseñaMasSalt);//apartir de aca se convierte en hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(cadenaByte);
                contraseñaHash = BitConverter.ToString(hash);
            }

            return contraseñaHash;
        }

        public static string GenerarSalt(string contraseña)
        {

            int numeroRandom = GeneradorRandom();
            SetSalt(numeroRandom);
            contraseña = numeroRandom.ToString() + contraseña;//Concateno el Salt a la contraseña

            return contraseña;
        }

        public static int GeneradorRandom() 
        {
            Random random = new Random();
            int numeroRandom = random.Next(100000, 999999);//Genero Salt
            return numeroRandom;
        }
    }
}
