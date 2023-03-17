using System.Runtime.CompilerServices;

namespace PokeApp2.Views;

public partial class GenerationPage : ContentPage
{
    GenerationViewModel vm;
    public GenerationPage(GenerationViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
    }
    protected override async void OnAppearing()
    {
        if (vm.FirstRun == true && vm.GetGenerationsCommand.CanExecute(null))
        {
            await vm.GetGenerationsCommand.ExecuteAsync(null);
            vm.FirstRun = false;
        }
        base.OnAppearing();
    }
}