using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpedcordClient
{
    public partial class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("discordId")]
        public long DiscordId { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("oauth")]
        public Oauth Oauth { get; set; }
    }

    public partial class Oauth
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}