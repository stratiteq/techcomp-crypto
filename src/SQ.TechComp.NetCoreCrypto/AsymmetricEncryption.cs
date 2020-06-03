using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TechComp.NetCoreCrypto
{
    static class AsymmetricEncryption
    {        
        internal static byte[] Encrypt(string message, RSAParameters rsaParameters)
        {
            using var rsaAlg = RSA.Create(rsaParameters);
            return rsaAlg.Encrypt(Encoding.UTF8.GetBytes(message), RSAEncryptionPadding.Pkcs1);
        }

        internal static string Decrypt(byte[] cipherText, RSAParameters rsaParameters)
        {
            using var rsaAlg = RSA.Create(rsaParameters);
            var decryptedMessage = rsaAlg.Decrypt(cipherText, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(decryptedMessage);
        }

        internal static byte[] Sign(string message, RSAParameters rsaParameters)
        {
            using var rsaAlg = RSA.Create(rsaParameters);
            return rsaAlg.SignData(Encoding.UTF8.GetBytes(message), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        internal static bool Verify(string message, byte[] signature, RSAParameters rsaParameters)
        {
            using var rsaAlg = RSA.Create(rsaParameters);
            return rsaAlg.VerifyData(Encoding.UTF8.GetBytes(message), signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}