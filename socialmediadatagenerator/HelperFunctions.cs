using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

        public static string ConvertToBase64String(Stream stream) {
            byte[] bytes;
            using (var memoryStream = new MemoryStream()) {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return Convert.ToBase64String(bytes);
        }
    }
}
