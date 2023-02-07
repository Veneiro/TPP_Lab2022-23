using System;
using System.Threading;

namespace lab01TPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList exampleList = new SinglyLinkedList();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Lists Checker");
            Console.WriteLine("1 - Random List, Size 9");
            Console.WriteLine("2 - Add Number");
            Console.WriteLine("3 - Remove Number");
            Console.WriteLine("4 - Get Element at");
            Console.WriteLine("5 - Get List");
            Console.WriteLine("6 - Help");
            Console.WriteLine("");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Choose an Option:  ");
            int x;
            int y;
            int z;
            while (int.TryParse(Console.ReadLine(), out x))
            {
                if (x == 1)
                {
                    Console.WriteLine("-------R-A-N-D-O-M--C-H-E-C-K-------");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("--------Adding-9-random-int---------");
                    for (int i = 0; i <= 8; i++)
                    {
                        Random r = new Random();
                        int num = r.Next(100);
                        Console.WriteLine("          Element {0} added", num);
                        exampleList.Add(num);
                    }
                    Console.WriteLine("---------Addition-Finished----------");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("After Adding list:");
                    Console.WriteLine(exampleList.ToString());
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Getting element at 3 position:");
                    Console.WriteLine(exampleList.GetElement(3));
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Removing element at position 3");
                    exampleList.Remove(3);
                    Console.WriteLine("After Removing list:");
                    Console.WriteLine(exampleList.ToString());

                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("TYPE 1 TO CONTINUE: ");
                    if (int.TryParse(Console.ReadLine(), out y))
                    {
                        while (y != 1)
                        {
                            Console.WriteLine("Please, press 1 to continue...");
                            int.TryParse(Console.ReadLine(), out y);
                        }
                        Console.Clear();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Lists Checker");
                        Console.WriteLine("1 - Random List, Size 9");
                        Console.WriteLine("2 - Add Number");
                        Console.WriteLine("3 - Remove Number");
                        Console.WriteLine("4 - Get Element at");
                        Console.WriteLine("5 - Get List");
                        Console.WriteLine("6 - Help");
                        Console.WriteLine("");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (x == 2)
                {
                    Console.WriteLine("Type the number you want to add: ");
                    if (int.TryParse(Console.ReadLine(), out z))
                    {
                        exampleList.Add(z);
                        Console.WriteLine("--Number Added--");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Not an integer, please try again");
                        Thread.Sleep(500);
                    }
                }
                if (x == 3)
                {
                    Console.WriteLine("Type the position of the number you want to remove: ");
                    if (int.TryParse(Console.ReadLine(), out z))
                    {
                        exampleList.Remove(z);
                        Console.WriteLine("--Number at position " + z + " Removed--");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Not an integer, please try again");
                        Thread.Sleep(500);
                    }
                }
                if (x == 4)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Type the position of the number you want to get: ");
                    if (int.TryParse(Console.ReadLine(), out z))
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("The number at position " + z + " is: ");
                        Console.WriteLine(exampleList.GetElement(z));
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("TYPE 1 TO CONTINUE: ");
                        if (int.TryParse(Console.ReadLine(), out y))
                        {
                            while (y != 1)
                            {
                                Console.WriteLine("Please, press 1 to continue...");
                                int.TryParse(Console.ReadLine(), out y);
                            }
                            Console.Clear();
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Lists Checker");
                            Console.WriteLine("1 - Random List, Size 9");
                            Console.WriteLine("2 - Add Number");
                            Console.WriteLine("3 - Remove Number");
                            Console.WriteLine("4 - Get Element at");
                            Console.WriteLine("5 - Get List");
                            Console.WriteLine("6 - Help");
                            Console.WriteLine("");
                            Console.WriteLine("0 - Exit");
                            Console.WriteLine("------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not an integer, please try again");
                        Thread.Sleep(500);
                    }
                }
                if (x == 5)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Your current list: ");
                    Console.WriteLine(exampleList.ToString());
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("TYPE 1 TO CONTINUE: ");
                    if (int.TryParse(Console.ReadLine(), out y))
                    {
                        while (y != 1)
                        {
                            Console.WriteLine("Please, press 1 to continue...");
                            int.TryParse(Console.ReadLine(), out y);
                        }
                        Console.Clear();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Lists Checker");
                        Console.WriteLine("1 - Random List, Size 9");
                        Console.WriteLine("2 - Add Number");
                        Console.WriteLine("3 - Remove Number");
                        Console.WriteLine("4 - Get Element at");
                        Console.WriteLine("5 - Get List");
                        Console.WriteLine("6 - Help");
                        Console.WriteLine("");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (x == 6)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("--------------H-E-L-P---------------");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("If you want to do a global check of\n" +
                                    "the List class just press 1 and Enter.\n" +
                                    "This will generate a set of 10 random\n" +
                                    "numbers and show you the add, remove\n" +
                                    "and getElement operations on the screen.\n" +
                                    "\nYou can also choose between the other\n" +
                                    "options that allows you to make the\n" +
                                    "add, remove and getElement by yourself.\n" +
                                    "\nIf you want to check the current state of\n" +
                                    "the list you can check it by choosing 5");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("TYPE 1 TO CONTINUE: ");
                    if (int.TryParse(Console.ReadLine(), out y))
                    {
                        while (y != 1)
                        {
                            Console.WriteLine("Please, press 1 to continue...");
                            int.TryParse(Console.ReadLine(), out y);
                        }
                        Console.Clear();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("Lists Checker");
                        Console.WriteLine("1 - Random List, Size 9");
                        Console.WriteLine("2 - Add Number");
                        Console.WriteLine("3 - Remove Number");
                        Console.WriteLine("4 - Get Element at");
                        Console.WriteLine("5 - Get List");
                        Console.WriteLine("6 - Help");
                        Console.WriteLine("");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (x == 0)
                {
                    Console.Clear();
                    string text1 = @"
                           ___                                 ____      _ __  __         __
                          / _ \_______  ___ ________ ___ _    / __/_ __ (_) /_/ /____ ___/ /
                         / ___/ __/ _ \/ _ `/ __/ _ `/  ' \  / _/ \ \ // / __/ __/ -_) _  / 
                        /_/  /_/  \___/\_, /_/  \_,_/_/_/_/ /___//_\_\/_/\__/\__/\__/\_,_/  
                                      /___/                                                 
                        ";
                    Console.WriteLine(text1);
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Lists Checker");
                    Console.WriteLine("1 - Random List, Size 9");
                    Console.WriteLine("2 - Add Number");
                    Console.WriteLine("3 - Remove Number");
                    Console.WriteLine("4 - Get Element at");
                    Console.WriteLine("5 - Get List");
                    Console.WriteLine("6 - Help");
                    Console.WriteLine("");
                    Console.WriteLine("0 - Exit");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Choose an Option: ");
                }
            }
            Console.Clear();
            string text2 = @"
                   ____                    _  __     _  __
                  / __/__________  ____   / |/ /__ _/ |/ /
                 / _// __/ __/ _ \/ __/  /    / _ `/    / 
                /___/_/ /_/  \___/_/    /_/|_/\_,_/_/|_/  
                                          
                ";
            Console.WriteLine(text2);
        }
    }
}
