﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace PokeApp2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //builder.Services.AddSingleton<SQLiteConnection>(provider => new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True;"));

            builder.Services.AddSingleton<PokeApiService>();
            builder.Services.AddSingleton<GenerationPage>();
            builder.Services.AddSingleton<GenerationViewModel>();

            builder.Services.AddTransient<VersionGroupPage>();
            builder.Services.AddTransient<VersionGroupViewModel>();

            builder.Services.AddTransient<PokedexPage>();
            builder.Services.AddTransient<PokedexViewModel>();

            builder.Services.AddTransient<PokemonEntryPage>();
            builder.Services.AddTransient<PokemonEntryViewModel>();

            builder.Services.AddTransient<PokemonVarietyPage>();
            builder.Services.AddTransient<PokemonVarietyViewModel>();

            builder.Services.AddTransient<PokemonPage>();
            builder.Services.AddTransient<PokemonViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}