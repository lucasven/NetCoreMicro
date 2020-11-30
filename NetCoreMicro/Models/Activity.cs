﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.API.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
