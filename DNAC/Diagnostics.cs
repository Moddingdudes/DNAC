using System;

namespace DNAC
{
    public static class Diagnostics
    {
        public static void PrintAsBinary(byte num)
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
        }

        public static void PrintCodon(Codon codon, bool printProtein)
        {
            Console.Write("{0} {1} {2}", codon.base1, codon.base2, codon.base3);
            if (printProtein)
            {
                Console.Write(" - Resulting in protein {0}\n", AminoAcidConversion.GetAminoAcid(codon));
            }
        }

        public static void FillRandomBases(uint count, ref byte[] byteList)
        {
            if ((count & 3) == 0)
            {
                byteList = new byte[(count / 4)];
            }
            else
            {
                byteList = new byte[(count / 4) + 1];
            }

            DNABases[] baseArray = new DNABases[4];

            uint index = 0;

            for (uint i = 1; i <= count; i++)
            {
                System.Random random = new Random();

                int rand = random.Next(0, 4);

                baseArray[i % 4] = (DNABases)rand;

                if (i % 4 == 0)
                {
                    byteList[index] = Bitpacker.PackByte(baseArray).GetValueOrDefault();
                    index++;
                }
            }
        }
    }
}
