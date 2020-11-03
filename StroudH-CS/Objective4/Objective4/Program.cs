using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        // Subroutine to concat name
        static string FullName(string String1, string String2)
        {
            return String1.ToUpper() + " " + String2.ToUpper();
        }

        static void TestName()
        {
            string Forename = "John";
            string Surname = "Smith";
            string Student = FullName(Forename, Surname);
            Console.WriteLine("Full name: {0}", Student);
        }

        static void ShowLen(string Surname)
        {
            int StringLength = Surname.Length;
            Console.WriteLine("There are {0} letters in your surname, {1}.", StringLength, Surname);
        }

        static void TestLen()
        {
            string Surname = "Smith";
            ShowLen(Surname);

        }

        // Subroutine to process a phrase
        static void Output(string Phrase)
        {
            Console.WriteLine(Phrase.Substring(20, 6));
        }

        static void TestOutput()
        {
            string Phrase = "I saw a wolf in the forest. A lonely wolf.";
            Output(Phrase);

        }

        /*
        // Subroutine to process a phrase
        static (int, int)  Find(string Phrase, string Word)
        {
            int Start = Phrase.IndexOf(Word);
            int End = Start + Word.Length - 1;
            return (Start, End);
        }

        static void TestFind()
        {
            string Phrase = "Code never lies; comments sometimes do. - Ron Jeffries";
            string Word = "comments";
            (int Start, int End) = Find(Phrase, Word);
            Console.WriteLine("'{0}' can be found between characters {1} and {2} in '{3}'.", Word, Start, End, Phrase);

        }
        
        */


        static string Replace(string S1, string S2, string S3)
        {
            int S = S1.IndexOf(S2);
            int E = S + S2.Length;
            string NewString = S1.Substring(0, S);
            NewString += S3;
            NewString += S1.Substring(E, S1.Length - E);
            return NewString;
        }

        static void TestReplace()
        {
            string Phrase = "Strings are the root of physics.";
            string Word1 = "are";
            string Word2 = "may be";
            Console.WriteLine(Replace(Phrase, Word1, Word2));

        }


        //MAKE

        //Split name
        // if second parameter is 0 it return the name if its 1 return surname
        static string SplitName(string FullName, int num)
        {
            int space = FullName.IndexOf(" ");
            if (num == 0)
            {
                string NewString = FullName.Substring(0, space);
                return NewString;
            }
            if (num == 1)
            {
                string NewString = FullName.Substring(space + 1);
                return NewString;
            }
            else
            {
                string NewString = "ERROR!";
                return NewString;
            }


        }


        static void TestSplitName(string FullName)
        {
            Console.WriteLine(SplitName(FullName, 0));
            Console.WriteLine(SplitName(FullName, 1));
        }



        //Naming Convention
        static string GetIdentifier(string part1, string part2, string convention)
        {
            if (convention == "pascalcase")
            {
                part1 = part1.ToUpper().Substring(0, 1) + part1.ToLower().Substring(1);
                part2 = part2.ToUpper().Substring(0, 1) + part2.ToLower().Substring(1);
                return part1 + part2;

            }

            if (convention == "camelcase")
            {
                part1 = part1.ToLower();
                part2 = part2.ToUpper().Substring(0, 1) + part2.ToLower().Substring(1);
                return part1 + part2;

            }

            if (convention == "kebabcase")
            {
                part1 = part1.ToLower();
                part2 = part2.ToLower();
                return part1 + "-" + part2;

            }

            if (convention == "snakecase")
            {
                part1 = part1.ToLower();
                part2 = part2.ToLower();
                return part1 + "_" + part2;
            }

            else
            {
                return "ERROR!";
            }


        }

        static void TestIdentifier(string part1, string part2, string convention)
        {
            Console.WriteLine(GetIdentifier(part1, part2, convention));
        }


        static (int, int) LetterToCode(string Letter)
        {
            if (Letter == "A")
            {
                return (65, 193);
            }

            if (Letter == "B")
            {
                return (66, 194);
            }

            if (Letter == "C")
            {
                return (67, 195);
            }

            if (Letter == "D")
            {
                return (68, 196);
            }

            if (Letter == "E")
            {
                return (69, 197);
            }

            if (Letter == "F")
            {
                return (70, 198);
            }

            if (Letter == "G")
            {
                return (71, 199);
            }

            if (Letter == "H")
            {
                return (72, 200);
            }

            if (Letter == "I")
            {
                return (73, 201);
            }

            if (Letter == "J")
            {
                return (74, 209);
            }

            if (Letter == "K")
            {
                return (75, 210);
            }

            if (Letter == "L")
            {
                return (76, 211);
            }

            if (Letter == "M")
            {
                return (77, 212);
            }

            if (Letter == "N")
            {
                return (78, 213);
            }

            if (Letter == "O")
            {
                return (79, 214);
            }

            if (Letter == "P")
            {
                return (80, 215);
            }

            if (Letter == "Q")
            {
                return (81, 216);
            }

            if (Letter == "R")
            {
                return (82, 217);
            }

            if (Letter == "S")
            {
                return (83, 226);
            }

            if (Letter == "T")
            {
                return (84, 227);
            }

            if (Letter == "U")
            {
                return (85, 228);
            }

            if (Letter == "V")
            {
                return (86, 229);
            }

            if (Letter == "W")
            {
                return (87, 230);
            }

            if (Letter == "X")
            {
                return (88, 231);
            }

            if (Letter == "Y")
            {
                return (89, 232);
            }

            if (Letter == "Z")
            {
                return (90, 233);
            }

            if (Letter == " ")
            {
                return (32, 64);
            }

            else
            {
                return (-1, -1);
            }
        }

        static void TestConvertLetter(string Letter)
        {
            int ascii, ebcdic;
            (ascii, ebcdic) = LetterToCode(Letter);
            Console.WriteLine("Your character in ascii is {0}. \nYour character in ebcdic is {1}.", ascii, ebcdic);

        }


        //Main program
        static void Main(string[] args)
        {
            //TestName();

            //TestLen();

            //TestOutput();

            //TestReplace();

            //TestSplitName("Pennone Introne");

            //TestIdentifier("pennone", "introne", "snakecase");

            TestConvertLetter(" ");

            Console.ReadLine();
        }
    }
}
