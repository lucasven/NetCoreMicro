using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Events
{
    public class ActivityCreated : IAutheticatedEvent
    {
        public Guid ID { get; }
        public Guid UserId { get; }
        public string Category { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }

        protected ActivityCreated()
        {

        }

        public ActivityCreated(Guid id, Guid userid, string category, string name, string description)
        {
            ID = id;
            UserId = userid;
            Category = category;
            Name = name;
            Description = description;
        }
    }
}
