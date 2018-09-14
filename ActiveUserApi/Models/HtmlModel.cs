using System;
using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
  public class HtmlModel
  {
    [JsonProperty("mac")]
    public string Mac { get; set; }

    [JsonProperty("sc_name")]
    public string ScName { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

  }
}
