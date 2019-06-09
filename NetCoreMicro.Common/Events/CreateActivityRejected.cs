using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Events
{
    public class CreateActivityRejected : IRejectedEvent
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public string Code { get; set; }

        protected CreateActivityRejected()
        {

        }

        public CreateActivityRejected(Guid id,
            string code, string reason)
        {
            Id = id;
            Code = code;
            Reason = reason;
        }
    }
}
