using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAndDo.Models
{
    [Table("TenderCategories")]
    public class TenderCategory
    {
        public int TenderCategoryId { get; set; }
        public string Name { get; set; }
    }
}