using MyGym.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("EJERCICIO")]
    public class Ejercicio
    {
        [Key]
        public int EjercicioID { get; set; }
        public string Nombre { get; set; }
        public int Repeticiones { get; set; }
        public int Sets { get; set; }
        public int Duracion { get; set; }
        public int Distancia { get; set; }
        public int Peso { get; set; }
        public string Descripcion { get; set; }
        public TipoEjercicio Tipo { get; set; }
    }
}
