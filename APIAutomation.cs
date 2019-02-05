using System;
using Xunit;
using RestSharp;
using  RestSharp.Deserializers;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;

namespace RestAPIAutomation
{
    public class APIAutomation :BaseClass
    {
        ResponseClass _responseclass;
        List<ResponseClass> _responselist = new List<ResponseClass>();
        public  APIAutomation() : base()
        {
            
        }
        
        [Fact]
        public void GetAPIAutomation()
        {
            BaseAction action = new BaseAction();
           var AllRequests = action.ReadAllRequests();         
         
         foreach(var item in AllRequests)
         {    

             var requestname = item.Key;
             var value = item.Value.ToString();
             var _requestdetails = JsonConvert.DeserializeObject<Dictionary<string,dynamic>>(value);
             _responseclass = GetResponse(_requestdetails);

             //getting the response of each request           
            _responselist.Add(_responseclass);

            var createhtml = GenerateHtmlMonitorPage(_responselist);
         }
        
        }

      
        public ResponseClass GetResponse(Dictionary<string, dynamic> item)
        {
                    
          RestClient _client = new RestClient(BaseURL);
          _responseclass = new ResponseClass();
          IRestResponse _response;
          RestRequest _request ;    

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
                Stopwatch _stopwatch = new Stopwatch();
                _stopwatch.Start();
                _response = _client.Execute(_request);
                _stopwatch.Stop();

                _responseclass.ResponseTime = _stopwatch.Elapsed.TotalSeconds.ToString();
                _responseclass.StatusCode = _response.StatusCode.ToString();
                _responseclass.Result = _response.ResponseStatus.ToString();
                _responseclass.APIURL = _response.ResponseUri.ToString();
                _responseclass.Response = _response.Content;

                return _responseclass;
        }
               
        }
    }
