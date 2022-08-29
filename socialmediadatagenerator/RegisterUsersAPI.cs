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

        public static async Task<JsonValue> MakeRequest(JsonObject request, string subUrl, string url) {
            //Headers
            client.DefaultRequestHeaders.Clear();

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"{url}/{subUrl}", content);
            var data = await response;

            var readTask = data.Content.ReadAsStringAsync();
            var dataStr = await readTask;
            var dataJson = JsonObject.Parse(dataStr);

            return dataJson;
        }

        public static async Task<JsonValue> RegisterProfile(Identity user, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("username", user.userName);
            request.Add("password", user.password);
            request.Add("email", user.email);

            return await MakeRequest(request,"register",url);
        }

        public static async Task<JsonValue> Login(Identity user, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("username", user.userName);
            request.Add("password", user.password);

            var dataJson = await MakeRequest(request, "login", url);
            return dataJson;
        }

        public static async Task<JsonValue> SetProfile(Identity user, string session,string avatarbase64, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("session",session);
            request.Add("firstName", user.firstName);
            request.Add("lastName", user.lastName);
            request.Add("profileDesc", user.description);
            request.Add("avatar", avatarbase64);

            var dataJson = await MakeRequest(request, "updateprofile", url);
            return dataJson;
        }

        public static async Task<JsonValue> UploadImage(string session, string imagebase64, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("image", imagebase64);
            var dataJson = await MakeRequest(request, "uploadimage", url);

            if (!dataJson["success"]) return null;
            return dataJson;
        }

        public static async Task<bool> AddPost(Post post,List<string> linkedImages, string session, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("title", post.title);
            request.Add("body", post.body);
            request.Add("postLinkedImages", JsonValue.Parse(JsonSerializer.Serialize(linkedImages)));

            var dataJson = await MakeRequest(request, "addpost", url);
            return dataJson["success"];
        }

        public static async Task<JsonValue> GetUserInfo(string session, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("session", session);

            return await MakeRequest(request, "userinfo", url);
        }

        public static async Task<bool> AddFriend(int ID, string session, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("friendID", ID);
            request.Add("status", true);

            var dataJson = await MakeRequest(request, "changefriendstatus", url);
            return dataJson["success"];
        }

        public static async Task<bool> LikePost(int ID, string session, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("postID", ID);
            request.Add("status", true);

            var dataJson = await MakeRequest(request, "changelikestatus", url);
            return dataJson["success"];
        }

        public static async Task<bool> AddComment(int postID, string session, string comment, string url) {
            //Build request
            var request = new JsonObject();
            request.Add("session", session);
            request.Add("postID", postID);
            request.Add("content", comment);

            var dataJson = await MakeRequest(request, "addcomment", url);
            return dataJson["success"];
        }
    }
}
