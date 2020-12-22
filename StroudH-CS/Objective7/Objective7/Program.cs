using System;

namespace Objective7
{
    class Program
    {

        //TRY
        static string GetInput()
        {
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("Enter an option number: ");
            string Choice = Console.ReadLine();
            return Choice;
        }

        // Function to return a valid  input
        static string GetInputCheck()
        {
            Console.WriteLine("1. Option A");
            Console.WriteLine("2. Option B");
            bool Valid = false;
            string Choice = "";
            while (!Valid)
            {
                Console.WriteLine("Enter an option: ");
                Choice = Console.ReadLine();
                if ((Choice == "1") || (Choice == "2"))
                {
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid option chosen. Try again.");
                }
            }
            return Choice;
        }

        // Function to return an input as an integer 
        static int GetInputDice()
        {
            Console.WriteLine("What do you think the dice roll will be? ");
            string Choice = " ";
            bool ValidChoice = false;
            while (!ValidChoice)
            {
                Console.WriteLine("Enter a guess: ");
                Choice = Console.ReadLine();
                if (char.IsNumber(Convert.ToChar(Choice)) == true)
                {
                    ValidChoice = true;
                }
                if (!ValidChoice)
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            return Convert.ToInt32(Choice);
        }

        static void Try()
        {
            //string Choice = GetInputCheck();
            //Console.WriteLine("You chose option {0}.", Choice);

            Random Dice = new Random();
            int Roll = Dice.Next(1, 7);
            int Choice = GetInputDice();
            Console.WriteLine("The roll was {0}, you guessed {1}", Roll, Choice);
        }

        //Function that checks if a given password is valid
        static bool IsPasswordValid(string Password)
        {

            bool IsThereNumber = false;
            bool IsThereUpperCase = false;
            bool IsThereLowerCase = false;


            if (Password.Length < 8)
            {
                Console.WriteLine("Your password is too short!");
                return false;
            }

            for(int i=0; i<Password.Length; i++)
            {
                if(char.IsNumber(Password[i]))   //check if a char is a number
                {
                    IsThereNumber = true;
                }

                if(char.IsLower(Password[i]))   //check if a char is lowercase
                {
                    IsThereLowerCase = true;
                }

                if(char.IsUpper(Password[i]))   //check if a char is uppercase
                {
                    IsThereUpperCase = true;
                }       
            }


            if (IsThereNumber && IsThereLowerCase && IsThereUpperCase)
            {
                Console.WriteLine("Password is ok!");
                return true;
            }


            else
            {
                if(!IsThereNumber)
                {
                    Console.WriteLine("Invalid!\nPassword must contain at least one number");
                }

                if(!IsThereLowerCase)
                {
                    Console.WriteLine("Invalid!\nPassword must contain at least one low character");
                }

                if(!IsThereUpperCase)
                {
                    Console.WriteLine("Invalid!\nPassword must contain at least one upper character");
                }

                return false;
            }
        }

        //Function that ask user for a password and check if it's valid
        static void ChoosePassword()
        {
            Console.WriteLine("\nSelect a password:");
            string Password = Console.ReadLine();

            while(!IsPasswordValid(Password))
            {
                Console.WriteLine("\nSelect a password:");
                Console.WriteLine("(It must have at least 1 number, and 1 upper and lower character. It also can't be shorter than 8 characters");
                Password = Console.ReadLine();
            }
        }

        //subfunction that given a xx:yy format string return xx (hour value)
        static int CheckHour(string Time)
        {
            string Hour1 = Convert.ToString(Time[0]);
            string Hour2 = Convert.ToString(Time[1]);

            string Hours = Hour1 + Hour2;

            int HoursInt = Convert.ToInt32(Hours);

            return HoursInt;
        }

        //given a string verify if it is in a valid xx:yy form
        //return true if is ok and false if it's not ok
        static bool CheckTimeInput(string Time)
        {
            //structure check
            //check if places 1,2,4,5 are digit and 3 is semicolon to validate input
            if (char.IsDigit(Time[0]) == false || char.IsDigit(Time[1]) == false || Time[2] != ':' || char.IsDigit(Time[3]) == false || char.IsDigit(Time[4]) == false || Time.Length > 5)
            {
                Console.WriteLine("Invalid format.");
                return false;
            }

            else
            {
                //logic check
                //check if invalid time and minutes values are given
                string Hour1 = Convert.ToString(Time[0]);
                string Hour2 = Convert.ToString(Time[1]);
                string Minute1 = Convert.ToString(Time[3]);
                string Minute2 = Convert.ToString(Time[4]);

                string Hours = Hour1 + Hour2;
                string Minutes = Minute1 + Minute2;

                int HoursInt = Convert.ToInt32(Hours);
                int MinutesInt = Convert.ToInt32(Minutes);


                if (HoursInt >= 24 || MinutesInt >= 60)
                {
                    Console.WriteLine("Invalid Time.");
                    return false;

                }
                else
                {
                    return true;
                }
            }
        }

        //subfunction that given 2 strings of time in xx:xx format return time in minutes between the 2 times
        static int CalcTime(string EnterTime, string LeftTime)
        {
            int TotalHours;
            int TotalMinutes;

            int TotalTime;

            //convert enter time in a convenient format
            string EHour1 = Convert.ToString(EnterTime[0]);
            string EHour2 = Convert.ToString(EnterTime[1]);
            string EMinute1 = Convert.ToString(EnterTime[3]);
            string EMinute2 = Convert.ToString(EnterTime[4]);

            string EHours = EHour1 + EHour2;
            string EMinutes = EMinute1 + EMinute2;

            int EHoursInt = Convert.ToInt32(EHours);
            int EMinutesInt = Convert.ToInt32(EMinutes);

            //convert left time in a convenient format
            string LHour1 = Convert.ToString(LeftTime[0]);
            string LHour2 = Convert.ToString(LeftTime[1]);
            string LMinute1 = Convert.ToString(LeftTime[3]);
            string LMinute2 = Convert.ToString(LeftTime[4]);

            string LHours = LHour1 + LHour2;
            string LMinutes = LMinute1 + LMinute2;


            int LHoursInt = Convert.ToInt32(LHours);
            int LMinutesInt = Convert.ToInt32(LMinutes);

            //Calculate total hours and total minutes
            TotalHours = LHoursInt - EHoursInt;
            TotalMinutes = LMinutesInt - EMinutesInt;

            //if total minutes are negative then another calculation must be done to get real minutes
            if (TotalMinutes<0)
            {
                TotalMinutes = (60 - EMinutesInt) + LMinutesInt;
                
            }

            TotalTime = (60 * TotalHours) + TotalMinutes;

            return TotalTime;
        }

        //Subfunction that calculate the cost of a parking given a time and the fact if the driver is disabled
        static double CostCalculator(int Time, string Disabled)
        {
            //more than 4 hours
            if (Time>240)
            {
                return 8.00;
            }

            //between 3 and 4
            if (Time<=240 && Time>180)
            {
                return 4.50;
            }

            //between 2 and 3
            if (Time<=180 && Time>120)
            {
                if (Disabled == "y")
                {
                    return 0;
                }

                else
                {
                    return 3.90;
                }
            }

            //between 2 and 1
            if (Time <=120 && Time>60)
            {
                if (Disabled == "y")
                {
                    return 0;
                }

                else
                {
                    return 2.90;
                }
            }

            //less than or 1 hour
            if (Time <= 60)
            {
                if (Disabled == "y")
                {
                    return 0;
                }

                else
                {
                    return 1.50;
                }
            }

            else
                Console.WriteLine("Error occurred when calulating price!");
            return 999;
        }

        //Function that calculate the cost of a parking in a car park
        static void ParkingCostProblem()
        {
            //Ask for time when car entered
            string EnterHour = "";
            string LeftHour = "";
            string Disabled = "n";

            bool ValidEnter = false;
            while (!ValidEnter)
            {
                Console.WriteLine("Insert time when you entered the parking: (xx:xx format)");
                EnterHour = Console.ReadLine();

                ValidEnter = CheckTimeInput(EnterHour);
            }

            //Ask for time when car left
            ValidEnter = false;
            while(!ValidEnter)
            {
                Console.WriteLine("Insert time when you left the parking: (xx:xx format)");
                LeftHour = Console.ReadLine();

                ValidEnter = CheckTimeInput(LeftHour);
            }

            //Convert string format and extract hours
            int EHour = CheckHour(EnterHour);
            int LHour = CheckHour(LeftHour);

            //Check if parking is during free hours
            if (EHour>=20 && LHour <= 6)
            {
                Console.WriteLine("Night park, no fee");
            }

            //Check if driver is disabled
            ValidEnter = false;
            while(!ValidEnter)
            {
                Console.WriteLine("Are you disabled (y/n):");
                Disabled = Console.ReadLine();
                if (Disabled == "y" || Disabled == "n")
                {
                    ValidEnter = true;
                }
            }

            int TotalTime = CalcTime(EnterHour, LeftHour);

            double Cost = CostCalculator(TotalTime, Disabled);


            Console.WriteLine("Fee is: {0}£", Cost);

        }

        static int RockPaperScissors()
        {
            //section that handle user choice
            string UserChoiceString = "";
            bool ValidEnter = false;
            while(!ValidEnter)
            {
                Console.WriteLine("Choose:\n\t1) Rock\n\t2) Paper\n\t3)Scissors");
                UserChoiceString = Console.ReadLine();

                if (UserChoiceString == "1" || UserChoiceString == "2" || UserChoiceString == "3")
                {
                    ValidEnter = true;
                }
            }
            int UserChoice = Convert.ToInt32(UserChoiceString);

            if (UserChoice == 1)
                Console.WriteLine("\nYou chose rock.");
            if (UserChoice == 2)
                Console.WriteLine("\nYou chose paper.");
            if (UserChoice == 3)
                Console.WriteLine("\nYou chose scissors.");


            //section that handle pc random choice
            Random Number = new Random();
            int PCChoice = Number.Next(1, 4);

            if (PCChoice == 1)
                Console.WriteLine("\nPC chose rock.\n");
            if (PCChoice == 2)
                Console.WriteLine("\nPC chose paper.\n");
            if (PCChoice == 3)
                Console.WriteLine("\nPC chose scissors.\n");


            //section that handle logic to determine who won

            //Paths if User chose rock
            if (UserChoice == 1)
            {
                if (PCChoice == 1)
                {
                    Console.WriteLine("It's a draw!");
                    return 0;
                }


                if (PCChoice == 2)
                {
                    Console.WriteLine("You lost!");
                    return -1;
                }


                else
                {
                    Console.WriteLine("You won!");
                    return 1;
                }
            }

            //Paths if User chose paper
            if (UserChoice == 2)
            {
                if (PCChoice == 1)
                {
                    Console.WriteLine("You won!");
                    return 1;
                }


                if (PCChoice == 2)
                {
                    Console.WriteLine("It's a draw!");
                    return 0;
                }


                else
                {
                    Console.WriteLine("You lost!");
                    return -1;
                }
            }

            //Paths if User chose 3
            else
            {
                if (PCChoice == 1)
                {
                    Console.WriteLine("You lost!");
                    return -1;
                }


                if (PCChoice == 2)
                {
                    Console.WriteLine("You won!");
                    return 1;
                }


                else
                {
                    Console.WriteLine("It's a draw!");
                    return 0;
                }
            }
        }

        //function that let player play rock paper scissors until one of the player reach 5 wins
        static void Game()
        {
            int UserWins = 0;
            int PCWins = 0;

            int Score = 0;

            while(UserWins < 5 && PCWins < 5)
            {
                Score = RockPaperScissors();

                if (Score == 1)
                    UserWins += 1;
                if (Score == -1)
                    PCWins += 1;

                Console.WriteLine("\nUser score: {0}", UserWins);
                Console.WriteLine("Pc score: {0}", PCWins);


            }
        }


        static void Main()
        {
            //Try();

            //ChoosePassword();

            //ParkingCostProblem();

            Game();

            Console.ReadLine();
        }
    }
}
