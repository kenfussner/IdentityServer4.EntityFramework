// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace IdentityServer4.EntityFramework.Configuration
{
    public class ConfigurationStoreOptions
    {
        public string DefaultSchema { get; set; }

        public ConfigurationStoreDatabaseTables DatabaseTables { get; set; } = new ConfigurationStoreDatabaseTables();
    }
}
