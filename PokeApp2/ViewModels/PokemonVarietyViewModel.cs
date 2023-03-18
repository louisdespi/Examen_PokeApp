namespace PokeApp2.ViewModels
{
    [QueryProperty("PokemonEntry", "PokemonEntry")]
    public partial class PokemonVarietyViewModel : BaseViewModel
    {
        PokeApiService apiService;
        [ObservableProperty]
        PokemonEntry pokemonEntry;
        [ObservableProperty]
        ObservableCollection<Pokemon> pokemons;
        [ObservableProperty]
        Pokedex selectedItem;
        public bool FirstRun { get; set; } = true;
        public PokemonVarietyViewModel(PokeApiService service)
        {
            this.apiService = service;
            Pokemons = new ObservableCollection<Pokemon>();
            Title = string.Empty;
        }

        [RelayCommand]
        async Task GetPokemonListAsync()
        {
            if (Title == string.Empty) Title = PokemonEntry.PokemonSpecie.Names.FrenchOrEnglish;
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;
                Pokemons.Clear();
                PokemonSpecie ps = PokemonEntry.PokemonSpecie;
                foreach (PokemonVariety pv in ps.Varieties)
                {
                    pv.Pokemon = await apiService.GetObjAsync<Pokemon>(pv.PokemonResource);
                    this.Pokemons.Add(pv.Pokemon);
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
        async Task GoToPokemonAsync(Pokemon pokemon)
        {
            if (pokemon is null)
                return;
            await Shell.Current.GoToAsync(nameof(PokemonPage), true, new Dictionary<string, object>
            {
                { "PokemonEntry", PokemonEntry },
                { "Pokemon", pokemon },
            });
        }
    }
}