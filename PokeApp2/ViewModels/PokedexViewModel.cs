namespace PokeApp2.ViewModels
{
    [QueryProperty("VersionGroup", "VersionGroup")]
    public partial class PokedexViewModel : BaseViewModel
    {
        PokeApiService apiService;
        [ObservableProperty]
        VersionGroup versionGroup;
        [ObservableProperty]
        ObservableCollection<Pokedex> pokedexes;
        [ObservableProperty]
        Pokedex selectedItem;
        public PokedexViewModel(PokeApiService service)
        {
            this.apiService = service;
            Pokedexes = new ObservableCollection<Pokedex>();
            Title = string.Empty;
        }

        [RelayCommand]
        async Task GetPokedexesAsync()
        {
            if (Title == string.Empty) Title = VersionGroup.Name;
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;
                Pokedexes.Clear();
                VersionGroup.Pokedexes = await apiService.GetListObjAsync<Pokedex>(VersionGroup.PokedexesResource);
                foreach (Pokedex p in VersionGroup.Pokedexes)
                {
                    if (p.Names.FrenchOrEnglish == null) p.Names.FrenchOrEnglish = p.Name;
                    if (p.Descriptions.FrenchOrEnglish == null) p.Descriptions.FrenchOrEnglish = String.Empty;
                    p.CountEntries = p.PokemonEntries.Count;
                    this.Pokedexes.Add(p);
                }
                /*if (this.Pokedexes.Count < 2)
                {
                    await GoToPokemonEntriesGroupsAsync(this.Pokedexes[0]);
                }*/
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
        async Task GoToPokemonEntriesGroupsAsync(Pokedex pokedex)
        {
            if (pokedex is null)
                return;
            await Shell.Current.GoToAsync(nameof(PokemonEntryPage), true, new Dictionary<string, object>
            {
                { "Pokedex", pokedex },
            });
        }
    }
}
