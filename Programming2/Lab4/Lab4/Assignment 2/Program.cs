﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Start();
        }

        void Start()
        {
            HangmanGame hangman = new HangmanGame();
            PlayHangman(hangman);
            Console.ReadKey();
        }

        bool PlayHangman(HangmanGame hangman)
        {
            int attempts = 8;

            List<char> enteredLetters = new List<char>();
            List<string> words = ListofWords();
            hangman.Init(SelectWord(words));

            while (!hangman.isGuessed())
            {
                if (attempts == 0)
                {
                    DisplayWords(hangman.secretWord);
                    Console.WriteLine("Game Over! :(");
                    return false;
                }
                DisplayWords(hangman.guessedWord);
                Console.WriteLine();

                if (!hangman.GuessLetter(ReadLetter(enteredLetters)))
                    attempts--;

                DisplayLetters(enteredLetters);
                Console.WriteLine("\nAttempts left : " + attempts + "\n");
            }

            DisplayWords(hangman.secretWord);
            Console.WriteLine("You Guessed The Word!");
            return true;
        }

        void DisplayWords(string word)
        {
            string newword = "";
            for (int i = 0; i < word.Length; i++)
                newword += word[i] + " ";

            Console.WriteLine(newword);
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write("\nEntered Letters : ");

            for (int i = 0; i < letters.Count; i++)
            {
                Console.Write(letters[i] + " ");
            }

        }

        char ReadLetter(List<char> blacklistLetters)
        {
            char letter = ' ';
            Console.Write("Enter a letter : ");
            letter = Console.ReadKey().KeyChar;

            while (blacklistLetters.Contains(letter))
            {
                Console.WriteLine();
                Console.Write("Please enter another letter : ");
                letter = Console.ReadKey().KeyChar;
            }
            blacklistLetters.Add(letter);
            return letter;
        }
        List<string> ListofWords()
        {
            StreamReader reader = new StreamReader("words.txt");
            List<string> words = new List<string>();

            while (!reader.EndOfStream)
            {
                if (reader.ReadLine().Length >= 3)
                    words.Add(reader.ReadLine());
            }

            
            return words;
        }

        string SelectWord(List<string> words)
        {
            string selectedword = "";
            Random rnd = new Random();
            int rndnr = rnd.Next(words.Count);
            selectedword = words[rndnr];
            return selectedword;
        }


    }
}
