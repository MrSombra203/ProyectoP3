namespace ProyectoP3.Views;
using ProyectoP3.ViewModels;

public partial class RegisterCarPage : ContentPage
{
	public RegisterCarPage()
	{
		InitializeComponent();
        BindingContext = new RegisterCarViewModel(App.Database); 

    }
}