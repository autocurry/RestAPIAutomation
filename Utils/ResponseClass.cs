using Newtonsoft.Json;

public class ResponseClass{

    [JsonProperty(PropertyName ="ResponseUri")]
        public string APIURL { get; set; }

    [JsonProperty(PropertyName ="ResponseStatus")]
    public string Result { get; set; }

    [JsonProperty(PropertyName ="StatusCode")]
        public string StatusCode { get; set; }

   // [JsonProperty(PropertyName ="ResponseUri")]
     public string ResponseTime { get; set; }

    [JsonProperty(PropertyName ="Content")]
    public string Response { get; set; }

  
}