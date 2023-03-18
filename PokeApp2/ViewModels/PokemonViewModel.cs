namespace PokeApp2.ViewModels
{
    [QueryProperty("Pokemon", "Pokemon")]
    [QueryProperty("PokemonEntry", "PokemonEntry")]
    public partial class PokemonViewModel : BaseViewModel
    {
        //SQLiteConnection sqlConnection;
        PokeApiService apiService;
        [ObservableProperty]
        Pokemon pokemon;
        [ObservableProperty]
        PokemonEntry pokemonEntry;
        public bool FirstRun { get; set; } = true;
        public PokemonViewModel(PokeApiService service/*, SQLiteConnection sqlConnection*/)
        {
            this.apiService = service;
            //this.sqlConnection = sqlConnection;
        }

        [RelayCommand]
        public void SetDatas()
        {
            PokemonEntry p = PokemonEntry;
            Title = Pokemon.Name;
        }
        /*[RelayCommand]
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
        }*/

        /*[RelayCommand]
        async Task GoToPokedexesAsync(VersionGroup versionGroup)
        {
            if (versionGroup is null)
                return;
            await Shell.Current.GoToAsync(nameof(PokedexPage), true, new Dictionary<string, object>
            {
                { "VersionGroup", versionGroup },
            });
        }*/
    }
}
