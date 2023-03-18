namespace PokeApp2.Views;

public partial class PokemonPage : ContentPage
{
	PokemonViewModel vm;
	public PokemonPage(PokemonViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        if (vm.FirstRun && vm.SetDatasCommand.CanExecute(null))
        {
            vm.SetDatasCommand.Execute(null);
            vm.FirstRun = false;
        }
        base.OnAppearing();
    }
}