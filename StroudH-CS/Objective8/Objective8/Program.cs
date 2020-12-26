using System;

// Library that help handling lists (in our case)
using System.Collections.Generic;


namespace Objective8
{
    class Program
    {
        // ------- TRY 1 
        // Function to output the contents of an array
        static void OutputArray(string[] Sentence)
        {
            int Index = 0;
            foreach (string Word in Sentence)
            {
                Console.WriteLine("Word {0} is {1}.", Index, Word);
                Index++;
            }
        }


        // ------- TRY 2, 3
        // Function to output the contents of an array (secondo try example)
        static void OutputArrayInLine(string[] Sentence)
        {
            foreach (string Word in Sentence)
            {
                Console.Write(Word + " ");
            }
            Console.WriteLine();
        }

        // ------- TRY 4
        static string[,] Product = new string[4, 2];

        // Subroutine to put data into the array
        static void NewDatabase()
        {
            Product[0, 0] = "Cornflakes"; Product[0, 1] = "1.40";
            Product[1, 0] = "Weetabix"; Product[1, 1] = "1.20";
        }

        // Subroutine to output a product from the array
        static void OutputProduct(int Number)
        {
            Console.WriteLine("{0}: £{1:0.00}", Product[Number, 0], Product[Number, 1]);
        }

        // ------- TRY 5
        static List<string> Pocket = new List<string>();

        // Subroutine to put data into the list
        static void PutInPocket(string Item)
        {
            Pocket.Add(Item);
        }

        // Subroutine to remove data from the list
        static void TakeOutOfPocket(string Item)
        {
            Pocket.Remove(Item);
        }

        // Subroutine to output the list
        static void ShowPocket()
        {
            foreach (string Item in Pocket)
            {
                Console.WriteLine(Item);
            }
        }


        // INVESTIGATE 1
        static char[,] Grid = new char[5, 5];

        static void NewGrid()
        {
            char Letter;
            int ASCII;
            Random Pick = new Random();
            for (int Y = 0; Y < 5; Y++)
            {
                for (int X = 0; X < 5; X++)
                {
                    ASCII = Pick.Next(1, 26) + 64;
                    Letter = (char)ASCII;
                    Grid[X, Y] = Letter;
                }
            }
        }


        //Try program
        static void Try()
        {
            //TRY 1
            //string[] Sentence = { "The", "quick", "brown", "fox", "jumps" };
            //OutputArray(Sentence);

            //TRY 2
            //string[] Sentence = { "The", "quick", "brown", "fox", "jumps" };
            //OutputArrayInLine(Sentence);
            //Sentence[1] = "small";
            //Sentence[2] = "grey";
            //Sentence[3] = "squirrel";
            //OutputArrayInLine(Sentence);

            //TRY 3
            //string[] Sentence = new string[2];
            //Sentence[0] = "Hello";
            //Sentence[1] = "World";
            //OutputArrayInLine(Sentence);

            //TRY 4
            //NewDatabase();
            //OutputProduct(1);

            //TRY 5
            PutInPocket("Wallet");
            PutInPocket("Keys");
            PutInPocket("Tissue");
            TakeOutOfPocket("Keys");
            ShowPocket();

        }

        // --- MAKE

        
        // --- STRONG NUMBER PROBLEM ---
        //Function that return the factorial of a number given as input
        static int Factorial(int Number)
        {
            //0 factorial is always 1
            if(Number == 0)
            {
                return 1;
            }

            int i, Fact;
            Fact = Number;
            for(i = Number - 1; i>=1; i--)
            {
                Fact = Fact * i;
            }

            return Fact;
        }

