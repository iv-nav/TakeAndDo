using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAndDo.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Index]
        public int ApplicationUserId { get; set; }
        [Index]
        public int AgentId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Agent Agent { get; set; }
    }
}