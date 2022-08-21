using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialmediadatagenerator
{
    class Identity {
        public string userName;
        public string email;
        public string password;

        public string firstName;
        public string lastName;
        public string gender;
        public string description;

        public string profileImagePath;

        public Identity(string u = "",string f = "",string l = "") {
            userName = u;
            firstName = f;
            lastName = l;
        }
    }
}
