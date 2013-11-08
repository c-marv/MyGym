using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data.Entities
{
    [Table("GRUPO")]
    public class Grupo
    {
        [Key]
        public int GrupoID { get; set; }
        public string Nombre { get; set; }
        public int RecomendacionMinima { get; set; }
        public int RecomendacionMaxima { get; set; }

        public virtual ICollection<Alimento> Alimento { get; set; }

        public Grupo()
        {
            Alimento = new HashSet<Alimento>();
        }
    }
}
