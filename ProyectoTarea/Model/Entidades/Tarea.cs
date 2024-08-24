using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Titulo { get; set; }
        [MaxLength(100)]
        public string? Descripcion { get; set; } = " ";  
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Boolean Estado { get; set; }
    }
}
