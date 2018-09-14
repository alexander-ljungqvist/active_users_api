using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
  public class NetworkModel
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("mac_addr")]
    public string MacAddr { get; set; }

  }
}
