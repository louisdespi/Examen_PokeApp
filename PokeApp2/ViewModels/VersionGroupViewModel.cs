namespace PokeApp2.ViewModels
{
    [QueryProperty("Generation", "Generation")]
    public partial class VersionGroupViewModel : BaseViewModel
    {
        PokeApiService apiService;
        [ObservableProperty]
        Generation generation;
        [ObservableProperty]
        ObservableCollection<VersionGroup> versionGroups;
        public bool FirstRun { get; set; } = true;
        public VersionGroupViewModel(PokeApiService service)
        {
            this.apiService = service;
            VersionGroups = new ObservableCollection<VersionGroup>();
            Title = string.Empty;
        }

        [RelayCommand]
        async Task GetVersionGroupsAsync()
        {
            if (Title == string.Empty) Title = Generation.Names.FrenchOrEnglish;
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;
                VersionGroups.Clear();
                Generation.VersionGroups = await apiService.GetListObjAsync<VersionGroup>(Generation.VersionGroupsResource);
                foreach (VersionGroup vg in Generation.VersionGroups)
                {
                    this.VersionGroups.Add(vg);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GoToPokedexesAsync(VersionGroup versionGroup)
        {
            if (versionGroup is null)
                return;
            await Shell.Current.GoToAsync(nameof(PokedexPage), true, new Dictionary<string, object>
            {
                { "VersionGroup", versionGroup },
            });
        }
    }
}
