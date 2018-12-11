using System;

namespace SQ.TechComp.NetCoreCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Demos.CryptographicHashFunctionDemo();
            Demos.SymmetricEncryptionDemo();
            Demos.AsymmetricEncryptionDemo();            
            Demos.MessageSignatureDemo();
        }
    }
}
