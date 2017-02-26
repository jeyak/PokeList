using PokeList_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokeList_UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class PokemonFamilyPage : Page
    {
        private List<Pokemon> currentPokemons;
        public PokemonFamilyPage()
        {
            this.InitializeComponent();
            this.currentPokemons = new List<Pokemon>();
            //var pivot1 = new PivotItem();
            //pivot1.Header = "Pivot 1";
            //pivot1.Content = new Frame();
            //var pivot2 = new PivotItem();
            //pivot2.Header = "Pivot 2";
            //pivot2.Content = new Frame();
            //this.pokemonFamilyPivot.Items.Add(pivot1);
            //this.pokemonFamilyPivot.Items.Add(pivot2);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter != null)
            {
                await PokeDataLayer.getPokemonFamiliy(Convert.ToInt32((e.Parameter as Pokemon).number), this.currentPokemons);
                int i = 0;
                foreach (Pokemon pokemon in this.currentPokemons)
                {
                    var pivotItem = new PivotItem();
                    var frame = new Frame();
                    frame.Navigate(typeof(FeaturePage), pokemon);
                    frame.Margin = new Thickness(0);
                    frame.Padding = new Thickness(0);
                    pivotItem.Content = frame;
                    pivotItem.Header = pokemon.name;
                    if(Convert.ToInt32((e.Parameter as Pokemon).number) == Convert.ToInt32(pokemon.number))
                    {
                        this.pokemonFamilyPivot.Items.Insert(0, pivotItem);
                    }
                    else
                    {
                        this.pokemonFamilyPivot.Items.Add(pivotItem);
                    }
                }
            }
        }
    }
}
