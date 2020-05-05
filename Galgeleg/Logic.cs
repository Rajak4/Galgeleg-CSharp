﻿using System;
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
            wordToGuess = wordList[random.Next(wordList.Count)].ToString();
            showVisibleWord();
        }

        private void showVisibleWord()
        {
            visibleWord = "";
            for(int i = 0; i < wordToGuess.Length; i++)
            {
                String letter = wordToGuess.Substring(i, ++i); //Måske bugger ++i
                if (usedLetters.Contains(letter))
                {
                    visibleWord += letter;
                } else
                {
                    visibleWord += "*";
                }
            }
        }

    }
}
