namespace ProyectoP3
{
    public partial class ListaAuto : ContentPage
    {
        public ListaAuto()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ListaAutoViewModel(App.Database); // Aqu� inyectamos el servicio de base de datos
        }
    }
}
