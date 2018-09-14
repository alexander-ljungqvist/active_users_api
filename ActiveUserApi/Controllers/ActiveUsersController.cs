using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ActiveUserApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Web.Http.Cors;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ActiveUserApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActiveUsersController : ControllerBase
  {
    // GET api/activeusers
    [HttpGet]
    public ActionResult<string> Get()
    {
      InitiateAPI();
      var activeUsers = DisplayPhoneStatus();
      return activeUsers;

    }

    // GET api/activeusers/5
    [HttpGet("{mqtt}")]
    public ActionResult<string> Get(string mqtt)
    {
      InitiateAPI();
      PostMqtt();
      return "Sending mqtt...";
    }

    public void InitiateAPI()
    {
      List<JsonFileModel> modelOfJson = new List<JsonFileModel>();

      var employeeList = getEmployees();

      var deviceList = getDeviceModels();

      foreach (var employeeValue in employeeList)
      {
        foreach (var deviceModelValue in deviceList)
        {
          if (employeeValue.Username == deviceModelValue.AssignedTo && deviceModelValue.Type == "Mobile Phone")
          {
            JsonFileModel newEntry = new JsonFileModel();

            newEntry.Name = employeeValue.DisplayName; 

            newEntry.UserName = employeeValue.Username; 

            newEntry.MacAddr = deviceModelValue.MacAddrWiFi;

            newEntry.PhoneNumber = employeeValue.WorkMobile;

            modelOfJson.Add(newEntry);
          }
        }
      }

      string jsonModelString = JsonConvert.SerializeObject(modelOfJson.ToArray());

      System.IO.File.Delete(@"JSON_structure/employees.txt");

      System.IO.File.WriteAllText(@"JSON_structure/employees.txt", jsonModelString);
    }

    public string DisplayPhoneStatus()
    {
      
      var listOfActiveUsers = FindActiveUsers();

      var JsonActiveUsers = JsonConvert.SerializeObject(listOfActiveUsers);

      return JsonActiveUsers;
    }

    public void PostMqtt()
    {
      var listOfActiveUsers = FindActiveUsers();

      var alarmStatus = FindAlarmStatus();

      var mqttList = JsonConvert.SerializeObject(listOfActiveUsers);

      SendToMqtt(mqttList, "Securitas/sms/People");

      SendToMqtt(alarmStatus, "Securitas/sms/Status");

    }

    public void SendToMqtt(string mqtt, string adr)
    {
      MqttClient client = new MqttClient("172.16.8.233");

      byte code = client.Connect(Guid.NewGuid().ToString());

      client.ProtocolVersion = MqttProtocolVersion.Version_3_1;

      client.MqttMsgPublished += client_MqttMsgPublished;

      ushort msgId = client.Publish(adr, // topic
                                    Encoding.UTF8.GetBytes(mqtt), // message body
                                    MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // QoS level
                                    false); // retained

      void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
      {

        Debug.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);

      }

    }

    public string FindAlarmStatus()
    {
      var request = new RestRequest(Method.GET);

      request.AddHeader("Content-Type", "application/json");

      var clientPyramidAlarm = new RestClient("http://172.16.119.13:8123/api/states/alarm_control_panel.pyramid");

      var clientPetraAlarm = new RestClient("http://172.16.119.13:8123/api/states/alarm_control_panel.petra");

      IRestResponse responeFromPyramid = clientPyramidAlarm.Execute(request);

      IRestResponse responseFromPetra = clientPetraAlarm.Execute(request);

      var contentForPyramid = responeFromPyramid.Content; // raw content as string

      var contentForPetra = responseFromPetra.Content; // raw content as string

      var modelForAlarm = new AlarmModel();

      var modelContentPyramid = JsonConvert.DeserializeObject<HassioAlarmModel>(contentForPyramid);

      var modelContentPetra = JsonConvert.DeserializeObject<HassioAlarmModel>(contentForPetra);

      modelForAlarm.NamePyramid = modelContentPyramid.Attributes.FriendlyName;

      modelForAlarm.StatePyramid = modelContentPyramid.State;

      modelForAlarm.NamePetra = modelContentPetra.Attributes.FriendlyName;

      modelForAlarm.StatePetra = modelContentPetra.State;

      var alarmString = JsonConvert.SerializeObject(modelForAlarm);


      return alarmString;
    }


    public List<HassioModel> GroupAllDevices()
    {
      List<string> riplist = new List<string>();

      List<DeviceModel> dmList = new List<DeviceModel>();

      var hassioModel = new List<HassioModel>();
     
      var client = new RestClient();

      try
      {
        client = new RestClient("http://172.16.119.13:8123/api/states/group.all_devices");
      }
      catch (Exception e)
      {
        Console.WriteLine("Hass IO dead" + e);
        Environment.Exit(0);
      }
      
      // client.Authenticator = new HttpBasicAuthenticator(username, password);

      var request = new RestRequest(Method.GET);

      // easily add HTTP Headers
      request.AddHeader("Content-Type", "application/json");

      IRestResponse response = client.Execute(request);

      string content = response.Content; // raw content as string

      var modelFromHass = JsonConvert.DeserializeObject<DeviceTrackerModel>(content);

      foreach (var deviceTrackerName in modelFromHass.Attributes.EntityId)
      {
        var deviceTrackerQuery = new RestClient("http://172.16.119.13:8123/api/states/" + deviceTrackerName);

        IRestResponse responseDeviceTracker = deviceTrackerQuery.Execute(request);

        var contentForDeviceTracker = responseDeviceTracker.Content; // raw content as string

        var convertedHassio = JsonConvert.DeserializeObject<HassioModel>(contentForDeviceTracker);

        hassioModel.Add(convertedHassio);

      }
     
      return hassioModel;
    }

    public List<DeviceModel> getDeviceModels()
    {
      List<DeviceModel> dmList = new List<DeviceModel>();

      var requestToInventory = new RestClient("http://inventory.pyramid.se/api/DevicesApi");

      var request = new RestRequest(Method.GET);

      IRestResponse responseForDeviceModel = requestToInventory.Execute(request);

      var contentForDeviceModel = responseForDeviceModel.Content; // raw content as string

      dmList = JsonConvert.DeserializeObject<List<DeviceModel>>(contentForDeviceModel);

      return dmList;
    }

    public List<EmployeeModel> getEmployees()
    {
      var employeeList = new List<EmployeeModel>();

      var employeeRequest = new RestClient("http://inventory.pyramid.se/api/EmployeesApi");

      var request = new RestRequest(Method.GET);

      IRestResponse responseForEmployeeRequest = employeeRequest.Execute(request);

      var response_employee_req = responseForEmployeeRequest.Content;

      employeeList = JsonConvert.DeserializeObject<List<EmployeeModel>>(response_employee_req);

      var empList = employeeList.OrderBy(a => a.Username).ToList();

      return empList;
    }

    public List<HtmlModel> FindActiveUsers()
    {
      var hassioModel = GroupAllDevices();

      List<HtmlModel> activeUsers = new List<HtmlModel>();

      var jsonArr = JsonConvert.DeserializeObject<List<JsonFileModel>>(System.IO.File.ReadAllText(@"JSON_structure/employees.txt"));
      var networks = JsonConvert.DeserializeObject<List<NetworkModel>>(System.IO.File.ReadAllText(@"JSON_structure/networks.txt"));

      foreach (var jsonVal in jsonArr)
      {
        foreach (var hassioValue in hassioModel)
        {
          foreach (var networkVal in networks)
          {
            if (jsonVal.MacAddr == hassioValue.Attributes.Mac && hassioValue.Attributes.ApMac == networkVal.MacAddr && hassioValue.State =="home")
            {
              var data = new HtmlModel();

              data.Mac = hassioValue.Attributes.Mac;

              data.ScName = jsonVal.UserName;

              data.Name = jsonVal.Name;

              data.State = hassioValue.State;

              data.Location = networkVal.Name.Substring(0, 3);

              data.PhoneNumber = jsonVal.PhoneNumber;

              activeUsers.Add(data);
            }
          }

        }

      }
      return activeUsers;

    }
  }

}
