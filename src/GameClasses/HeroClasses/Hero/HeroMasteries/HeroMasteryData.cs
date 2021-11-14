using System;
using System.Collections.Generic;

namespace RaidHelper
{
    public  class HeroMasteryData
    {
        IntPtr ClassPtr;
        public  HeroMasteryData(IntPtr Ptr)
        {
            ClassPtr = Ptr;
            DoTheWork();
        }
        Dictionary<string, int> CurrentAmount;
        List<int> Masteries;
        int ResetCount;
        Dictionary<string, int> TotalAmount;
        private void DoTheWork()
        {
            this.CurrentAmount = CurrentAmountDict(ProcessApi.GetPointer(ClassPtr, 0x10));
            this.Masteries = new List<int>();
            this.ResetCount = (int)(long)ProcessApi.ReturnRead(ClassPtr+0x28);
            this.TotalAmount = TotalAmountDict(ProcessApi.GetPointer(ClassPtr, 0x18));

        }

        private Dictionary<string, int> CurrentAmountDict(IntPtr ptr)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            return result;
        }

        private Dictionary<string, int> TotalAmountDict(IntPtr ptr)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            return result;
        }
    }
}