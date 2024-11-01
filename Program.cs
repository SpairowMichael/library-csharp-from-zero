using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security;

namespace learn
{
    class Program
    {
        static void Main(string[] args)
        {

            bool isOpen = true;
            string[,] books =
            {
              //{ "",       "1",            "2",            "3"    },
                { "1", "Taras Shevchenko", "Ivan Franko", "Lesya Ukrainka" },
                { "2", "George Byron", "William Shakespear", "Dante Alighieri" },
                { "3", "Friedrich Schiller", "Thomas More", "Ivan Karpenko-Kary"}
            };

            while (isOpen) 
            { 
                Console.SetCursorPosition(0, 23);
                Console.WriteLine("\nList of authors:\n");

                Console.WriteLine("         1             2               3");
                for (int i = 0; i < books.GetLength(0); i++) 
                {
                    for (int j = 0; j < books.GetLength(1); j++) 
                    {
                        Console.Write(books[i, j] + " | ");
                    }

                    Console.WriteLine();

                }

                Console.SetCursorPosition(0, 0);

                Console.WriteLine("Library");
                Console.WriteLine(
                    "\n1 - find out author's name by index" +
                    "\n2 - find book by author" +
                    "\n3 - quit"
                    );

                Console.Write("Select menu command: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int shelf, cell;
                        Console.Write("Enter shelf number: ");
                        shelf = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Enter cell number: ");
                        cell = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Search results:   {books[shelf, cell]}");

                        break;
                    case 2:
                        string author;
                        bool authorIsFound = false;
                        Console.Write("Enter author's name: ");
                        author = Console.ReadLine();

                        for (int i = 0; i < books.GetLength(0); i++ )
                        {
                            for(int j = 0;  j < books.GetLength(1); j++)
                            {
                                if(author.ToLower() == books[i, j].ToLower())
                                {
                                    Console.Write(
                                        $"Author {books[i, j]} is have index " +
                                        $"shelf {i + 1}, cell {j}\n"
                                        );
                                    authorIsFound = true;
                                }
                            }
                        }
                        if(authorIsFound == false)
                        {
                            Console.WriteLine("Author doesn`t exist");
                        }
                        break;
                    case 3:
                        isOpen = false;
                        break;
                    
                    default:
                        Console.WriteLine("Command doest't exist");
                        break;
                }

                if (isOpen)
                {
                    Console.WriteLine("\nPress a key for continue...");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}