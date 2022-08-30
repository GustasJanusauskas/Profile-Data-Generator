using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Identity(string u = "",string f = "",string l = "") {
            userName = u;
            firstName = f;
            lastName = l;
        }
    }
}
