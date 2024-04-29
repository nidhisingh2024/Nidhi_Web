using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini_projec
{
    class User_class
    {
        static miniprojectEntities1 db = new miniprojectEntities1();
        static Ticket_Booking ticket_b = new Ticket_Booking();
        static Random random = new Random();
        static int user_id;
        static UserDetail user = new UserDetail();

        // Method to display available trains
       public static void ShowTrains()
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine("| Train-No | Train-Name       | Source     | Destination                          |");
            Console.WriteLine("|----------|----------------- |------------|--------------------------------------|");

            var train = db.TrainDetails.Where(t => t.train_stat == "Active").ToList();
            foreach (var v in train)
            {
                Console.WriteLine("| {0,-8} | {1,-11} |{2,-6}| {3,-48}   |", v.Train_No, v.Train_Name, v.Source, v.Destination);
            }
            Console.WriteLine("===================================================================================");
        }


        // Method to book a ticket
        
static void ShowFare_Seat(int tno)
{
    var fare = db.Fares.FirstOrDefault(t => t.Train_No == tno);
    var seat = db.Seats.FirstOrDefault(s => s.Train_No == tno);

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
    Console.WriteLine("|                        Fare and Seat Details                                                             |");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
    Console.WriteLine("| Train No | FirstAC Fare | FirstAC Seats | SecondAC Fare | SecondAC Seats | Sleeper Fare | Sleeper Seats |");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

    if (fare != null && seat != null)
    {
        Console.WriteLine($"| {fare.Train_No,-9} | {fare.C1_AC,-12} | {seat.C1_AC,-13} | {fare.C2_AC,-13} | {seat.C2_AC,-15} | {fare.SL,-11} | {seat.SL,-13} |");
    }
    else
    {
        Console.WriteLine("| Unable to retrieve fare and seat details for the specified train number. |");
    }

          Console.WriteLine("*********************************************************************************************************");
          Console.WriteLine("*********************************************************************************************************");
        }

        static void BookTicket(int use_id)
        {
            ShowTrains();

            Ticket_Booking book_t = new Ticket_Booking();
            int pnr = random.Next(10000, 99999);
            book_t.PNR_No = pnr;
            book_t.Booking_time_date = DateTime.Now;
            book_t.User_Id = user_id;

            Console.WriteLine("Enter train number to book ticket...");
            int tno;
            if (!int.TryParse(Console.ReadLine(), out tno))
            {
                Console.WriteLine("Invalid input for train number.");
                return;
            }

            ShowFare_Seat(tno);

            var selectedTrain = db.TrainDetails.FirstOrDefault(t => t.Train_No == tno && t.train_stat == "Active");
            if (selectedTrain != null)
            {
                book_t.Train_No = tno;

                Console.WriteLine("Enter the number of tickets to book:");
                int numTickets;
                if (!int.TryParse(Console.ReadLine(), out numTickets) || numTickets <= 0)
                {
                    Console.WriteLine("Invalid input for number of tickets.");
                    return;
                }

                Console.WriteLine("Book ticket for FirstAc, SecondAC, Sleeper...");
                string @class = Console.ReadLine().ToLower();
                book_t.tktClass = @class;
                book_t.tktstatus = "confirm";
                int amt = 0;
                if ( @class== "firstac")
                    amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.C1_AC).FirstOrDefault();
                else if (@class == "secondac")
                    amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.C2_AC).FirstOrDefault();
                else
                    amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.SL).FirstOrDefault();

                book_t.TotalFare = amt * numTickets;

                db.Ticket_Booking.Add(book_t);
                db.SaveChanges();

                Console.WriteLine("Thanks for booking ticket....");
                db.SeatManageProc(tno,@class);
            }
            else
            {
                Console.WriteLine("Sorry, the selected train is inactive. Please choose an active train.");

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***********************************************************************************");
            Console.WriteLine("************************************************************************************");
        }
        // Method to print tickets
        // Method to print tickets
        // Method to print tickets
        public static void PrintTickets(int us_id)
        {
            var userTickets = db.Ticket_Booking.Where(bt => bt.User_Id == us_id).ToList();
            int ticketCount = userTickets.Count;

            var user = db.UserDetails.FirstOrDefault(u => u.User_Id == us_id);

            Console.WriteLine("===================================================================================");
            Console.WriteLine("| User ID: {0,-8} | User Name: {1,-20} | Tickets Booked: {2,-5} |", user.User_Id, user.User_Name, ticketCount);
            Console.WriteLine("|---------------------------------------------------------------------------------|");
            Console.WriteLine("| PNR No. | Train No. | Total Fare | Booking Date            | Class     | Status  |");
            Console.WriteLine("|---------|-----------|------------|-------------------------|-----------|---------|");

            foreach (var ticket in userTickets)
            {
                string status = ticket.tktstatus == "Canceled" ? "Canceled" : "Active";
                Console.WriteLine("| {0,-7} | {1,-9} | {2,-10} | {3,-24:yyyy-MM-dd HH:mm:ss} | {4,-9} | {5,-8} |",
                                  ticket.PNR_No, ticket.Train_No, ticket.TotalFare, ticket.Booking_time_date, ticket.tktClass, status);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("************************************************************************************************");
            Console.WriteLine("************************************************************************************************");
        }


        static void CancelTicket()
        {
            Console.WriteLine("Enter User ID to cancel the ticket:");
            int userId = int.Parse(Console.ReadLine());

            var userTickets = db.Ticket_Booking.Where(bt => bt.User_Id == userId && bt.tktstatus != "Canceled").ToList();

            if (userTickets.Any())
            {
                Console.WriteLine("===================================================================================");
                Console.WriteLine("| PNR No. | Train No. | Total Fare | Booking Date                                 |");
                Console.WriteLine("|---------|-----------|------------|----------------------------------------------|");

                foreach (var ticket in userTickets)
                {
                    Console.WriteLine("| {0,-7} | {1,-9} | {2,-10} | {3,-44} |",
                                      ticket.PNR_No, ticket.Train_No, ticket.TotalFare, ticket.Booking_time_date);
                }

                Console.WriteLine("===================================================================================");

                Console.WriteLine("Enter the PNR No. to cancel:");
                int PNR_No = int.Parse(Console.ReadLine());

                var ticketToCancel = db.Ticket_Booking.FirstOrDefault(t => t.User_Id == userId && t.PNR_No == PNR_No && t.tktstatus != "Canceled");

                if (ticketToCancel != null)
                {
                    ticketToCancel.tktstatus = "Canceled";
                    ticketToCancel.Booking_time_date = DateTime.Now;

                    db.SaveChanges();
                    string @class = (string)db.Ticket_Booking.Where(t => t.PNR_No == PNR_No).Select(t => t.tktClass).FirstOrDefault();
                    int trainNo = (int)db.Ticket_Booking.Where(t => t.User_Id == userId && t.PNR_No == PNR_No).Select(t => t.Train_No).FirstOrDefault();
                    db.SeatManageProcCan(trainNo, @class);
                    Console.WriteLine("Ticket canceled successfully.");
                }
                else
                {
                    Console.WriteLine("No active ticket found with the provided Train No.");
                }
            }
            else
            {
                Console.WriteLine("No active tickets found for the provided User ID.");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("******************************************************************************************************************");
            Console.WriteLine("******************************************************************************************************************");
        }
        // Method to authenticate user
        public static void UserCheck()
        {
            Console.WriteLine("===================================================================================");
            Console.WriteLine("|                              User Authentication                                 |");
            Console.WriteLine("===================================================================================");
            Console.WriteLine("| Options                        | Keys                                            |");
            Console.WriteLine("|--------------------------------|-------------------------------------------------|");
            Console.WriteLine("| Create Account                 | Enter '1' for account creation                  |");
            Console.WriteLine("| Login                          | Enter '2' for Login                             |");
            Console.WriteLine("| Exit                           | Enter any other key to exit                     |");
            Console.WriteLine("===================================================================================");

            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                Console.WriteLine("Enter User Id:");
                user_id = int.Parse(Console.ReadLine());
                user.User_Id = user_id;
                Console.WriteLine("Enter User Name: ");
                user.User_Name = Console.ReadLine();
                Console.WriteLine("Enter User Password: ");
                user.password = Console.ReadLine(); 
                db.UserDetails.Add(user);

                db.SaveChanges();
                Console.WriteLine("Account Created Successfully...");
               
            }
            else if (ans == 2)
            {
                Console.Write("Enter User-ID: ");
                user_id = int.Parse(Console.ReadLine());
                Console.Write("Enter User Password: ");
                string password = ReadPassword(); 
                var validate = Validate(user_id, password);
                if (validate)
                    user_option();
                else
                {
                    Console.WriteLine("OOPS! Invalid User credentials...");
                    UserCheck();
                }
            }
            else
                Environment.Exit(0);
        }
        
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
                    Console.Write("*"); 
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); 
            return password.ToString();
        }

        private static bool Validate(int user_id, string password)
        {
            var user = db.UserDetails.FirstOrDefault(u => u.User_Id == user_id && u.password == password);
            return user != null;
        }
        public static void user_option()
        {
            Console.WriteLine("\t1. To Book Ticket Press '1'");
            Console.WriteLine("\t2. To Show Booked Ticket Press '2'");
            Console.WriteLine("\t3.To Cancel Ticket Press '3'");
            Console.WriteLine("\t4.For Exit... Press '4'");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                BookTicket(user_id);
                user_option();
            }
            else if (ans == 2)
            {
                
                PrintTickets(user_id);
                Console.ReadKey();
                Console.WriteLine();
                user_option()
;
            }
            else if (ans == 3)
            {
                CancelTicket();
                Console.ReadKey();
                Console.WriteLine();
                user_option();
            }
            else
                Environment.Exit(0);
        }

    }
}





