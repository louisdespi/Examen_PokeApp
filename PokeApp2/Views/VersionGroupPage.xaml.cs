namespace PokeApp2.Views;

public partial class VersionGroupPage : ContentPage
{
	VersionGroupViewModel vm;
	public VersionGroupPage(VersionGroupViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        if (vm.FirstRun == true && vm.GetVersionGroupsCommand.CanExecute(null))
        {
            await vm.GetVersionGroupsCommand.ExecuteAsync(null);
            vm.FirstRun = false;
        }
        base.OnAppearing();
    }
}