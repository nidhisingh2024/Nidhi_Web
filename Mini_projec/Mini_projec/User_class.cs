using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini_projec
{
    class User_class
    {
        static miniprojectEntities db = new miniprojectEntities();
        static Ticket_Booking tb = new Ticket_Booking();
        static Random random = new Random();
        static int user_id;
        static UserDetail u = new UserDetail();

        // Method to display available trains
        static void ShowTrains()
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine("| Train-No | Train-Name  | Source | Destination                                     |");
            Console.WriteLine("|----------|-------------|--------|--------------------------------------------------|");

            var train = db.TrainDetails.Where(t => t.train_stat == "Active").ToList();
            foreach (var v in train)
            {
                Console.WriteLine("| {0,-8} | {1,-11} | {2,-6} | {3,-48} |", v.Train_No, v.Train_Name, v.Source, v.Destination);
            }
            Console.WriteLine("===================================================================================");
        }

        // Method to book a ticket
        static void BookTicket(int uid)
        {
            ShowTrains();
            Ticket_Booking book_t = new Ticket_Booking();
            int pnr = random.Next(10000, 99999);
            book_t.Booking_time_date = DateTime.Now;
            book_t.User_Id = uid;
            Console.WriteLine("Enter train no to book ticket...");
            int tno = int.Parse(Console.ReadLine());
            book_t.Train_No = tno;

            Console.WriteLine("Book ticket for FirstAc, SecondAC, Sleeper...");
            string ans = Console.ReadLine().ToLower();
            book_t.tktstatus = ans;
            int amt = 0;
            if (ans == "firstac")
                amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.C1_AC).FirstOrDefault();
            else if (ans == "secondac")
                amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.C2_AC).FirstOrDefault();
            else
                amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.SL).FirstOrDefault();
            book_t.TotalFare = amt;

            db.Ticket_Booking.Add(book_t);
            db.SaveChanges();

            Console.WriteLine("Thanks for booking ticket....");
        }

        // Method to cancel a ticket
        static void CancelTicket()
        {
            Console.WriteLine("Enter booking id to cancel ticket...");
            int bookid = int.Parse(Console.ReadLine());
            //db.CancelTicket(bookid);
        }

        // Method to print tickets
        public static void PrintTickets(int uid)
        {
            var tkt = db.Ticket_Booking.Where(bt => bt.User_Id == uid);
            foreach (var v in tkt)
            {
                Console.WriteLine("{0,-7} userid: {1,-5} {2,-7} \n{3,-5} {4}\n", v.PNR_No, v.User_Id, v.Train_No, v.TotalFare, v.Booking_time_date);
            }
        }

        // Method to authenticate user
        public static void UserCheck()
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine("|                              User Authentication                                 |");
            Console.WriteLine("===================================================================================");
            Console.WriteLine("| Options                        | Keys                                             |");
            Console.WriteLine("|--------------------------------|--------------------------------------------------|");
            Console.WriteLine("| Create Account                 | Enter '1' for account creation                    |");
            Console.WriteLine("| Login                          | Enter '2' for Login                                |");
            Console.WriteLine("| Exit                           | Enter any other key to exit                        |");
            Console.WriteLine("===================================================================================");

            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                Console.WriteLine("Enter user id:");
                user_id = int.Parse(Console.ReadLine());
                u.User_Id = user_id;
                Console.WriteLine("Enter user Name: ");
                u.User_Name = Console.ReadLine();
                Console.WriteLine("Enter user Password: ");
                u.password = ReadPassword(); // Call method to hide password input
                db.UserDetails.Add(u);

                db.SaveChanges();
                Console.WriteLine("Account Created successfully...");
                UserCheck();
            }
            else if (ans == 2)
            {
                Console.Write("Enter User-ID: ");
                user_id = int.Parse(Console.ReadLine());
                Console.Write("Enter User Password: ");
                string password = ReadPassword(); // Call method to hide password input
                var validate = Validate(user_id, password);
                if (validate)
                    UserCheck();
                else
                {
                    Console.WriteLine("OOPS! Invalid User credentials...");
                    UserCheck();
                }
            }
            else
                Environment.Exit(0);
        }

        // Method to read password without displaying it on the console
        private static string ReadPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                {
                    password.Append(key.KeyChar);
                    Console.Write("*"); // Display asterisks (*) for each character
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); // Move to the next line after input
            return password.ToString();
        }

        // Method to validate user credentials
        private static bool Validate(int user_id, string password)
        {
            var user = db.UserDetails.FirstOrDefault(u => u.User_Id == user_id && u.password == password);
            return user != null;
        }
    }
}





