using System;

namespace VHS
{
    class Program
    {
        static void Main(string[] args)
        {            
            var vhsperson = new VHSPERSON(); // Creates the class
            vhsperson.AskForName(); // Ask user for the name 
            
            Sunday(vhsperson); // Ask user for 3 things to do on sunday, effects the scores
            Console.ResetColor();
            StartGame(vhsperson); // Game start for real now
            EndGame(vhsperson);
        }

        private static void EndGame(VHSPERSON vhsperson)
        {
            Console.WriteLine("Its now friday evening.. and the boss calls you");
            Console.ReadKey();
            Console.WriteLine("To get a promotion you'll need: ");
            Console.WriteLine("Health: X");
            Console.WriteLine("Skill: X");
            Console.WriteLine("BossLikes: X");
            Console.WriteLine("VHSRepaired: X");
            Console.WriteLine("CustomerHappines");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Your score is:" );
            CurrentScore(vhsperson);
        }

        static Random morning = new Random(); // Creates random things (check WakeUo() for example)
        private static int dayCount;
        private static int time = 9;
        private static void StartGame(VHSPERSON vhsperson)
        {
            while (dayCount != 4)
            {
                Console.Clear();
                Console.WriteLine($"It's now {WhatDay(dayCount)}");
                Console.ReadKey();
                Console.WriteLine("Your current scores is:");
                CurrentScore(vhsperson);
                Console.ReadKey();
                WakeUp(vhsperson);
                StartWork(vhsperson);
                dayCount++;
                if (vhsperson.Energi <= 0)
                {
                    Console.WriteLine($"Dude.. you have {vhsperson.Energi} energy in the end of the day?");
                    Console.WriteLine("Not sure how that's possible.. ");
                    Console.ReadKey();
                    Console.WriteLine("You faint and gets -5 in health");
                    vhsperson.Health -= 5;
                    vhsperson.Energi = 10;
                }
            }
        }

        private static string WhatDay(int dayCount)
        {
            string day = "";
            switch (dayCount)
            {
                case 0:
                    day = "Monday";
                    return day;
                case 1:
                    day = "Thuesday";
                    return day;
                case 2:
                    day = "Wednesday";
                    return day;
                case 3:
                    day = "Thursday";
                    return day;
                case 4:
                    day = "Friday";
                    return day;
                default:
                    return "Error";
            }
        }

        private static void StartWork(VHSPERSON vhsperson)
        {
            Console.Clear();
            Console.WriteLine($"You've now arrived at your job and have {vhsperson.Energi} energy");
            Console.ReadKey();
            FirstEventOfTheDay(vhsperson);
        }

        private static void FirstEventOfTheDay(VHSPERSON vhsperson)
        {
            if (vhsperson.LunchLada > 0)
            {
                Console.WriteLine("Bringning the 'lunchlåda' to work");
                Console.ReadKey();
                vhsperson.Energi += 1;
                vhsperson.LunchLada -= 1;
            }
           int coffeCout = 0;            
           ChoicesBefore12(vhsperson, coffeCout);            
           ChoicesAfter12(vhsperson, coffeCout);         
           ChoicesAfter17(vhsperson, coffeCout);             
        }

        private static void ChoicesAfter17(VHSPERSON vhsperson, int coffeCout)
        {
            int number = 0;

            decimal timelocal = 17;
            while (timelocal < 20)
            {
                number = 0;
                while (number == 0)
                {
                   
                    Console.Clear();               
                    Console.Write($"Is late... the time is {timelocal}:00");
                    Console.WriteLine(", and you only have 2 options:");
                    Console.WriteLine("1: Help a customer, + boss like, - energy)");
                    Console.WriteLine("2: Go home");                    
                    string choice = Console.ReadLine();
                    int.TryParse(choice, out number);

                    if (number == 1) Console.WriteLine("Work work wok +1 in boss like and -2 in energy"); vhsperson.BossLikes += 1; vhsperson.Energi -= 2; timelocal++;

                    if (number == 2)
                    {
                        Console.WriteLine("Then lets go home");
                        timelocal++;
                    }
                    else if (number == 0)
                    {
                        Console.WriteLine("You only have 2 options... 1 or 2");
                    }
                Console.ReadKey();
                if (timelocal == 20)
                {
                    Console.WriteLine($"it's {timelocal} now!! Go HOME! -3 in energy");
                    vhsperson.Energi -= 3;
                }               

                }
            }
            Console.ReadKey();
        }
               

