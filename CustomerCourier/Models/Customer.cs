using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCourier.Models
{
    internal class Customer
    {

        private static int _id;
        public int Id { get; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int PackageCount { get; set; }

        public Customer(string fullName, string phoneNumber, string address, int packageCount)
        {
            Id = ++_id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Address = address;
            PackageCount = packageCount;
        }
    }
}
