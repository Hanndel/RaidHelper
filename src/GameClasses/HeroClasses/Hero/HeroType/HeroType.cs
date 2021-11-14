using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{
    public class HeroType
    {  
        IntPtr ClassPtr = IntPtr.Zero;
        public HeroType(IntPtr Ptr)
        {
            ClassPtr = Ptr;
            if (ClassPtr != IntPtr.Zero)
            {
                DoTheWork();
            }
        }

        public string name;

        private void DoTheWork()
        {
            IntPtr NamePointer = ProcessApi.FindMultiLevelPointer(Globals.Handle, ClassPtr, new int[] { 0x18, 0x18 });
            byte[] ByteCodeArray = ProcessApi.ReturnBytes(NamePointer + 0x14, 32);
            string _name = Encoding.Unicode.GetString(ByteCodeArray)+"\0";
            int position = _name.IndexOf("\0");
            this.name = position > -1 ? _name.Substring(0, _name.IndexOf('\0')) : Encoding.Unicode.GetString(ByteCodeArray);
        }
    }
}