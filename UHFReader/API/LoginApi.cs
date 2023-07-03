using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UHFReader.API
{
    public class LoginApi
    {
       public static LoginResponse loginResponse = new LoginResponse();

        public async void Login()
        {
            var options = new RestClientOptions("https://uat-cityparking-idp.vetc.com.vn")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/auth/realms/plx/protocol/openid-connect/token", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Basic cGx4OjExMmNiY2FjLTI1NDEtNGFlNS1iODlhLTVkNDE3N2MzNmY2Yw==");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "admin");
            request.AddParameter("password", "admin");
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://uat-cityparking-idp.vetc.com.vn/auth/realms/plx/protocol/openid-connect/token");
            //request.Headers.Add("Authorization", "Basic cGx4OjExMmNiY2FjLTI1NDEtNGFlNS1iODlhLTVkNDE3N2MzNmY2Yw==");
            //var collection = new List<KeyValuePair<string, string>>();
            //collection.Add(new KeyValuePair<string, string>("grant_type", "password"));
            //collection.Add(new KeyValuePair<string, string>("username", "admin"));
            //collection.Add(new KeyValuePair<string, string>("password", "admin"));
            //var content = new FormUrlEncodedContent(collection);
            //request.Content = content;
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

    }
    public class LoginResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }

        [JsonProperty("not-before-policy")]
        public int notbeforepolicy { get; set; }
        public string session_state { get; set; }
        public string scope { get; set; }

    }

}
