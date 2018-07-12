using System.Collections.Generic;

namespace Options.Core
{
    public class Options : List<Option>
    {
        public bool MultipleSelection { get; }

        public Options(bool multipleSelection = false)
        {
            MultipleSelection = multipleSelection;
        }
    }
}