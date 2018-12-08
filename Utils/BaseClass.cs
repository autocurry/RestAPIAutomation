using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

public class BaseClass
{
    public static IConfiguration APIConfig {get;set;}
    public static string BaseURL {get;set;}
    
    public BaseClass()
    {
        Console.Write("inside base class con");
        var builder = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
                            .SetBasePath(Directory.GetCurrentDirectory())
                                .AddEnvironmentVariables();

            APIConfig = builder.Build();
            BaseURL=APIConfig["BaseURL"]; 
    }

}