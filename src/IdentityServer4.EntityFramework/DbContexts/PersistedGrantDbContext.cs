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
    public class PersistedGrantDbContext : DbContext, IPersistedGrantDbContext
    {
        OperationalStoreOptions _operationalStoreOptions;

        public PersistedGrantDbContext(DbContextOptions<PersistedGrantDbContext> options) : this(options, null) { }

        public PersistedGrantDbContext(DbContextOptions<PersistedGrantDbContext> options, OperationalStoreOptions operationalStoreOptions) 
            : base(options)
        {
            _operationalStoreOptions = operationalStoreOptions ?? new OperationalStoreOptions();
        }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurePersistedGrantContext(_operationalStoreOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}