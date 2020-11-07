using System;

namespace Objective5
{
    class Program
    {

        /* TRY  */

        // Subroutine to demonstrate loops
        static void OutputMessage(string Message)
        {
            for (int Counter = 0; Counter < 10; Counter++)
            {
                Console.WriteLine(Message);
            }
        }

        static void TestOutputMessage()
        {
            string Message = "This is how you get code to repeat.";
            OutputMessage(Message);
        }


        // Subroutine to demonstrate loops
        static void DemoLoop()
        {
            for (int Counter = 1; Counter < 11; Counter++)
            {
                Console.WriteLine("This is line {0}", Counter);
            }
        }

        // Subroutine to demonstrate loops
        static void CharLoop(string Message)
        {
            for (int Index = 0; Index < Message.Length; Index++)
            {
                string Alpha = Message.Substring(Index, 1);
                Console.WriteLine("Character {0} of {1} is {2}.", Index, Message, Alpha);
            }
        }

        static void TestCharLoop()
        {
            string Message = "Should indexes start at 0 or 1 ? The compromise of 0.5 was rejected without proper consideration.";
            CharLoop(Message);
        }

        static void Countdown(int T)
        {
            Console.WriteLine("T minus {0} to liftoff", T);
            for (int Cd = T - 1; Cd > -1; Cd--)
            {
                Console.WriteLine(Cd);
            }
        }




        /* MAKE  */

        static string GetPassword(string Message)
        {
            //initialize string that will be returned by the function containing the password
            string Password = "Password is: ";

            //loop thru every character in the message and add its index to the password if the content is a vowel
            for (int index = 0; index < Message.Length; index++)
            {
                string Content = Message.Substring(index, 1);
                if (Content == "a" || Content == "e" || Content == "i" || Content == "o" || Content == "u")
                {
                    Password += index;
                }
            }

            //check if last char in the string is a space if so the message didn't have vowels and return error
            if (Password.Substring(Password.Length-1, 1) == " ")
            {
                Password = "Error! No vowels found in message!";
            }

            return Password;
            

        }

        static void TestGetPassword(string Message)
        {
            Console.WriteLine(GetPassword(Message));
        }


        // returns True if the number of ones is odd and False if the number of ones is even.
        static bool OddParity(string Sequence)
        {
            //keep track of number of ones in the sequence
            int onecounter = 0;
            for (int index=0; index<Sequence.Length; index++)
            {
                string Content = Sequence.Substring(index, 1);
                // check if sequence is accettable
                if (Content != "0" && Content != "1")
                {
                    Console.WriteLine("Sequence must be made of only 1 and 0.");
                    return false;
                }

                //check is content of index is a one and add it to the counter
                if (Content == "1")
                {
                    onecounter++;
                }             
            }

            if ((onecounter % 2) == 1)
                return true;

            else
                return false;
        }

        static void TestOddParity(string Sequence)
        {
            Console.WriteLine(OddParity(Sequence));
        }

        //returns True if the number is a prime number and False if it is not a prime number.
        static bool isPrime(double Number)
        {
            //check for every int between 2 and the half of the input
            for (int index=2; index < Math.Ceiling(Number/2) ; index++)
            {
                //debug
                //Console.WriteLine("{0} divided by {1}", Number, index);

                //check if number is divisible
                if ((Number % index)==0)
                {
                    return false;
                }
            }

            return true;
        }


        static void TestIsPrime(int Number)
        {
            Console.WriteLine(isPrime(Number));
        }


        //Main program
        static void Main(string[] args)
        {
            //TestOutputMessage();
            //DemoLoop();
            //TestCharLoop();
            //Countdown(10);


            //TestGetPassword("pennone");
            //TestOddParity("10001000141");
            //TestIsPrime(2017);

            Console.ReadLine();
        }
    }

}
