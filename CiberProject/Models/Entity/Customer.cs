using System;
using System.Collections.Generic;

namespace CiberProject.Models.Entity
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
