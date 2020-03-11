﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string categoryName { get; set; }

        public string description { get; set; }

        public List<Car> Cars { get; set; }
    }
}