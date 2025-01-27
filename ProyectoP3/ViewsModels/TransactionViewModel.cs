using ProyectoP3.Models;
using ProyectoP3.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ProyectoP3.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        private DatabaseService _databaseService;

        public ObservableCollection<Usuario> Usuarios { get; set; }
        public ObservableCollection<Auto> Autos { get; set; }

        private Usuario _usuarioSeleccionado;
        public Usuario UsuarioSeleccionado
        {
            get => _usuarioSeleccionado;
            set
            {
                _usuarioSeleccionado = value;
                OnPropertyChanged();
            }
        }

        private Auto _autoSeleccionado;
        public Auto AutoSeleccionado
        {
            get => _autoSeleccionado;
            set
            {
                _autoSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public ICommand RealizarTransaccionCommand { get; set; }

        public TransactionViewModel()
        {
            _databaseService = App.Database;
            RealizarTransaccionCommand = new Command(RealizarTransaccion);
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                var usuarios = await _databaseService.GetVendedoresAsync();
                var autos = await _databaseService.GetAutosAsync();

                Usuarios = new ObservableCollection<Usuario>(usuarios);
                Autos = new ObservableCollection<Auto>(autos);

                // Notifica que las colecciones han cambiado
                OnPropertyChanged(nameof(Usuarios));
                OnPropertyChanged(nameof(Autos));
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

            var transaccion = new Transaction
            {
                UsuarioId = UsuarioSeleccionado.IdUsuario,
                AutoId = AutoSeleccionado.IdAuto,
                Fecha = DateTime.Now
            };

            try
            {
                await _databaseService.SaveTransactionAsync(transaccion);
                await App.Current.MainPage.DisplayAlert("Éxito", "Transacción registrada con éxito.", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Error al registrar la transacción: {ex.Message}", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
