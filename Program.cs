namespace DiceRollerLab
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string comboMessage = "";
            string totalMessage = "";

            bool playAgain = true;

            while (playAgain)
            {
                int sides = GetNumberOfSides();
                int roll1 = RollDice(sides);
                int roll2 = RollDice(sides);
                int total = roll1 + roll2;

                Console.WriteLine($"You rolled a {roll1} and a {roll2} for a total of {total}");

                comboMessage = CheckCombo(roll1, roll2, sides);
                if (!string.IsNullOrEmpty(comboMessage))
                {
                    Console.WriteLine(comboMessage);
                }
                else
                {
                    totalMessage = CheckTotal(total, sides);
                    if (!string.IsNullOrEmpty(totalMessage))
                    {
                        Console.WriteLine(totalMessage);
                    }
                }

                playAgain = AskToRollAgain();
            }

        }

        public static int GetNumberOfSides()
        {
            int sides = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter the number of sides for the dice: ");
                if (int.TryParse(Console.ReadLine(), out sides) && sides > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number greater than 0.");
                }
            }
            return sides;
        }

        public static int RollDice(int sides)
        {
            Random random = new Random();
            return random.Next(1, sides + 1);
        }

        public static string CheckCombo(int roll1, int roll2, int sides)
        {
            if (sides == 6 )
            { 
                if (roll1 == 1 && roll2 == 1)
                {
                    return "Snake Eyes!";
                }
                else if (roll1 == 1 && roll2 == 2)
                {
                    return "Ace Deuce!";
                }
                else if (roll1 == 6 && roll2 == 6)
                {
                    return "Box Cars!";
                }
            }
            else if (sides == 10)
            {
                if (roll1 == 10 && roll2 == 10)
                {
                    return "You hit the max!";
                }
                else if ((roll1 <= 9 && roll2 <= 9) && (roll1 >= 4 && roll2 >=4))
                {
                    return "Not a bad roll";
                }
                else if (roll1 < 4 && roll2 < 4)
                {
                    return "Ouch! That's some bad luck!";
                }
            }
            //returning null so C# is happy
            return "";
        }

        public static string CheckTotal(int total, int sides)
        {
            if (sides == 6)
            {
                if (total == 7 || total == 11)
                {
                    return "You Win!";
                }
                else if (total == 2 || total == 3 || total == 12)
                {
                    return "Craps!";
                }
                
            }else if (sides == 10)
            {
                if (total == 20)
                {
                    return "You rolled a twenty! Congrats!";
                }
                else if(total == 2)
                {
                    return "That's some crap luck mate";
                }
            }
            //returning null so C# is happy
            return "";
        }

        public static bool AskToRollAgain()
        {
            string input;

            Console.Write("Roll again? (yes/no): ");
            input = Console.ReadLine().Trim().ToLower();

            try
            {
                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    throw new Exception("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return AskToRollAgain(); //Recursive call to retry input
            }
        }
    }
}