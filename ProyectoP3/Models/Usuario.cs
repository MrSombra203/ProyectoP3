using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ProyectoP3.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
