namespace PokeApp2.Views;

public partial class PokemonEntryPage : ContentPage
{
	PokemonEntryViewModel vm;
	public PokemonEntryPage(PokemonEntryViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        if (vm.FirstRun && vm.GetPokemonEntriesListCommand.CanExecute(null))
        {
            await vm.GetPokemonEntriesListCommand.ExecuteAsync(null);
            vm.FirstRun = false;
        }
        base.OnAppearing();
    }
}