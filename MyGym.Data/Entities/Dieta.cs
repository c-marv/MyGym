
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
    [Table("DIETA")]
    public class Dieta
    {
        [Key]
        public int DietaID { get; set; }
        public Dia Dia { get; set; }
        public double Calorias { get; set; }
        public double Proteinas { get; set; }
        public double Grasas { get; set; }
        public double HidratosCarbono { get; set; }

        // Timepo de Comida
        //public int TiempoDeComidaID { get; set; }
        //[ForeignKey("TiempoDeComidaID")]
        //public virtual TiempoDeComida TiempoDeComida { get; set; }
        // Usuario
        public int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Tiene> Tiene { get; set; }

        public Dieta()
        {
            Tiene = new HashSet<Tiene>();
        }
    }
}
