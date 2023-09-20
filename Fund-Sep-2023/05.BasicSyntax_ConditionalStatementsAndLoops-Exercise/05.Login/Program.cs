//string userName = Console.ReadLine();
//string password = "";

//int passTryCount = 0;

//for (int i = userName.Length - 1; i >= 0; i--)
//{
//    password += userName[i];
//}

//while (passTryCount < 4)
//{
//    string pass = Console.ReadLine();
//    passTryCount++;

//    if (pass == password)
//    {
//        Console.WriteLine($"User {userName} logged in.");
//        break;
//    }

//    else if (passTryCount == 4)
//    {
//        Console.WriteLine($"User {userName} blocked!");
//    }

//    else if (pass != password)
//    {
//        Console.WriteLine("Incorrect password. Try again.");
//    }
   
//}


string userName = Console.ReadLine();
string password = new string(userName.Reverse().ToArray()); // obrushta teksta naopyki bukwa po bukwa

int passTryCount = 0;

//for (int i = userName.Length - 1; i >= 0; i--)
//{
//    password += userName[i];
//}

while (passTryCount < 4)
{
    string pass = Console.ReadLine();
    passTryCount++;

    if (pass == password)
    {
        Console.WriteLine($"User {userName} logged in.");
        break;
    }

    else if (passTryCount == 4)
    {
        Console.WriteLine($"User {userName} blocked!");
    }

    else if (pass != password)
    {
        Console.WriteLine("Incorrect password. Try again.");
    }

}




