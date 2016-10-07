// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityServer4.EntityFramework.Configuration
{
    public class ConfigurationStoreDatabaseTables
    {
        public DatabaseTable Scope { get; set; } = new DatabaseTable { Name = "Scopes", Schema = null };
        public DatabaseTable ScopeClaim { get; set; } = new DatabaseTable { Name = "ScopeClaims", Schema = null };
        public DatabaseTable ScopeSecret { get; set; } = new DatabaseTable { Name = "ScopeSecrets", Schema = null };
        public DatabaseTable Client { get; set; } = new DatabaseTable { Name = "Clients", Schema = null };
        public DatabaseTable ClientGrantType { get; set; } = new DatabaseTable { Name = "ClientGrantTypes", Schema = null };
        public DatabaseTable ClientRedirectUri { get; set; } = new DatabaseTable { Name = "ClientRedirectUris", Schema = null };
        public DatabaseTable ClientPostLogoutRedirectUri { get; set; } = new DatabaseTable { Name = "ClientPostLogoutRedirectUris", Schema = null };
        public DatabaseTable ClientScope { get; set; } = new DatabaseTable { Name = "ClientScopes", Schema = null };
        public DatabaseTable ClientSecret { get; set; } = new DatabaseTable { Name = "ClientSecrets", Schema = null };
        public DatabaseTable ClientClaim { get; set; } = new DatabaseTable { Name = "ClientClaims", Schema = null };
        public DatabaseTable ClientIdPRestriction { get; set; } = new DatabaseTable { Name = "ClientIdPRestrictions", Schema = null };
        public DatabaseTable ClientCorsOrigin { get; set; } = new DatabaseTable { Name = "ClientCorsOrigins", Schema = null };
    }
}