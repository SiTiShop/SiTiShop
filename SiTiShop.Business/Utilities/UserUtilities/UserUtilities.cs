using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Business.Utilities.UserUtilities
{
    public class UserUtilities
    {
        public static byte[] CreatePasswordHash(string password)
        {
            using (MD5 mh = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hash = mh.ComputeHash(inputBytes);
                return hash;
            }
        }

        public static bool VerifyPasswordHash(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }
    }
}
