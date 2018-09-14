using System;
using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
  public class AttributesForAlarmModel
  {

    [JsonProperty("changed_by")]
    public object ChangedBy { get; set; }

    [JsonProperty("code_format")]
    public object CodeFormat { get; set; }

    [JsonProperty("friendly_name")]
    public string FriendlyName { get; set; }
  }

  public class HassioAlarmModel
  {

    [JsonProperty("attributes")]
    public AttributesForAlarmModel Attributes { get; set; }

    [JsonProperty("entity_id")]
    public string EntityId { get; set; }

    [JsonProperty("last_changed")]
    public DateTime LastChanged { get; set; }

    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }
  }
}
