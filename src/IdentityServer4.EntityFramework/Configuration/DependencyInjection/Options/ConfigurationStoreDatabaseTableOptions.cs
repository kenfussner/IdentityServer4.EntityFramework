// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityServer4.EntityFramework.Configuration
{
    public class ConfigurationStoreDatabaseTableOptions
    {
        public DatabaseTable Scope { get; set; } = Constants.ScopeTable;
        public DatabaseTable ScopeClaim { get; set; } = Constants.ScopeClaimTable;
        public DatabaseTable ScopeSecret { get; set; } = Constants.ScopeSecretTable;
        public DatabaseTable Client { get; set; } = Constants.ClientTable;
        public DatabaseTable ClientGrantType { get; set; } = Constants.ClientGrantTypeTable;
        public DatabaseTable ClientRedirectUri { get; set; } = Constants.ClientRedirectUriTable;
        public DatabaseTable ClientPostLogoutRedirectUri { get; set; } = Constants.ClientPostLogoutRedirectUriTable;
        public DatabaseTable ClientScope { get; set; } = Constants.ClientScopeTable;
        public DatabaseTable ClientSecret { get; set; } = Constants.ClientSecretTable;
        public DatabaseTable ClientClaim { get; set; } = Constants.ClientClaimTable;
        public DatabaseTable ClientIdPRestriction { get; set; } = Constants.ClientIdPRestrictionTable;
        public DatabaseTable ClientCorsOrigin { get; set; } = Constants.ClientCorsOriginTable;
    }
}