        private static decimal ChoicesAfter12(VHSPERSON vhsperson, int coffeCout)
        {
            decimal timelocal = 12;
            while (timelocal < 17)
            {
                    Console.Clear();              
                    Console.Write($"The time is {timelocal}:00");
                    Console.WriteLine(", and you have a few choices:");
                //  Console.WriteLine("1: Drink coffe (+energy)");    not after 12:00?
                    Console.WriteLine("1: Help a customer (+ customer happiness, - energy )");
                    Console.WriteLine("2: Buy better tools (+ tools)");
                    Console.WriteLine("3: Chat with your colleagues (+ health, - energy)");
                    Console.WriteLine("4: Play pingis (+ health, - energy)");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 2) coffeCout++;
                    PrintChoices(vhsperson, choice);
                    Console.ReadKey();
                    timelocal++; 
            }
            return timelocal;
        }

        private static decimal ChoicesBefore12(VHSPERSON vhsperson, int coffeCout)
        {
            decimal timeLocal = time;
            while (timeLocal < 12)
            {
                Console.Clear();
                if (coffeCout <= 2)
                {
                      Console.Write($"The time is {timeLocal}:00");
                      Console.WriteLine(", and you have a few choices:");
                      Console.WriteLine("1: Help a customer (+ customer happiness, - energy)");
                      Console.WriteLine("2: Buy better tools (+ tools)");
                      Console.WriteLine("3: Chat with your colleagues (+health, - energy)");
                      Console.WriteLine("4: Play pingis (+ health, - energy)");
                      Console.WriteLine("5: Drink coffe (+ energy).. but dont drink to much!");
                      int choice = int.Parse(Console.ReadLine());
                      if (choice == 2) coffeCout++;                                  
                      PrintChoices(vhsperson, choice);
                      Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Only junior developers can drick this much coffe!");
                    Console.WriteLine("-4 energy, -4 health");
                    Console.ReadKey();
                    vhsperson.Energi -= 4;
                    vhsperson.Health -= 4;
                    coffeCout = 0;
                }
                timeLocal++;
            }
            return timeLocal;
        }

        private static void PrintChoices(VHSPERSON vhsperson, int choice)
        {
            switch (choice)
            {
                case 5: Console.WriteLine("You drink coffe, +1 energy"); vhsperson.Energi += 1; break;
                case 1: 
                    if (vhsperson.ToolLevel >= 1)
                    {
                        Console.WriteLine($"You helped a customer, +{vhsperson.ToolLevel} in customer happiness, -2 in energy");
                        vhsperson.CustomerHappines += vhsperson.ToolLevel;
                        vhsperson.Energi -= 2;
                        vhsperson.VHSRepaired += 1;
                    }
                    else
                    {
                        Console.WriteLine("You helped a customer, +1 in customer happiness, -1 in energy");
                        vhsperson.CustomerHappines += 1;
                        vhsperson.Energi -= 1;
                        vhsperson.VHSRepaired += 1;
                    }
                    break; 
                case 2: Console.WriteLine("You bought a better tool, this will make you work better"); vhsperson.ToolLevel += 1; break;
                case 3: Console.WriteLine("You chatted with your colleagues, -1 energy and +1 health "); vhsperson.Energi -= 1; vhsperson.Health += 1; break;
                case 4: Console.WriteLine("You played pingis and gaines 1 health and lost 1 energy"); vhsperson.Energi -= 1; vhsperson.Health += 1; break;
                default: Console.WriteLine("Error in PrintChoices"); break;
            }
        }

        private static void WakeUp(VHSPERSON vhsperson)
        {
            int n = 0;            
            n = morning.Next(5);            

            if (n == 1)
            {
                Console.WriteLine("Your boss calls your phone and wakes you up.. you overslept!!!");
                Console.WriteLine("Your boss asks you to get here quickly! The boss likes you a bit less now...");
                Console.WriteLine("You only gained 4 energy from the night");
                Console.ReadKey();
                vhsperson.Energi += 4;
                vhsperson.BossLikes -= 1;
                TakeTaxiOrBus(vhsperson);
                time = 10; // Changes time from 9 to 10
            }
            else
            {
                Console.WriteLine("You slept good and gained 8 energy from the night");
                Console.ReadKey();
                vhsperson.Energi += 8;
                TakeTaxiOrBus(vhsperson);
            }
        }

