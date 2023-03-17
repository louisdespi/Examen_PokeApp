namespace PokeApp2.ViewModels
{
    [QueryProperty("Pokedex", "Pokedex")]
    public partial class PokemonEntryViewModel : BaseViewModel
    {
        PokeApiService apiService;
        [ObservableProperty]
        Pokedex pokedex;
        [ObservableProperty]
        ObservableCollection<PokemonEntry> pokemonEntries;
        [ObservableProperty]
        bool isRefreshing = false;
        public bool FirstRun { get; set; } = true;
        public PokemonEntryViewModel(PokeApiService service)
        {
            this.apiService = service;
            pokemonEntries = new ObservableCollection<PokemonEntry>();
            Title = string.Empty;
        }

        [RelayCommand]
        async Task GetPokemonEntriesListAsync()
        {
            if (Title == string.Empty) Title = Pokedex.Names.FrenchOrEnglish;
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsRefreshing = true;
                IsBusy = true;
                PokemonEntries.Clear();
                foreach (PokemonEntry pe in Pokedex.PokemonEntries)
                {
                    pe.PokemonSpecie = await apiService.GetObjAsync<PokemonSpecie>(pe.PokemonSpecieResource);
                    this.PokemonEntries.Add(pe);
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
        async Task GoToPokemonVarietiesAsync(PokemonEntry pokemonEntry)
        {
            if (pokemonEntry is null)
                return;
            await Shell.Current.GoToAsync(nameof(PokemonVarietyPage), true, new Dictionary<string, object>
            {
                { "PokemonEntry", pokemonEntry },
            });
        }
    }
}