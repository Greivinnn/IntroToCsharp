// See https://aka.ms/new-console-template for more information

// #1 Add 100 to a list of intergers
using System.Runtime.ConstrainedExecution;
using System.Text;

void Add100 (List<int> numList)
{
    for (int i = 0;  i < numList.Count; i++)
    {
        numList[i] = numList[i] + 100;
    }
    foreach(int num in numList)
    {
        Console.WriteLine(num);
    }
}

List<int> numList = new List<int>() { 1, 2, 3, 4, 5, 6 };
Console.WriteLine("Original List:");
foreach (int num in numList)
{
    Console.WriteLine(num);
}
Console.WriteLine("\nAfter using Add100 function:");
Add100(numList);

// #2 Capitalize everything inside the string list

//void CapitalizeFunction(List<string> listInput)
//{
//    StringBuilder sb = new StringBuilder();

//    for (int i = 0; i < listInput.Count; i++)
//    {
//        sb.
//    }
//}

// #3 Convert military time to normal time (am/pm)
void ConvertTime(int time)
{
    if (time >= 0 && time <= 11)
    {
        if (time == 0)
        {
            Console.WriteLine("The regular time is: " + (time + 12) + " am");
            return;
        }
        Console.WriteLine("The regular time is: " + time + " am");
    }
    else if (time >= 12 && time <= 23)
    {
        if (time > 12)
        {
            Console.WriteLine("The regular time is: " + (time - 12) + " pm");
            return;
        }
        Console.WriteLine("The regular time is: " + time + " pm");
    }
    else
    {
        Console.WriteLine("Invalid, out of range 0-23");
    }
}

Console.Write("Enter military time (0 to 23): ");
int time = Convert.ToInt32(Console.ReadLine());
ConvertTime(time);