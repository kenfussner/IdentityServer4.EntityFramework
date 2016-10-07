// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Configuration;

namespace IdentityServer4.EntityFramework.DbContexts
{
    public class ConfigurationDbContext : DbContext, IConfigurationDbContext
    {
        private ConfigurationStoreOptions _configurationStoreOptions;

        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options) : this(options, null) { }

        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options, ConfigurationStoreOptions configurationStoreOptions) 
            : base(options)
        {
            _configurationStoreOptions = configurationStoreOptions ?? new ConfigurationStoreOptions();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Scope> Scopes { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureClientContext(_configurationStoreOptions);
            modelBuilder.ConfigureScopeContext(_configurationStoreOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}