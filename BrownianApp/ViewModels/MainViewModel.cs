using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BrownianApp.Models;
using BrownianApp.Drawables;

namespace BrownianApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] private double precoInicial = 100;
        [ObservableProperty] private double volatilidade = 20;
        [ObservableProperty] private double retornoMedio = 1;
        [ObservableProperty] private int tempo = 252;

        public BrownianDrawable Drawable { get; } = new BrownianDrawable();

        [RelayCommand]
        private void GerarSimulacao()
        {
            var prices = BrownianModel.GenerateBrownianMotion(
                Volatilidade / 100.0, // ajustando para percentual
                RetornoMedio / 100.0,
                PrecoInicial,
                Tempo
            );

            Drawable.Prices = prices;
        }
    }
}
