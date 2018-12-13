using System;
using System.Collections.Generic;
using System.Text;

namespace VHS
{
    class VHSPERSON
    {
        public string Name { get; set; }
        public int Energi { get; set; }       

        public int Money { get; set; }
        public int Health { get; set; }
        public int Skill { get; set; }
        public int BossLikes { get; set; }
        public int VHSRepaired { get; set; }
        public int ToolLevel { get; set; }
        public int CustomerHappines { get; set; }
        public int LunchLada { get; internal set; }

        internal void AskForName()
        {
            Console.WriteLine("What is your name?");
            Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Hi {Name}, lets play a game!");
            Energi = 10;
            Money = 5;
            Health = 10;
            Skill = 5;
            BossLikes = 0;
            VHSRepaired = 0;
            ToolLevel = 0;
            LunchLada = 0;
            CustomerHappines = 0;
            Console.ReadKey();
            Console.Clear();
        }

    }
}
