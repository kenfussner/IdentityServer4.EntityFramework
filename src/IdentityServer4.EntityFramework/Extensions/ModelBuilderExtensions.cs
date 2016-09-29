// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdentityServer4.EntityFramework.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureClientContext(this ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrEmpty(Constants.OperationalStoreDefaultSchema))
            {
                modelBuilder.HasDefaultSchema(Constants.OperationalStoreDefaultSchema);
            }

            modelBuilder.Entity<Client>(client =>
            {
                if (string.IsNullOrEmpty(Constants.ClientTable.Schema))
                {
                    client.ToTable(Constants.ClientTable.Name).HasKey(x => x.Id);
                }
                else
                {
                    client.ToTable(Constants.ClientTable.Name, Constants.ClientTable.Schema).HasKey(x => x.Id);
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
                if (string.IsNullOrEmpty(Constants.ClientGrantTypeTable.Schema))
                {
                    grantType.ToTable(Constants.ClientGrantTypeTable.Name);
                }
                else
                {
                    grantType.ToTable(Constants.ClientGrantTypeTable.Name, Constants.ClientGrantTypeTable.Schema);
                }
                grantType.Property(x => x.GrantType).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<ClientRedirectUri>(redirectUri =>
            {
                if (string.IsNullOrEmpty(Constants.ClientRedirectUriTable.Schema))
                {
                    redirectUri.ToTable(Constants.ClientRedirectUriTable.Name);
                }
                else
                {
                    redirectUri.ToTable(Constants.ClientRedirectUriTable.Name, Constants.ClientRedirectUriTable.Schema);
                }
                redirectUri.Property(x => x.RedirectUri).HasMaxLength(2000).IsRequired();
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>(postLogoutRedirectUri =>
            {
                if (string.IsNullOrEmpty(Constants.ClientPostLogoutRedirectUriTable.Schema))
                {
                    postLogoutRedirectUri.ToTable(Constants.ClientPostLogoutRedirectUriTable.Name);
                }
                else
                {
                    postLogoutRedirectUri.ToTable(Constants.ClientPostLogoutRedirectUriTable.Name, Constants.ClientPostLogoutRedirectUriTable.Schema);
                }
                postLogoutRedirectUri.Property(x => x.PostLogoutRedirectUri).HasMaxLength(2000).IsRequired();
            });

            modelBuilder.Entity<ClientScope>(scope =>
            {
                if (string.IsNullOrEmpty(Constants.ClientScopeTable.Schema))
                {
                    scope.ToTable(Constants.ClientScopeTable.Name);
                }
                else
                {
                    scope.ToTable(Constants.ClientScopeTable.Name, Constants.ClientScopeTable.Schema);
                }
                scope.Property(x => x.Scope).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<ClientSecret>(secret =>
            {
                if (string.IsNullOrEmpty(Constants.ClientSecretTable.Schema))
                {
                    secret.ToTable(Constants.ClientSecretTable.Name);
                }
                else
                {
                    secret.ToTable(Constants.ClientSecretTable.Name, Constants.ClientSecretTable.Schema);
                }
                secret.Property(x => x.Value).HasMaxLength(250).IsRequired();
                secret.Property(x => x.Type).HasMaxLength(250);
                secret.Property(x => x.Description).HasMaxLength(2000);
            });

            modelBuilder.Entity<ClientClaim>(claim =>
            {
                if (string.IsNullOrEmpty(Constants.ClientClaimTable.Schema))
                {
                    claim.ToTable(Constants.ClientClaimTable.Name);
                }
                else
                {
                    claim.ToTable(Constants.ClientClaimTable.Name, Constants.ClientClaimTable.Schema);
                }
                claim.Property(x => x.Type).HasMaxLength(250).IsRequired();
                claim.Property(x => x.Value).HasMaxLength(250).IsRequired();
            });

            modelBuilder.Entity<ClientIdPRestriction>(idPRestriction =>
            {
                if (string.IsNullOrEmpty(Constants.ClientIdPRestrictionTable.Schema))
                {
                    idPRestriction.ToTable(Constants.ClientIdPRestrictionTable.Name);
                }
                else
                {
                    idPRestriction.ToTable(Constants.ClientIdPRestrictionTable.Name, Constants.ClientIdPRestrictionTable.Schema);
                }
                idPRestriction.Property(x => x.Provider).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<ClientCorsOrigin>(corsOrigin =>
            {
                if (string.IsNullOrEmpty(Constants.ClientCorsOriginTable.Schema))
                {
                    corsOrigin.ToTable(Constants.ClientCorsOriginTable.Name);
                }
                else
                {
                    corsOrigin.ToTable(Constants.ClientCorsOriginTable.Name, Constants.ClientCorsOriginTable.Schema);
                }
                corsOrigin.Property(x => x.Origin).HasMaxLength(150).IsRequired();
            });
        }

        public static void ConfigurePersistedGrantContext(this ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrEmpty(Constants.ConfigurationStoreDefaultSchema))
            {
                modelBuilder.HasDefaultSchema(Constants.ConfigurationStoreDefaultSchema);
            }

            modelBuilder.Entity<PersistedGrant>(grant =>
            {
                if (string.IsNullOrEmpty(Constants.PersistedGrantTable.Schema))
                {
                    grant.ToTable(Constants.PersistedGrantTable.Name);
                }
                else
                {
                    grant.ToTable(Constants.PersistedGrantTable.Name, Constants.PersistedGrantTable.Schema);
                }
                grant.HasKey(x => new {x.Key, x.Type});
                grant.Property(x => x.SubjectId);
                grant.Property(x => x.ClientId).HasMaxLength(200).IsRequired();
                grant.Property(x => x.CreationTime).IsRequired();
                grant.Property(x => x.Expiration).IsRequired();
                grant.Property(x => x.Data).IsRequired();
            });
        }

        public static void ConfigureScopeContext(this ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrEmpty(Constants.OperationalStoreDefaultSchema))
            {
                modelBuilder.HasDefaultSchema(Constants.OperationalStoreDefaultSchema);
            }

            modelBuilder.Entity<ScopeClaim>(scopeClaim =>
            {
                if (string.IsNullOrEmpty(Constants.ScopeClaimTable.Schema))
                {
                    scopeClaim.ToTable(Constants.ScopeClaimTable.Name).HasKey(x => x.Id);
                }
                else
                {
                    scopeClaim.ToTable(Constants.ScopeClaimTable.Name, Constants.ScopeClaimTable.Schema).HasKey(x => x.Id);
                }
                scopeClaim.Property(x => x.Name).HasMaxLength(200).IsRequired();
                scopeClaim.Property(x => x.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<ScopeSecret>(scopeSecret =>
            {
                if (string.IsNullOrEmpty(Constants.ScopeSecretTable.Schema))
                {
                    scopeSecret.ToTable(Constants.ScopeSecretTable.Name).HasKey(x => x.Id);
                }
                else
                {
                    scopeSecret.ToTable(Constants.ScopeSecretTable.Name, Constants.ScopeSecretTable.Schema).HasKey(x => x.Id);
                }
                scopeSecret.Property(x => x.Description).HasMaxLength(1000);
                scopeSecret.Property(x => x.Type).HasMaxLength(250);
                scopeSecret.Property(x => x.Value).HasMaxLength(250);
            });

            modelBuilder.Entity<Scope>(scope =>
            {
                if (string.IsNullOrEmpty(Constants.ScopeTable.Schema))
                {
                    scope.ToTable(Constants.ScopeTable.Name).HasKey(x => x.Id);
                }
                else
                {
                    scope.ToTable(Constants.ScopeTable.Name, Constants.ScopeTable.Schema).HasKey(x => x.Id);
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
