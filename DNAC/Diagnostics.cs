using System;

namespace DNAC
{
    public static class Diagnostics
    {
        public static void PrintAsBinary(byte num, bool endLine)
        {
            int remainder;
            string result = string.Empty;
            while (num > 0)
            {
                remainder = num % 2;
                num /= 2;
                result = remainder.ToString() + result;
            }

            string final = "";

            for (int i=0; i<8-result.Length; i++)
            {
                final += "0";
            }


            Console.Write("{0}", final + result);

            if (endLine) Console.Write("\n");
        }

        public static void PrintCodon(Codon codon, bool printProtein)
        {
            Console.Write("{0} {1} {2}", codon.base1, codon.base2, codon.base3);
            if (printProtein)
            {
                Console.Write(" - Resulting in protein {0}\n", AminoAcidConversion.GetAminoAcid(codon));
            }
        }

        public static void FillRandomBases(int count, ref byte[] byteList)
        {
            if ((count & 3) == 0)
            {
                byteList = new byte[(count / 4)];
            }
            else
            {
                byteList = new byte[(count / 4) + 1];
            }

            System.Random random = new Random();
            int rand;

            for (int i = 0; i < count; i++)
            {
                

                rand = random.Next(0, 4);

                byteList[i / 4] = (byte)(byteList[i / 4] | (rand << ((i & 3) << 1)));
            }
        }
    }
}
