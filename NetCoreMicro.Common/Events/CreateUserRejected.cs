﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Events
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Email { get; set; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateUserRejected()
        {

        }

        public CreateUserRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
