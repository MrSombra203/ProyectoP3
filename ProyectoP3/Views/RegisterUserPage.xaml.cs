namespace ProyectoP3.Views;
using ProyectoP3.ViewModels;
	

public partial class RegisterUserPage : ContentPage
{
	public RegisterUserPage()
	{
		InitializeComponent();
        BindingContext = new RegisterUserViewModel();  // Asociar el ViewModel

    }
}