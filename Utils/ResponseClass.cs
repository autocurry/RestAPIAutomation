public class ResponseClass{

    public string APIURL { get; set; }
    public string Result { get; set; }
    public string StatusCode { get; set; }
    public string ResponseTime { get; set; }
    public string Response { get; set; }

    public void SetResponseClass(string _apiurl,string _result,string _statuscode,string _responsetime,string _response)
    {
        APIURL = _apiurl;
        Result = _result;
        StatusCode = _statuscode;
        ResponseTime = _responsetime;
        string Response = _response;

    }
}