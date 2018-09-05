using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Models.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public int UserId { get; set; }
    }
}
