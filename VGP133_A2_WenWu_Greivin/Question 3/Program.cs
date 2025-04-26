// See https://aka.ms/new-console-template for more information

//Question 3
using Question_3;

Book book1 = new Book("Juan", "Atomic Habits", "James Clear", "0-7264-1048-9", false);
Book book2 = new Book("Marco", "Diary of a Wimpy Kid", "Jeff Kinney", "0-4307-5877-4", false);
Book book3 = new Book("Alfred", "Gone with the Wind", "Margaret Mitchell", "0-8701-8586-1", false);

// make sure eveything works 
book1.DisplayInfo();
book1.Return();
book1.DisplayInfo();
book1.CheckOut();
book1.DisplayInfo();
Console.WriteLine();

book2.DisplayInfo();
book2.Return();
book2.DisplayInfo();
book2.CheckOut();
book2.DisplayInfo();
Console.WriteLine();

book3.DisplayInfo();
book3.Return();
book3.DisplayInfo();
book3.CheckOut();
book3.DisplayInfo();
Console.WriteLine();