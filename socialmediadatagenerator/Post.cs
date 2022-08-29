using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Json;

namespace socialmediadatagenerator {
    public class Post {
        public string title { get; set; }
        public string body { get; set; }

        [JsonConstructor]
        public Post (string title, string body) {
            this.title = title;
            this.body = body;
        }
    }
}
