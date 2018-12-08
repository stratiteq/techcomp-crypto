using System;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TechComp.NetCoreCrypto
{
    static class CryptographicHash
    {
        internal static string ComputeHash(string message)
        {
            using(var sha256 = SHA256.Create())  
            {  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(message));

                return hashedBytes.ToHex();
            } 
        }
    }
}