using System;
using System.Collections.Generic;
using Options.Core;
using Xamarin.Forms;

namespace Options.Forms
{
    public class GroupedOptionsListViewBehavior : OptionsListViewBehaviorBase
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            if (bindable.ItemsSource is IEnumerable<GroupedOptions> options)
                Delegate = new GroupedOptionsListViewDelegate(options);
            else
                throw new Exception();
        }
    }
}