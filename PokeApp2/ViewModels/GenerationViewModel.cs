namespace PokeApp2.ViewModels
{
    public partial class GenerationViewModel : BaseViewModel
    {
        PokeApiService apiService;
        [ObservableProperty]
        ObservableCollection<Generation> generations;
        [ObservableProperty]
        bool isRefreshing;
        public bool FirstRun { get; set; } = true;
        public GenerationViewModel(PokeApiService service)
        {
            Title = "Toutes les generations";
            this.apiService = service;
            Generations = new ObservableCollection<Generation>();
        }

        [RelayCommand]
        async Task GetGenerationsAsync()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                Generations.Clear();
                List<Generation> generations = (await apiService.GetAllGenerationsAsync());
                foreach (Generation generation in generations)
                {
                    //generation.VersionGroup = await apiService.GetListObjAsync<VersionGroup>(generation.VersionGroupsResource);
                    this.Generations.Add(generation);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToVersionGroupsAsync(Generation generation)
        {
            if (generation is null)
                return;
            await Shell.Current.GoToAsync(nameof(VersionGroupPage), true, new Dictionary<string, object>
            {
                { "Generation", generation },
            });
        }
    }
}
