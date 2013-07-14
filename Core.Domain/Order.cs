using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }

        public Address ShipmentAddress { get; set; }
    }
}
