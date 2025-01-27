using Microsoft.Extensions.Logging;
using ProyectoP3.Services;
using ProyectoP3.ViewModels;

namespace ProyectoP3
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



            // Registrar servicios y ViewModels
            builder.Services.AddSingleton<DatabaseService>(); // Registra tu servicio de base de datos
            builder.Services.AddTransient<ListaAutoViewModel>(); // Registra el ViewModel

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
