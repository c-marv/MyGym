using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("ACTIVIDAD")]
    public class Actividad
    {
        [Key]
        public int ActividadID { get; set; }
        public DateTime Fecha { get; set; }
        public int RutinaID { get; set; }
        public int EjercicioID { get; set; }
        [ForeignKey("RutinaID")]
        public virtual Rutina Rutina { get; set; }
        [ForeignKey("EjercicioID")]
        public virtual Ejercicio Ejercicio { get; set; }
    }
}