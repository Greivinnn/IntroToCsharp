// See https://aka.ms/new-console-template for more information

using Question_2;

Console.WriteLine("Question 2\n");

Console.WriteLine("Queue of intergers");
MyQueue<int> listOfInts = new MyQueue<int>();
listOfInts.Enqueue(1);
listOfInts.Enqueue(2);
listOfInts.Enqueue(3);
listOfInts.Enqueue(4);
listOfInts.Enqueue(5);
listOfInts.PrintList();
listOfInts.Dequeue();
listOfInts.PrintList();

Console.WriteLine();

Console.WriteLine("Queue of strings:");
MyQueue<string> listOfStrings = new MyQueue<string>();
listOfStrings.Enqueue("Greivin");
listOfStrings.Enqueue("Marco");
listOfStrings.Enqueue("Alfred");
listOfStrings.Enqueue("Juan");
listOfStrings.Enqueue("NotME");
listOfStrings.PrintList();
listOfStrings.Dequeue();
listOfStrings.PrintList();
