using System;

namespace SQ.TechComp.NetCoreCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Cryptographic hash demo *****");
            Demos.CryptographicHashFunctionDemo();
            Console.Write(Environment.NewLine);
            
            Console.WriteLine("***** Symmetric encryption demo *****");
            Demos.SymmetricEncryptionDemo();
            Console.Write(Environment.NewLine);
            
            Console.WriteLine("***** Asymmetric encryption demo *****");
            Demos.AsymmetricEncryptionDemo();
            Console.Write(Environment.NewLine);
            
            Console.WriteLine("***** Message signature demo *****");
            Demos.MessageSignatureDemo();
            Console.Write(Environment.NewLine);
        }
    }
}
