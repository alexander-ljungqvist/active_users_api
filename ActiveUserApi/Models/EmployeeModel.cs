using System;
using Newtonsoft.Json;

namespace ActiveUserApi.Models
{
  public class EmployeeModel
  {
    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("Guid")]
    public string Guid { get; set; }

    [JsonProperty("EmployeeId")]
    public string EmployeeId { get; set; }

    [JsonProperty("FirstName")]
    public string FirstName { get; set; }

    [JsonProperty("LastName")]
    public string LastName { get; set; }

    [JsonProperty("DisplayName")]
    public string DisplayName { get; set; }

    [JsonProperty("Username")]
    public string Username { get; set; }

    [JsonProperty("UPN")]
    public string UPN { get; set; }

    [JsonProperty("Password")]
    public object Password { get; set; }

    [JsonProperty("EmailAddress")]
    public string EmailAddress { get; set; }

    [JsonProperty("WorkMobile")]
    public string WorkMobile { get; set; }

    [JsonProperty("WorkPhone")]
    public object WorkPhone { get; set; }

    [JsonProperty("JobTitle")]
    public string JobTitle { get; set; }

    [JsonProperty("Department")]
    public string Department { get; set; }

    [JsonProperty("Company")]
    public string Company { get; set; }

    [JsonProperty("CompanyCarRegNo")]
    public object CompanyCarRegNo { get; set; }

    [JsonProperty("RefManager")]
    public object RefManager { get; set; }

    [JsonProperty("AlarmPermssions")]
    public object AlarmPermssions { get; set; }

    [JsonProperty("PersonInAlarm")]
    public object PersonInAlarm { get; set; }

    [JsonProperty("DateHired")]
    public object DateHired { get; set; }

    [JsonProperty("DateLeft")]
    public object DateLeft { get; set; }

    [JsonProperty("PrivateMobile")]
    public object PrivateMobile { get; set; }

    [JsonProperty("PrivateEmail")]
    public object PrivateEmail { get; set; }

    [JsonProperty("AllowedEmail")]
    public bool AllowedEmail { get; set; }

    [JsonProperty("AllowedFileServer")]
    public bool AllowedFileServer { get; set; }

    [JsonProperty("AllowedOfficeAccess")]
    public bool AllowedOfficeAccess { get; set; }

    [JsonProperty("AllowedNetwork")]
    public bool AllowedNetwork { get; set; }

    [JsonProperty("AllowedPhone")]
    public bool AllowedPhone { get; set; }

    [JsonProperty("AllowedVPN")]
    public bool AllowedVPN { get; set; }

    [JsonProperty("IsExternal")]
    public bool IsExternal { get; set; }

    [JsonProperty("SignedNDA")]
    public bool SignedNDA { get; set; }

    [JsonProperty("TrackableID")]
    public object TrackableID { get; set; }

  }
}
