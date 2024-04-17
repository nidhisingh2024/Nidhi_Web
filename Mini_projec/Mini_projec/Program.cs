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

            Console.WriteLine(@"
               _________
              //  ||  \\--.
          ___//___||___\\___
         |      _     _      |   
         |     | |   | |     |   
         |_____|_|___|_|_____|   
           (O)       (O)");

            Console.WriteLine("┌──────────────────────────────┐");
            Console.WriteLine("│           MAIN MENU          │");
            Console.WriteLine("└──────────────────────────────┘");
            Console.WriteLine("| For Admin, press 1...        |");
            Console.WriteLine("| For User, press 2...         |");
            Console.WriteLine("| For Exit, press 3...         |");
            Console.WriteLine("└──────────────────────────────┘");

            int ipt = int.Parse(Console.ReadLine());
            if (ipt == 1)
            {
                Console.WriteLine("┌──────────────────────────────────────────┐");
                Console.WriteLine("│          ADMIN PANEL - RESERVATION        │");
                Console.WriteLine("└──────────────────────────────────────────┘");

                Console.WriteLine("| Press 1 to add a new train...            |");
                Console.WriteLine("| Press 2 to modify a train...             |");
                Console.WriteLine("| Press 3 to delete a train...             |");
                Console.WriteLine("└──────────────────────────────────────────┘");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Admin.addTrain();
                        break;
                    case 2:
                        Admin.modify_train();
                        break;
                    case 3:
                        Admin.delete_train();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }

            else if (ipt == 2)
            {
                Console.WriteLine("┌──────────────────────────────────┐");
                Console.WriteLine("│       USER AUTHENTICATION        │");
                Console.WriteLine("└──────────────────────────────────┘");
                User_class.UserCheck();
            }
            else
                Environment.Exit(0);
        }
    }
}

