using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyGym.Data.Entities
{
    public class Imagen
    {
        public int ImagenID { get; set; }
        public string Description { get; set; }
        [Column(TypeName="image")]
        public byte[] Image { get; set; }
    }
}
