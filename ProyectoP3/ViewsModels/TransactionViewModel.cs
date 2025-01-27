using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProyectoP3.ViewModels
{
    public class TransactionViewModel
    {
        public ObservableCollection<Models.Usuario> Usuarios { get; set; }
        public ObservableCollection<Models.Auto> Autos { get; set; }
        public Models.Usuario UsuarioSeleccionado { get; set; }
        public Models.Auto AutoSeleccionado { get; set; }
        public ICommand RealizarTransaccionCommand { get; set; }

        public TransactionViewModel()
        {
            RealizarTransaccionCommand = new Command(RealizarTransaccion);
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                Usuarios = new ObservableCollection<Models.Usuario>(await App.Database.GetVendedoresAsync());
                Autos = new ObservableCollection<Models.Auto>(await App.Database.GetAutosAsync());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Error al cargar datos: {ex.Message}", "OK");
            }
        }

        private async void RealizarTransaccion()
        {
            if (UsuarioSeleccionado == null || AutoSeleccionado == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Selecciona un comprador y un auto.", "OK");
                return;
            }

            // Implementa la lógica de la transacción aquí
            await App.Current.MainPage.DisplayAlert("Éxito", "Transacción realizada correctamente.", "OK");
        }

    }
}
