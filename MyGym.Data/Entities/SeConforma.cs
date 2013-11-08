using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("SE_CONFORMA")]
    public class SeConforma
    {
        [Key, Column(Order = 1)]
        public int RecomendacionID { get; set; }
        [Key, Column(Order = 2)]
        public int AlimentoID { get; set; }

        public double Cantidad { get; set; } // En Gramos

        [ForeignKey("AlimentoID")]
        public virtual Alimento Alimento { get; set; }
        [ForeignKey("RecomendacionID")]
        public virtual Recomendacion Recomendacion { get; set; }
    }
}
