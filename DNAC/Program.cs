using System;
using System.Diagnostics;

namespace DNAC
{
    #region ENUMERATORS
    public enum DNABases
    {
        ADENINE = 0, //00
        CYTOSINE = 1, //01
        GUANINE = 2, //10
        THYMINE = 3, //11
    }

    public enum mRNABases
    {
        URACIL = 0, //00
        GUANINE = 1, //01
        CYTOSINE = 2, //10
        ADENINE = 3 //11
    }

    public enum AminoAcids
    {
        ALANINE = 0,
        ARGININE = 1,
        ASPARAGINE = 2,
        ASPARTIC_ACID = 3,
        CYSTEINE = 4,
        GLUTAMINE = 5,
        GLUTAMIC_ACID = 6,
        GLYCINE = 7,
        HISTIDINE = 8,
        ISOLEUCINE = 9,
        LEUCINE = 10,
        LYSINE = 11,
        METHIONINE = 12,
        PHENYLALANINE = 13,
        PROLINE = 14,
        SERINE = 15,
        THREONINE = 16,
        TRYPTOPHAN = 17,
        TYROSINE = 18,
        VALINE = 19,
        STOP = 20
    }
    #endregion

    #region STRUCTS
    public struct Codon
    {
        public mRNABases base1;
        public mRNABases base2;
        public mRNABases base3;

        public Codon(mRNABases base1, mRNABases base2, mRNABases base3)
        {
            this.base1 = base1;
            this.base2 = base2;
            this.base3 = base3;
        }
    }
    #endregion

    class Program
    {
        private static byte[] byteList;
        private static string dnaStream = "CAT";

        

        static void Main(string[] args)
        {
            AminoAcidConversion.CacheConversionChart();

            Bitpacker.PackByteList(ref dnaStream, ref byteList);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i=0; i<byteList.Length; i++) {

                Codon? codon = Bitpacker.GetCodonAtPosition(i, ref byteList);
                if (!codon.HasValue) break;
                Codon codonReal = codon.GetValueOrDefault();
                Diagnostics.PrintCodon(codonReal, true);
            }

            stopWatch.Stop();

            Console.WriteLine("{0} seconds and {1} milliseconds", stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
        }
    }
}
