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
            StartGame(vhsperson); // Game start for real now

            Console.WriteLine("Its now friday evening.. and the boss calls you"); // 
        }


        static Random morning = new Random(); // Creates random things (check WakeUo() for example)
        private static int dayCount;
        private static int time = 9;


        private static void StartGame(VHSPERSON vhsperson)
        {
            while (dayCount != 4)
            {
                Console.WriteLine($"It's now {WhatDay(dayCount)}");
                Console.ReadKey();
                Console.WriteLine("Your current scores are:");
                CurrentScore(vhsperson);
                Console.ReadKey();
                WakeUp(vhsperson);
                StartWork(vhsperson);
                dayCount++;
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
            Console.WriteLine($"You now arrived at the job and have {vhsperson.Energi} energi left");
            Console.ReadKey();
            FirstEventOfTheDay(vhsperson);

        }

        private static void FirstEventOfTheDay(VHSPERSON vhsperson)
        {
           int coffeCout = 0;            
           ChoicesBefore12(vhsperson, coffeCout);            
           ChoicesAfter12(vhsperson, coffeCout);         
           ChoicesAfter17(vhsperson, coffeCout);             
        }

        private static void ChoicesAfter17(VHSPERSON vhsperson, int coffeCout)
        {
            decimal timelocal = 17;
            while (timelocal < 20)
            {
                Console.Clear();
               
                    Console.Write($"Is late... the time is {timelocal}:00");
                    Console.WriteLine(", and you only have 2 options:");
                    Console.WriteLine("1: Help a customer (+money)");
                    Console.WriteLine("2: Go home");                    
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1) Console.WriteLine("Work work wok");
                    if (choice == 2)
                    {
                        Console.WriteLine("Then lets go home"); break;
                    }
                    Console.ReadKey();
                    timelocal++;
                if (timelocal == 20)
                {
                    Console.WriteLine($"it's {timelocal} now!! Go HOME!");
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
                if (coffeCout <= 2)
                {
                    Console.Write($"The time is {timelocal}:00");
                    Console.WriteLine(", and you have a few choices:");
                    Console.WriteLine("1: Drink coffe (+energi)");
                    Console.WriteLine("2: Help a customer (+money)");
                    Console.WriteLine("3: Buy better tools (+tools)");
                    Console.WriteLine("4: Chat with your colleagues (+health but - energi)");
                    Console.WriteLine("5: Play pingis (+health but - energi)");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 2) coffeCout++;
                    PrintChoices(vhsperson, choice);
                    Console.ReadKey();
                    timelocal++;
                }
                else
                {
                    Console.WriteLine("You drank to much coffe this day and lost 2 in health and 2 in energi");
                    Console.ReadKey();
                    vhsperson.Energi -= 2;
                    vhsperson.Health -= 2;
                    coffeCout = 0;
                }
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
                      Console.WriteLine("1: Drink coffe (+energi)");
                      Console.WriteLine("2: Help a customer (+money)");
                      Console.WriteLine("3: Buy better tools (+tools)");
                      Console.WriteLine("4: Chat with your colleagues (+health but - energi)");
                      Console.WriteLine("5: Play pingis (+health but - energi)");
                      int choice = int.Parse(Console.ReadLine());
                          if (choice == 2) coffeCout++;                                  
                      PrintChoices(vhsperson, choice);
                      Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You drank to much coffe this day and lost 2 in health and 2 in energi");
                    Console.ReadKey();
                    vhsperson.Energi -= 2;
                    vhsperson.Health -= 2;
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
                case 1: Console.WriteLine("You drink coffe and gaines +1 energi"); vhsperson.Energi += 1; break;
                case 2: Console.WriteLine("You helped a customer and gaines +1 customer like"); vhsperson.CustomerHappines += 1; break;
                case 3: Console.WriteLine("You bought a better tool, this will make you work better"); vhsperson.ToolLevel += 1; break;
                case 4: Console.WriteLine("You chatted with your colleagues, "); vhsperson.Energi -= 1; vhsperson.Health += 1; break;
                case 5: Console.WriteLine("You played pingis and gaines 1 health and lost 1 energi"); vhsperson.Energi -= 1; vhsperson.Health += 1; break;
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
                Console.WriteLine("You gained 4 energi from the night");
                Console.ReadKey();
                vhsperson.Energi += 4;
                vhsperson.BossLikes -= 1;
                TakeTaxiOrBus(vhsperson);
                time = 10; // Changes time from 9 to 10
            }
            else
            {
                Console.WriteLine("You gained 5 energi from the night");
                Console.ReadKey();
                vhsperson.Energi += 5;
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
                    Console.WriteLine("Brumm brumm, this will cost you 1 money");
                    vhsperson.Money -= 1;
                    Console.ReadKey();
                    break;
                }
                else if (busTaxi.ToUpper() == "BUS")
                {
                    Console.WriteLine("Brumm brumm, this is good for the environment, but you lost 1 energi");
                    vhsperson.Energi -= 1;
                    Console.ReadKey();

                    break;
                }
                else
                {
                    Console.WriteLine(".. you can only enter yes or no");
                    Console.ReadKey();
                    Console.Clear();
                }     
              
            }
        }

        private static void CurrentScore(VHSPERSON vhsperson)
        {
            Console.WriteLine($"Money: {vhsperson.Money}");
            Console.WriteLine($"Health: {vhsperson.Health}");
            Console.WriteLine($"Energi: {vhsperson.Energi}");
            Console.WriteLine($"Skill: {vhsperson.Skill}");
        }

        private static void Sunday(VHSPERSON vhsperson)
        {
            int count = 0;
            int pickLeft = 3;
            Console.WriteLine("Welcome, today is Sunday");
            Console.WriteLine("What do you want to do today? Pick 3 things");
            while (count != 3)
            {
                Console.WriteLine("     1: Drink beer with your friends");
                Console.WriteLine("     2: Make food");
                Console.WriteLine("     3: Chill with your partner");
                Console.WriteLine("     4: Read");
                Console.WriteLine("     5: Netflix");
                Console.WriteLine("Pick a option from 1-5");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Woop woop, beer is nice");
                        Console.WriteLine("You spent 1 energi and 1 money");
                        vhsperson.Energi -= 1;
                        vhsperson.Money -= 1;
                        count++;

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You made food for the whole week");
                        Console.WriteLine("You spent 1 energi and and 1 money");
                        vhsperson.Energi -= 1;
                        vhsperson.Money -= 1;
                        count++;

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("You had a perfect chill-sunday");
                        Console.WriteLine("You gained 1 energi");
                        vhsperson.Energi += 1;
                        count++;
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("You now know more!");
                        Console.WriteLine("You gained 1 skill");
                        vhsperson.Skill += 1;
                        count++;
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("A perfect movie for a parfect sunday");
                        Console.WriteLine("You gained nothing from this");
                        count++;
                        break;

                    default:
                        Console.WriteLine("... you need to enter a number between 1-5");
                        break;
                }
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

        }
    }
}
