﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Mongo
{
    public class MongoOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public bool Seed { get; set; }
    }
}
