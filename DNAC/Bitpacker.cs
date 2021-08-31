namespace DNAC
{
    public static class Bitpacker
    {
        private static sbyte localOffset = 6; //Offset for bits in current byte
        private static byte endPadding; //How many bits do we have outside of the last bit that is unused?

        public static byte ConvertBaseToByte(DNABases @base)
        {
            return (byte)(@base.GetHashCode() & 3);
        }

        private static void MergeBytes(byte @base, ref byte @byte)
        {
            byte mask = (byte)(@base << localOffset);
            @byte = (byte)(@byte | mask);

            localOffset -= 2;
            if (localOffset < 0) localOffset = 6;
        }

        public static void PackByteList(ref string baseString, ref byte[] byteList, UnknownDNAHandler NDNAHandler = null)
        {
            if ((baseString.Length & 3) == 0)
            {
                byteList = new byte[(baseString.Length / 4)];
            }
            else
            {
                byteList = new byte[(baseString.Length / 4) + 1];
            }
            

            // 9 * 2

            endPadding = (byte)(8 - ((baseString.Length * 2) % 8));
            if (endPadding == 8) endPadding = 0;

            DNABases[] baseArray = new DNABases[4];
            byte count = 0;
            uint byteListIndex = 0;

            for (int i = 0; i < baseString.Length; i++)
            {
                DNABases @base = DNAOperations.GetDNABaseFromChar(baseString[i]);
                if (NDNAHandler != null)
                {
                    NDNAHandler.appendCompressedUnknownDNAInfo(i, @base);
                }
                if (@base == DNABases.UNRECOGNIZED) continue;
                baseArray[count] = @base;

                count++;

                if (count >= 4)
                {
                    byte? nullableByte = PackByte(baseArray);

                    if (nullableByte.HasValue)
                    {
                        byte @byte = nullableByte.GetValueOrDefault();

                        byteList[byteListIndex] = @byte;
                        byteListIndex++;
                    }

                    count = 0;
                }
            }

            if (count > 0)
            {
                for (int i = count; i < 4; i++)
                {
                    baseArray[i] = DNABases.ADENINE;
                }
                byte? nullableByte = PackByte(baseArray);

                if (nullableByte.HasValue)
                {
                    byte @byte = nullableByte.GetValueOrDefault();

                    byteList[byteListIndex] = @byte;
                }
            }
        }

        public static DNABases GetDNABaseAtIndex(int index, ref byte[] byteList)
        {
            // Returns the DNA base at any position. Throws exception if it is outside of bounds
            int byteIndex = index / 4;
            int bitOffset = (index & 3) << 1;
            if (byteIndex >= byteList.Length - 1)
            {
                if (bitOffset >= 8-endPadding) throw new System.ArgumentOutOfRangeException($"Index {index} was outside of bounds for array {byteList}");
            }
            byte mask = (byte)(3 << (6 - bitOffset));

            //System.Console.WriteLine("\nByte index: {0}, bit offset: {1}", byteIndex, bitOffset);

            return (DNABases)((byteList[byteIndex] & mask) >> (6 - bitOffset));
        }

        public static Codon? GetCodonAtPosition(int position, ref byte[] byteList)
        {
            //position 0 will return the first 6 bits of the bytelist list as a codon
            //position 3 will return bits 18-24 of the bytelist list as a codon

            //position 1 is 3-4-5

            //GetDNABaseAtIndex function

            mRNABases[] bases = new mRNABases[3];

            for (int i = 0; i < 3; i++)
            {

                int byteIndex = ((position * 6) + (i * 2)) / 8;
                int bitOffset = ((((position * 6) + (i * 2))) & 7);
                byte mask = (byte)(3 << (6 - bitOffset));

                mRNABases @base = (mRNABases)((byteList[byteIndex] & mask) >> (6 - bitOffset));
                bases[i] = @base;
            }

            return new Codon(bases[0], bases[1], bases[2]);
        }

        public static byte? PackByte(DNABases[] bases)
        {
            if (bases.Length != 4) return null;

            byte output = 0;

            for (int i=0; i<bases.Length; i++)
            {
                byte baseAsByte = ConvertBaseToByte(bases[i]);
                MergeBytes(baseAsByte, ref output);
            }

            localOffset = 6;

            return output;
        }
    }
}
