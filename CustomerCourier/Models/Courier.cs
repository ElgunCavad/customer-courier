using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCourier.Models
{
    internal class Courier
    {
        
        private static int _id;
        public int Id { get; }

        public string FullName { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int DeliveredCount { get; private set; }

        public Courier(string fullName)
        {
            Id = ++_id;
            FullName = fullName;
        }

        public void IncrementDelivered()
        {
            DeliveredCount++;
        }

    }
}
