using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class BaseAction{
    string jsonfilepath = @"./Datafiles/requests.json";

public Dictionary<string,dynamic> ReadAllRequests(){

    var json = File.ReadAllText(jsonfilepath);

     var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);  


    return values;

}


}