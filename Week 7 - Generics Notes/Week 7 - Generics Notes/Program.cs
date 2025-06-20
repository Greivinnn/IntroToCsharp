// See https://aka.ms/new-console-template for more information

using Week_7___Generics_Notes;

//Stacks<int> myStack = new Stacks<int>();

//myStack.PrintNumber(845);

Box<int> intBox = new Box<int>();
intBox.Pack(52);
intBox.Unpack();

Box<string> stringBox = new Box<string>();
stringBox.Pack("Alfredo");
stringBox.Unpack();

MultipleGenerics<string, string> Pair = new MultipleGenerics<string, string>("1,000,000", "Beers");
Pair.Show();