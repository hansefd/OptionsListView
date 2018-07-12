using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Options.Core;
using Options.Forms.Adapters;

namespace Options.Forms
{
    public class GroupedOptionsListViewDelegate : IOptionsListViewDelegate
    {
        public IEnumerable<GroupedOptions> Source { get; private set; }

        public GroupedOptionsListViewDelegate(IEnumerable<GroupedOptions> source) => Source = source;

       public void UpdateOptionState(Option selectedOption)
        {
            var selectedGroupOptions = Source?.FirstOrDefault(x => x.Contains(selectedOption));

            if (selectedGroupOptions is null)
                return;

            if (selectedGroupOptions.MultipleSelection)
                selectedOption.IsSelected = !selectedOption.IsSelected;

            foreach (var option in selectedGroupOptions)
                option.IsSelected = false;

            selectedOption.IsSelected = !selectedOption.IsSelected;
        }

        public void UpdateSource(IEnumerable source) => Source = (IEnumerable<GroupedOptions>) source;

    }
}