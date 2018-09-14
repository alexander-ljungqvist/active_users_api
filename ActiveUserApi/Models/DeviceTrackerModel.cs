using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
    public class AttributesDeviceTracker
    {

      [JsonProperty("auto")]
      public bool Auto { get; set; }

      [JsonProperty("entity_id")]
      public IList<string> EntityId { get; set; }

      [JsonProperty("friendly_name")]
      public string FriendlyName { get; set; }

      [JsonProperty("hidden")]
      public bool Hidden { get; set; }

      [JsonProperty("order")]
      public int Order { get; set; }
    }

    public class DeviceTrackerModel
    {

      [JsonProperty("attributes")]
      public AttributesDeviceTracker Attributes { get; set; }

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
