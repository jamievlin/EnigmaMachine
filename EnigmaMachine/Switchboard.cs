using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    public class MappingPair
    {
        private Dictionary<int, int> KeyList;
        private Dictionary<int, int> KeyReverse;

        public MappingPair()
        {
            KeyList = new Dictionary<int, int>();
            KeyReverse = new Dictionary<int, int>();
        }

        /// <summary>
        /// returns -1 if key doesn't exist
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public int GetKeyForward(int Input)
        {
            int ForwardKey;
            if (KeyList.ContainsKey(Input))
            {
                ForwardKey = KeyList[Input];
            }
            else
            {
                ForwardKey = -1;
            }

            return ForwardKey;
        }
        /// <summary>
        /// returns -1 if key doesn't exist
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public int GetKeyReverse(int Input)
        {
            int ReturnKey;
            if (KeyReverse.ContainsKey(Input))
            {
                ReturnKey = KeyReverse[Input];
            }
            else
            {
                ReturnKey = -1;
            }

            return ReturnKey;
        }

        public void Add(int KeyA, int KeyB)
        {
                KeyList.Add(KeyA, KeyB);
                KeyReverse.Add(KeyB, KeyA);
        }
    }

    public class Switchboard
    {
        private MappingPair KeyPair;

        public Switchboard()
        {
            KeyPair = new MappingPair();
        }

        public Switchboard(string KeySet) // parallel for?
        {
            KeyPair = new MappingPair();
            for (int i = 1; i <= 26; i++)
            {
                KeyPair.Add(i, char.ToUpper(KeySet[i - 1]) - 64);
            }
        }

        /// <summary>
        /// true if adds succesfully, false if already contains.
        /// </summary>
        /// <param name="Pair"></param>
        /// <returns></returns>
        /// 
        private void AddKeyPair(int KeyA, int KeyB)
        {
            KeyPair.Add(KeyA, KeyB);
        }

        public virtual int GetKeyForward(int Key)
        {
            return KeyPair.GetKeyForward(Key);
        }
        public virtual int GetKeyBackwards(int Key)
        {
            return KeyPair.GetKeyReverse(Key);
        }
    }
}
