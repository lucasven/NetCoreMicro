using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
