using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration; // Add this using directive

namespace MVC.Repository
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }

        // Add a constructor that takes IConfiguration as a parameter
        public ServiceRepository(IConfiguration configuration)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(configuration["ServiceUrl"]); // Use the configuration object to get the ServiceUrl
        }

        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }

        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
