// See https://aka.ms/new-console-template for more information

//Question 1 - Rectangle 

using Question_1;

Rectangle recta1 = new Rectangle(5, 6);
Rectangle recta2 = new Rectangle(10, 10);
Rectangle recta3 = new Rectangle(9, 4);

Console.WriteLine("Rectangle 1:");
Console.WriteLine(recta1.GetPerimeter());
recta1.RectangleLenght = 12;
recta1.RectangleWidth = 12;
Console.WriteLine(recta1.GetPerimeter());
Console.WriteLine(recta1.GetArea());

Console.WriteLine("\nRectangle 2:");
Console.WriteLine(recta2.GetPerimeter());
recta2.ChangeSize(5, 5);
Console.WriteLine(recta2.GetPerimeter());
Console.WriteLine(recta2.GetArea());

Console.WriteLine("\nRectangle 3:");
Console.WriteLine(recta3.GetPerimeter());
recta2.ChangeSize(-100, 5);
Console.WriteLine(recta3.GetPerimeter());
Console.WriteLine(recta3.GetArea());
