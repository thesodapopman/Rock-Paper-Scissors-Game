using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class GameLogic
    {
        public GameLogic()
        {

        }

        public GameLogic(string Name)
        {
            this.Name = Name;
        }

        private int CPUPick;
        private int HumanPick;
        private int rounds;
        private int HumanScore = 0;
        private int CPUScore = 0;
        private string Name;

        public void SetValidRounds(string param)
        {
            //returns a valid whole number
            var PotentialRounds = ValidWholeNumber(param);

            //number of rounds has to be odd 
            while (PotentialRounds % 2 == 0)
            {
                Console.WriteLine("Oops! The number of Rounds needs to be an odd number");
                PotentialRounds = ValidWholeNumber(Console.ReadLine());
            }

            rounds = Convert.ToInt32(PotentialRounds);
        }

        public int ValidWholeNumber (string param)
        {
            //returns a valid whole number
            bool res = false;
            int num1;

            while (res == false)
            {
                res = int.TryParse(param, out num1);
                if (res == false)
                {
                    Console.WriteLine("Oops! Please Enter a whole number");
                    param = Console.ReadLine();
                }
            }
            return Convert.ToInt32(param);
        }

        public int ValidWholeNumber123(string param)
        {
            //returns a valid whole number between 1-3
            var PotentialNumber = ValidWholeNumber(param);

            while(PotentialNumber != 1 && PotentialNumber != 2 && PotentialNumber != 3)
            {
                Console.WriteLine("Oops! Please Enter a number between 1 and 3 for Rock, Paper and Scissors");
                PotentialNumber = ValidWholeNumber(Console.ReadLine());
            }
            return PotentialNumber;
        }
        
        public void DetermineRoundWinner()
        {
            /**** 1 = Rock, 2 = Paper, 3 = Scissors ****
             * Rock beats scissors, loses to paper (1 beats 3, loses to 2)
             * paper beats rock, loses to scissors (2 beats 1, loses to 3)
             * scissors beats papar, loses to rock (3 beats 2, loses to 1)
             * 
            */

            if (HumanPick == 1 && CPUPick == 2)
            {
                //win for computer
                CPUScore++;
                Console.WriteLine($"**** Result: Win for Computer! {ConvertToRPS(CPUPick)} beats {ConvertToRPS(HumanPick)} ****");
                
            }
            else if(HumanPick == 1 && CPUPick == 3)
            {
                //win for human
                HumanScore++;
                Console.WriteLine($"**** Result: Win for {Name}! {ConvertToRPS(HumanPick)} beats {ConvertToRPS(CPUPick)} ****");
            }
            else if(HumanPick == 2 && CPUPick == 1)
            {
                //win for human
                HumanScore++;
                Console.WriteLine($"**** Result: Win for {Name}! {ConvertToRPS(HumanPick)} beats {ConvertToRPS(CPUPick)} ****");
            }
            else if(HumanPick == 2 && CPUPick == 3)
            {
                //win for computer
                CPUScore++;
                Console.WriteLine($"**** Result: Win for Computer! {ConvertToRPS(CPUPick)} beats {ConvertToRPS(HumanPick)} ****");
            }
            else if(HumanPick == 3 && CPUPick == 2)
            {
                //win for human
                HumanScore++;
                Console.WriteLine($"**** Result: Win for {Name}! {ConvertToRPS(HumanPick)} beats {ConvertToRPS(CPUPick)} ****");
            }
            else
            {
                //HumanPick == 3 && CPUPick == 1
                //win for computer
                CPUScore++;
                Console.WriteLine($"**** Result: Win for Computer! {ConvertToRPS(CPUPick)} beats {ConvertToRPS(HumanPick)} ****");
            }
        }
        
        private string ConvertToRPS(int param)
        {
            //convert int 1-3 into actual string values
            if (param == 1)
            {
                return "Rock";
            }
            else if (param == 2)
            {
                return "Paper";
            }
            else
                return "Scissors";
        }

        public void DetermineWinner()
        {
            if(HumanScore > CPUScore)
            {
                Console.WriteLine($"**** FINAL SCORE: {Name}: {HumanScore} Computer: {CPUScore} ****");
                Console.WriteLine($"**** Congratulations! {Name}, You Won! ****");
            }
            else
            {
                Console.WriteLine($"**** FINAL SCORE: {Name}: {HumanScore} Computer: {CPUScore} ****");
                Console.WriteLine($"**** Darnit! The Computer Beat You! {Name}****");
            }
        }

        public void SetCPUPick()
        {
            Random rand = new Random();
            CPUPick = rand.Next(1, 4);
        }

        public int GetCPUPick()
        {
            return CPUPick;
        }

        public void SetHumanPick(string HumanPick)
        {
            this.HumanPick = ValidWholeNumber123(HumanPick);
        }

        public int GetHumanPick()
        {
            return HumanPick;
        }

        public void SetPlayerName(string Name)
        {
            this.Name = Name;
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public int GetRounds()
        {
            return rounds;
        }

        public int GetCPUScore()
        {
            return CPUScore;
        }

        public int GetHumanScore()
        {
            return HumanScore;
        }


    }
}
