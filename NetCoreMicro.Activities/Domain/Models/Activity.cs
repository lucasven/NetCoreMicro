using NetCoreMicro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.Services.Activities.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }


        protected Activity()
        {
        }

        public Activity(Guid _id, Category _category, Guid _userId, string _name, string _description, DateTime _createdat)
        {
            if(string.IsNullOrEmpty(_name))
            {
                throw new NetCoreMicroException("empty_activity_name",
                    $"Activity name cannot be empty.");
            }

            Id = _id;
            Category = _category.Name;
            UserId = _userId;
            Name = _name;
            Description = _description;
            CreatedAt = _createdat;

        }
    }
}
