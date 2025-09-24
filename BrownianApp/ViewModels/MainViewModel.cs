using BrownianApp.Drawables;
using BrownianApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BrownianApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] private double precoInicial = 100;
        [ObservableProperty] private double volatilidade = 20;
        [ObservableProperty] private double retornoMedio = 1;
        [ObservableProperty] private int tempo = 252;

        [ObservableProperty] private Color linhaCor = Colors.MediumPurple;
        [ObservableProperty] private float linhaEspessura = 1.5f;
        [ObservableProperty] private ColorItem linhaCorSelecionada;
        public BrownianDrawable Drawable { get; } = new BrownianDrawable();

        public ObservableCollection<ColorItem> CoresDisponiveis { get; } = new ObservableCollection<ColorItem>
        {
            new ColorItem{ Name = "Roxo", Color = Colors.MediumPurple },
            new ColorItem{ Name = "Vermelho", Color = Colors.Red },
            new ColorItem{ Name = "Verde", Color = Colors.Green },
            new ColorItem{ Name = "Azul", Color = Colors.Blue },
            new ColorItem{ Name = "Laranja", Color = Colors.Orange },
        };

        [RelayCommand]
        private async void GerarSimulacao()
        {
            if (LinhaCorSelecionada == null)
            {
                await Application.Current.MainPage.DisplayAlert("Atenção", "Escolha uma cor para o gráfico antes de gerar a simulação.", "OK");
                return;
            }

            int seed = (int)(PrecoInicial * 1000 + Volatilidade * 100 + RetornoMedio * 100 + Tempo);

            var prices = BrownianModel.GenerateBrownianMotion(
                Volatilidade / 100.0,
                RetornoMedio / 100.0,
                PrecoInicial,
                Tempo,
                seed
            );

            Drawable.Prices = prices;

            Drawable.StrokeColor = linhaCorSelecionada.Color;
            Drawable.StrokeSize = LinhaEspessura;
        }
    }
}
