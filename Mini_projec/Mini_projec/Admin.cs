using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_projec
{
    class Admin
    {
        static miniprojectEntities db = new miniprojectEntities();
        static TrainDetail t = new TrainDetail();

        public static void addTrain()
        {
            Console.WriteLine("┌───────────────────────┐");
            Console.WriteLine("│       Add Train       │");
            Console.WriteLine("└───────────────────────┘");

            Console.WriteLine("Enter train details:");
            Console.Write("Train No: ");
            int train_no = int.Parse(Console.ReadLine());
            t.Train_No = train_no;
            Console.Write("Train Name: ");
            string tname = Console.ReadLine();
            t.Train_Name = tname;
            Console.Write("Source: ");
            string source = Console.ReadLine();
            t.Source = source;
            Console.Write("Destination: ");
            string dest = Console.ReadLine();
            t.Destination = dest;
            string sts = "Active";
            t.train_stat = sts;
            db.TrainDetails.Add(t);
            db.SaveChanges();

            Console.WriteLine("\nTrain has been added successfully.");
            Console.WriteLine("Now, enter train fare and seat details...");

            Console.WriteLine("\nFares:");
            Console.Write("First AC: ");
            int first_acfare = int.Parse(Console.ReadLine());
            Console.Write("Second AC: ");
            int sec_AcFare = int.Parse(Console.ReadLine());
            Console.Write("Sleeper: ");
            int slpFare = int.Parse(Console.ReadLine());

            db.Add_fare(train_no, first_acfare, sec_AcFare, slpFare);

            Console.WriteLine("\nEnter total seats:");
            Console.Write("First AC: ");
            int fir_Ac = int.Parse(Console.ReadLine());
            Console.Write("Second AC: ");
            int sec_Ac = int.Parse(Console.ReadLine());
            Console.Write("Sleeper: ");
            int slp = int.Parse(Console.ReadLine());

            db.Add_seat(train_no, fir_Ac, sec_Ac, slp);
        }

static void showTrains()

        {

            var train = db.TrainDetails.ToList();

            foreach (var v in train)

            {

                Console.WriteLine($"Train No{v.Train_No}  Train Name {v.Train_Name} Train Source {v.Source}   {v.Destination}");

            }

        }
        public static void delete_train()
        {
            Console.WriteLine("┌───────────────────────┐");
            Console.WriteLine("│     Delete Train      │");
            Console.WriteLine("└───────────────────────┘");

            Console.WriteLine("Enter train no:");
            int trainno = int.Parse(Console.ReadLine());
            db.Softdeletetrain(trainno);
        }

        public static void modify_train()
        {
            Console.WriteLine("┌───────────────────────┐");
            Console.WriteLine("│     Modify Train      │");
            Console.WriteLine("└───────────────────────┘");

            Console.WriteLine("Enter train to modify:");
            int trainno = int.Parse(Console.ReadLine());
            Console.Write("Enter new source: ");
            string source = Console.ReadLine();
            Console.Write("Enter new destination: ");
            string dest = Console.ReadLine();

            db.modifytrain(trainno, source, dest);
        }
    }
}

