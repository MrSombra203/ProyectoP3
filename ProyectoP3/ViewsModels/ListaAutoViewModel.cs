using System.Collections.ObjectModel;
using ProyectoP3.Models;

namespace ProyectoP3.ViewModels
{
    public class ListaAutoViewModel
    {
        private readonly Services.DatabaseService _databaseService;

        public ObservableCollection<Auto> Autos { get; set; }

        public ListaAutoViewModel(Services.DatabaseService databaseService)
        {
            _databaseService = databaseService;
            Autos = new ObservableCollection<Auto>();
            CargarAutos();
        }

        public async void CargarAutos()
        {
            try
            {
                var autos = await _databaseService.GetAutosAsync();
                foreach (var auto in autos)
                {
                    Autos.Add(auto);
                }
            }
            catch (Exception ex)
            {
                // Mostrar un error si ocurre un problema al cargar los datos
                await App.Current.MainPage.DisplayAlert("Error", $"Error al cargar los autos: {ex.Message}", "OK");
            }
        }
    }
}