        // Function that given a string number return true if the number is strong false if the number is not strong
        static bool IsStrong(string Number)
        {
            //list where digits of the number are stored
            int[] Digits = new int[Number.Length];

            //store int number
            int Num = Convert.ToInt32(Number);

            //loop that convert the string number into a list of digit
            for(int i=0; i<Number.Length; i++)
            {
                //selecting a single digit first
                char Value = Number[i];
                //convert it to a string then into a int (toint32 function only work with strings)
                Digits[i] = Convert.ToInt32(Value.ToString());
            }

            //store sum of the factorial(digit)
            int FactorialSum = 0;

            for (int i = 0; i < Number.Length; i++)
            {
                FactorialSum += Factorial(Digits[i]);
            }

            if (FactorialSum == Num)
                return true;
            else
                return false;
        }

        //ask user for a int and tell if its strong or not
        static void StrongNumbers()
        {
            //bool that check if a string value is a numeric value
            bool IsNumber;
            int i = 0;

            string Number = "";
            bool ValidValue = false;
            while(!ValidValue)
            {
                Console.WriteLine("Give me a number, i'll tell you if it's a strong number");
                Number = Console.ReadLine();
                IsNumber = int.TryParse(Number, out i);

                if (IsNumber)
                {
                    ValidValue = true;
                }
            }

            //contains the output of the function IsStrong
            bool Answer = IsStrong(Number);

            if (Answer)
            {
                Console.WriteLine("Yes! {0} is a strong number.", Number);
            }
            else
            {
                Console.WriteLine("Nope, sorry! {0} is not a strong number.", Number);
            }

            
            
        }


        // --- MATHS TEST PROBLEM ---
        //function that test children's addition skill. return int test score
        static int SingleTest()
        {
            //set of variables needed to test the "kids"
            int Score = 0;
            int A, B, Answer, Response;
            string ResponseString;
            Random Random = new Random();

            //Loop that generate questions for the students
            for (int i = 0; i<5; i++)
            {
                A = Random.Next(10, 100);
                B = Random.Next(10, 100);
                Answer = A + B;

                Console.WriteLine("Question n.{0} \nWhat's {1} + {2}", (i+1), A, B);
                ResponseString = Console.ReadLine();
                Response = Convert.ToInt32(ResponseString);

                if (Response == Answer)
                {
                    Score++;
                    Console.WriteLine("Correct! A point has been given to you! \nYour score: {0}\n", Score);
                }
                else
                {
                    Console.WriteLine("Not quite...\nYour score: {0}\n", Score);
                }
            }

            return Score;
        }

        //function that ask a student for his/her name and surname
        static void TestCylcle()
        {
            //list that store student name and result
            string[] StudentsData = new string[2];

            //get student name
            Console.WriteLine("Enter your name:");
            StudentsData[0] = Console.ReadLine();

            //test student and get result in 1 position of the array
            StudentsData[1] = Convert.ToString(SingleTest());

            Console.WriteLine("Student results:\nName: {0}\nScore:{1}/5", StudentsData[0], StudentsData[1]);
        }

        //whole function that repeat the cycle of getting student name and testing him/her and repeating until every student is done
        static void CompleteTestLoop()
        {
            Console.WriteLine("--- Starting assessment about addition ---");

            bool isOver = false;
            string Over = "";
            while(!isOver)
            {
                TestCylcle();

                Console.WriteLine("\nPress 'y' if the test is over, otherwhise press any key:");
                Over = Console.ReadLine();

                if (Over == "y" || Over == "Y")
                {
                    isOver = true;
                }
            }
        }

        // --- TANK PROBLEM ---

        // define game grid where tanks will be placed. Tanks will be noted as 1s and empty spaces as 0s.
        static int[,] GameGrid = new int[8,8];

        // define player grid where there will be displayed where the player has already guess and where he hit a tank
        static int[,] PlayerTrack = new int[9, 9];

        // function that display the game grid nicely
        static void DisplayGrid(int[,] Grid)
        {
            int rowLength = Grid.GetLength(0);
            int colLength = Grid.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", Grid[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.WriteLine("---------------------");
        }

        // create a list of lists where coordinates of the tanks generated will be stored
        static List<List<int>> CoordList = new List<List<int>>();

