using SQLite;

namespace ProyectoP3.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
