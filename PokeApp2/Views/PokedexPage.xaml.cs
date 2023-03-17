namespace PokeApp2.Views;

public partial class PokedexPage : ContentPage
{
	PokedexViewModel vm;
	public PokedexPage(PokedexViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        if (vm.GetPokedexesCommand.CanExecute(null))
        {
            await vm.GetPokedexesCommand.ExecuteAsync(null);
        }
        base.OnAppearing();
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;
        var selected = e.SelectedItem as Pokedex;
        // Faire quelque chose avec l'élément sélectionné
        vm.GoToPokemonEntriesGroupsCommand.Execute(selected);

        // Réinitialiser la sélection de la liste
        ((ListView)sender).SelectedItem = null;
    }
}