        // function that prepare gamegrid where tanks are and player track where player guesses are tracked
        static void SetUpGrids()
        {
            //Game-grid
            // to avoid errors all the square in the game grid are initially set to 0
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    GameGrid[i, j] = 0;
                }
            }

            //Player-grid
            //initally displays coords and 0s
            for (int y=0; y<=8; y++)
            {
                for (int x = 0; x <= 8; x++)
                {
                    if (y == 0)
                    {
                        PlayerTrack[y, x] = x - 1;
                    }
                    else if (x == 0)
                    {
                        PlayerTrack[y, x] = y - 1;
                    }
                    else
                    {
                        PlayerTrack[y, x] = 0;
                    }

                    //reset the first square
                    if (x == 0 && y == 0)
                    {
                        PlayerTrack[y, x] = 0;
                    }
                }
            }

        }
        
        
        // function that randomly generates x and y coords of a tank and place them in the gamegrid
        static void TanksCoords(List<List<int>> CoordList)
        {
            

            // random number that will generate x,y position of the tanks
            Random RandomX = new Random();
            Random RandomY = new Random();
            int X, Y;

            for (int i=0; i<=10; i++)
            {
                X = RandomX.Next(0, 8);
                Y = RandomY.Next(0, 8);

                CoordList.Add(new List<int> { X, Y });
            }

            for (int i = 0; i <= 10; i++)
            {
                // X and Y have the randomly generated values and those coords will be changed into a 1 in the game grid
                Y = CoordList[i][0];
                X = CoordList[i][1];
                GameGrid[Y, X] = 1;
            }

            /* debug
            foreach (var Sub in CoordList)
            {
                foreach (var Obj in Sub)
                {
                    Console.WriteLine(Obj);
                }
            }
            */
            Console.WriteLine("DEBUGGING");
            DisplayGrid(GameGrid);
        }

        //function where the tank game actually take place
        static void Game()
        {
            SetUpGrids();
            TanksCoords(CoordList);

            //keep track of how many tanks were hit
            int HitCounter = 0;

            Console.WriteLine("TANKS PROBLEM!");
            Console.WriteLine("Select a square in the grid below.\nIf you hit a tank a '9' will appear in that square otherwise an '8' will appear.\nBe careful you only have 50 guesses.");
            for (int i = 0; i <= 50; i++)
            {
                int X  = 0, Y = 0;
                Console.WriteLine("This is your {0} guess.", (i + 1));

                //loop where user input of next guess is taken
                bool ValidEnter = false;
                while(!ValidEnter)
                {
                    try
                    {
                        Console.WriteLine("Enter Y value: ");
                        Y = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter X value: ");
                        X = Convert.ToInt32(Console.ReadLine());
                    }
                    
                    catch
                    {
                        Console.WriteLine("Plese enter only numeric values");
                        continue;
                    }

                    if (X>=0 && X<=7 && Y>=0 && Y<=7)
                    {
                        ValidEnter = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }

                //true if a tank is hit
                bool isHit = false;
                //loop that check if a guess hit a tank comparing coordinates
                for (int j=0; j<CoordList.Count; j++)
                {
                    if (CoordList[j][0] == Y)
                    {
                        if (CoordList[j][1] == X)
                        {
                            isHit = true;
                            CoordList.RemoveAt(j);
                        }
                    }
                }

                if (isHit)
                {
                    Console.WriteLine("You hit a tank!");
                    PlayerTrack[Y + 1, X + 1] = 9;
                    
                    DisplayGrid(GameGrid);
                    HitCounter++;
                }
                else
                {
                    Console.WriteLine("You missed! Try again...");
                    PlayerTrack[Y + 1, X + 1] = 8;
                }
                

                Console.WriteLine("\n");
                DisplayGrid(PlayerTrack);

                
            }

        }


        static void Main(string[] args)
        {
            //Try();

            //StrongNumbers();

            //CompleteTestLoop();

            Game();

            Console.ReadLine();
        }
    }
}
