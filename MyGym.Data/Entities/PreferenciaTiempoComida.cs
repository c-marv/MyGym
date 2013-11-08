using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("PREFERENCIA_TIEMPO_COMIDA")]
    public class PreferenciaTiempoComida
    {
        [Key, Column(Order = 1)]
        public int TiempoDeComidaID { get; set; }
        [Key, Column(Order = 2)]
        public int UsuarioID { get; set; }

        [ForeignKey("TiempoDeComidaID")]
        public virtual TiempoDeComida TiempoDeComida { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; }
    }
}
