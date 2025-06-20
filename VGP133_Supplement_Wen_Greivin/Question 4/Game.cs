using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Question_4
{
    public class Game
    {
        private List<Card> _deck;
        private List<Card> _playerHand;
        private List<Card> _dealerHand;

        public Game()   //constructor initialized the deck, shuffles it, and initializes the hand of the player and the dealer
        {
            _deck = CreateDeck();
            ShuffleDeck();
            _playerHand = new List<Card>();
            _dealerHand = new List<Card>();
        }
        public List<Card> CreateDeck()  //creates a 52 card deck for our game
        {
            List<Card> newDeck = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            foreach (string suit in suits)
            {
                for (int value = 1; value <= 13; value++)
                {
                    newDeck.Add(new Card(suit, value));
                }
            }
            return newDeck;
        }
        public void ShuffleDeck()   // shuffle the deck using the fisher-yates shuffle algorithm
        {
            Random shuffle = new Random();
            int n = _deck.Count;

            while (n > 1)
            {
                n--;
                int k = shuffle.Next(n + 1);
                Card temp = _deck[k];
                _deck[k] = _deck[n];
                _deck[n] = temp;
            }
        }
        public Card DealCard()  // deals the top card and removes it immeadietly
        {
            Card card = _deck[0];
            _deck.RemoveAt(0);
            return card;
        }
        private int CalculateHandValue(List<Card> hand) // calculate and returns the total value of a hand, if the value is an ace it automatically sets it to 11 or 1 based on the players hand
        {
            int value = 0;
            int aceCount = 0;

            foreach (Card card in hand)
            {
                if (card._value == 1) // Ace = value 11 or value 10
                {
                    aceCount++;
                    value += 11;
                }
                else if (card._value > 10) // Face card = value 10
                {
                    value += 10;
                }
                else // Number card
                {
                    value += card._value;
                }
            }

            // Adjust for aces if they are going to bust
            while (value > 21 && aceCount > 0)
            {
                value -= 10; // Change an ace from 11 to 1
                aceCount--;
            }

            return value;
        }
        public void DisplayHand(List<Card> hand, string name)   // display hands
        {
            Console.WriteLine($"\n{name}'s hand:");
            foreach (Card card in hand)
            {
                if (card._value == 1)
                {
                    Console.WriteLine($"Ace of {card._suit}");
                }
                else if (card._value == 11)
                {
                    Console.WriteLine($"Jack of {card._suit}");
                }
                else if (card._value == 12)
                {
                    Console.WriteLine($"Queen of {card._suit}");
                }
                else if (card._value == 13)
                {
                    Console.WriteLine($"King of {card._suit}");
                }
                else
                {
                    Console.WriteLine($"{card._value} of {card._suit}");
                }
            }
            Console.WriteLine($"Total: {CalculateHandValue(hand)}");
        }
        public void Start() // game logic and game flow
        {
            _playerHand.Add(DealCard());
            _dealerHand.Add(DealCard());
            _playerHand.Add(DealCard());
            _dealerHand.Add(DealCard());

            DisplayHand(_playerHand, "Alfredo");
            DisplayHand(_dealerHand, "Dealer");

            PlayerTurn();

            if (CalculateHandValue(_playerHand) <= 21)
            {
                DealerTurn();
            }

            DetermineWinner();
        }
        public void PlayerTurn()
        {
            while (true)
            {
                int handValue = CalculateHandValue(_playerHand);

                if (handValue > 21)
                {
                    Console.WriteLine("\nBust! Your hand value exceeds 21.");
                    break;
                }

                Console.WriteLine("\nDo you want to Hit (H) or Stand (S)?");
                string choice = Console.ReadLine().Trim().ToUpper();

                if (choice == "H")
                {
                    Card newCard = DealCard();
                    _playerHand.Add(newCard);
                    if (newCard._value == 1)
                    {
                        Console.WriteLine($"\nYou drew: Ace of {newCard._suit}");
                    }
                    else if (newCard._value == 11)
                    {
                        Console.WriteLine($"\nYou drew: Jack of {newCard._suit}");
                    }
                    else if (newCard._value == 12)
                    {
                        Console.WriteLine($"\nYou drew: Queen of {newCard._suit}");
                    }
                    else if (newCard._value == 13)
                    {
                        Console.WriteLine($"\nYou drew: King of {newCard._suit}");
                    }
                    else
                    {
                        Console.WriteLine($"\nYou drew: {newCard._value} of {newCard._suit}");
                    }
                    DisplayHand(_playerHand, "Player");
                }
                else if (choice == "S")
                {
                    Console.WriteLine("\nYou chose to stand.");
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter H for Hit or S for Stand.");
                }
            }
        }
        public void DealerTurn()
        {
            Console.WriteLine("\nDealer's turn:");

            while (CalculateHandValue(_dealerHand) < 17)
            {
                Card newCard = DealCard();
                _dealerHand.Add(newCard);
                if (newCard._value == 1)
                {
                    Console.WriteLine($"Dealer drew: Ace of {newCard._suit}");
                }
                else if (newCard._value == 11)
                {
                    Console.WriteLine($"Dealer drew: Jack of {newCard._suit}");
                }
                else if (newCard._value == 12)
                {
                    Console.WriteLine($"Dealer drew: Queen of {newCard._suit}");
                }
                else if (newCard._value == 13)
                {
                    Console.WriteLine($"Dealer drew: King of {newCard._suit}");
                }
                else
                {
                    Console.WriteLine($"Dealer drew: {newCard._value} of {newCard._suit}");
                }
                DisplayHand(_dealerHand, "Dealer");
            }

            if (CalculateHandValue(_dealerHand) > 21)
            {
                Console.WriteLine("\nDealer busts!");
            }
            else
            {
                Console.WriteLine("\nDealer stands.");
            }
        }
        public void DetermineWinner()
        {
            int playerValue = CalculateHandValue(_playerHand);
            int dealerValue = CalculateHandValue(_dealerHand);

            Console.WriteLine("\n=== Game Results ===");
            Console.WriteLine($"Your hand value: {playerValue}");
            Console.WriteLine($"Dealer's hand value: {dealerValue}");

            if (playerValue > 21)
            {
                Console.WriteLine("You busted! Dealer wins, you go home sad.");
            }
            else if (dealerValue > 21)
            {
                Console.WriteLine("Dealer busts! You win! YAAAY THE DEALER GOES AWAY SAD");
            }
            else if (playerValue > dealerValue)
            {
                Console.WriteLine("NICEEE! You win, you beat the dealer!");
            }
            else if (dealerValue > playerValue)
            {
                Console.WriteLine("Dealer wins, good luck next time newbie!");
            }
            else
            {
                Console.WriteLine("RING RING RING. It's a tie!");
            }
        }
    }
}
