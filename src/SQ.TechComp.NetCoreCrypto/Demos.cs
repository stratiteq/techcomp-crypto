using System;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TechComp.NetCoreCrypto
{
    static class Demos
    {
        internal static void CryptographicHashFunctionDemo()
        {
            Console.WriteLine("***** Cryptographic hash demo *****");

            foreach (var message in new[] {
                "Fox",
                "The red fox jumps over the blue dog",
                "The red fox jumps ouer the blue dog",
                "The red fox jumps oevr the blue dog",
                "The red fox jumps oer the blue dog"})
            {
                Console.WriteLine($"{ message } => { CryptographicHash.ComputeHash(message) }");
            }
            
            Console.Write(Environment.NewLine);
        }

        internal static void SymmetricEncryptionDemo()
        {
            Console.WriteLine("***** Symmetric encryption demo *****");

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
            
            Console.Write(Environment.NewLine);
        }

        internal static void AsymmetricEncryptionDemo()
        {
            Console.WriteLine("***** Asymmetric encryption demo *****");

            var unencryptedMessage = "To be or not to be, that is the question, whether tis nobler in the...";
            Console.WriteLine("Unencrypted message: " + unencryptedMessage);

            // 1. Create a public / private key pair.
            RSAParameters privateAndPublicKeys, publicKeyOnly;
            using (var rsaAlg = RSA.Create())
            {
                privateAndPublicKeys = rsaAlg.ExportParameters(includePrivateParameters: true);
                publicKeyOnly = rsaAlg.ExportParameters(includePrivateParameters: false);
            }

            // 2. Sender: Encrypt message using public key
            var encryptedMessage = AsymmetricEncryption.Encrypt(unencryptedMessage, publicKeyOnly);
            Console.WriteLine("Sending encrypted message: " + encryptedMessage.ToHex());

            // 3. Receiver: Decrypt message using private key
            var decryptedMessage = AsymmetricEncryption.Decrypt(encryptedMessage, privateAndPublicKeys);
            Console.WriteLine("Recieved and decrypted message: " + decryptedMessage);
            
            Console.Write(Environment.NewLine);
        }

        internal static void MessageSignatureDemo()
        {
            Console.WriteLine("***** Message signature demo *****");

            var message = "To be or not to be, that is the question, whether tis nobler in the...";
            Console.WriteLine("Message to be verified: " + message);

            // 1. Create a public / private key pair.
            RSAParameters privateAndPublicKeys, publicKeyOnly;
            using (var rsaAlg = RSA.Create())
            {
                privateAndPublicKeys = rsaAlg.ExportParameters(includePrivateParameters: true);
                publicKeyOnly = rsaAlg.ExportParameters(includePrivateParameters: false);
            }

            // 2. Sender: Sign message using private key
            var signature = AsymmetricEncryption.Sign(message, privateAndPublicKeys);
            Console.WriteLine("Message signature: " + signature.ToHex());

            // 3. Receiver: Verify message authenticity using public key
            var isTampered = AsymmetricEncryption.Verify(message, signature, publicKeyOnly);
            Console.WriteLine("Message is untampered: " + isTampered.ToString());

            Console.Write(Environment.NewLine);
        }
    }
}