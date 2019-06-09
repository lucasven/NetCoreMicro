using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.Services.Activities.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        protected Category()
        {
        }

        public Category(string _name)
        {
            Id = Guid.NewGuid();
            Name = _name.ToLowerInvariant();
        }
    }
}
