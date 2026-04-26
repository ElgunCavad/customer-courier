using CustomerCourier.Helper;
using CustomerCourier.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerCourier.Service
{
 internal class InMemoryDeliveryService : DeliveryService
 {
 private readonly List<Package> _packages = new();
 private readonly List<Courier> _couriers = new();
 private readonly List<Customer> _customers = new();

 public InMemoryDeliveryService()
 {
 // seed some couriers and customers for demo
 _couriers.Add(new Courier("Ali Veli"));
 _couriers.Add(new Courier("Leyla Quliyeva"));

 _customers.Add(new Customer("Nicat Ahmedov", "0500000000", "Baku",0));
 _customers.Add(new Customer("Sara Mammadova", "0511111111", "Ganja",0));
 }

 public void CreatePackage(Customer sender, string receiverName, string receiverAddress, double weight)
 {
 var pkg = new Package()
 {
 TrackingNumber = GenerateTracking(),
 Sender = sender,
 ReceiverName = receiverName,
 ReceiverAddress = receiverAddress,
 Weight = weight,
 Status = Status.Created,
 Courier = null
 };

 _packages.Add(pkg);
 sender.PackageCount++;
 Console.WriteLine($"Package created with tracking: {pkg.TrackingNumber}");
 }

 public void AssignCourier(string trackingNo)
 {
 var pkg = _packages.FirstOrDefault(p => p.TrackingNumber == trackingNo);
 if (pkg == null) { Console.WriteLine("Package not found"); return; }
 if (pkg.Courier != null) { Console.WriteLine("Courier already assigned"); return; }

 var courier = _couriers.FirstOrDefault(c => c.IsAvailable);
 if (courier == null) { Console.WriteLine("No available courier"); return; }

 courier.IsAvailable = false;
 pkg.Courier = courier;
 pkg.Status = Status.InTransit;
 Console.WriteLine($"Assigned courier {courier.FullName} to package {pkg.TrackingNumber}");
 }

 public void DeliverPackage(string trackingNo)
 {
 var pkg = _packages.FirstOrDefault(p => p.TrackingNumber == trackingNo);
 if (pkg == null) { Console.WriteLine("Package not found"); return; }
 if (pkg.Courier == null) { Console.WriteLine("No courier assigned"); return; }

 pkg.Status = Status.Delivered;
 pkg.Courier.IncrementDelivered();
 pkg.Courier.IsAvailable = true;
 Console.WriteLine($"Package {pkg.TrackingNumber} delivered by {pkg.Courier.FullName}");
 }

 public Package GetPackage(string trackingNo)
 {
 return _packages.FirstOrDefault(p => p.TrackingNumber == trackingNo);
 }

 public void GetPackageInfo(string trackingNo)
 {
 var pkg = GetPackage(trackingNo);
 if (pkg == null) { Console.WriteLine("Package not found"); return; }

 Console.WriteLine($"Tracking: {pkg.TrackingNumber}");
 Console.WriteLine($"Sender: {pkg.Sender.FullName}");
 Console.WriteLine($"Receiver: {pkg.ReceiverName}, {pkg.ReceiverAddress}");
 Console.WriteLine($"Weight: {pkg.Weight}");
 Console.WriteLine($"Status: {pkg.Status}");
 Console.WriteLine($"Courier: {(pkg.Courier != null ? pkg.Courier.FullName : "Unassigned")}");
 }

 public List<Package> GetAllPackages()
 {
 return _packages.ToList();
 }

 public List<Package> GetPackagesByCourier(int courierId)
 {
 return _packages.Where(p => p.Courier != null && p.Courier.Id == courierId).ToList();
 }

 public List<Package> GetPackagesByCustomer(int customerId)
 {
 return _packages.Where(p => p.Sender != null && p.Sender.Id == customerId).ToList();
 }

 private string GenerateTracking()
 {
 return $"TRK{DateTime.UtcNow.Ticks}";
 }
 }
}
