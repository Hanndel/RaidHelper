using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidHelper
{
        public class SecondaryBonuses
        {
            private IntPtr ClassPtr;
            private IntPtr Handle;
            public SecondaryBonuses(IntPtr handle, IntPtr ptr)
            {
                Handle = handle;
                ClassPtr = ptr;
                this.DoTheWork();
            }


            string KindId;
            int Level;
            float value;

            private void DoTheWork()
            {
            KindId = ArtifactKindId((int)ReturnRead(this.ClassPtr + 0x10));
            Level = (int)ReturnRead(this.ClassPtr + 0x28);
            long _fastMath = (long)ReturnRead(ReturnRead((this.ClassPtr + 0x18)) + 0x18);
            value = (float)Math.Round(_fastMath / 4294967296.0, 2);
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
                return BytesToHexa(Read);
            }
            private bool IntToBool(int Int)
            {
                return Int == 1 ? true : false;
            }
            private string ArtifactKindId(int id)
            {
                string[] Rarity = new string[] { "Health", "Attack", "Defence", "Speed", "Resistance", "Accuracy", "Critical Chance", "Critical Damage", "Critical Heal"};
                return Rarity[id];
            }
        }
}
