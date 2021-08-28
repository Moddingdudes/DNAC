namespace DNAC
{
    internal static class Bitpacker
    {
        private static byte localOffset = 6; //Offset for bits in current byte

        private static byte ConvertBaseToByte(DNABases @base)
        {
            return (byte)(@base.GetHashCode() & 3);
        }

        private static void MergeBytes(byte @base, ref byte @byte)
        {
            if (localOffset <= 0) localOffset = 6;
            byte mask = (byte)(@base << localOffset);

            @byte = (byte)(@byte | mask);

            localOffset -= 2;
        }

        public static void PackByteList(ref string baseString, ref byte[] byteList)
        {
            if ((baseString.Length & 3) == 0)
            {
                byteList = new byte[(baseString.Length / 4)];
            }
            else
            {
                byteList = new byte[(baseString.Length / 4) + 1];
            }

            DNABases[] baseArray = new DNABases[4];
            byte count = 0;
            uint byteListIndex = 0;
            for (int i = 0; i < baseString.Length; i++)
            {
                DNABases @base = DNAOperations.GetDNABaseFromChar(baseString[i]);
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

        public static Codon? GetCodonAtPosition(int position, ref byte[] byteList)
        {
            //position 0 will return the first 6 bits of the bytelist list as a codon
            //position 3 will return bits 18-24 of the bytelist list as a codon

            int startBit = position * 6; //Position is 0, multiply 0 by 6 to get 0, Position is 1, multiply 1 by 6 to get 6
            int endBit = (position * 6) + 6; //Position is 0, multiply 0 by 6 and add 6 to get 6, Position is 1, multiply 1 by 6 and add 6 to get 12

            int index = startBit / 8;

            if (index >= byteList.Length) return null;
            byte neededByte = byteList[index];
            byte adjacentByte = 0;
            bool hasAdjacentByte = false;
            int localBitshift = startBit - (index * 8);

            if (localBitshift <= 2)
            {
                return new Codon(
                    (mRNABases)((neededByte & (3 << 6) >> localBitshift) >> 6),
                    (mRNABases)((neededByte & (3 << 6) >> localBitshift + 2) >> 4),
                    (mRNABases)((neededByte & (3 << 6) >> localBitshift + 4) >> 2));
            }

            try
            {
                adjacentByte = byteList[index + 1];
                hasAdjacentByte = true;
            }
            catch {
                return null;
            }

            if (hasAdjacentByte)
            {
                ushort completeByte = (ushort)((neededByte << 8) | adjacentByte);

                return new Codon(
                    (mRNABases)((completeByte & (3 << 14) >> localBitshift) >> (16 - (localBitshift + 2))),
                    (mRNABases)((completeByte & (3 << 14) >> localBitshift + 2) >> (14 - (localBitshift + 2))),
                    (mRNABases)((completeByte & (3 << 14) >> localBitshift + 4) >> (12 - (localBitshift + 2))));
            }

            return null;
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
