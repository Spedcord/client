using Newtonsoft.Json;

namespace SpedcordClient
{
    public partial class Company
    {
        [JsonProperty("name")]
        public string name;
    }
}