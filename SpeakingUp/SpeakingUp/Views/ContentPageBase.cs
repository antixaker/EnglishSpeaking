using SpeakingUp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpeakingUp.Views
{
    public abstract class ContentPageBase : ContentPage
    {
        protected override void OnAppearing()
        {
            if (BindingContext!=null && BindingContext is IViewModelBase)
            {
                (BindingContext as IViewModelBase)?.Initialize();
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            if (BindingContext != null && BindingContext is IViewModelBase)
            {
                (BindingContext as IViewModelBase)?.Deinitialize();
            }

            base.OnDisappearing();
        }
    }
}
