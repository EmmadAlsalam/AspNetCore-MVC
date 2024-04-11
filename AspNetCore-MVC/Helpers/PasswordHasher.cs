//using System;
//using System.Security.Cryptography;
//using System.Text;

//namespace Infrastructure.Helpers
//{
//    public class PasswordHasher
//    {
//        public static (string, string) GenerateSecurePassword(string password)
//        {
//            try
//            {
//                using var hmac = new HMACSHA512();
//                var securityKey = Convert.ToBase64String(hmac.Key);
//                var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
//                return (securityKey, hash);
//            }
//            catch { }
//            return (null!, null!);
//        }

//        public static bool ValidateSecurePassword(string password, string hash, string securityKey)
//        {
//            try
//            {
//                using var hmac = new HMACSHA512(Convert.FromBase64String(securityKey));
//                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

//                for (var i = 0; i < computedHash.Length; i++)
//                {
//                    if (computedHash[i] != hash[i])
//                        return false;
//                }
//                return true;
//            }
//            catch { }
//            return false;
//        }
//    }
//}
