using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration; 

namespace MVC.Repository
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }

        
        public ServiceRepository(IConfiguration configuration)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(configuration["ServiceUrl"]); 
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
