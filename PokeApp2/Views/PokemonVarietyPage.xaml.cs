namespace PokeApp2.Views;

public partial class PokemonVarietyPage : ContentPage
{
	PokemonVarietyViewModel vm;
	public PokemonVarietyPage(PokemonVarietyViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        if (vm.GetPokemonListCommand.CanExecute(null))
        {
            await vm.GetPokemonListCommand.ExecuteAsync(null);
        }
        base.OnAppearing();
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;
        var selected = e.SelectedItem as Pokedex;
        // Faire quelque chose avec l'élément sélectionné
        //vm.GoToPokemonEntriesGroupsCommand.Execute(selected);

        // Réinitialiser la sélection de la liste
        ((ListView)sender).SelectedItem = null;
    }
}