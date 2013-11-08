using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("SE_RECOMIENDA_EN")]
    public class SeRecomienda
    {
        [Key, Column(Order = 1)]
        public int TiempoDeComidaID { get; set; }
        [Key, Column(Order = 2)]
        public int RecomendacionID { get; set; }

        [ForeignKey("TiempoDeComidaID")]
        public virtual TiempoDeComida TiempoDeComida { get; set; }
        [ForeignKey("RecomendacionID")]
        public virtual Recomendacion Recomendacion { get; set; }
    }
}
