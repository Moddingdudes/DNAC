namespace DNAC
{
    public static class DNAOperations
    {
        public static DNABases GetDNABaseFromChar(char character)
        {
            /*switch (character)
            {
                case 'A':
                    return DNABases.ADENINE;
                case 'C':
                    return DNABases.CYTOSINE;
                case 'G':
                    return DNABases.GUANINE;
                case 'T':
                    return DNABases.THYMINE;
                case 'N':
                    return DNABases.UNRECOGNIZED;
            }*/

            return (DNABases)((character >> 1) & 3);

            throw new System.ArgumentException($"Attempted conversion from Char ({character}) to mRNA. Make sure argument is only 'A', 'C', 'G', or 'T'");
        }

        public static DNABases ConvertToDNA(mRNABases mRNABase)
        {
            return (DNABases)mRNABase.GetHashCode();
        }

        /*public static ref ulong[] ScanForDNAInSection(ref byte[] toSearch, string key)
        {
            //Searches through all toSearch and return all indexes where it was found

            //Convert key into byte[]

            // 'UACA'
            // 4 * 2 / 8
            byte[] byteKey = new byte[((key.Length * 2) / 8) + 1];
            for (int i=0; i<key.Length; i++)
            {
                DNABases @base = GetDNABaseFromChar(key[i]);

                Bitpacker.ConvertBaseToByte(@base);
            }
        }*/
    }
}
