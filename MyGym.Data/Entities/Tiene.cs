using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("TIENE")]
    public class Tiene
    {
        [Key, Column(Order = 1)]
        public int DietaID { get; set; }
        [Key, Column(Order = 2)]
        public int RecomendacionID { get; set; }

        [ForeignKey("DietaID")]
        public virtual Dieta Dieta { get; set; }
        [ForeignKey("RecomendacionID")]
        public virtual Recomendacion Recomendacion { get; set; }
    }
}
