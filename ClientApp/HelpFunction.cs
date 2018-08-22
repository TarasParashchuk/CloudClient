using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class HelpFunction
    {
        private string path = string.Empty;
        private string content = string.Empty;
        private int id = 0;

        public HelpFunction(string path)
        {
            this.path = path;
        }

        public HelpFunction(string path, int id)
        {
            this.path = path;
            this.id = id;

            GetJson();
        }

        public async Task<string> DeleteFileServer(string name, string id)
        {
            var httpClient = new HttpClient();

            var postData = new Dictionary<string, object>();

            postData.Add("Name", name);
            postData.Add("Id", id);

            var jsonRequest = JsonConvert.SerializeObject(postData);

            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync(path, content);
            var resultString = await result.Content.ReadAsStringAsync();
            return resultString;
        }

        public async Task<string> SendFileServer(string name, string loginclient, string login, string password)
        {
            var httpClient = new HttpClient();

            var postData = new Dictionary<string, object>();

            postData.Add("Name", name);
            postData.Add("LoginClient", loginclient);
            postData.Add("Login", login);
            postData.Add("Password", password);

            var jsonRequest = JsonConvert.SerializeObject(postData);

            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync(path, content);
            var resultString = await result.Content.ReadAsStringAsync();
            return resultString;
        }

        public async Task<string> SendDataServer(string login, string password)
        {
            var httpClient = new HttpClient();

            var postData = new Dictionary<string, object>();

            postData.Add("Login", login);
            postData.Add("Password", password);

            var jsonRequest = JsonConvert.SerializeObject(postData);

            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync(path, content);
            var resultString = await result.Content.ReadAsStringAsync();
            return resultString;
        }

        private async void GetJson()
        {
            using (var client = new HttpClient())
            {
                if (id != 0)
                {
                    var parameters = new Dictionary<string, string>();
                    parameters["id"] = id.ToString();
                    var response = client.PostAsync(path, new FormUrlEncodedContent(parameters)).Result;
                    content = await response.Content.ReadAsStringAsync();
                }
                else content = client.GetStringAsync(path).Result;
            }
        }

        public List<Model> GetDataBox()
        {
            return JsonConvert.DeserializeObject<List<Model>>(content);
        }
    }

    public class Model 
    {
        public string Name { get; set; }
    }
}
