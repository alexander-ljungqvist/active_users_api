using System;
using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
    public class DeviceModel
    {

      [JsonProperty("Id")]
      public int Id { get; set; }

      [JsonProperty("Guid")]
      public string Guid { get; set; }

      [JsonProperty("Name")]
      public string Name { get; set; }

      [JsonProperty("Description")]
      public string Description { get; set; }

      [JsonProperty("SerialNumber")]
      public string SerialNumber { get; set; }

      [JsonProperty("ProductID")]
      public string ProductID { get; set; }

      [JsonProperty("Type")]
      public string Type { get; set; }

      [JsonProperty("Make")]
      public string Make { get; set; }

      [JsonProperty("Model")]
      public string Model { get; set; }

      [JsonProperty("OS")]
      public string OS { get; set; }

      [JsonProperty("OSVesion")]
      public string OSVesion { get; set; }

      [JsonProperty("Year")]
      public string Year { get; set; }

      [JsonProperty("AssignedTo")]
      public string AssignedTo { get; set; }

      [JsonProperty("MacAddrEth")]
      public string MacAddrEth { get; set; }

      [JsonProperty("MacAddrWiFi")]
      public string MacAddrWiFi { get; set; }

      [JsonProperty("PurchasedFrom")]
      public string PurchasedFrom { get; set; }

      [JsonProperty("DatePurchased")]
      public string DatePurchased { get; set; }

      [JsonProperty("LeasingNumber")]
      public string LeasingNumber { get; set; }

      [JsonProperty("LeasingExpires")]
      public string LeasingExpires { get; set; }

      [JsonProperty("WarrantyNumber")]
      public string WarrantyNumber { get; set; }

      [JsonProperty("WarrantyExpires")]
      public string WarrantyExpires { get; set; }

      [JsonProperty("Status")]
      public string Status { get; set; }

      [JsonProperty("Comment")]
      public string Comment { get; set; }

      [JsonProperty("CPU")]
      public string CPU { get; set; }

      [JsonProperty("RAM")]
      public string RAM { get; set; }

      [JsonProperty("HDD")]
      public string HDD { get; set; }

      [JsonProperty("IMEI")]
      public string IMEI { get; set; }
    }
    }
