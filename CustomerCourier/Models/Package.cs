using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace CustomerCourier.Models
{
    internal class Package
    {

        public string TrackingNumber { get; set; }

        public Customer Sender { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverAddress { get; set; }

        public double Weight { get; set; }

        public Status Status { get; set; }

        public Courier? Courier { get; set; }
    }
}
