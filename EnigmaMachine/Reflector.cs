using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    public class Reflector
    {
        MappingPair Pair;

        public Reflector()
        {
            Pair = new MappingPair();
        }

        /// <summary>
        /// Assume there's 4 keys, A B C D E. CBADE -> A<->C, B<->B, and so on.
        /// </summary>
        /// <param name="KeySet"></param>
        public Reflector(string KeySet)
        {
            Pair = new MappingPair();
            for (int i = 1; i <= 26; i++)
            {
                Pair.Add(i, char.ToUpper(KeySet[i - 1]) - 64);
            }
        }

        public void AddKey(int KeyA, int KeyB)
        {
            if (Pair.GetKeyReverse(KeyA) != -1)
            {
                Pair.Add(KeyA, KeyB);
            }
        }

        public int GetKey(int Key)
        {
            int ReturnKey;
            ReturnKey = Pair.GetKeyForward(Key);

            if (ReturnKey == -1)
            {
                ReturnKey = Pair.GetKeyReverse(Key);
            }

            return ReturnKey;
        }
    }
}
