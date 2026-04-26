using CustomerCourier.Models;
using CustomerCourier.Service;
using System;

namespace CustomerCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new InMemoryDeliveryService();
            bool exit = false;

            // create a simple menu to demonstrate features
            while (!exit)
            {
                Console.WriteLine("--- Customer Courier Menu ---");
                Console.WriteLine("1. Create Package");
                Console.WriteLine("2. Assign Courier");
                Console.WriteLine("3. Deliver Package");
                Console.WriteLine("4. Get Package Info");
                Console.WriteLine("5. List All Packages");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Sender Full Name: ");
                        var sname = Console.ReadLine();
                        Console.Write("Sender Phone: ");
                        var sphone = Console.ReadLine();
                        Console.Write("Sender Address: ");
                        var saddr = Console.ReadLine();
                        Console.Write("Receiver Name: ");
                        var rname = Console.ReadLine();
                        Console.Write("Receiver Address: ");
                        var raddr = Console.ReadLine();
                        Console.Write("Weight (kg): ");
                        var wstr = Console.ReadLine();
                        double.TryParse(wstr, out var weight);
                        var customer = new Customer(sname ?? "", sphone ?? "", saddr ?? "",0);
                        service.CreatePackage(customer, rname ?? "", raddr ?? "", weight);
                        break;
                    case "2":
                        Console.Write("Tracking No: ");
                        var t1 = Console.ReadLine();
                        service.AssignCourier(t1 ?? "");
                        break;
                    case "3":
                        Console.Write("Tracking No: ");
                        var t2 = Console.ReadLine();
                        service.DeliverPackage(t2 ?? "");
                        break;
                    case "4":
                        Console.Write("Tracking No: ");
                        var t3 = Console.ReadLine();
                        service.GetPackageInfo(t3 ?? "");
                        break;
                    case "5":
                        var list = service.GetAllPackages();
                        foreach (var p in list)
                        {
                            Console.WriteLine($"{p.TrackingNumber} - {p.ReceiverName} - {p.Status}");
                        }
                        break;
                    case "0":
                        exit = true; break;
                    default:
                        Console.WriteLine("Invalid choice"); break;
                }
            }
        }
    }
}
