using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace VHS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "VHS MADNESS";
            var vhsperson = new VHSPERSON(); // Creates the class
            string something = File.ReadAllText(@"C:\Users\Risberg\Desktop\Projekt Week 3\ScoreBoard\ScoreBoard.txt");
            int value = IntroPage();
          
            if (value == 2)
            {
                PrintScoreBoard(something);

            }
            loadingTheMainGame();



            Console.Clear();
            vhsperson.AskForName(); // Ask user for the name 

            
            Sunday(vhsperson); // Ask user for 3 things to do on sunday, effects the scores
            Console.ResetColor();
            StartGame(vhsperson); // Game start for real now
            EndGame(vhsperson, something);
        }

        private static void loadingTheMainGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("Loading game... [           ]");
            for (int i = 16; i <= 26; i++)
            {
                Console.SetCursorPosition(i + 1, 0);
                Console.Write("*");
                Thread.Sleep(200);
            }

            Console.ReadKey();

        }

        private static int IntroPage()
        {
            displayIntro(20, 0);
            int value = displayChoices(45, 15);
           
            return value;

        }

        private static int displayChoices(int left, int top)
        {
            Console.CursorVisible = true;
            int number = 0;
            int value = 0;
            Console.SetCursorPosition(left, top);
            Console.WriteLine("1. Start new game");
            Console.SetCursorPosition(left, top + 1);
            Console.WriteLine("2. Highscore");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("Choose your option: ");
            string choice = Console.ReadLine();
            int.TryParse(choice, out number);

            if (number == 1)
            {
                value = 1;
            }
            else if (number == 2)
            {
                value = 2;
            }
            else if (number != 1 || number != 2)
            {
                Console.SetCursorPosition(33, top + 5);
                Console.WriteLine("You can only choose between the number 1 and 2.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(left + 19, top + 2);
                Console.Write("                   ");
                Console.SetCursorPosition(left, top + 3);
                displayChoices(left, top);
            }
            return value;
        }

        private static void displayIntro(int left, int top)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(left, top);

            string[] ram = new string[]
                {@"======================================================================"};

            string[] titel = new string[]
                {@"                   __      ___    _  _____                           _                     ",
                 @"                   \ \    / / |  | |/ ____|                         | |                    ",
                 @"                    \ \  / /| |__| | (___ ______ _ __ ___   __ _  __| |_ __   ___  ___ ___ ",
                 @"                     \ \/ / |  __  |\___ \______| '_ ` _ \ / _` |/ _` | '_ \ / _ \/ __/ __|",
                 @"                      \  /  | |  | |____) |     | | | | | | (_| | (_| | | | |  __/\__ \__ \",
                 @"                       \/   |_|  |_|_____/      |_| |_| |_|\__,_|\__,_|_| |_|\___||___/___/" };


            var line1 = new List<char>() { 'Y', 'o', 'u', ' ', 'a', 'r', 'e', ' ', 't', 'h', 'e', ' ', 'V', 'H', 'S', '-', 'g', 'u', 'y', '!' };
            var line2 = new List<char>() { 'Y', 'o', 'u', ' ', 'n','e','e','d',' ','t','o',' ','g','e','t',' ',
                'p','r','o','m','o','t','e','d',' ','t','o',' ','a','f','f','o','r','d', ' ','y','o','u','r',' ','e','x','c','l','u','s','i','v','e',
                ' ','c','o','l','l','e','c','t','i','o','n',' ','o','f', ' ','m','a','p','l','e',' ','s','y','r','u','p','.' };

            var line3 = new List<char>() {'D','o',' ','y','o','u','r',' ','b','e','s','t',',',' ','w','o','r','k',' ','h','a','r','d',',',' ','t','a','k','e',
            ' ','c','a','r','e',' ','o','f',' ','c','u','s','t','o','m','e','r','s',' ','a','n','d',' ','f','i','n','d', ' ', 't', 'h', 'e', ' ', 'm', 'i', 'n', 'i', '-', 'g', 'a', 'm', 'e', 's', '.', '.', '.' };

            var line4 = new List<char>() { 'a', 'n', 'd', ' ', 't', 'h', 'e', 'n', ' ', 'm', 'a', 'y', 'b', 'e', ',', ' ', 'j', 'u', 's', 't', ' ',
                'm', 'a', 'y', 'b', 'e',',',' ','y','o','u',' ','w','i','l','l',' ','a','c','h','i','e','v','e',' ','y','o','u','r',' ', 'g','o','a','l','.' };

            var line5 = new List<char>() { 'B','u','t',' ','r','e','m','e','m','b','e','r',',',' ','y','o','u',' ','o','n','l','y',' ','h','a','v','e',
            ' ','f','i','v','e',' ','d','a','y','s',' ','a','n','d',' ','t','h','e',' ','c','l','o','c','k',' ','i','s',' ','t','i','c','k','i','n','g','.'};

            //foreach (var item in ram)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (string text in titel)
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine(text);
            //    Thread.Sleep(200);
            //    Console.ResetColor();
            //}

            //foreach (var item in ram)
            //{
            //    Console.SetCursorPosition(left, 7);
            //    Console.WriteLine(item);
            //}

            //Console.SetCursorPosition(45, 9);
            //foreach (var item in line1)
            //{
            //    Console.Write(item);
            //    Thread.Sleep(70);
            //}

            //Console.SetCursorPosition(left, 10);
            //foreach (var item in line2)
            //{
            //    Console.Write(item);
            //    Thread.Sleep(70);
            //}

            //Console.SetCursorPosition(left, 11);
            //foreach (var item in line3)
            //{
            //    Console.Write(item);
            //    Thread.Sleep(70);
            //}

            //Console.SetCursorPosition(left, 12);
            //foreach (var item in line4)
            //{
            //    Console.Write(item);
            //    Thread.Sleep(70);
            //}

            //Console.SetCursorPosition(left, 13);
            //foreach (var item in line5)
            //{
            //    Console.Write(item);
            //    Thread.Sleep(70);
            //}
            //Console.WriteLine();
            //Thread.Sleep(3000);
        }

        private static void PrintScoreBoard(string something)
        {
            Console.Clear();
            Console.WriteLine(something);
            Console.ReadKey();
            Console.Clear();
        }

        private static void EndGame(VHSPERSON vhsperson, string something)
        {
            Console.Clear();
            Console.WriteLine("Its now friday evening.. and the boss calls you");
            Console.ReadKey();
            Console.WriteLine("To get a promotion you'll need: ");
            Console.WriteLine("Health > 1"); 
            Console.WriteLine("Skill > 2");
            Console.WriteLine("BossLikes > 2");
            Console.WriteLine("VHSRepaired > 5");
            Console.WriteLine("CustomerHappines > 20");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Your score is:" );
            CurrentScore(vhsperson);
            PromotedOrnot(vhsperson);
            int scoreBoard = vhsperson.BossLikes + vhsperson.CustomerHappines + vhsperson.Energi + vhsperson.Health + vhsperson.Money + vhsperson.Skill + vhsperson.VHSRepaired;
            Console.WriteLine($"Total score: {scoreBoard}");
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Risberg\Desktop\Projekt Week 3\ScoreBoard\ScoreBoard.txt"))
            {
                writer.WriteLine(something + vhsperson.Name + " " + scoreBoard);
            }
        }

        private static void PromotedOrnot(VHSPERSON vhsperson)
        {
            if (vhsperson.Health > 1 && vhsperson.Skill > 2 && vhsperson.BossLikes > 2 && vhsperson.VHSRepaired > 5 && vhsperson.CustomerHappines > 20)
            {
                Promoted(vhsperson);
            }
            else
            {
                Fired(vhsperson);
            }

        }

        private static void Fired(VHSPERSON vhsperson)
        {
            Console.Clear();
            string[] you = new string[]
            {
                  @"                                       ",
                  @"            ██╗   ██╗ ██████╗ ██╗   ██╗",
                  @"            ╚██╗ ██╔╝██╔═══██╗██║   ██║",
                  @"             ╚████╔╝ ██║   ██║██║   ██║",
                  @"              ╚██╔╝  ██║   ██║██║   ██║",
                  @"               ██║   ╚██████╔╝╚██████╔╝",
                  @"               ╚═╝    ╚═════╝  ╚═════╝"

            };

            string[] are = new string[]
            {
                @"                                         ",
                @"                 █████╗ ██████╗ ███████╗ ",
                @"                ██╔══██╗██╔══██╗██╔════╝ ",
                @"                ███████║██████╔╝█████╗   ",
                @"                ██╔══██║██╔══██╗██╔══╝   ",
                @"                ██║  ██║██║  ██║███████╗ ",
                @"                ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝ "

            };

            string[] fired = new string[]
            {
                @"                                                      ",
                @"                  ███████╗██╗██████╗ ███████╗██████╗  ",
                @"                  ██╔════╝██║██╔══██╗██╔════╝██╔══██╗ ",
                @"                  █████╗  ██║██████╔╝█████╗  ██║  ██║ ",
                @"                  ██╔══╝  ██║██╔══██╗██╔══╝  ██║  ██║ ",
                @"                  ██║     ██║██║  ██║███████╗██████╔╝ ",
                @"                  ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝╚═════╝  "

            };


            foreach (var item in you)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            foreach (var x in are)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();

            foreach (var y in fired)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(y);
                Thread.Sleep(100);
                Console.ResetColor();
            }


            Console.ReadKey();
            Environment.Exit(1);
        }

        private static void Promoted(VHSPERSON vhsperson)
        {
            Console.Clear();
            string[] you = new string[]
            {
                  @"                                      ",
                  @"            ██╗   ██╗ ██████╗ ██╗   ██╗",
                  @"            ╚██╗ ██╔╝██╔═══██╗██║   ██║",
                  @"             ╚████╔╝ ██║   ██║██║   ██║",
                  @"              ╚██╔╝  ██║   ██║██║   ██║",
                  @"               ██║   ╚██████╔╝╚██████╔╝",
                  @"               ╚═╝    ╚═════╝  ╚═════╝"

            };

            string[] are = new string[]
            {
                @"                                         ",
                @"                 █████╗ ██████╗ ███████╗ ",
                @"                ██╔══██╗██╔══██╗██╔════╝ ",
                @"                ███████║██████╔╝█████╗   ",
                @"                ██╔══██║██╔══██╗██╔══╝   ",
                @"                ██║  ██║██║  ██║███████╗ ",
                @"                ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝ "

            };

            string[] promoted = new string[]
            {
                @"                                                                              ",
                @"      ██████╗ ██████╗  ██████╗ ███╗   ███╗ ██████╗ ████████╗███████╗██████╗   ",
                @"      ██╔══██╗██╔══██╗██╔═══██╗████╗ ████║██╔═══██╗╚══██╔══╝██╔════╝██╔══██╗  ",
                @"      ██████╔╝██████╔╝██║   ██║██╔████╔██║██║   ██║   ██║   █████╗  ██║  ██║  ",
                @"      ██╔═══╝ ██╔══██╗██║   ██║██║╚██╔╝██║██║   ██║   ██║   ██╔══╝  ██║  ██║  ",
                @"      ██║     ██║  ██║╚██████╔╝██║ ╚═╝ ██║╚██████╔╝   ██║   ███████╗██████╔╝  ",
                @"      ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝    ╚═╝   ╚══════╝╚═════╝   "
            };


            foreach (var item in you)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            foreach (var x in are)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();

            foreach (var y in promoted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(y);
                Thread.Sleep(100);
                Console.ResetColor();
            }


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
                    Console.ReadKey();

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
                while (number == 0 || timelocal < 20)
                {
                   
                    Console.Clear();               
                    Console.Write($"Is late... the time is {timelocal}:00");
                    Console.WriteLine(", and you only have 2 options:");
                    Console.WriteLine("1: Help a customer, + boss like, - energy)");
                    Console.WriteLine("2: Go home");                    
                    string choice = Console.ReadLine();
                    
                    int.TryParse(choice, out number);
                    if (number == 0)
                    {
                        Console.WriteLine("You only have 2 options... 1 or 2");
                    }
                    else if (number == 1)
                    {
                        Console.WriteLine("Work work wok +1 in boss like and -2 in energy, -1 health"); vhsperson.BossLikes += 1; vhsperson.Energi -= 2; vhsperson.Health -= 1; timelocal++; number = 0;
                    }
                    else if (number == 2)
                    {
                        Console.WriteLine("Then lets go home");
                        Console.ReadKey();
                        timelocal = 20;
                        break;
                    }
                  
                Console.ReadKey();
                if (timelocal == 20)
                {
                    Console.WriteLine($"it's {timelocal} now!! Go HOME! -3 in energy");
                    vhsperson.Energi -= 3;
                    break;
                }               

                }

            }
            if (vhsperson.Health < 0)
            {
                HealthToLow(vhsperson);
            }
            Console.ReadKey();
        }

        private static void HealthToLow(VHSPERSON vhsperson)
        {
            Console.WriteLine($"Your health it to low.. ({vhsperson.Health}) and you need to go to the hospital");
            Console.ReadKey();
            Console.WriteLine("The doctor gives you a 30 % chance");
            Console.ReadKey();
            Console.WriteLine("Roll the dice, if you get 1 or 2 you die, and if you get 3,4,5 or 6 you live");
            Console.WriteLine("Press enter to roll the dice");
            Console.ReadKey();
            int n = 0;
            n = morning.Next(6);
            if (n <= 2)
            {
                Console.WriteLine($"You rolled {n}...");
                Console.ReadKey();
                Dead();
            }
            else
            {
                Console.WriteLine($"You rolled {n}, yaay! Going back to work!");
                vhsperson.Health = 10;
                Console.WriteLine($"Health is back to {vhsperson.Health}");
            }
        }

        private static void Dead()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                   ■ ■ ■ ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
                Console.WriteLine("             ■      R.I.P.     ■");
                Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■ ■ ■ ■      ");
                Console.WriteLine("          Try not to work so much!  ");
                Console.ResetColor();

                Thread.Sleep(1000);
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                   ■ ■ ■ ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
                Console.WriteLine("             ■      R.I.P.     ■");
                Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■     ■      ");
                Console.WriteLine("                   ■ ■ ■ ■      ");
                Console.WriteLine("          Try not to work so much!  ");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                   ■ ■ ■ ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("             ■      R.I.P.     ■");
            Console.WriteLine("             ■ ■ ■ ■     ■ ■ ■ ■");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■     ■      ");
            Console.WriteLine("                   ■ ■ ■ ■      ");
            Console.WriteLine("          Try not to work so much!  ");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(1);

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
                    PrintChoices(vhsperson, choice);
                    Console.ReadKey();
                    timelocal++; 
               
            }
            return timelocal;
        }

        private static decimal ChoicesBefore12(VHSPERSON vhsperson, int coffeCout)
        {
            coffeCout = 0;
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
                    if (choice == 2)
                    {
                        coffeCout++;
                    }
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
            int n = 0;
            n = morning.Next(20);
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
            if (n == 1)
            {
                Console.Clear();
                Console.WriteLine($"<BOSS>: {vhsperson.Name}, WAKE UP!!!");
                Console.WriteLine("You fell aslep during your task");
                Console.WriteLine("-2 boss like.. think you need to work late a few days to fix this");
                vhsperson.BossLikes -= 2;
            }
            if (n == 2)
            {
                Random random = new Random();

                int randomNumber = random.Next(1, 10);
                int guess = 0;
                int count = 0;
                Console.Clear();
                Console.WriteLine($"<BOSS> {vhsperson.Name}, i'm thinking of a number between 1-10, can you guess which one?");
                Console.WriteLine("Enter a number");

                while (guess != randomNumber)
                {
                    guess = int.Parse(Console.ReadLine());

                    if (guess < randomNumber)
                    {
                        Console.WriteLine("Nope! The number is higher than " + guess + ". Try again.");
                        count++;
                    }
                    else if (guess > randomNumber)
                    {
                        Console.WriteLine("Wrong, the number is lower than " + guess + ". Try again.");
                        count++;
                    }
                }
                count++;
                Console.WriteLine("Correct, the number was " + randomNumber + ".");
                if (count <= 3)
                {
                    Console.WriteLine("You gain 5 rubies");
                    vhsperson.Money += 5;
                }
                else if (count > 3 && count <= 5)
                {
                    Console.WriteLine("Not to bad, you gain 1 rubie");
                    vhsperson.Money += 1;
                }
                else
                {
                    Console.WriteLine(".. that was bad.. to many guesses");
                }
                Console.WriteLine($"You guessed: {count} times");

            }
            if (n == 3)
            {
                int countLocal = 0;
                Console.Clear();
                Console.WriteLine($"<Läraren Oskar>: {vhsperson.Name}, lets play a game");
                Console.ReadKey();
                while (countLocal == 0)
                {
                Console.Write("Solve this equation: '(2 + 4) * (2 - 4)', enter a number and press enter:");
                string solveInput = Console.ReadLine();
                    if (solveInput == "-12")
                    {
                        Console.WriteLine("Correct! You gain 1 rubies");
                        vhsperson.Money += 1;
                        countLocal = 1;
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The correct awnser is: -12, you loose 1 rubie");
                        vhsperson.Money -= 1;
                        countLocal = 1;
                    }

                }

            }
            if (n == 4)
            {
                Console.Clear();
                Console.WriteLine("A masked armed robber enters the store, and yells 'Give me all your money'");
                Console.WriteLine("What do you do?");
                Console.ReadKey();
                Console.WriteLine("1: Hide under the counter");
                Console.WriteLine("2: Fight the robber");
                Console.WriteLine("3: Help the robber");
                Console.WriteLine("Enter a number and press enter");
                int input = 0;
                string input2 = Console.ReadLine();
                int.TryParse(input2, out input);
                if (input == 1)
                {
                    Console.Clear();
                    Console.WriteLine("The robber takes all the money...");
                    Console.WriteLine("The boss yells at you, - boss point");
                    vhsperson.BossLikes -= 1;
                    Console.ReadKey();
                }
                else if (input == 2)
                {
                    Random random = new Random();
                    Console.WriteLine("You take a bunch of VHS-tapes and throw them at the robber");
                    Console.ReadKey();
                    int randomNumber = random.Next(1, 2);
                    if (randomNumber == 1)
                    {
                        Console.WriteLine("The robber dodges and beats you");
                        Console.WriteLine("- energy, - health, + boss point");
                        vhsperson.Energi -= 1; vhsperson.BossLikes += 1; vhsperson.Health -= 1;
                    }
                    else
                    {
                        Console.WriteLine("The robber gets hit and runs away");
                        Console.WriteLine("+ boss point, + energy");
                        vhsperson.BossLikes += 1; vhsperson.Energi += 1;
                    }
                    
                }
                else
                {
                    Random random = new Random();
                    Console.WriteLine("You help the robber and take a few VHS-tapes for yourself");
                    Console.ReadKey();
                    int randomNumber = random.Next(1, 2);
                    if (randomNumber == 1)
                    {
                        Console.WriteLine("The boss calls the cop, and you are sent to jail");
                        Console.ReadKey();
                        Fired(vhsperson);
                    }
                    else
                    {
                        Console.WriteLine("Yaaaay, you got the new Back to the Future 2 movie");
                        Console.WriteLine("+ money, + health, - energy");
                        vhsperson.Money += 1; vhsperson.Health += 1; vhsperson.Energi -= 1;
                    }

                }
                Console.ReadKey();

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
                    if (vhsperson.Money <= 1)
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
