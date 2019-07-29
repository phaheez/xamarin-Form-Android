using HelloWorld.Helpers;
using HelloWorld.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public class ApiServices
    {
        private readonly HttpClient client;

        public ApiServices()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatiion/json"));
        }

        public async Task<bool> RegisterAsync(string username, string fullname, string email, string password, string confirmPassword, string phoneNumber)
        {
            var model = new RegisterModel
            {
                UserName = username,
                FullName = fullname,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                PhoneNumber = phoneNumber
            };

            var json = JsonConvert.SerializeObject(model);

            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BASE_URL + "api/account/register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<JsonMessage<object>> LoginAsync(string email, string password)
        {
            var model = new LoginModel
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(model);

            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BASE_URL + "api/account/login", content);

            var jsonResult = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<JsonMessage<object>>(jsonResult);

            Debug.WriteLine(jsonResult);
            Debug.WriteLine(result);

            return result;
        }

        public async Task<T> PostResponse<T>(string url, string jsonString) where T: class
        {
            var token = "";
            string mediaType = "application/json";
            var content = new StringContent(jsonString, Encoding.UTF8, mediaType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.PostAsync(url, content);
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var contentResponse = JsonConvert.DeserializeObject<T>(jsonResult);
            return contentResponse;
        }
    }
}
