using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoP3.Models
{
    public class Auto
    {
        [PrimaryKey, AutoIncrement]
        public int IdAuto { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; }

        [Range(1900, 2100, ErrorMessage = "Año inválido")]
        public int Anio { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        public int PropietarioId { get; set; }
    }
}

