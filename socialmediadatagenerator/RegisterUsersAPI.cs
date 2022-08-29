using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Json;
using System.Text.Json;

namespace socialmediadatagenerator {
    class RegisterUsersAPI {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<JsonValue> RegisterProfile(Identity user, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("username", user.userName);
            request.Add("password", user.password);
            request.Add("email", user.email);

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/register", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson;
        }

        public static async Task<JsonValue> Login(Identity user, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("username", user.userName);
            request.Add("password", user.password);

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/login", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            if (!dataJson["success"]) return null;
            return dataJson;
        }

        public static async Task<JsonValue> SetProfile(Identity user, string session,string avatarbase64, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("session",session);
            request.Add("firstName", user.firstName);
            request.Add("lastName", user.lastName);
            request.Add("profileDesc", user.description);
            request.Add("avatar", avatarbase64);

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/login", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            if (!dataJson["success"]) return null;
            return dataJson;
        }

        public static async Task<JsonValue> UploadImage(string session, string imagebase64, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("image", imagebase64);

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/uploadimage", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            if (!dataJson["success"]) return null;
            return dataJson;
        }

        public static async Task<bool> AddPost(Post post,List<string> linkedImages, string session, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("title", post.title);
            request.Add("body", post.body);
            request.Add("postLinkedImages", JsonValue.Parse(JsonSerializer.Serialize(linkedImages)));

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/addpost", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson["success"];
        }

        public static async Task<JsonValue> GetUserInfo(string session, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("session", session);

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/userinfo", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson;
        }

        public static async Task<bool> AddFriend(int ID, string session, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("friendID", ID);
            request.Add("status", true);


            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/changefriendstatus", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson["success"];
        }

        public static async Task<bool> LikePost(int ID, string session, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("postID", ID);
            request.Add("status", true);


            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/changelikestatus", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson["success"];
        }

        public static async Task<bool> AddComment(int postID, string session, string comment, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("postID", postID);
            request.Add("content", comment);


            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/addcomment", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson["success"];
        }
    }
}
