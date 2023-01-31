using BankApp.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace BankApp.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public Guid PasswordSalt { get; set; }
        public Role Role { get; set; }

        public bool IsAuthentic(string password)
        {
            //string saltedPassword = password + PasswordSalt;
            //var passwordHash = Encoding.UTF8.GetBytes(saltedPassword);
            //HashAlgorithm sha512 = SHA512.Create();
            //var computedPassword = sha512.ComputeHash(passwordHash);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedPassword = hmac.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));

                //return PasswordHash == computedPassword;
                return PasswordHash.SequenceEqual(computedPassword);
            }
        }
    }
}
