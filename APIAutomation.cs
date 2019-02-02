using System;
using Xunit;
using RestSharp;
using  RestSharp.Deserializers;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            BaseAction action = new BaseAction();
           var AllRequests = action.ReadAllRequests();
           IRestResponse response;
           List<ResponseClass> _responselist;
           ResponseClass _responseclass;
         
         foreach(var item in AllRequests)
         {
             _responselist = new List<ResponseClass>();
             _responseclass = new ResponseClass();

             var requestname = item.Key;
             var value = item.Value.ToString();
             var _requestdetails = JsonConvert.DeserializeObject<Dictionary<string,string>>(value);
             response = GetResponse(_requestdetails);

             //getting the response of each request
            _responseclass.StatusCode = response.StatusCode.ToString();
            _responseclass.Result = response.ResponseStatus.ToString();
            _responseclass.APIURL = response.ResponseUri.ToString();
            _responseclass.Response = response.Content;



         }




        }

        private IRestResponse GetResponse(Dictionary<string, string> item)
        {
                    
          RestClient _client = new RestClient(BaseURL);
          
          RestRequest _request ;       
          IRestResponse _response; 

            var requestmethod = string.Empty;
            if(item.Keys.Count>1)
            {
             requestmethod = item["requestmethod"];
            }

            switch(requestmethod)
            {
                case "POST":
                _request = new RestRequest(item["requesturl"],Method.POST);
                break;

                case "PUT":
                _request = new RestRequest(item["requesturl"],Method.PUT);
                break;

                case "DELETE":
                _request = new RestRequest(item["requesturl"],Method.DELETE);
                break;

                default:
                _request = new RestRequest(item["requesturl"],Method.GET);
                break;

            }
              _response = _client.Execute(_request);
          
                return _response;
               
        }
    }
}
