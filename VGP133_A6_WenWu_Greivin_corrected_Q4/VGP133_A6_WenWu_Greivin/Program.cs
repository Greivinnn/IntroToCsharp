// See https://aka.ms/new-console-template for more information

using Question_1;

Console.WriteLine("Question 1\n");

Console.WriteLine("Swapping numbers");
Swap<int> swapInt = new Swap<int>();
int num1 = 100;
int num2 = 500;
swapInt.SwapAndPrint(ref num1, ref num2);

Console.WriteLine();

Console.WriteLine("Swapping strings");
Swap<string> swapString = new Swap<string>();
string name1 = "Charles";
string name2 = "Greivin";
swapString.SwapAndPrint(ref name1, ref name2);

