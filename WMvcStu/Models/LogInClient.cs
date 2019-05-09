using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WMvcPro.Models
{
    public class LogInClient
    {
        private string Base_URL = "http://localhost:24335/api/";

        public LogIn Create(LogIn logIn)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("LogIn", logIn).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<LogIn>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }

    }
}