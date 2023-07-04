using System;
using System.Text.RegularExpressions;
namespace monty
{
    class Monty
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int car = rnd.Next(0, 3);
            List <bool> doors = new List <bool>(){false, false, false};
            List <int> numbers = new List<int>(){1, 2, 3};
            doors[car]=true;
            int choice = 0;
            int tracker = 0;
            int i = 0;
            string change = "";
            Console.Write("Choose a door from 1-3: ");
            choice = int.Parse(Console.ReadLine());
            
            while (i != 1)
            {
                tracker = rnd.Next(0, 3);
                if ((tracker+1)!=choice && doors[tracker]==false)
                {
                    Console.WriteLine("Door number "+(tracker+1)+ " and reveals a goat");
                    doors.RemoveAt(tracker);
                    numbers.RemoveAt(tracker);
                    Console.Write("Do you wish to switch to the other unopened door? ");
                    change = Console.ReadLine();
                    if (change == "y")
                    {
                        foreach (int alt in numbers)
                        {
                            if (choice != alt)
                            {
                                choice = numbers.IndexOf(alt);
                            }
                        }
                    }
                    else 
                    {
                        choice = numbers.IndexOf(choice);
                    }
                    i++;
                }
            }
            if (doors[choice]== true)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost...");
            }
        }
    }
}