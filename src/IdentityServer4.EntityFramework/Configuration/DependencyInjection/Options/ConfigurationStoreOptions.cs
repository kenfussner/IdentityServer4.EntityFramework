// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityServer4.EntityFramework.Configuration
{
    public class ConfigurationStoreOptions
    {
        public string DefaultSchema { get; set; } = Constants.ConfigurationStoreDefaultSchema;

        public ConfigurationStoreDatabaseTableOptions DatabaseTableOptions { get; set; } = new ConfigurationStoreDatabaseTableOptions();
        
        public Action<DbContextOptionsBuilder> DbContextOptionsBuilder { get; set; }
    }
}
