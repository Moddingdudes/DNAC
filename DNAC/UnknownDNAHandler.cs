using System;
using System.Collections.Generic;

namespace DNAC
{
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
