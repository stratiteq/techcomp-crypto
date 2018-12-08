using System;

namespace SQ.TechComp.NetCoreCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Cryptographic hash demo *****");
            Demos.CryptographicHashFunction();
            Console.WriteLine(string.Empty);
            
            Console.WriteLine("***** Symmetric encryption demo *****");
            Demos.SymmetricEncryptionDemo();
            Console.WriteLine(string.Empty);
        }
    }
}
