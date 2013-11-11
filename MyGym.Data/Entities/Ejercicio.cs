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
        public double Distancia { get; set; }
        public int Peso { get; set; }
        public int Calorias { get; set; }
        public virtual ICollection<Instruccion> Instruccion { get; set; }
        public virtual ICollection<Imagen> Imagen { get; set; }
        public TipoEjercicio Tipo { get; set; }
        public Ejercicio()
        {
            Instruccion = new HashSet<Instruccion>();
            Imagen = new HashSet<Imagen>();
        }
    }
}
