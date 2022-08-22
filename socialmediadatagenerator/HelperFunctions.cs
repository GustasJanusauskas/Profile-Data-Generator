using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialmediadatagenerator {
    class HelperFunctions {
        public static bool StringContainsAny(string haystack, params string[] needles) {
            foreach (string needle in needles) {
                if (haystack.Contains(needle))
                    return true;
            }

            return false;
        }
    }
}
