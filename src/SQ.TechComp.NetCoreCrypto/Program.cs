using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TechComp.NetCoreCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Cryptographic hash demo *****");
            CryptographicHashFunctionDemo();
            Console.WriteLine(string.Empty);
            
            Console.WriteLine("***** Symmetric encryption demo *****");
            SymmetricEncryptionDemo();
            Console.WriteLine(string.Empty);
        }

        private static void CryptographicHashFunctionDemo()
        {
            foreach (var message in new[] {
                "Fox",
                "The red fox jumps over the blue dog",
                "The red fox jumps ouer the blue dog",
                "The red fox jumps oevr the blue dog",
                "The red fox jumps oer the blue dog"})
            {
                Console.WriteLine($"{ message } => { ComputeHash(message) }");
            }
        }

        private static string ComputeHash(string message)
        {
            using(var sha256 = SHA256.Create())  
            {  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(message));

                return hashedBytes.ToHex();
            } 
        }

        private static void SymmetricEncryptionDemo()
        {
            var unencryptedMessage = "To be or not to be, that is the question, whether tis nobler in the...";
            Console.WriteLine("Unencrypted message: " + unencryptedMessage);

            // 1. Create a key (shared key between sender and reciever).
            byte[] key, iv;
            using (Aes aesAlg = Aes.Create())
            {
                key = aesAlg.Key;
                iv = aesAlg.IV;
            }

            // 2. Sender: Encrypt message using key
            var encryptedMessage = EncryptSymmetric(unencryptedMessage, key, iv);
            Console.WriteLine("Sending encrypted message: " + encryptedMessage.ToHex());

            // 3. Receiver: Decrypt message using same key
            var decryptedMessage = DecryptSymmetric(encryptedMessage, key, iv);
            Console.WriteLine("Recieved and decrypted message: " + decryptedMessage);
        }

        private static byte[] EncryptSymmetric(string message, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(message); // Write all data to the stream.
                        }
                        return ms.ToArray();
                    }
                }
            };
        }

        private static string DecryptSymmetric(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var ms = new MemoryStream(cipherText))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
