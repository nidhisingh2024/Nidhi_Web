using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_projec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Indian Train Reservation System");

            while (true)
            {
                Console.WriteLine("┌──────────────────────────────┐");
                Console.WriteLine("│           MAIN MENU          │");
                Console.WriteLine("└──────────────────────────────┘");
                Console.WriteLine("| For Admin, press 1...        |");
                Console.WriteLine("| For User, press 2...         |");
                Console.WriteLine("| For Exit, press 3...         |");
                Console.WriteLine("└──────────────────────────────┘");

                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                   adminoption();
                }
                else if (input == 2)
                {
                    Console.WriteLine("┌──────────────────────────────────┐");
                    Console.WriteLine("│       USER AUTHENTICATION        │");
                    Console.WriteLine("└──────────────────────────────────┘");
                    User_class.UserCheck();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        public static void adminoption()
        {
            while (true)
            {
                Console.WriteLine("┌──────────────────────────────────────────┐");
                Console.WriteLine("│          ADMIN PANEL - RESERVATION        │");
                Console.WriteLine("└──────────────────────────────────────────┘");

                Console.WriteLine("| Press 1 to add a new train...            |");
                Console.WriteLine("| Press 2 to modify a train...             |");
                Console.WriteLine("| Press 3 to delete a train...             |");
                Console.WriteLine("| Press 4 to shows train...                |");
                Console.WriteLine("| Press 5 to go back to the main menu...   |");
                Console.WriteLine("└──────────────────────────────────────────┘");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Admin.addTrain();
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 2:
                        Admin.modifytrain();
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 3:
                        Admin.delete_train();
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 4:
                        Admin.showTrains();
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 5:
                        return; 

                    default:
                        Environment.Exit(0);
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}

