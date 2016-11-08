using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EnigmaMachine
{
    public class EnigmaMachine
    {

        private Switchboard MainSwitchboard;
        private List<Rotor> Rotors;
        private Reflector Reflector;

        public EnigmaMachine(Switchboard InputSwitchboard, List<Rotor> InputRotor, Reflector InputReflector)
        {
            MainSwitchboard = InputSwitchboard;
            Rotors = InputRotor;
            Reflector = InputReflector;
        }

        public void SetRotorStartingPosition(int RotorIndex, sbyte Position)
        {
            Rotors[RotorIndex].Index = Position;
        }
        
        public int GetNextKey(int InputKey)
        {
            int SwitchedKey = MainSwitchboard.GetKeyForward(InputKey);

            foreach (Rotor R in Rotors)
            {
                SwitchedKey = R.GetKeyForward(SwitchedKey);
            }

            SwitchedKey = Reflector.GetKey(SwitchedKey);

            for (int i = Rotors.Count - 1; i >= 0; i--)
            {
                SwitchedKey = Rotors[i].GetKeyBackwards(SwitchedKey);
            }

            int Result = MainSwitchboard.GetKeyBackwards(SwitchedKey);
            RotateRotors();
            return Result;
        }

        public void RotateRotors()
        {
            sbyte Index = 0;
            bool CycleCompleted = Rotors[Index].Rotate();
            while (CycleCompleted)
            {
                Index += 1;
                CycleCompleted = Rotors[Index].Rotate();
            }
        }
    }
}
