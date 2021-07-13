using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineCommander.Api.Services
{

    public interface IKeyValueStore 
    {
        Task<bool> Set(string key, string value);
        Task<string> Get(string key);
    }
    public class ImmanuelStore : IKeyValueStore
    {
        private const string KVP_API_KEY = "xzgiu73q";
        public async Task<string> Get(string key)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("", "")
            });


            var client = new HttpClient();
            client.BaseAddress = new Uri("https://keyvalue.immanuel.co/api/KeyVal/GetValue/" + KVP_API_KEY + "/" + key);
                
            var response = await client.GetAsync("");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> Set(string key, string value)
        {
            //try
            //{
                var client = new HttpClient();

                client.BaseAddress = new Uri("https://keyvalue.immanuel.co/api/KeyVal/UpdateValue/" + KVP_API_KEY + "/" + key + "/" + value);
                var requestContent = new StringContent("", Encoding.UTF8, "application/json");
                var response = await client.PostAsync("", requestContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync() == "true";
            //}
            //catch(Exception ex)
           // {
          //      throw;
           //     return false;
          //  }        
        }
    }
}