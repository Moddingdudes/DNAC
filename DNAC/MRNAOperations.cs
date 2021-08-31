namespace DNAC
{
    public static class MRNAOperations
    {
        public static mRNABases GetMRNABaseFromChar(char character)
        {
            switch (character)
            {
                case 'A':
                    return mRNABases.ADENINE;
                case 'C':
                    return mRNABases.CYTOSINE;
                case 'G':
                    return mRNABases.GUANINE;
                case 'U':
                    return mRNABases.URACIL;
                case 'N':
                    return mRNABases.UNRECOGNIZED;
            }

            throw new System.ArgumentException($"Attempted conversion from Char ({character}) to mRNA. Make sure argument is only 'A', 'C', 'G', or 'T'");
        }

        public static mRNABases ConvertToMRNA(DNABases dnaBase)
        {
            return (mRNABases)dnaBase.GetHashCode();
        }
    }
}
