using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace OrbitCity.API.Client
{
    public class Telldus
    {
        private string Url;
        private HttpClient Hc;

        public Telldus(string url)
        {
            this.Url = url;
            this.Hc = new HttpClient();
            Hc.BaseAddress = new Uri(url);
            Hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public T Get<T>(string path)
        {
            HttpResponseMessage rsp = Hc.GetAsync(path).Result;
            rsp.EnsureSuccessStatusCode(); //TODO catch 
            return rsp.Content.ReadAsAsync<T>().Result;
        }

        public T Post<T,D>(string path, D data)
        {
            HttpResponseMessage rsp = Hc.PostAsJsonAsync<D>(path, data).Result;
            rsp.EnsureSuccessStatusCode(); //TODO catch 
            return rsp.Content.ReadAsAsync<T>().Result;
        }
    }
}
