﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
