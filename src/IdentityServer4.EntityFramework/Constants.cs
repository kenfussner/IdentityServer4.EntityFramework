// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.Configuration;

namespace IdentityServer4.EntityFramework
{
    public static class Constants
    {
        public static string ConfigurationStoreDefaultSchema = null;
        public static string OperationalStoreDefaultSchema = null;

        public static DatabaseTable ScopeTable = new DatabaseTable { Name = "Scopes", Schema = null };
        public static DatabaseTable ScopeClaimTable = new DatabaseTable { Name = "ScopeClaims", Schema = null };
        public static DatabaseTable ScopeSecretTable = new DatabaseTable { Name = "ScopeSecrets", Schema = null };

        public static DatabaseTable PersistedGrantTable = new DatabaseTable { Name = "PersistedGrants", Schema = null };

        public static DatabaseTable ClientTable = new DatabaseTable { Name = "Clients", Schema = null };
        public static DatabaseTable ClientGrantTypeTable = new DatabaseTable { Name = "ClientGrantTypes", Schema = null };
        public static DatabaseTable ClientRedirectUriTable = new DatabaseTable { Name = "ClientRedirectUris", Schema = null };
        public static DatabaseTable ClientPostLogoutRedirectUriTable = new DatabaseTable { Name = "ClientPostLogoutRedirectUris", Schema = null };
        public static DatabaseTable ClientScopeTable = new DatabaseTable { Name = "ClientScopes", Schema = null };
        public static DatabaseTable ClientSecretTable = new DatabaseTable { Name = "ClientSecrets", Schema = null };
        public static DatabaseTable ClientClaimTable = new DatabaseTable { Name = "ClientClaims", Schema = null };
        public static DatabaseTable ClientIdPRestrictionTable = new DatabaseTable { Name = "ClientIdPRestrictions", Schema = null };
        public static DatabaseTable ClientCorsOriginTable = new DatabaseTable { Name = "ClientCorsOrigins", Schema = null };
    }
}