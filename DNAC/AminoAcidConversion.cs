namespace DNAC
{
    public static class AminoAcidConversion
    {
        // U A C
        // 00 01 10 00
        // 00011000
        //6 bit conversion system
        private static AminoAcids[,,] conversions = new AminoAcids[16, 4, 4];

        public static void CacheConversionChart()
        {
            #region CONVERSION CHART
            // U = 00, ARRAY INDEX = 0
            // A = 01, ARRAY INDEX = 1
            // C = 10, ARRAY INDEX = 2
            // G = 11, ARRAY INDEX = 3
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.URACIL, mRNABases.URACIL, AminoAcids.PHENYLALANINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.URACIL, mRNABases.CYTOSINE, AminoAcids.PHENYLALANINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.URACIL, mRNABases.ADENINE, AminoAcids.LEUCINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.URACIL, mRNABases.GUANINE, AminoAcids.LEUCINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.CYTOSINE, mRNABases.URACIL, AminoAcids.SERINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.CYTOSINE, mRNABases.CYTOSINE, AminoAcids.SERINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.CYTOSINE, mRNABases.ADENINE, AminoAcids.SERINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.CYTOSINE, mRNABases.GUANINE, AminoAcids.SERINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.ADENINE, mRNABases.URACIL, AminoAcids.TYROSINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.ADENINE, mRNABases.CYTOSINE, AminoAcids.TYROSINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.ADENINE, mRNABases.ADENINE, AminoAcids.STOP);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.ADENINE, mRNABases.GUANINE, AminoAcids.STOP);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.GUANINE, mRNABases.URACIL, AminoAcids.CYSTEINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.GUANINE, mRNABases.CYTOSINE, AminoAcids.CYSTEINE);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.GUANINE, mRNABases.ADENINE, AminoAcids.STOP);
            ConvertToAminoAcidArray(mRNABases.URACIL, mRNABases.GUANINE, mRNABases.GUANINE, AminoAcids.TRYPTOPHAN);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.URACIL, mRNABases.URACIL, AminoAcids.LEUCINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.URACIL, mRNABases.CYTOSINE, AminoAcids.LEUCINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.URACIL, mRNABases.ADENINE, AminoAcids.LEUCINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.URACIL, mRNABases.GUANINE, AminoAcids.LEUCINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.CYTOSINE, mRNABases.URACIL, AminoAcids.PROLINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.CYTOSINE, mRNABases.CYTOSINE, AminoAcids.PROLINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.CYTOSINE, mRNABases.ADENINE, AminoAcids.PROLINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.CYTOSINE, mRNABases.GUANINE, AminoAcids.PROLINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.ADENINE, mRNABases.URACIL, AminoAcids.HISTIDINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.ADENINE, mRNABases.CYTOSINE, AminoAcids.HISTIDINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.ADENINE, mRNABases.ADENINE, AminoAcids.GLUTAMINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.ADENINE, mRNABases.GUANINE, AminoAcids.GLUTAMINE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.GUANINE, mRNABases.URACIL, AminoAcids.ARGININE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.GUANINE, mRNABases.CYTOSINE, AminoAcids.ARGININE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.GUANINE, mRNABases.ADENINE, AminoAcids.ARGININE);
            ConvertToAminoAcidArray(mRNABases.CYTOSINE, mRNABases.GUANINE, mRNABases.GUANINE, AminoAcids.ARGININE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.URACIL, mRNABases.URACIL, AminoAcids.ISOLEUCINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.URACIL, mRNABases.CYTOSINE, AminoAcids.ISOLEUCINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.URACIL, mRNABases.ADENINE, AminoAcids.ISOLEUCINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.URACIL, mRNABases.GUANINE, AminoAcids.METHIONINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.CYTOSINE, mRNABases.URACIL, AminoAcids.THREONINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.CYTOSINE, mRNABases.CYTOSINE, AminoAcids.THREONINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.CYTOSINE, mRNABases.ADENINE, AminoAcids.THREONINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.CYTOSINE, mRNABases.GUANINE, AminoAcids.THREONINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.ADENINE, mRNABases.URACIL, AminoAcids.ASPARAGINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.ADENINE, mRNABases.CYTOSINE, AminoAcids.ASPARAGINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.ADENINE, mRNABases.ADENINE, AminoAcids.LYSINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.ADENINE, mRNABases.GUANINE, AminoAcids.LYSINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.GUANINE, mRNABases.URACIL, AminoAcids.SERINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.GUANINE, mRNABases.CYTOSINE, AminoAcids.SERINE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.GUANINE, mRNABases.ADENINE, AminoAcids.ARGININE);
            ConvertToAminoAcidArray(mRNABases.ADENINE, mRNABases.GUANINE, mRNABases.GUANINE, AminoAcids.ARGININE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.URACIL, mRNABases.URACIL, AminoAcids.VALINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.URACIL, mRNABases.CYTOSINE, AminoAcids.VALINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.URACIL, mRNABases.ADENINE, AminoAcids.VALINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.URACIL, mRNABases.GUANINE, AminoAcids.VALINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.CYTOSINE, mRNABases.URACIL, AminoAcids.ALANINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.CYTOSINE, mRNABases.CYTOSINE, AminoAcids.ALANINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.CYTOSINE, mRNABases.ADENINE, AminoAcids.ALANINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.CYTOSINE, mRNABases.GUANINE, AminoAcids.ALANINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.ADENINE, mRNABases.URACIL, AminoAcids.ASPARTIC_ACID);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.ADENINE, mRNABases.CYTOSINE, AminoAcids.ASPARTIC_ACID);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.ADENINE, mRNABases.ADENINE, AminoAcids.GLUTAMIC_ACID);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.ADENINE, mRNABases.GUANINE, AminoAcids.GLUTAMIC_ACID);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.GUANINE, mRNABases.URACIL, AminoAcids.GLYCINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.GUANINE, mRNABases.CYTOSINE, AminoAcids.GLYCINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.GUANINE, mRNABases.ADENINE, AminoAcids.GLYCINE);
            ConvertToAminoAcidArray(mRNABases.GUANINE, mRNABases.GUANINE, mRNABases.GUANINE, AminoAcids.GLYCINE);
            #endregion
        }

        public static AminoAcids GetAminoAcid(Codon codon)
        {
            return conversions[codon.base1.GetHashCode(), codon.base2.GetHashCode(), codon.base3.GetHashCode()];
        }

        private static void ConvertToAminoAcidArray(mRNABases base1, mRNABases base2, mRNABases base3, AminoAcids value)
        {
            conversions[base1.GetHashCode(), base2.GetHashCode(), base3.GetHashCode()] = value;
        }
    }
}
