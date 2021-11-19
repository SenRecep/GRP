using Duende.IdentityServer;
using Duende.IdentityServer.Models;

using GRP.IdentityServer.Services;

using System;
using System.Collections.Generic;

namespace GRP.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_watertankcalculator"){
                Scopes={"watertankcalculator_fullpermission"},
                ApiSecrets=new []{ new Secret("watertankcalculator_secret".Sha256())}},
            new ApiResource("resource_gateway"){
                Scopes={"gateway_fullpermission"},
                ApiSecrets=new []{ new Secret("gateway_secret".Sha256())}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("watertankcalculator_fullpermission","Water Tank Calculator ICIN TUM IZINLER"),
                new ApiScope("gateway_fullpermission","GATEWAY ICIN TUM IZINLER"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new ProfileWithRoleIdentityResource(),
                new IdentityResources.Email(),
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "WebClient_CC",
                    ClientName = "Web Client CC",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("webclient_client_secret".Sha256()) },

                    AllowedScopes =
                    {
                        IdentityServerConstants.LocalApi.ScopeName,
                        "gateway_fullpermission"
                    }
                },

                new Client
                {
                    ClientId = "WebClient_ROP",
                    ClientName = "Web Client ROP",

                    ClientSecrets = { new Secret("webclient_client_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "watertankcalculator_fullpermission",
                        "gateway_fullpermission",
                        "roles"
                    },
                    AccessTokenLifetime =(int)TimeSpan.FromDays(5).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)TimeSpan.FromDays(20).TotalSeconds
                },
                new Client
                {
                    ClientId = "Token_Exchange_Clinet",
                    ClientName = "Token Exchange Clinet",

                    AllowedGrantTypes = new []{"urn:ietf:params:oauth:grant-type:token-exchange"},
                    ClientSecrets = { new Secret("webclient_client_secret".Sha256()) },
                    //todo api dan api a istek yaparken ikinci api tarafinin izilerinin bildirilmesi gerek
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "watertankcalculator_fullpermission"
                    }
                }
            };
    }

}