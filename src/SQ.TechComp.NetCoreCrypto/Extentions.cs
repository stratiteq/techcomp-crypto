using System;

namespace SQ.TechComp.NetCoreCrypto
{
    static class Extentions
    {
        public static string ToHex(this byte[] x) =>
            BitConverter.ToString(x).Replace("-", "").ToLower();
    }
}