﻿using System;

namespace _04.SalesDatabase.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public StoreLocation StoreLocation { get; set; }

        public DateTime Date { get; set; } 

    }
}