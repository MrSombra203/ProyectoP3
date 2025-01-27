namespace ProyectoP3.Views;
using ProyectoP3.ViewModels;


public partial class TransactionPage : ContentPage
{
	public TransactionPage()
	{
		InitializeComponent();
        BindingContext = new TransactionViewModel();

    }
}