using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgeleg
{
    class Game
    {

        public void Test() {

            // test to win game
            Logic logic = new Logic();
            string testWord = "testWord";
            logic.ResetGame(testWord);
            logic.NumLives = 5;
            
            foreach(char c in testWord)
            {
                logic.SubmitLetter(c.ToString());
            }
            Console.WriteLine($"Game is won: {logic.GameIsWon}");
        }
            
    }
}
