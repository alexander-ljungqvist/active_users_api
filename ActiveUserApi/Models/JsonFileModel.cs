using System;
using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
  public class JsonFileModel
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("user_name")]
    public string UserName { get; set; }

    [JsonProperty("mac_addr")]
    public string MacAddr { get; set; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }


  }
}
