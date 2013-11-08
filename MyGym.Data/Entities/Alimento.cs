using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("ALIMENTO")]
    public class Alimento
    {
        [Key]
        public int AlimentoID { get; set; }
        public string Nombre { get; set; }

        public double Calorias { get; set; } // x100 gramos
        public double Proteinas { get; set; } // x100 gramos
        public double Grasas { get; set; } // x100 gramos
        public double HidratosDeCarbono { get; set; } // x100 gramos

        public int GrupoID { get; set; }
        [ForeignKey("GrupoID")]
        public virtual Grupo Grupo { get; set; }

        public virtual ICollection<SeConforma> SeConforma { get; set; }

        public Alimento()
        {
            SeConforma = new HashSet<SeConforma>();
        }
    }
}
