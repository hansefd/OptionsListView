using System;
using Options.Core;
using Options.Forms.Adapters;
using Xamarin.Forms;

namespace Options.Forms
{
    public abstract class OptionsListViewBehaviorBase : Behavior<ListView>
    {
        protected IOptionsListViewDelegate Delegate;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            AttachEvents(bindable);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            DetachEvents(bindable);

            base.OnDetachingFrom(bindable);
        }

        private void OnOptionStateChanged(object sender, SelectedItemChangedEventArgs e) =>
            Delegate.UpdateOptionState((Option) e.SelectedItem);

        private void OnBindingContextChanged(object sender, EventArgs e) =>
            Delegate?.UpdateSource(((ListView) sender).ItemsSource);

        private void AttachEvents(ListView bindable)
        {
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.ItemSelected          += OnOptionStateChanged;
        }

        private void DetachEvents(ListView bindable)
        {
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.ItemSelected          -= OnOptionStateChanged;
        }
    }
}