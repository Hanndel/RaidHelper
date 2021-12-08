using System;
using System.Text;

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
            IntPtr jumpOne = ProcessApi.GetPointer(ClassPtr, 0x18);
            IntPtr jumpTwo = ProcessApi.GetPointer(jumpOne, 0x18);
            byte[] ByteCodeArray = ProcessApi.ReturnBytes(jumpTwo + 0x14, 32);
            string _name = Encoding.Unicode.GetString(ByteCodeArray) + "\0";
            int position = _name.IndexOf("\0");
            this.name = position > -1 ? _name.Substring(0, _name.IndexOf('\0')) : Encoding.Unicode.GetString(ByteCodeArray);
        }
    }
}