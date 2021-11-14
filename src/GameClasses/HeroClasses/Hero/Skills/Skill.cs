using System;
namespace RaidHelper
{
    public class Skill
    {
        IntPtr ClassPtr;
        public Skill(IntPtr ptr)
        {
            ClassPtr = ptr;
        }
    }
}