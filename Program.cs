using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        // variables
        bool continueGame = true;
        int generatedNum;
        int gameNum = 0;
        bool[] winLoss = new bool[10];
        int wins = 0;
        double feedback;

        Console.WriteLine("N U M B E R  G U E S S E R\n"
                        + "   Maximum games: 10\n");

        //this is the main game loop, will execute as long as player wished and as long as amount of played games was 10 or 
        while(continueGame==true && gameNum <9){
            //print
            Console.WriteLine("  Pick Your Difficulty\n"
                    + "--------------------------\n"
                    + "1 for Easy\n"
                    + "2 for Medium\n"
                    + "3 for Hard\n"
                    + "4 for Nightmare\n"
                    + "--------------------------");
            
            Console.Write("Choice: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nGame Number " + (gameNum + 1) + "\n");

            // this will read the input and see if it is valid
            if (n>=1 && n<=4){
                Console.Write("Generating a number ");
                int i=0;
                //this while is for aesthetic purposes, will use sleep() method to generate a delay before each dot in ". . ."
                while (i < 3){ //this is going to cause slower execution, might have to remove it
                        Thread.Sleep(500);
                        Console.Write(". ");
                        Thread.Sleep(500);
                        i++;
                    }
                
                Console.WriteLine("\n");
                generatedNum = numberGen(n);
                Console.WriteLine("Generated num: " + generatedNum);
                int guessInput  = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                
                //this if else chain will set the array value of the game turn to true if the guess was correct
                if(guessInput == generatedNum){
                    Console.WriteLine("-------------------");
                    Console.WriteLine("| You're correct! |");
                    Console.WriteLine("-------------------\n");
                    wins++;
                    winLoss[gameNum] = true; //will set the array to true (its default is false)
                }
                else{
                    Console.WriteLine("-------------------");
                    Console.WriteLine("|     Try again!  |\n"
                            +          "| The number was " + generatedNum);
                    Console.WriteLine("-------------------\n");
                }
                
                Console.WriteLine("Wins: " + wins + " -- Games: " + (gameNum + 1));
                gameNum++;
                
                Console.WriteLine("Continue? (type 1 to continue, anything else to stop)");
                string continueGameRaw = Console.ReadLine();
                //sets continueGame according to continueGameRaw
                if (continueGameRaw != "1"){
                    continueGame = false;
                }

                Console.WriteLine("");
            }//end game round (if)
        }//end game (while)


        wins = 0;
        //this will count how many games you won
        for (int i = 0; i < gameNum; i++){
            if (winLoss[i] == true){
                wins++;
            }
        }
        
        //this will show results and give feedback
        Console.WriteLine("You played " + gameNum + " out of 10 games.\n"
                + "You won " + wins + " out of " + gameNum + " played games.");
        
        bool noWins = false;
        if (wins == 0){
            wins = 1;
            noWins = true;
        }
        
        feedback = ((double)gameNum)/((double)wins);
        Console.WriteLine(feedback); //debug command
        if(noWins)
            Console.WriteLine("Try leveling up your Luck stat!");
        else if(feedback == 1.0)
            Console.WriteLine("Very good job! You did perfect!");

        else if (feedback <= 2){
            Console.WriteLine("Good job!");
        }
        else if (feedback < gameNum){
            Console.WriteLine("You can do better next time!");
        }
        else if (feedback == gameNum){
            Console.WriteLine("Try leveling up your Luck stat!");       
        }
    }//end of main

    public static int numberGen(int n){
        Random rand = new Random();
        int numberGen;
        switch (n) {
            case 1:
                //easy
                numberGen = rand.Next(1, 6);
                Console.Write("Pick a number between 1 and 5: ");
                break;
            case 2:
                //medium
                numberGen = rand.Next(1, 11);
                Console.Write("Pick a number between 1 and 10: ");
                break;
            case 3:
                //hard
                numberGen = rand.Next(1, 21); //between 1 and 20
                Console.Write("Pick a number between 1 and 20: ");
                break;
            default:
                //nightmare
                numberGen = rand.Next(1, 101);  //adding a hint system would be nice, if its even/odd, prime, divisible by a set of given numbers
                Console.Write("Pick a number between 1 and 100: ");
                break;
        }
        Console.WriteLine("generated number:" + numberGen); //debug command
        return numberGen;
    }
}