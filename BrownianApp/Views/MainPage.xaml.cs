using BrownianApp.Drawables;
using BrownianApp.ViewModels;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace BrownianApp.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm;
        BrownianDrawable _drawable;

        public MainPage()
        {
            InitializeComponent();

            if (BindingContext is MainViewModel vm)
            {
                vm.Drawable.OnPricesUpdated += () =>
                {
                    graphicsView.Invalidate(); // força redesenho
                };
            }
        }
    }
}
