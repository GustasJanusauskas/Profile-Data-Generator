using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace socialmediadatagenerator
{
    class RequestsAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public static async void GetProfilePicture(string filename = "test.jpg") {
            if (!filename.Contains(".jpg")) filename += ".jpg";
            if (!Directory.Exists("profile_images")) Directory.CreateDirectory("profile_images");

            var task = client.GetStreamAsync("https://thispersondoesnotexist.com/image");
            var result = await task;
            using (var fileStream = new FileStream("profile_images\\" + filename, FileMode.Create)) {
                result.CopyTo(fileStream);
            }
        }
    }
}
