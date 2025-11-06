// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("WVZ7SHmhDbhigaoZZPL/fjIlL9CTfjSaG0fyoPdEA7ei5mkEP3IfN1QRQiRw+oz5vaYxkuGnBU+4V+xBRDujIXonPj1pmsS6khLPKB8EStQb0ujyj5/QDoAQfpSUA47sQGGnPJ81JJ3ivNf+8OtJnyLtG0/vJAM3B4SKhbUHhI+HB4SEhUBQWNBzHXxta1qtuGsepF4Pu+Uc0/4/H3L+e84jIKq2VcEQIecD7tqVwAbVykuYkNTyJrA4pwvCwQq79Mn1Usdoc7jFE0vT/neG5ZFIOBiKervR/Hli77UHhKe1iIOMrwPNA3KIhISEgIWGRha93Jevgs/plmkIrbl3v7jEfh9xG4HeGXSWUk0zmpPgRWlx8BMY3FKfwVBAcBvpfoeGhIWE");
        private static int[] order = new int[] { 8,7,6,11,10,10,7,12,9,13,10,13,12,13,14 };
        private static int key = 133;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
