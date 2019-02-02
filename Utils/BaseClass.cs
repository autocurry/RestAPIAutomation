using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class BaseClass
{
    public static IConfiguration APIConfig {get;set;}
    public static string BaseURL {get;set;}
    
    public BaseClass()
    {
          string jsonfilepath = @"./Datafiles/appsettings.json";

          var json = File.ReadAllText(jsonfilepath);

          var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);  
            BaseURL=values["BaseURL"]; 
    }

}