using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Tareas.Models
{
    public class Tarea
    {
        // [Key]
        public Guid TareaId { get; set; }

        // [ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }

        // [Required]
        // [MaxLength(200)]
        public string Titulo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }

        // [NotMapped]
        public string? Resumen { get; set; }
    }

    public enum Prioridad
    {
        Baja, Media, Alta
    }
}