using System.Collections;
using System.Linq;
using Options.Core;

namespace Options.Forms.Adapters
{
    public class OptionsListViewDelegate : IOptionsListViewDelegate
    {
        public Core.Options Source { get; private set; }

        public OptionsListViewDelegate(Core.Options source) => Source = source;

        public void UpdateOptionState(Option selectedOption)
        {
            if (Source is null)
                return;

            if (Source.MultipleSelection)
                selectedOption.IsSelected = !selectedOption.IsSelected;
            else
            {
                foreach (var option in Source.Where(x => x != selectedOption))
                    option.IsSelected = false;

                selectedOption.IsSelected = !selectedOption.IsSelected;
            }
        }

        public void UpdateSource(IEnumerable source) => Source = (Core.Options) source;
    }
}