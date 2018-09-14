using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
  public class AlarmModel
  {
    [JsonProperty("name_pyramid")]
    public string NamePyramid { get; set; }

    [JsonProperty("state_pyramid")]
    public string StatePyramid { get; set; }

    [JsonProperty("name_petra")]
    public string NamePetra { get; set; }

    [JsonProperty("state_petra")]
    public string StatePetra { get; set; }

  }
}