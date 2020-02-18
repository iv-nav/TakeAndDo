using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeAndDo.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Agent()
        {
            Teams = new List<Team>();
            Orders = new List<Order>();
        }
    }
}