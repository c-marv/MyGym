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
    [Table("HISTORIAL")]
    public class Historial
    {
        [Key]
        public int HistorialID { get; set; }
        public DateTime Fecha { get; set; }
        public double Peso { get; set; }
        public double Estatura { get; set; }
        public EstadoNutricional EstadoNutricional { get; set; }
        public double IMC { get; set; }

        // Promedia de calorias, proteinas, grasas e hidratos de carbono por semana
        public double Calorias { get; set; }
        public double Proteinas { get; set; }
        public double Grasas { get; set; }
        public double HidratosCarbono { get; set; }

        public int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; }
    }
}
