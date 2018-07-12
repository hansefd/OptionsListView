using System.Collections.Generic;
using Options.Core;

namespace Options.Playground.Core
{
    public class MainViewModel
    {
        public List<GroupedOptions> Options { get; set; }

        public MainViewModel()
        {
            Options = new List<GroupedOptions> {new GroupedOptions("Group 1") {new Option("Option 1")}};
        }
    }
}