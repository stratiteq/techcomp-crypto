using System;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TechComp.NetCoreCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type some hash and press Enter");

            string input;
            do
            {
                input = Console.ReadLine();

                Console.WriteLine(ComputeHash(input));
            }
            while (input != "q");
        }

        private static string ComputeHash(string message)
        {
            using(var sha256 = SHA256.Create())  
            {  
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(message));  
                
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();  
                
                // Return the hash   
                return hash;
            }  
        }

    }
}
