using System.Windows.Input;

namespace ProyectoP3.ViewModels
{
    public class RegisterCarViewModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal Precio { get; set; }
        public ICommand RegistrarAutoCommand { get; set; }

        public RegisterCarViewModel()
        {
            RegistrarAutoCommand = new Command(RegistrarAuto);
        }

        private async void RegistrarAuto()
        {
            var auto = new Models.Auto
            {
                Marca = this.Marca,
                Modelo = this.Modelo,
                Anio = this.Anio,
                Precio = this.Precio
            };

            await App.Database.SaveAutoAsync(auto); // Deberás implementar este método.
            await App.Current.MainPage.DisplayAlert("Éxito", "Auto registrado correctamente.", "OK");
        }
    }
}