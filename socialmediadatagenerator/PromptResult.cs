using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialmediadatagenerator {
    class PromptResult {
        public List<string> prompts;
        public string lastPromptName;

        public PromptResult(List<string> p,string lp) {
            prompts = p;
            lastPromptName = lp;
        }
    }
}
