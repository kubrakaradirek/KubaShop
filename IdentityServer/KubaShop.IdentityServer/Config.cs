﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace KubaShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            //Herbir mikroservis için o mikroservis için bir key belirlendi.
            //ApiResource için tek tek isimlendirme verildi.
            //Key
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission", "CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={ "DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={ "OrderFullPermission" }},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        //Tokenı aldığımız kullanıcıların hangi bilgilerine erişim sağlanacağı belirlendi.
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };
        //Client oluşumu
        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor izinleri
            new Client
            {
                ClientId="KubaShopVisitorId",
                ClientName="Kuba Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,//İzin işleri
                ClientSecrets={new Secret("kubashopsecret".Sha256())},
                AllowedScopes={ "DiscountFullPermission" }//Kapsamlar hangi işlemleri yapacağını belirler.
            },

            //Manager
            new Client
            {
                ClientId="KubaShopManagerId",
                ClientName="Kuba Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("kubashopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
            },

            //Admin
            new Client
            {
                ClientId="KubaShopAdminId",
                ClientName="Kuba Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword, //ResourceOwnerPassword
                ClientSecrets={new Secret("kubashopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600//Token ömrü 
            }
        };
    }
}