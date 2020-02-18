using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAndDo.Models
{
    public class Region
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"({RegionId} {Name})";
        }
    }
}