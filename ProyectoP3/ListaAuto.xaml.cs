namespace ProyectoP3
{
    public partial class ListaAuto : ContentPage
    {
        public ListaAuto()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ListaAutoViewModel(App.Database); // Aquí inyectamos el servicio de base de datos
        }
    }
}
