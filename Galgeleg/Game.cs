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

            Logic logic = new Logic();
            logic.resetGame();
            logic.NumLives = 5;
            logic.submitLetter("o");
            logic.submitLetter("a");
            logic.submitLetter("e");
            logic.submitLetter("j");
            logic.submitLetter("a");
            logic.submitLetter("k");
            logic.submitLetter("c");
            logic.submitLetter("C");
            logic.submitLetter("u");



        }
            
    }
}
