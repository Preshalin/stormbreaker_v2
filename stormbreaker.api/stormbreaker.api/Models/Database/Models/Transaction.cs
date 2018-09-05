using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Models.Database.Models
{
    public class Transaction : Base
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public virtual Account Account { get; set; }

        public virtual Category Category { get; set; }
    }
}
