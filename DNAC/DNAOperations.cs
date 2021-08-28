namespace DNAC
{
    public static class DNAOperations
    {
        public static DNABases GetDNABaseFromChar(char character)
        {
            switch (character)
            {
                case 'A':
                    return DNABases.ADENINE;
                case 'C':
                    return DNABases.CYTOSINE;
                case 'G':
                    return DNABases.GUANINE;
                case 'T':
                    return DNABases.THYMINE;
            }

            throw new System.ArgumentException($"Attempted conversion from Char ({character}) to mRNA. Make sure argument is only 'A', 'C', 'G', or 'T'");
        }

        public static DNABases ConvertToDNA(mRNABases mRNABase)
        {
            return (DNABases)mRNABase.GetHashCode();
        }
    }
}
