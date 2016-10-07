﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace IdentityServer4.EntityFramework.Configuration
{
    public class OperationalStoreOptions
    {
        public string DefaultSchema { get; set; }

        public OperationalStoreDatabaseTables DatabaseTables { get; set; } = new OperationalStoreDatabaseTables();
    }
}