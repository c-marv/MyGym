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
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nick { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public Sexo Sexo { get; set; }
        public double Peso { get; set; } // En Kilogramos
        public double Estatura { get; set; } // En metros
        public ComplexionFisica ComplexionFisica { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Posible cambio
        public Nivel Nivel { get; set; }
        public float FactorActividad { get; set; }
        //

        public virtual ICollection<Dieta> Dieta { get; set; }
        public virtual ICollection<Historial> Historial { get; set; }
        // Posible cambio
        public virtual ICollection<PreferenciaTiempoComida> TiemposDeComida { get; set; }
        public Usuario()
        {
            Dieta = new HashSet<Dieta>();
            Historial = new HashSet<Historial>();
            TiemposDeComida = new HashSet<PreferenciaTiempoComida>();
        }
    }
}
