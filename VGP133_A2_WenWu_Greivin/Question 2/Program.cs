// See https://aka.ms/new-console-template for more information

// Question 2
using Question_2;

Employee employee1 = new Employee("Carlos", 22, "Carlos@gmail.com");
Employee employee2 = new Employee("Alfred", 36, "FriesYum@lcv.com");
Employee employee3 = new Employee("Juan", 19, "Juan@lcv.com");

employee1.DisplayInfo();
employee1.CheckValidEmail();
Console.WriteLine();

employee2.DisplayInfo();
employee2.CheckValidEmail();
Console.WriteLine();

employee3.DisplayInfo();
employee3.CheckValidEmail();
Console.WriteLine();


