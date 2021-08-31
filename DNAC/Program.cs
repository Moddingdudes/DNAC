using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace DNAC
{
    #region ENUMERATORS
    public enum DNABases
    {
        ADENINE = 0, //00
        CYTOSINE = 1, //01
        GUANINE = 3, //10
        THYMINE = 2, //11
        UNRECOGNIZED = 4 //00
    }

    public enum mRNABases
    {
        URACIL = 0, //00
        GUANINE = 1, //01
        CYTOSINE = 3, //10
        ADENINE = 2, //11
        UNRECOGNIZED = 4 //00
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

    public struct UnknownDNADeltaInfo
    {
        public int index;
        public int duration;

        public UnknownDNADeltaInfo(int index, int duration)
        {
            this.index = index;
            this.duration = duration;
        }
    }
    #endregion

    class Program
    {
        private static byte[] byteList;
        private static string dnaStream = "ACCGCA";
        private static UnknownDNAHandler NDNAHandler;

        static void Main(string[] args)
        {
            AminoAcidConversion.CacheConversionChart();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            dnaStream = System.IO.File.ReadAllText(@"Myfilepath");

            NDNAHandler = new UnknownDNAHandler();

            Bitpacker.PackByteList(ref dnaStream, ref byteList, NDNAHandler);

            for (int i = 0; i < byteList.Length; i++)
            {
                if (!Bitpacker.GetCodonAtPosition(i, ref byteList).HasValue) break;
            }

            stopWatch.Stop();
            Console.WriteLine("Took {0} seconds and {1} milliseconds to compute codons", stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
        }
    }

    public class UnknownDNAHandler
    {
        private List<UnknownDNADeltaInfo> unknownDNADeltaInfo = new List<UnknownDNADeltaInfo>();
        private int duration = 0;
        private int index = 0;

        public void appendCompressedUnknownDNAInfo(int index, DNABases @base)
        {
            //Appends to reference unknown DNA array at index given DNA stream, returns index to start searching again.

            if (@base == DNABases.UNRECOGNIZED)
            {
                if (duration <= 0)
                {
                    this.index = index;
                }
                duration++;
            }
            else
            {
                if (duration > 0)
                {
                    unknownDNADeltaInfo.Add(new UnknownDNADeltaInfo(this.index, duration));
                    duration = 0;
                }
            }
        }

        public void DebugDeltaInfo()
        {
            for (int i=0; i<unknownDNADeltaInfo.Count; i++)
            {
                Console.WriteLine("Index: {0} through duration: {1}", unknownDNADeltaInfo[i].index, unknownDNADeltaInfo[i].duration);
            }
        }
    }
}
