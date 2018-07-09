using System.Collections.ObjectModel;

namespace Options.Core
{
    public class Options : ObservableCollection<Option>
    {
        public bool MultipleSelection { get; }

        public Options(bool multipleSelection = false)
        {
            MultipleSelection = multipleSelection;
        }
    }
}