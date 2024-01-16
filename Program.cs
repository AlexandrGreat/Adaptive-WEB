using System;

main();

void main() 
{
    Console.WriteLine("Please, select an action");
    Console.WriteLine("-------------------");
    Console.WriteLine("1: Count symbols in file");
    Console.WriteLine("2: Do some math");
    Console.WriteLine("-------------------");
    ConsoleKeyInfo input;
    input = Console.ReadKey(true);
    if (input.Key == ConsoleKey.D1) { Console.Clear(); action1(); }
    if (input.Key == ConsoleKey.D2) { Console.Clear(); action2(); }
}

void action1() 
{
    Console.WriteLine("ACTION 1");
    Console.WriteLine("-------------------");
    string fileName = "action1text.txt";
    if (File.Exists(fileName))
    {
        Console.WriteLine("Symbols in " + fileName + ": " + File.ReadAllText(fileName).Length);
    }
    else
        Console.WriteLine("Error while opening file");
    Console.WriteLine("-------------------");
    Console.WriteLine("Press any key to return to main menu");
    Console.ReadKey();
    Console.Clear();
    main();
}

void action2() 
{
    string a, b;
    double a1, b1;
    Console.WriteLine("ACTION 2");
    Console.WriteLine("-------------------");
    Console.WriteLine("Input 2 numbers:");
    a = Console.ReadLine();
    b = Console.ReadLine();
    if (double.TryParse(a, out a1) && double.TryParse(b, out b1)) 
    {
        Console.WriteLine("Please, select an action");
        Console.WriteLine("-------------------");
        Console.WriteLine("1: +");
        Console.WriteLine("2: -");
        Console.WriteLine("3: *");
        Console.WriteLine("4: /");
        Console.WriteLine("-------------------");
        ConsoleKeyInfo input;
        input = Console.ReadKey(true);
        if (input.Key == ConsoleKey.D1) { Console.WriteLine(a1 + " + " + b1 + " = " + (a1 + b1)); }
        if (input.Key == ConsoleKey.D2) { Console.WriteLine(a1 + " - " + b1 + " = " + (a1 - b1)); }
        if (input.Key == ConsoleKey.D3) { Console.WriteLine(a1 + " * " + b1 + " = " + (a1 * b1)); }
        if (input.Key == ConsoleKey.D4) { Console.WriteLine(a1 + " / " + b1 + " = " + (a1 / b1)); }
    }
    else
    {
        Console.WriteLine("Cant parse to double");
    }
    Console.WriteLine("-------------------");
    Console.WriteLine("Press any key to return to main menu");
    Console.ReadKey();
    Console.Clear();
    main();
}
