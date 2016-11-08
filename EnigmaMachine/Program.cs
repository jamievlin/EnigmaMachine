using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Rotor RotorA = new Rotor(0, "DMTWSILRUYQNKFEJCAZBPGXOHV");
            RotorA.Index = 15;

            Rotor RotorB = new Rotor(0, "HQZGPJTMOBLNCIFDYAWVEUSRKX");
            RotorB.Index = 13;

            Rotor RotorC = new Rotor(0, "UQNTLSZFMREHDPXKIBVYGJCWOA");
            RotorC.Index = 20;


            Switchboard SwitchboardA = new Switchboard("AJDKSIRUXBLHWTMCQGZNPYFVOE");
            Reflector ReflectorA = new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");

            EnigmaMachine Machine1 = new EnigmaMachine(SwitchboardA, new List<Rotor> { RotorA, RotorB, RotorC }, ReflectorA);

            ConsoleKeyInfo Key;

            do
            {
                Key = Console.ReadKey(true);
                if (Key.Key != ConsoleKey.Enter)
                {
                    Console.Title = String.Format("Rotor Position {1},{2},{3} : Received {0}", char.ToUpper(Key.KeyChar), RotorA.Index, RotorB.Index, RotorC.Index);
                    Console.Write((char)(Machine1.GetNextKey(char.ToUpper(Key.KeyChar) - 64) + 64));
                }

            } while (Key.Key != ConsoleKey.Enter);
        }
    }
}
