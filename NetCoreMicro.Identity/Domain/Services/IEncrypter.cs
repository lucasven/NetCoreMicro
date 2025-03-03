﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.Services.Identity.Domain.Services
{
    public interface IEncrypter
    {
        string GetSalt();
        string GetHash(string value, string salt);
    }
}
