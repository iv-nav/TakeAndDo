using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAndDo.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Index]
        public int AgentId { get; set; }
        [Index]
        public int TenderId { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Tender Tender { get; set; }
    }
}