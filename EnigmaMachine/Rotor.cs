namespace EnigmaMachine
{
    public class Rotor : Switchboard
    {
        
        public sbyte Index { get; set; }
        const sbyte RotationsCount = 26;

        public Rotor(sbyte StartIndex) : base()
        {
            Index = StartIndex;
        }

        public Rotor(sbyte StartIndex, string StartKey) : base(StartKey)
        {
            Index = StartIndex;
        }

        /// <summary>
        /// Returns a Global position based on the Index
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public override int GetKeyBackwards(int Key)
        {
            int LocalKey = ((Key + Index - 1) % RotationsCount) + 1;
            int LocalResult = base.GetKeyBackwards(LocalKey);
            int GlobalResult = ((LocalResult - Index + 25 /* -1 + 26 - prevent negative modulo*/) % RotationsCount) + 1;
            return GlobalResult;
        }

        public override int GetKeyForward(int Key)
        {
            int LocalKey = ((Key + Index - 1) % RotationsCount) + 1;
            int LocalResult = base.GetKeyForward(LocalKey);
            int GlobalResult = ((LocalResult - Index + 25 /* -1 + 26 - prevent negative modulo*/ ) % RotationsCount) + 1;
            return GlobalResult;
        }


        /// <summary>
        /// Shifts by one index. Returns true if index Completes cycle, false if not.
        /// </summary>
        /// <returns></returns>
        public bool Rotate()
        {
            bool CompletedCycle;
            if (Index == (RotationsCount - 1))
            {
                Index = 0;
                CompletedCycle = true;
            }
            else
            {
                Index += 1;
                CompletedCycle = false;
            }

            return CompletedCycle;
        }
    }
}