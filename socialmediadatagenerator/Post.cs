using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialmediadatagenerator {
    public class Post {
        public string title { get; set; }
        public string body { get; set; }

        public Post (string t, string b) {
            title = t;
            body = b;
        }
    }
}
