﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDecription { get; set; }

        public string LongtDecription { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
