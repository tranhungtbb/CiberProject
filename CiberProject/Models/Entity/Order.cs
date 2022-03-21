﻿using System;
using System.Collections.Generic;

namespace CiberProject.Models.Entity
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? Customer { get; set; }
        public int? Product { get; set; }
        public int? Amout { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderName { get; set; }
    }
}
