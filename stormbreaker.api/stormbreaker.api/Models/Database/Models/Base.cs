using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Models.Database.Models
{
    public class Base
    {
        public DateTime CreatedOn { get; set; }

        public virtual User CreatedBy { get; set; }
   
        public DateTime ModifiedOn { get; set; }

        public virtual User ModifiedBy { get; set; }
    }
}
