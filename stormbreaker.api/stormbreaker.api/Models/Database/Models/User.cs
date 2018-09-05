using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Models.Database.Models
{
    public class User
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual User CreatedBy { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstNames { get; set; }

        public string LastName { get; set; }
    }
}
