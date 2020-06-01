using Newtonsoft.Json;

namespace SpedcordClient
{
    public partial class Job
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("startedAt")]
        public long StartedAt { get; set; }

        [JsonProperty("endedAt")]
        public long EndedAt { get; set; }

        [JsonProperty("cargoWeight")]
        public double CargoWeight { get; set; }

        [JsonProperty("pay")]
        public double Pay { get; set; }

        [JsonProperty("fromCity")]
        public string FromCity { get; set; }

        [JsonProperty("toCity")]
        public string ToCity { get; set; }

        [JsonProperty("cargo")]
        public string Cargo { get; set; }

        [JsonProperty("truck")]
        public string Truck { get; set; }
    }
}