// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.Configuration;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdentityServer4.EntityFramework.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureClientContext(this ModelBuilder modelBuilder, ConfigurationStoreOptions options)
        {
            if (!string.IsNullOrEmpty(options.DefaultSchema))
            {
                modelBuilder.HasDefaultSchema(options.DefaultSchema);
            }

            modelBuilder.Entity<Client>(client =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.Client.Schema))
                {
                    client.ToTable(options.DatabaseTables.Client.Name).HasKey(x => x.Id);
                }
                else
                {
                    client.ToTable(options.DatabaseTables.Client.Name, options.DatabaseTables.Client.Schema).HasKey(x => x.Id);
                }
                client.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
                client.Property(x => x.ClientName).HasMaxLength(200).IsRequired();
                client.Property(x => x.ClientUri).HasMaxLength(2000);

                client.HasMany(x => x.AllowedGrantTypes).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.RedirectUris).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.PostLogoutRedirectUris).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.AllowedScopes).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.ClientSecrets).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.Claims).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.IdentityProviderRestrictions).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
                client.HasMany(x => x.AllowedCorsOrigins).WithOne(x => x.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ClientGrantType>(grantType =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientGrantType.Schema))
                {
                    grantType.ToTable(options.DatabaseTables.ClientGrantType.Name);
                }
                else
                {
                    grantType.ToTable(options.DatabaseTables.ClientGrantType.Name, options.DatabaseTables.ClientGrantType.Schema);
                }
                grantType.Property(x => x.GrantType).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<ClientRedirectUri>(redirectUri =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientRedirectUri.Schema))
                {
                    redirectUri.ToTable(options.DatabaseTables.ClientRedirectUri.Name);
                }
                else
                {
                    redirectUri.ToTable(options.DatabaseTables.ClientRedirectUri.Name, options.DatabaseTables.ClientRedirectUri.Schema);
                }
                redirectUri.Property(x => x.RedirectUri).HasMaxLength(2000).IsRequired();
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>(postLogoutRedirectUri =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientPostLogoutRedirectUri.Schema))
                {
                    postLogoutRedirectUri.ToTable(options.DatabaseTables.ClientPostLogoutRedirectUri.Name);
                }
                else
                {
                    postLogoutRedirectUri.ToTable(options.DatabaseTables.ClientPostLogoutRedirectUri.Name, options.DatabaseTables.ClientPostLogoutRedirectUri.Schema);
                }
                postLogoutRedirectUri.Property(x => x.PostLogoutRedirectUri).HasMaxLength(2000).IsRequired();
            });

            modelBuilder.Entity<ClientScope>(scope =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientScope.Schema))
                {
                    scope.ToTable(options.DatabaseTables.ClientScope.Name);
                }
                else
                {
                    scope.ToTable(options.DatabaseTables.ClientScope.Name, options.DatabaseTables.ClientScope.Schema);
                }
                scope.Property(x => x.Scope).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<ClientSecret>(secret =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientSecret.Schema))
                {
                    secret.ToTable(options.DatabaseTables.ClientSecret.Name);
                }
                else
                {
                    secret.ToTable(options.DatabaseTables.ClientSecret.Name, options.DatabaseTables.ClientSecret.Schema);
                }
                secret.Property(x => x.Value).HasMaxLength(250).IsRequired();
                secret.Property(x => x.Type).HasMaxLength(250);
                secret.Property(x => x.Description).HasMaxLength(2000);
            });

            modelBuilder.Entity<ClientClaim>(claim =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientClaim.Schema))
                {
                    claim.ToTable(options.DatabaseTables.ClientClaim.Name);
                }
                else
                {
                    claim.ToTable(options.DatabaseTables.ClientClaim.Name, options.DatabaseTables.ClientClaim.Schema);
                }
                claim.Property(x => x.Type).HasMaxLength(250).IsRequired();
                claim.Property(x => x.Value).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<ClientIdPRestriction>(idPRestriction =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientIdPRestriction.Schema))
                {
                    idPRestriction.ToTable(options.DatabaseTables.ClientIdPRestriction.Name);
                }
                else
                {
                    idPRestriction.ToTable(options.DatabaseTables.ClientIdPRestriction.Name, options.DatabaseTables.ClientIdPRestriction.Schema);
                }
                idPRestriction.Property(x => x.Provider).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<ClientCorsOrigin>(corsOrigin =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ClientCorsOrigin.Schema))
                {
                    corsOrigin.ToTable(options.DatabaseTables.ClientCorsOrigin.Name);
                }
                else
                {
                    corsOrigin.ToTable(options.DatabaseTables.ClientCorsOrigin.Name, options.DatabaseTables.ClientCorsOrigin.Schema);
                }
                corsOrigin.Property(x => x.Origin).HasMaxLength(150).IsRequired();
            });
        }

        public static void ConfigurePersistedGrantContext(this ModelBuilder modelBuilder, OperationalStoreOptions options)
        {
            if (!string.IsNullOrEmpty(options.DefaultSchema))
            {
                modelBuilder.HasDefaultSchema(options.DefaultSchema);
            }

            modelBuilder.Entity<PersistedGrant>(grant =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.PersistedGrant.Schema))
                {
                    grant.ToTable(options.DatabaseTables.PersistedGrant.Name);
                }
                else
                {
                    grant.ToTable(options.DatabaseTables.PersistedGrant.Name, options.DatabaseTables.PersistedGrant.Schema);
                }
                grant.HasKey(x => new {x.Key, x.Type});
                grant.Property(x => x.SubjectId);
                grant.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
                grant.Property(x => x.CreationTime).IsRequired();
                grant.Property(x => x.Expiration).IsRequired();
                grant.Property(x => x.Data).IsRequired();
            });
        }

        public static void ConfigureScopeContext(this ModelBuilder modelBuilder, ConfigurationStoreOptions options)
        {
            if (!string.IsNullOrEmpty(options.DefaultSchema))
            {
                modelBuilder.HasDefaultSchema(options.DefaultSchema);
            }

            modelBuilder.Entity<ScopeClaim>(scopeClaim =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ScopeClaim.Schema))
                {
                    scopeClaim.ToTable(options.DatabaseTables.ScopeClaim.Name).HasKey(x => x.Id);
                }
                else
                {
                    scopeClaim.ToTable(options.DatabaseTables.ScopeClaim.Name, options.DatabaseTables.ScopeClaim.Schema).HasKey(x => x.Id);
                }
                scopeClaim.Property(x => x.Name).HasMaxLength(200).IsRequired();
                scopeClaim.Property(x => x.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<ScopeSecret>(scopeSecret =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.ScopeSecret.Schema))
                {
                    scopeSecret.ToTable(options.DatabaseTables.ScopeSecret.Name).HasKey(x => x.Id);
                }
                else
                {
                    scopeSecret.ToTable(options.DatabaseTables.ScopeSecret.Name, options.DatabaseTables.ScopeSecret.Schema).HasKey(x => x.Id);
                }
                scopeSecret.Property(x => x.Description).HasMaxLength(1000);
                scopeSecret.Property(x => x.Type).HasMaxLength(250);
                scopeSecret.Property(x => x.Value).HasMaxLength(250);
            });

            modelBuilder.Entity<Scope>(scope =>
            {
                if (string.IsNullOrEmpty(options.DatabaseTables.Scope.Schema))
                {
                    scope.ToTable(options.DatabaseTables.Scope.Name).HasKey(x => x.Id);
                }
                else
                {
                    scope.ToTable(options.DatabaseTables.Scope.Name, options.DatabaseTables.Scope.Schema).HasKey(x => x.Id);
                }
                scope.Property(x => x.Name).HasMaxLength(200).IsRequired();
                scope.Property(x => x.DisplayName).HasMaxLength(200);
                scope.Property(x => x.Description).HasMaxLength(1000);
                scope.Property(x => x.ClaimsRule).HasMaxLength(200);
                scope.HasMany(x => x.Claims).WithOne(x => x.Scope).IsRequired().OnDelete(DeleteBehavior.Cascade);
                scope.HasMany(x => x.ScopeSecrets).WithOne(x => x.Scope).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
