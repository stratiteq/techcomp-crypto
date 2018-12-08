using System;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TechComp.NetCoreCrypto
{
    static class Demos
    {
        internal static void CryptographicHashFunction()
        {
            foreach (var message in new[] {
                "Fox",
                "The red fox jumps over the blue dog",
                "The red fox jumps ouer the blue dog",
                "The red fox jumps oevr the blue dog",
                "The red fox jumps oer the blue dog"})
            {
                Console.WriteLine($"{ message } => { CryptographicHash.ComputeHash(message) }");
            }
        }

        internal static void SymmetricEncryptionDemo()
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
            var encryptedMessage = SymmetricEncryption.Encrypt(unencryptedMessage, key, iv);
            Console.WriteLine("Sending encrypted message: " + encryptedMessage.ToHex());

            // 3. Receiver: Decrypt message using same key
            var decryptedMessage = SymmetricEncryption.Decrypt(encryptedMessage, key, iv);
            Console.WriteLine("Recieved and decrypted message: " + decryptedMessage);
        }
    }
}