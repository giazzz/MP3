using Mp3.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Service
{
    class MemberServiceImp : MemberService
    {
        public Member GetInformation(string token, string infoUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync(infoUrl).Result.Content.ReadAsStringAsync().Result;
            //JObject jsonJObject = JObject.Parse(responseContent);
            //Debug.WriteLine("Info: " + jsonJObject["email"]);
            Member mem = Newtonsoft.Json.JsonConvert.DeserializeObject<Member>(responseContent);
            return mem;
        }

        public string Login(string username, string password, string loginUrl)
        {
            var memberLogin = new Mp3.Entity.MemberLogin()
            {
                email = username,
                password = password
            };
            var dataContent = new StringContent(JsonConvert.SerializeObject(memberLogin),
                Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var responseContent = client.PostAsync(loginUrl, dataContent).Result.Content.ReadAsStringAsync().Result;
            JObject jsonJObject = JObject.Parse(responseContent);
            String token = jsonJObject["token"].ToString();
            //Debug.WriteLine(jsonJObject["token"]);
            return token;
        }

        public Member Register(Member member, String registerUrl)
        {

            var httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8,
                "application/json");
            Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(registerUrl, content);

            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + responseContent);

            //Convert json to ofject C#:
            Member resMember = JsonConvert.DeserializeObject<Member>(responseContent);
            Debug.WriteLine("Register email: " + resMember.email);
            return resMember;
        }
    }
}
