﻿using System;
using System.Configuration;
using MongoDB.Bson;

namespace LyphTEC.MongoSimpleMembership.Models
{
    /// <summary>
    /// Represents an OpenAuth or OpenID account
    /// </summary>
    public class OAuthMembership
    {
        /// <summary>
        /// Instantiates a new instance of the <see cref="OAuthMembership"/> class
        /// </summary>
        /// <param name="provider">Provider name</param>
        /// <param name="providerUserId">Provider UserId</param>
        /// <param name="userId">UserId</param>
        public OAuthMembership(string provider, string providerUserId, int userId)
        {
            Check.IsNotNull(provider);
            Check.IsNotNull(providerUserId);

            Provider = provider;
            ProviderUserId = providerUserId;
            UserId = userId;
        }

        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets the provider name
        /// </summary>
        public string Provider { get; private set; }

        /// <summary>
        /// Gets the provider UserId
        /// </summary>
        public string ProviderUserId { get; private set; }

        /// <summary>
        /// Gets the UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets the name of the collection when stored in Mongo. By default it's &quot;webpages_OAuthMembership&quot; (similar to the standard SimpleMembershipProvider in WebMatrix.WebData), but can be overridden in config by app setting &quot;MongoSimpleMembership:OAuthMembershipName&quot;
        /// </summary>
        /// <returns></returns>
        public static string GetCollectionName()
        {
            var name = "webpages_OAuthMembership";
            
            var setting = ConfigurationManager.AppSettings["MongoSimpleMembership:OAuthMembershipName"];
            if (setting != null && !string.IsNullOrWhiteSpace(setting))
                name = setting;

            return name;
        }
    }
}
