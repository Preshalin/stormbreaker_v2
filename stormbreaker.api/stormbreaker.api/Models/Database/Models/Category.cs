﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Models.Database.Models
{
    public class Category : Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public virtual User User { get; set; }
    }
}
