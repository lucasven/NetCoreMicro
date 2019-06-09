using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Events
{
    public class UserAuthenticated : IEvent
    {
        public string Email { get; }

        protected UserAuthenticated()
        {

        }
        public UserAuthenticated(string email)
        {
            Email = email;
        }
    }
}
