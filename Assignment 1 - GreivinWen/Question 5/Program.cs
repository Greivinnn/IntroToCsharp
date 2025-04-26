// See https://aka.ms/new-console-template for more information

// Question 5
static bool IsValidIPAddress(string ipAddress)
{
    if (ipAddress == null || ipAddress == "")
    {
        return false;
    }
    // 1. split the ip address inputted, for example: "192.168.1.1" becomes ["192", "168", "1", "1"]
    string[] parts = ipAddress.Split('.');

    // 2. check if there are exactly 4 parts
    if (parts.Length != 4)
    {
        return false;
    }

    //check each part one by one
    for (int i = 0; i < 4; i++)
    {
        int value;

        if(!int.TryParse(parts[i], out value))
        {
            return false;
        }

        // 3. check if each part is a number between 0 and 255
        if (value < 0 || value > 255)
        {
            return false;
        }
    }
    return true;    // if everything is ok, return true
}

string ipAddress;
bool isValid;

do
{
    Console.Write("Input IP Address: ");
    ipAddress = Console.ReadLine();

    isValid = IsValidIPAddress(ipAddress);

    if (!isValid)
    {
        Console.WriteLine("Invalid IP Address! Please try again.");
    }
    else
    {
        Console.WriteLine("Valid IP Address!");
    }

} while (!isValid);
