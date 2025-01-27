using System;
using System.Windows.Input;

namespace ProyectoP3.ViewModels
{
    public class RegisterUserViewModel
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICommand RegistrarVendedorCommand { get; set; }

        public RegisterUserViewModel()
        {
            FechaNacimiento = DateTime.Today;
            RegistrarVendedorCommand = new Command(RegistrarUsuario);
        }

        private async void RegistrarUsuario()
        {
            var usuario = new Models.Usuario
            {
                Nombre = this.Nombre,
                Correo = this.Correo,
                FechaNacimiento = this.FechaNacimiento
            };

            await App.Database.SaveVendedorAsync(usuario); // Guardamos el usuario en la base de datos
            await App.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");
        }
    }
}