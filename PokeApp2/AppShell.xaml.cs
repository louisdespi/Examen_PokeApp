namespace PokeApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VersionGroupPage), typeof(VersionGroupPage));
            Routing.RegisterRoute(nameof(PokedexPage), typeof(PokedexPage));
            Routing.RegisterRoute(nameof(PokemonEntryPage), typeof(PokemonEntryPage));
            Routing.RegisterRoute(nameof(PokemonVarietyPage), typeof(PokemonVarietyPage));
            Routing.RegisterRoute(nameof(PokemonPage), typeof(PokemonPage));
        }
    }
}