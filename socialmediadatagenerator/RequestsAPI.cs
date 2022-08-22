using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Json;
using System.Text.Json;

namespace socialmediadatagenerator
{
    class RequestsAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public static async void SaveProfilePicture(string filename = "test.jpg") {
            if (!filename.Contains(".jpg")) filename += ".jpg";
            if (!Directory.Exists("profile_images")) Directory.CreateDirectory("profile_images");

            //Header
            client.DefaultRequestHeaders.Clear();

            var task = client.GetStreamAsync("https://thispersondoesnotexist.com/image");
            var result = await task;
            using (var fileStream = new FileStream("profile_images\\" + filename, FileMode.Create)) {
                result.CopyTo(fileStream);
            }
        }

        public static async Task<string> GetOpenAIResponse(string prompt,string token) {
            if (token.Length < 51) return null;
            //Header
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Build request
            var request = new JsonObject();
            request.Add("model","text-davinci-002");
            request.Add("prompt", prompt);
            request.Add("temperature",0.95);
            request.Add("max_tokens",256);

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://api.openai.com/v1/completions",content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            Console.WriteLine(dataJson["choices"][0]["text"].ToString());
            return dataJson["choices"][0]["text"];
        }
    }
}
