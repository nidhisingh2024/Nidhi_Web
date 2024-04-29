using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_projec
{
    class Admin
    {
        static miniprojectEntities1 data_base = new miniprojectEntities1();
        static TrainDetail tr = new TrainDetail();

        public static void addTrain()
        {
            Console.WriteLine("┌───────────────────────┐");
            Console.WriteLine("│       Add Train       │");
            Console.WriteLine("└───────────────────────┘");

            Console.WriteLine("Enter train details:");
            Console.Write("Train No: ");
            int train_no = int.Parse(Console.ReadLine());
            tr.Train_No = train_no;
            Console.Write("Train Name: ");
            string tname = Console.ReadLine();
            tr.Train_Name = tname;
            Console.Write("Source: ");
            string source = Console.ReadLine();
            tr.Source = source;
            Console.Write("Destination: ");
            string dest = Console.ReadLine();
            tr.Destination = dest;
            string sts = "Active";
            tr.train_stat = sts;
            data_base.TrainDetails.Add(tr);
            data_base.SaveChanges();

            Console.WriteLine("\nTrain has been added successfully.");
            Console.WriteLine("Now, enter train fare and seat details...");

            Console.WriteLine("\nFares:");
            Console.Write("First AC: ");
            int first_acfare = int.Parse(Console.ReadLine());
            Console.Write("Second AC: ");
            int sec_AcFare = int.Parse(Console.ReadLine());
            Console.Write("Sleeper: ");
            int slpFare = int.Parse(Console.ReadLine());

            data_base.addFare(train_no, first_acfare, sec_AcFare, slpFare);

            Console.WriteLine("\nEnter total seats:");
            Console.Write("First AC: ");
            int fir_Ac = int.Parse(Console.ReadLine());
            Console.Write("Second AC: ");
            int sec_Ac = int.Parse(Console.ReadLine());
            Console.Write("Sleeper: ");
            int slp = int.Parse(Console.ReadLine());

            data_base.addseat(train_no, fir_Ac, sec_Ac, slp);
            Console.WriteLine("Successs....");
            Program.adminoption();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***********************************************************************************");
            Console.WriteLine("************************************************************************************");
        }

        public static void showTrains()
        {
            var trains = data_base.TrainDetails.ToList();

            Console.WriteLine("|{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}", "Train No", "Train Name", "Source", "Destination","Status");
            Console.WriteLine(new string('-', 80)); 

            foreach (var train in trains)
            {

                Console.WriteLine("|{0,-10}|{1,-20}|{2,-20}|{3,-20}|{4,-20}", train.Train_No, train.Train_Name, train.Source, train.Destination,train.train_stat);
            }
        }

        public static void delete_train()
        {
            Console.WriteLine("┌───────────────────────┐");
            Console.WriteLine("│     Delete Train      │");
            Console.WriteLine("└───────────────────────┘");
            showTrains();
            Console.WriteLine("Enter train no:");
            int trainno = int.Parse(Console.ReadLine());
            data_base.Softdeletetrain(trainno);
            Console.WriteLine(  "Success...");
            Program.adminoption();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***********************************************************************************");
            Console.WriteLine("************************************************************************************");
        }

        public static void modifytrain()
        {
            showTrains();
            Console.WriteLine("Enter train to modfiy");
            int trainno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the source");
            string source = Console.ReadLine();
            Console.WriteLine("Enter the destination");
            string dest = Console.ReadLine();

            data_base.modifytrain(trainno, source, dest);
            Console.WriteLine("modification successful");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***********************************************************************************");
            Console.WriteLine("************************************************************************************");

        }

    }
}

