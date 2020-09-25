using Newtonsoft.Json;

namespace SpedcordClient.api
{
    public partial class ShopItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("price")]
        public double Price { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Price;
        }
    }
}