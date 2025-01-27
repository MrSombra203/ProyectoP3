using SQLite;
using System;

namespace ProyectoP3.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int IdTransaction { get; set; }

        public int UsuarioId { get; set; } 
        public int AutoId { get; set; }    
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
