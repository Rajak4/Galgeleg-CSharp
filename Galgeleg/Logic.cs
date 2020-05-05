using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgeleg
{
    class Logic
    {
        private String wordToGuess;
        private ArrayList wordList = new ArrayList();
        private ArrayList usedLetters = new ArrayList();
        private int numWrongLetters = 0;
        private bool lastGuessCorrect;
        private bool gameIsWon;
        private bool gameIsLost;
        private String visibleWord;
        private int numLives; // Skal lige sættes et sted


        public Logic()
        {
            wordList.Add("Hej");
            wordList.Add("Java");
            wordList.Add("C");
            wordList.Add("Python");
            wordList.Add("csharp");
            wordList.Add("Ruby");
            wordList.Add("Fortan");
            wordList.Add("HTML");
        }

        public int NumLives
        {
            get { return numLives; }
            set { numLives = value; }
        }

        public String VisibleWord
        {
            get { return visibleWord; }
            set { visibleWord = value; }
        }

        public String WordToGuess 
        {
            get { return wordToGuess; }
            set { wordToGuess = value; }
        }
        public ArrayList WordList
        {
            get { return wordList; }
            set { wordList = value; }
        }
        public ArrayList UsedLetters
        {
            get { return usedLetters; }
            set { usedLetters = value; }
        }
        public int NumWrongLetters
        {
            get { return numWrongLetters; }
            set { numWrongLetters = value; }
        }
        public bool LastGuessCorrect
        {
            get { return lastGuessCorrect; }
            set { lastGuessCorrect = value; }
        }
        public bool GameIsWon
        {
            get { return gameIsWon; }
            set { gameIsWon = value; }
        }
        public bool GameIsLost
        {
            get { return gameIsLost; }
            set { gameIsLost = value; }
        }



        public void resetGame() 
        {
            Random random = new Random();
            usedLetters.Clear();
            numWrongLetters = 0;
            gameIsLost = false;
            gameIsWon = false;

            if(wordList.Count == 0)
            {
                throw new Exception("Word list is empty");
            }
            wordToGuess = wordList[random.Next(wordList.Count)].ToString().ToUpper();
            Console.WriteLine($"Ordet du skal gætte er: {wordToGuess}");
            showVisibleWord();
        }

        private void showVisibleWord()
        {
            visibleWord = "";
            gameIsWon = true;
            foreach(char letter in wordToGuess)
            {
                
                Console.WriteLine("Letter er :" + letter);
              
                if (usedLetters.Contains(letter.ToString()))
                {
                    visibleWord += letter;
                } else
                {
                    visibleWord += "*";
                    gameIsWon = false;
                }
            }
        }
        public void submitLetter(string letter)
        {
            letter = letter.ToUpper();
            Console.WriteLine($"You guessed: {letter}");
            if (usedLetters.Contains(letter)) return; // Letter has already been used
            if (gameIsLost || gameIsWon) return;

            usedLetters.Add(letter);

            if (wordToGuess.Contains(letter))
            {
                lastGuessCorrect = true;
                Console.WriteLine($"Guess was correct: {letter}");
            } else
            {
                lastGuessCorrect = false;
                Console.WriteLine($"Guess was not correct: {letter}");
                numWrongLetters++;
                if(numWrongLetters > numLives)
                {
                    gameIsLost = true;
                }
            }
            showVisibleWord();
            logStatus();
        }
        public void logStatus()
        {
            Console.WriteLine("---------- ");
            Console.WriteLine("- ordet (skjult) = " + wordToGuess);
            Console.WriteLine("- synligtOrd = " + visibleWord);
            Console.WriteLine("- forkerteBogstaver = " + numWrongLetters + "\n");
            foreach(string s in usedLetters)
            {
                Console.Write(s + " ");
            }
            
            if (gameIsLost) Console.WriteLine("- SPILLET ER TABT");
            if (gameIsWon) Console.WriteLine("- SPILLET ER VUNDET");
            Console.WriteLine("\n---------- ");
        }

    }
}
