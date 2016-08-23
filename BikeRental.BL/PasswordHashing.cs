using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using BikeRental.Interfases;

namespace BikeRental.BL
{
    public class PasswordHashing : IPasswordHashing
    {
        private static byte saltValueSize = 32;

        public string GenerateSaltValue()
        {
            var generator = RandomNumberGenerator.Create();
            byte[] saltValue = new byte[saltValueSize];
            generator.GetBytes(saltValue);
            return Convert.ToBase64String(saltValue);
        }

        public string HashPassword(string password, string saltValue)
        {
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Password is null");

            var encoding = new UnicodeEncoding();
            var hash = new SHA256CryptoServiceProvider();

            if (saltValue == null)
            {
                saltValue = GenerateSaltValue();
            }

            byte[] binarySaltValue = Convert.FromBase64String(saltValue);
            byte[] valueToHash = new byte[saltValueSize + encoding.GetByteCount(password)];
            byte[] binaryPassword = encoding.GetBytes(password);

            binarySaltValue.CopyTo(valueToHash, 0);
            binaryPassword.CopyTo(valueToHash, saltValueSize);

            byte[] hachValue = hash.ComputeHash(valueToHash);
            var hashedPassword = String.Empty;
            foreach (byte hexdigit in hachValue)
            {
                hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
            }
            return hashedPassword;
        }
    }
}
