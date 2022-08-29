using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialmediadatagenerator {
    class PromptResult {
        public List<string> prompts;
        public List<string> posts;
        public string lastPromptName;

        public PromptResult(List<string> postsIn, List<string> promptsIn,string lp) {
            prompts = promptsIn;
            posts = postsIn;
            lastPromptName = lp;
        }
    }
}
