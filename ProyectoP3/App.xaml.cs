namespace ProyectoP3
{
    public partial class App : Application
    {
        private static Services.DatabaseService _database;

        public static Services.DatabaseService Database
        {
            get
            {
                if (_database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProyectoP3.db3");
                    _database = new Services.DatabaseService(dbPath);
                }
                return _database;
            }
        }
        public App()
        {
            InitializeComponent();
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}