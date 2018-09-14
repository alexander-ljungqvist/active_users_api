using System;
using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
  public class Attributes
  {

    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("_is_guest_by_uap")]
    public bool IsGuestByUap { get; set; }

    [JsonProperty("_last_seen_by_uap")]
    public long LastSeenByUap { get; set; }

    [JsonProperty("_uptime_by_uap")]
    public long UptimeByUap { get; set; }

    [JsonProperty("ap_mac")]
    public string ApMac { get; set; }

    [JsonProperty("assoc_time")]
    public long AssocTime { get; set; }

    [JsonProperty("bssid")]
    public string Bssid { get; set; }

    [JsonProperty("bytes-r")]
    public long BytesR { get; set; }

    [JsonProperty("ccq")]
    public long Ccq { get; set; }

    [JsonProperty("channel")]
    public long Channel { get; set; }

    [JsonProperty("essid")]
    public string Essid { get; set; }

    [JsonProperty("first_seen")]
    public long FirstSeen { get; set; }

    [JsonProperty("friendly_name")]
    public string FriendlyName { get; set; }

    [JsonProperty("hostname")]
    public string Hostname { get; set; }

    [JsonProperty("idletime")]
    public long Idletime { get; set; }

    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("is_guest")]
    public bool IsGuest { get; set; }

    [JsonProperty("is_wired")]
    public bool IsWired { get; set; }

    [JsonProperty("last_seen")]
    public long LastSeen { get; set; }

    [JsonProperty("latest_assoc_time")]
    public long LatestAssocTime { get; set; }

    [JsonProperty("mac")]
    public string Mac { get; set; }

    [JsonProperty("noise")]
    public long Noise { get; set; }

    [JsonProperty("oui")]
    public string Oui { get; set; }

    [JsonProperty("powersave_enabled")]
    public bool PowersaveEnabled { get; set; }

    [JsonProperty("qos_policy_applied")]
    public bool QosPolicyApplied { get; set; }

    [JsonProperty("radio")]
    public string Radio { get; set; }

    [JsonProperty("radio_proto")]
    public string RadioProto { get; set; }

    [JsonProperty("roam_count")]
    public long RoamCount { get; set; }

    [JsonProperty("rssi")]
    public long Rssi { get; set; }

    [JsonProperty("rx_bytes")]
    public long RxBytes { get; set; }

    [JsonProperty("rx_bytes-r")]
    public long RxBytesR { get; set; }

    [JsonProperty("rx_packets")]
    public long RxPackets { get; set; }

    [JsonProperty("rx_rate")]
    public long RxRate { get; set; }

    [JsonProperty("scanner")]
    public string Scanner { get; set; }

    [JsonProperty("signal")]
    public long Signal { get; set; }

    [JsonProperty("site_id")]
    public string SiteId { get; set; }

    [JsonProperty("source_type")]
    public string SourceType { get; set; }

    [JsonProperty("tx_bytes")]
    public long TxBytes { get; set; }

    [JsonProperty("tx_bytes-r")]
    public long TxBytesR { get; set; }

    [JsonProperty("tx_packets")]
    public long TxPackets { get; set; }

    [JsonProperty("tx_power")]
    public long TxPower { get; set; }

    [JsonProperty("tx_rate")]
    public long TxRate { get; set; }

    [JsonProperty("uptime")]
    public long Uptime { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("vlan")]
    public long Vlan { get; set; }
  }

  public class HassioModel
  {

    [JsonProperty("attributes")]
    public Attributes Attributes { get; set; }

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
