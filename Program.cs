using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean PlayGame = true;
            Console.WriteLine("Are You Ready to Play Rock Paper Scissors Against the Computer? Enter: (Y/N)");
            var answerYN = Console.ReadLine();

            while (PlayGame)
            {
                //Check to see if user wants to play
                if (answerYN != "Y" && answerYN != "N")
                {
                    Console.WriteLine("Oops! Please Enter a valid answer: (Y/N)");
                    answerYN = Console.ReadLine();
                }

                //start the game
                if(answerYN == "Y")
                {
                    var Game1 = new GameLogic();

                    Console.WriteLine("What is your name?");
                    Game1.SetPlayerName(Console.ReadLine());

                    Console.WriteLine($"Lets begin {Game1.GetPlayerName()}, Enter the number of rounds you would like to play");
                    Game1.SetValidRounds(Console.ReadLine());
                    Console.WriteLine($"The number of rounds chosen is: {Game1.GetRounds()}");

                    //start the rounds
                    for(var i = 1; i<=Game1.GetRounds(); i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"**** ROUND {i} ****");
                        Console.WriteLine($"SCORE: {Game1.GetPlayerName()}: {Game1.GetHumanScore()} Computer: {Game1.GetCPUScore()}");
                        Console.WriteLine("Enter 1-3, 1 = Rock, 2 = Paper, 3 = Scissors");
                        Game1.SetHumanPick(Console.ReadLine());
                        Game1.SetCPUPick();
                        
                        while(Game1.GetCPUPick() == Game1.GetHumanPick())
                        {
                            Console.WriteLine();
                            Console.WriteLine("**** Result: Tie! ****");
                            Console.WriteLine("Enter 1-3, 1 = Rock, 2 = Paper, 3 = Scissors");
                            Game1.SetHumanPick(Console.ReadLine());
                            Game1.SetCPUPick();
                        }

                        Game1.DetermineRoundWinner();

                        //Check to see if the game is over, if so output the winner
                        if( (Game1.GetHumanScore() * 2) == (Game1.GetRounds() + 1) || (Game1.GetCPUScore() * 2) == (Game1.GetRounds() + 1) ) 
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Game1.DetermineWinner();
                            Console.WriteLine();
                            Console.WriteLine();
                            break;
                        }
                    }

                    Console.WriteLine("Play Again? Y/N");
                    answerYN = Console.ReadLine();

                }

                //end the program
                if(answerYN == "N")
                {
                    PlayGame = false;
                }
            }
        }
    }
}
