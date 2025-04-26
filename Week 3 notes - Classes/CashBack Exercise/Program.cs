// See https://aka.ms/new-console-template for more information

using CashBack_Exercise;

CreditCard card1 = new CreditCard("Alice", 1.5f);
CreditCard card2 = new CreditCard("Bob", 2.0f);
CreditCard card3 = new CreditCard("Charlie", 1.0f);

card1.CalculateCashback(1000);
card2.CalculateCashback(1000);
card3.CalculateCashback(1000);
card1.CardHolderName = "Alice Smith"; // Update the card holder name