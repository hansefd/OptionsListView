using System.Collections.Generic;
using Options.Core;

namespace Options.Playground.Core
{
    public class MainViewModel
    {
        public List<GroupOptions> Options { get; set; }

        public MainViewModel()
        {
            Options = new List<GroupOptions> {new GroupOptions("Group 1") {new Option("Option 1")}};
        }
    }
}