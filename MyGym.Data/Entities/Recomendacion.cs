using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("RECOMENDACION")]
    public class Recomendacion
    {
        [Key]
        public int RecomendacionID { get; set; }
        public string Nombre { get; set; }
        public string Preparacion { get; set; }

        public double Calorias { get; set; } 
        public double Proteinas { get; set; } 
        public double Grasas { get; set; } 
        public double HidratosDeCarbono { get; set; } 

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public virtual ICollection<SeConforma> SeConforma { get; set; }
        public virtual ICollection<SeRecomienda> SeRecomiendaEn { get; set; }
        public virtual ICollection<Tiene> Tiene { get; set; }

        public Recomendacion()
        {
            SeConforma = new HashSet<SeConforma>();
            SeRecomiendaEn = new HashSet<SeRecomienda>();
            Tiene = new HashSet<Tiene>();
        }
    }
}
