using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PasswordHashing
    {
        public static (byte[],string) HashPassword(string password) 
        {
            byte[] salt = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 5000,
                numBytesRequested: 64 ));

            return (salt,hashed);
        }
        public static bool IsPasswordCorrect(byte[] salt,string password,string hashed) 
        { 
            string hasingresult= Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 5000,
                numBytesRequested: 64));

            if (hasingresult==hashed)
            {
                return true;
            }

            return false;
        }
    }
}
