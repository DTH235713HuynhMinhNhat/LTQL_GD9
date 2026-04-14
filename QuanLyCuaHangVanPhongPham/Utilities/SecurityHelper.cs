using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyCuaHangVanPhongPham.Utilities
{
    public static class SecurityHelper
    {
        /// <summary>
        /// Mã hóa chuỗi sang SHA256
        /// </summary>
        /// <param name="rawData">Chuỗi cần mã hóa</param>
        /// <returns>Chuỗi đã mã hóa hex</returns>
        public static string HashPassword(string rawData)
        {
            if (string.IsNullOrEmpty(rawData)) return "";

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Kiểm tra mật khẩu khớp với hash
        /// </summary>
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hashOfInput = HashPassword(inputPassword);
            return string.Equals(hashOfInput, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
