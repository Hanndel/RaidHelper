using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{
    class ArtifactClass
    {
        private IntPtr Handle;
        private IntPtr ClassPtr;
        long FailedUpgrades;
        long id;
        bool IsActivated;
        string KindId;
        long level;
        long price;
        PrimaryBonus primaryBonus;
        long rankid;
        string rarityid;
        string faction;
        long revision;
        List<SecondaryBonuses> secondaryBonus;
        long sellprice;
        string setKindId;
        long upgradeTime;
        bool isSeen;
        public ArtifactClass(IntPtr ptr)
        {
            Handle = Globals.Handle;
            ClassPtr = ptr;
            ArtifactParser(ClassPtr);
        }

        public void ArtifactParser(IntPtr ptr)
        {
            IntPtr ArtifactPointer = ReturnRead(ptr + 0x18);
            this.id = (int)(long)(ReturnRead(ArtifactPointer+0x10));
            this.revision = (long)ReturnRead(ArtifactPointer + 0x14);
            this.upgradeTime = (int)(long)(ReturnRead(ArtifactPointer + 0x18));
            this.sellprice = (int)(long)(ReturnRead(ArtifactPointer + 0x28));
            this.price = (int)(long)(ReturnRead(ArtifactPointer + 0x2C));
            this.level = (int)(long)(ReturnRead(ArtifactPointer + 0x30));
            this.IsActivated = UtilityClasses.IntToBool((int)(long)(ReturnRead(ArtifactPointer + 0x34)));
            this.KindId = ArtifactKindId((int)(long)(ReturnRead(ArtifactPointer + 0x38)));
            this.rankid = (int)(long)(ReturnRead(ArtifactPointer + 0x3C));
            this.rarityid = RarityId((int)(long)(ReturnRead(ArtifactPointer + 0x40)));
            this.primaryBonus = new PrimaryBonus(this.Handle, ReturnRead(ArtifactPointer + 0x48));
            this.secondaryBonus = SecondaryBonusesHere(this.Handle, ReturnRead(ArtifactPointer + 0x50));
            this.setKindId = SetKindId((int)(long)(ReturnRead(ArtifactPointer + 0x58)));
            this.faction = Faction((int)(long)(ReturnRead(ArtifactPointer + 0x5C)));
            this.isSeen = UtilityClasses.IntToBool((int)(long)(ReturnRead(ArtifactPointer + 0x60)));
            this.FailedUpgrades = (int)(long)(ReturnRead(ArtifactPointer + 0x64));
        }

        private IntPtr BytesToHexa(byte[] array)
        {
            IntPtr somethingToReturn = (IntPtr.Size == 4) ? IntPtr.Add(new IntPtr(BitConverter.ToInt32(array, 0)), 0) : somethingToReturn = IntPtr.Add(new IntPtr(BitConverter.ToInt64(array, 0)), 0);
            return somethingToReturn;
        }

        private IntPtr ReturnRead(IntPtr ptr)
        {
            byte[] Read = new byte[8];
            int BytesRead = 0;
            ProcessApi.ReadProcessMemory(this.Handle, ptr, Read, Read.Length, out BytesRead);
            IntPtr algo = BytesToHexa(Read);
            return algo;
        }
        private string SetKindId(int id)
        {
            string[] Sets = new string[] {"None","Life","Fatal","Defense","Speed","Critical Chance","Critical Damage","Accuracy","Resistance","LifeSteal","Fury","Daze","Cursed","Frost", "Frenzy", "Regeneration", "Immunity", "Shield", "Relentless", "Savage", "Destroy", "Stun", "Toxic", "Taunting","Retaliation", "Avenging", "Stalwart", "Reflex", "Curing", "Cruel", "Immortal","Divine Offence", "Divine Critical Rate", "Divine Life", "Divine Speed", "Swift Parry", "Deflection", "Resilience", "Perception", "AffinityBreaker", "Untouchable", "Fatal", "FrostBite", "Bloodthirst", "Guardian", "Fortitude", "Lethal","IgnoreCD", "RemoveDebuff", "ShieldAcessory", "ChangeHitType", "CounterattackAcessory"};
            return id <= Sets.Length ? Sets[id]: Sets[0];
        }
        
        private string RarityId(int id)
        {
            string[] Rarity = new string[] {"Unknown", "Common", "Uncommon", "Rare", "Epic", "Legendary" };
            return id <= Rarity.Length ? Rarity[id] : Rarity[0];
        }

        private string Faction(int id)
        {
            string[] Faction = new string[] { "Unknown", "BannerLords", "HighElves", "SacredOrder", "CovenOfMagi", "OgrynTribes", "LizardMen", "Skinwalkers", "Orcs", "Demonspawn", "UndeadHordes", "DarkElves", "KnightsRevenant", "Barbarians", "NyresanElves", "Samurai", "Dwarves" };
            return id <= Faction.Length ? Faction[id] : Faction[0];
        }

        private string ArtifactKindId(int id)
        {
            string[] Rarity = new string[] { "Unknown", "Helmet", "Chest", "Gloves", "Boots", "Weapon", "Shield", "Ring", "Cloak", "Banner", "UnknownAccessory" };
            return id <= Rarity.Length ? Rarity[id] : Rarity[0];
        }

        private List<SecondaryBonuses> SecondaryBonusesHere(IntPtr handle, IntPtr ptr)
        {
            List<SecondaryBonuses> _array = new List<SecondaryBonuses>();
            IntPtr WhereTheyAt = ReturnRead(ptr + 0x10);
            int amount = (int)ReturnRead(WhereTheyAt + 0x18);
            for (int i = 0; i < amount; i++)
            {
                IntPtr bonus = ReturnRead(WhereTheyAt+(0x20 + (i * 0x8)));
                _array.Add(new SecondaryBonuses(handle, bonus));

            }
            return _array;
        }
    }
}
