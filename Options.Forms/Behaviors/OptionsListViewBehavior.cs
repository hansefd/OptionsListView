using System;
using Options.Forms.Adapters;
using Xamarin.Forms;

namespace Options.Forms
{
    public class OptionsListViewBehavior : OptionsListViewBehaviorBase
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            if (bindable.ItemsSource is Core.Options options)
                Delegate = new OptionsListViewDelegate(options);
            else
                throw new Exception();
        }
    }
}