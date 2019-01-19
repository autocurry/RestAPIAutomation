using System;
using Xunit;
using RestSharp;
using  RestSharp.Deserializers;

namespace RestAPIAutomation
{
    public class APIAutomation :BaseClass
    {
        public  APIAutomation() : base()
        {
            
        }
        [Fact]
        public void GetAPIAutomation()
        {
          
            var url = "https://reqres.in/";
            var firstname =string.Empty;
            var lastname = string.Empty;

          RestClient _client = new RestClient(url);
          RestRequest _request = new RestRequest("/api/users/2",Method.GET);

          var response = _client.Execute (_request);
          string statusCode = response.StatusCode.ToString();

          if(statusCode.Equals("OK"))
          {

                JsonDeserializer deserial = new JsonDeserializer();
                RootObject _root = deserial.Deserialize<RootObject>(response);

                firstname = _root.data.first_name;
                lastname = _root.data.last_name;

          }

          else{
              Assert.False(false,"status code= "+statusCode);
          }

        }
    }
}
