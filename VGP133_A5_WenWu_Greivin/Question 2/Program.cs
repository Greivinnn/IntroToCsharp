// See https://aka.ms/new-console-template for more information

using Question_2;

string dir = System.AppDomain.CurrentDomain.BaseDirectory;
string file = dir + "Employee.txt";

if (!File.Exists(file))
{
    Console.WriteLine("File doest exist");
}

List<Employee> employees = new List<Employee>();

try
{
    using (StreamReader reader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read)))
    {
        while (!reader.EndOfStream)
        {
            string name = reader.ReadLine();
            int age = int.Parse(reader.ReadLine());
            float salary = float.Parse(reader.ReadLine());
            string email = reader.ReadLine();

            Employee employee = new Employee
            {
                Name = name,
                Age = age,
                Salary = salary,
                Email = email
            };
            employees.Add(employee);
        }
    }
    foreach(var employee in employees)
    {
        employee.PrintInfo();
        Console.WriteLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occured: {ex.Message}");
}
