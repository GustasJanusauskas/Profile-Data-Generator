using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace socialmediadatagenerator
{
    public class Identity {
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }

        public string description { get; set; }
        public string profileImagePath { get; set; }

        public List<Post> posts { get; set; } = new List<Post>();
        public List<string> images { get; set; } = new List<string>();
        public List<string> comments { get; set; } = new List<string>();

        [JsonConstructor]
        public Identity(string userName, string email, string password, string firstName, string lastName, string gender, string description, string profileImagePath, List<Post> posts, List<string> images, List<string> comments) {
            (this.userName, this.email, this.password, this.firstName, this.lastName, this.gender, this.description, this.profileImagePath, this.posts, this.images, this.comments) = (userName, email, password, firstName, lastName, gender, description, profileImagePath, posts, images, comments);
        }

        public Identity(string u = "",string f = "",string l = "") {
            userName = u;
            firstName = f;
            lastName = l;
        }
    }
}
