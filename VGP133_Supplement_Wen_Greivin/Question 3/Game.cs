using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_3
{
    public class Game
    {
        private string[] wordList;
        private Random random;
        private int maxAttempts = 8;

        public Game()
        {
            wordList = new string[]
            {
                "lantern",
                "whisper",
                "glacier",
                "vancouver",
                "orbit",
                "puddle",
                "anchor"
            };
            random = new Random();
        }
        public void Start()
        {
            int randomIndex = random.Next(0, wordList.Length);
            string selectedWord = wordList[randomIndex].ToLower();
            char[] guessedLetters = new char[selectedWord.Length];
            List<char> incorrectGuesses = new List<char>();
            int attempts = 0;
            bool gameWon = false;

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            Console.WriteLine("YOU AGAIN! You like me or what?");
            Console.WriteLine("ANYWAYS, here is the next game...");
            Console.WriteLine("Ever heard of hangman? SAVE THIS GUY BEFORE I CHOP HIS HEAD OFF");

            while (attempts < maxAttempts && !gameWon)
            {
                DisplayHangman(attempts);

                Console.WriteLine($"Attempts remaining: {maxAttempts - attempts}");

                if (incorrectGuesses.Count > 0)
                {
                    Console.WriteLine($"Incorrect guesses: {incorrectGuesses.Count}");
                }

                Console.WriteLine();
                for (int i = 0; i < guessedLetters.Length; i++)
                {
                    Console.Write($" {guessedLetters[i]} ");
                }

                Console.WriteLine("\nYour Guess: ");
                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0])) // handle any type of scenario, number inout, word input, special case...
                {
                    Console.WriteLine("INVALID INPUT! Enter a single letter please!");
                    continue;
                }

                char guess = input[0];

                if (guessedLetters.Contains(guess) || incorrectGuesses.Contains(guess)) // check if already guessed before
                {
                    Console.WriteLine($"You've already guessed '{guess}'. Try another letter!");
                    continue;
                }

                bool correctGuess = false;
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (selectedWord[i] == guess)
                    {
                        guessedLetters[i] = guess;
                        correctGuess = true;
                    }
                }

                if (correctGuess)
                {
                    Console.WriteLine("WOW GOOD JOB, That letter is in the word!");

                    if (!guessedLetters.Contains('_'))
                    {
                        gameWon = true;
                    }
                }
                else
                {
                    Console.WriteLine("WRONG! That letter is not in the word!");
                    incorrectGuesses.Add(guess);
                    attempts++;
                }
                Console.WriteLine();
            }

            DisplayHangman(attempts);

            Console.WriteLine();
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                Console.Write($" {guessedLetters[i]} ");
            }
            Console.WriteLine();

            if (gameWon)
            {
                Console.WriteLine($"CONGRATULATIONS! You saved whoever this guy is! The word was: {selectedWord}");
            }
            else
            {
                Console.WriteLine($"GAME OVER! This poor guy is DEAD because of YOUU! The word was: {selectedWord}");
            }
        }
        private void DisplayHangman(int attempts)
        {
            Console.WriteLine("=============================");

            switch (attempts)
            {
                case 0:
                    Console.WriteLine("         ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    break;
                case 1:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    break;
                case 2:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    break;
                case 3:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |    O  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    break;
                case 4:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |    O  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    break;
                case 5:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |    O  ");
                    Console.WriteLine(" |   /|  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    break;
                case 6:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |    O  ");
                    Console.WriteLine(" |   /|\\ ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    break;
                case 7:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |    O  ");
                    Console.WriteLine(" |   /|\\ ");
                    Console.WriteLine(" |   /   ");
                    Console.WriteLine(" |       ");
                    break;
                case 8:
                    Console.WriteLine(" ______  ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |    O  ");
                    Console.WriteLine(" |   /|\\ ");
                    Console.WriteLine(" |   / \\ ");
                    Console.WriteLine(" |       ");
                    break;
            }

            Console.WriteLine("=============================");
        }
    }
}
