using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Events
{
    public interface IAutheticatedEvent : IEvent
    {
        Guid UserId { get; }
    }
}
