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
    [Table("TIEMPO_DE_COMIDA")]
    public class TiempoDeComida
    {
        [Key]
        public int TiempoDeComidaID { get; set; }
        public TiempoComida Nombre { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }

        public virtual ICollection<SeRecomienda> SeRecomiendaEn { get; set; }
        // Posible cambio
        public virtual ICollection<PreferenciaTiempoComida> PreferenciasUsuarios { get; set; }
        public TiempoDeComida()
        {
            SeRecomiendaEn = new HashSet<SeRecomienda>();
            PreferenciasUsuarios = new HashSet<PreferenciaTiempoComida>();
        }
    }
}
