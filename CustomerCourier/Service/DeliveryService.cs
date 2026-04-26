using CustomerCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCourier.Service
{
    internal interface DeliveryService
    {

        public void CreatePackage(Customer sender, string receiverName, string receiverAddress, double weight);

        public void AssignCourier(string trackingNo);

        public void DeliverPackage(string trackingNo);

        public Package GetPackage(string trackingNo);

        public void GetPackageInfo(string trackingNo);

        public List<Package> GetAllPackages();

        public List<Package> GetPackagesByCourier(int courierId);

        public List<Package> GetPackagesByCustomer(int customerId);
    }
}