        private static void TakeTaxiOrBus(VHSPERSON vhsperson)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Do you want to take the bus or taxi to work? Type 'bus' or 'taxi'");
                string busTaxi = Console.ReadLine();
                if (busTaxi.ToUpper() == "TAXI")
                {
                    if (vhsperson.Money <= 0)
                    {
                        Console.WriteLine($"<Taxi Driver>: {vhsperson.Name} you dont have enough money at the end of the trip!!!");
                        Console.WriteLine("The driver beats you, - 5 health");
                        vhsperson.Health = -5;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Brumm brumm, this will cost you 2 rubies");
                        vhsperson.Money -= 2;
                        Console.ReadKey();
                    }                    
                    break;
                }
                else if (busTaxi.ToUpper() == "BUS")
                {
                    Console.WriteLine("Brumm brumm, this is good for the environment, but you lost 2 energy");
                    vhsperson.Energi -= 2;
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine(".. you can only enter bus or taxi...");
                    Console.ReadKey();
                    Console.Clear();
                }                   
            }
        }

        private static void CurrentScore(VHSPERSON vhsperson)
        {
            Console.WriteLine($"Rubies: {vhsperson.Money}");
            Console.WriteLine($"Health: {vhsperson.Health}");
            Console.WriteLine($"Energy: {vhsperson.Energi}");
            Console.WriteLine($"Skill: {vhsperson.Skill}");
            Console.WriteLine($"VHS:s fixed: {vhsperson.VHSRepaired}");
            Console.WriteLine($"Boss like: {vhsperson.BossLikes}");
            Console.WriteLine($"Customer happiness: {vhsperson.CustomerHappines}");            
        }

        private static void Sunday(VHSPERSON vhsperson)
        {
            int count = 0;
            int pickLeft = 3;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{vhsperson.Name}, today is Sunday, and you start your new job tomorrow....");
            Console.ResetColor();
            Console.ReadKey();
            Console.WriteLine("what do you want to do today? Pick 3 things (one by one, ex [1 - Enter, 4 - Enter, 2 - Enter])");
            while (count != 3)
            {
                Console.WriteLine("     1: Drink beer with your friends in Nordstan?");
                Console.WriteLine("     2: Make food at home?");
                Console.WriteLine("     3: Chill with your partner?");
                Console.WriteLine("     4: Read a book?");
                Console.WriteLine("     5: Netflix and chill?");
                Console.WriteLine("Pick a option from 1-5");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Woop woop, beer is nice");
                        Console.WriteLine("You spent 1 energy and 1 rubies");
                        vhsperson.Energi -= 1;
                        vhsperson.Money -= 1;
                        count++;
                        break;
                    case 2:
                        Console.WriteLine("You made food for the whole week");
                        Console.WriteLine("You spent 1 energy and 1 rubies");
                        Console.WriteLine("... but you will now have 5x 'Lunchlådor' and gain + 1 energy par day.");
                        vhsperson.LunchLada += 5;
                        vhsperson.Energi -= 1;
                        vhsperson.Money -= 1;
                        count++;
                        break;
                    case 3:
                        Console.WriteLine("You had a perfect 'chill-sunday'");
                        Console.WriteLine("And gained +1 energy");
                        vhsperson.Energi += 1;
                        count++;
                        break;
                    case 4:
                        Console.WriteLine("You now know more!");
                        Console.WriteLine("You gained 1 skill");
                        vhsperson.Skill += 1;
                        count++;
                        break;
                    case 5:
                        Console.WriteLine("A perfect movie for a perfect sunday");
                        Console.WriteLine("You gained nothing from this");
                        count++;
                        break;
                    default:
                        Console.WriteLine("... you need to enter a number between 1-5");
                        break;
                }
                Console.ResetColor();

                if (count != 3)
                {
                    pickLeft -= 1;
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine($"Pick {pickLeft} more");
                }
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Lets get to work");
            Console.ReadKey();
        }
    }
}
