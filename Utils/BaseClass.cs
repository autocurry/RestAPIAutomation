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

    public string root = @"./Datafiles";
    
    public BaseClass()
    {
          string jsonfilepath = root+"//appsettings.json";

          var json = File.ReadAllText(jsonfilepath);

          var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);  
            BaseURL=values["BaseURL"]; 
    }

      public bool GenerateJSON(List<ResponseClass> responselist)
        {
            var _list = responselist;
            if(!(_list == null))
            {
                string json = JsonConvert.SerializeObject(_list.ToArray());

                //write string to file
                System.IO.File.WriteAllText(root+"//reponsemonitor.json", json);


            return true;

            }
            else {
                return false;
            }

        }


}