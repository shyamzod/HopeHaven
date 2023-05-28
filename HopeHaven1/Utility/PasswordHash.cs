using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WpfApp2.Utility
{
    public class PasswordHash
    {
        public string ComputeHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash of the password string
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
