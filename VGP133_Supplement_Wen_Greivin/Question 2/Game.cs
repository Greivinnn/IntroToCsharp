using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    public class Game
    {
        private string[] wordList;
        private Random random;

        public Game()
        {
            wordList = new string[]
            {
                "programming",
                "computer",
                "college",
                "alberta",
                "timmies",
                "school",
                "bottle"
            };
            random = new Random();
        }

        public void Start()
        {
            int randomIndex = random.Next(0, wordList.Length);
            string selectedWord = wordList[randomIndex].ToLower();

            string jumbleWord = JumbleWord(selectedWord);

            Console.WriteLine("Welcome back to yet another game...");
            Console.WriteLine("Your mission now is to solve the word puzzle and find the real meaning of it");
            Console.WriteLine("You get only 1 try this time. Good luck *evil laugh*");

            Console.WriteLine($"Unscramble this word: {jumbleWord}");

            Console.WriteLine("Your answer: ");
            string playerGuess = Console.ReadLine();

            if (playerGuess.ToLower() == selectedWord)
            {
                Console.WriteLine("Congratulations lucky player... YOU WON!!");
            }
            else
            {
                Console.WriteLine("YOU HAVE LOSTTT *EVIL LAUGH*");
                Console.WriteLine("The correct answer was: " + selectedWord);
            }
        }

        private string JumbleWord(string word)
        {
            char[] characters = word.ToCharArray(); // convert word to character array

            for (int i = characters.Length - 1; i > 0; i--) // fisher-yates shuffle algorithm
            {
                int j = random.Next(0, i + 1);

                char temp = characters[i];
                characters[i] = characters[j];
                characters[j] = temp;
            }

            string jumbleWord = new string(characters); // convert the char array back to a string

            if (jumbleWord == word) // if the word is the same after mixing do it again
            {
                return JumbleWord(word);
            }

            return jumbleWord;
        }
    }
}
