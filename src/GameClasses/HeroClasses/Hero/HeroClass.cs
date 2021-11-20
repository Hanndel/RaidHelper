using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{
    public class HeroClass
    {
        IntPtr ClassPtr = IntPtr.Zero;
        IntPtr Handle = Globals.Handle;
        public HeroClass(IntPtr ChampPtr)
        {
            ClassPtr = ChampPtr;
            DoTheWork();
        }

        public HeroType _Type;
        public int Id;
        public int TypeId;
        public int Grade;
        public int Level;
        public int Experience;
        public int FullExperience;
        public bool Locked;
        public bool InStorage;
        public int HeroMarker;
        public HeroMasteryData MasteryData;
        public List<Skill> Skills;

        private void DoTheWork()
        {
            _Type = new HeroType(ProcessApi.GetPointer(ClassPtr, 0x10));
            Id = (int)(long)ProcessApi.ReturnRead(ClassPtr + 0x18);
            int _TypeId = (int)(long)ProcessApi.ReturnRead(ClassPtr + 0x1C);
            TypeId = (int)Math.Truncate((decimal)_TypeId/10)*10;
            Grade = (int)(long)ProcessApi.ReturnRead(ClassPtr + 0x20);
            Level = (int)(long)ProcessApi.ReturnRead(ClassPtr + 0x24);
            Experience = (int)(long)ProcessApi.ReturnRead(ClassPtr+0x28);
            FullExperience = (int)(long)ProcessApi.ReturnRead(ClassPtr + 0x2C);
            Locked = UtilityClasses.IntToBool((int)(long)ProcessApi.ReturnRead(ClassPtr + 0x30));
            InStorage = UtilityClasses.IntToBool((int)(long)ProcessApi.ReturnRead(ClassPtr + 0x31));
            HeroMarker = (int)(long)ProcessApi.ReturnRead(ClassPtr + 0x48);
            Skills = new List<Skill>();//ProcessApi.GetPointer(ClassPtr, 0x50)
            MasteryData = new HeroMasteryData(ProcessApi.GetPointer(ClassPtr,0x58));
        }
    }
}
