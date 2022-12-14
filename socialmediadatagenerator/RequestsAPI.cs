using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Json;
using System.Text.RegularExpressions;

namespace socialmediadatagenerator
{
    class RequestsAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public static async void SaveProfilePicture(string filename = "test.jpg") {
            if (!filename.Contains(".jpg")) filename += ".jpg";
            if (!Directory.Exists("profile_images")) Directory.CreateDirectory("profile_images");

            //Headers
            client.DefaultRequestHeaders.Clear();

            var task = client.GetStreamAsync("https://thispersondoesnotexist.com/image");
            var result = await task;
            using (var fileStream = new FileStream("profile_images\\" + filename, FileMode.Create)) {
                result.CopyTo(fileStream);
            }
        }

        public static async Task SaveSamplePicture(int index) {
            if (!Directory.Exists("sample_images")) Directory.CreateDirectory("sample_images");

            //Pad with zeroes
            string strIndex = index.ToString();
            while (strIndex.Length < 10) strIndex = "0" + strIndex;

            //Headers
            client.DefaultRequestHeaders.Clear();

            var task = client.GetStreamAsync($"https://cdn.vv42.net/file/art42-cdn/cubism/seed_{ strIndex }.jpg");
            var result = await task;
            using (var fileStream = new FileStream($"sample_images\\{strIndex}.jpg", FileMode.Create)) {
                result.CopyTo(fileStream);
            }
        }

        public static async Task<string> GetOpenAIResponse(string prompt,string token, int maxtokens = 512) {
            if (token.Length < 51) return null;
            //Headers
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Build request
            var request = new JsonObject();
            request.Add("model","text-davinci-002");
            request.Add("prompt", prompt);
            request.Add("temperature",0.85);
            request.Add("max_tokens",maxtokens);

            HttpResponseMessage data = null;
            try {
                var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
                var response = client.PostAsync("https://api.openai.com/v1/completions", content);
                data = await response;
            }
            catch(System.Net.Http.HttpRequestException) {
                Console.WriteLine("HttpRequestException thrown at OpenAI request, OpenAI might be down.");
                return "";
            }

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            Console.WriteLine(dataJson["choices"][0]["text"].ToString());
            return dataJson["choices"][0]["text"];
        }

        public static async Task<PromptResult> GetRedditWritingPrompts(string token, int amount, string lastName = "") {
            List<string> results = new List<string>();
            //Headers
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent","SocialMediaDataGenBot/0.1");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer",token);

            var response = client.GetAsync($"https://oauth.reddit.com/r/writingprompts/top?t=all{ (lastName.Length > 3 ? $"&after=" + lastName : "") }&limit={amount}");
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            var regex = new Regex(@"(\[WP\]|\[SP\]|\[EU\]|\[CW\]|\[TT\]|\[MP\]|\[IP\]|\[RF\])");
            string lastPostName = "";
            string postText;
            int ind = 0;
            foreach (JsonObject post in dataJson["data"]["children"]) {
                postText = post["data"]["title"].ToString();

                if (ind == dataJson["data"]["children"].Count - 1) lastPostName = post["data"]["name"]; //Get last post name
                //Ignore non prompt posts
                if (HelperFunctions.StringContainsAny(postText, new string[] { "[PM]", "[PI]", "[OT]", "[MOD]" })) continue;

                //Clear any flairs from post titles
                postText = regex.Replace(postText,"").Trim();
                results.Add(postText);

                ind++;
            }

            return new PromptResult(null,results,lastPostName);
        }

        public static async Task<string> GetRedditToken(string username, string password, string clientID, string clientSecret) {
            //Headers
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "SocialMediaDataGenBot/0.1");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientID}:{clientSecret}")));

            //Build request
            var request = new Dictionary<string, string>();
            request.Add("grant_type", "password");
            request.Add("username", username);
            request.Add("password", password);

            var content = new FormUrlEncodedContent(request);
            var response = client.PostAsync("https://www.reddit.com/api/v1/access_token", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson["access_token"];
        }
    }
}
