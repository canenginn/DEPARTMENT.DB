using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.WEB.Services
{
    public class Service
    {
        public object Post(object datas, string token, string route)
        {
            try
            {
                using (var client = new HttpClient())
                {
                
                    //client.BaseAddress = new Uri("https://localhost:5095/api/"); //local 
                    client.BaseAddress = new Uri("http://localhost:5095/api/"); //IIS

                    if (!String.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(datas);
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(route, requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else { return null; }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public object Get(string token, string route)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    //client.BaseAddress = new Uri("https://localhost:5095/api/"); //local 
                    client.BaseAddress = new Uri("http://localhost:5095/api/"); //IIS


                    if (!String.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var response = client.GetAsync(route).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else { return null; }

                }

            }
            catch (Exception ex)
            {
                return null;

            }

        }
    }
}
