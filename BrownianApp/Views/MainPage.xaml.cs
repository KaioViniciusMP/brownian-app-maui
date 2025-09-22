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

            _vm = BindingContext as MainViewModel;
            if (_vm != null)
                _vm.Drawable.OnPricesUpdated += () => graphicsView.Invalidate();
        }
    }
}
