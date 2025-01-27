using SQLite;
using System;

namespace ProyectoP3.Models
{
    public class Auto
    {
        [PrimaryKey, AutoIncrement]
        public int IdAuto { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal Precio { get; set; }

        public int PropietarioId { get; set; }
    }
}

