﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeAndDo.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}