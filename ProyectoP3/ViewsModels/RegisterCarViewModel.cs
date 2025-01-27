using System.Windows.Input;

namespace ProyectoP3.ViewModels
{
    public class RegisterCarViewModel
    {
        private readonly Services.DatabaseService _databaseService;

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal Precio { get; set; }
        public ICommand RegistrarAutoCommand { get; set; }

        public RegisterCarViewModel(Services.DatabaseService databaseService)
        {
            _databaseService = databaseService;
            RegistrarAutoCommand = new Command(RegistrarAuto);
        }

        private async void RegistrarAuto()
        {
            if (string.IsNullOrEmpty(Marca) || string.IsNullOrEmpty(Modelo) || Anio <= 0 || Precio <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            var auto = new Models.Auto
            {
                Marca = this.Marca,
                Modelo = this.Modelo,
                Anio = this.Anio,
                Precio = this.Precio
            };

            await _databaseService.SaveAutoAsync(auto);
            await App.Current.MainPage.DisplayAlert("Éxito", "Auto registrado correctamente.", "OK");
        }


    }
}
