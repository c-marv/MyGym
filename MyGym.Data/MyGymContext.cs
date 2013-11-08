using MyGym.Common.Enum;
using MyGym.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data
{
    public class MyGymContext : DbContext
    {
        private static MyGymContext db = new MyGymContext();
        public static MyGymContext DB
        {
            get { return db; }
            set { db = value; }
        }
        private Random random = new Random();
        public Random Random
        {
            get { return random; }
            set { random = value; }
        }
        // Usuario
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Historial> Historial { get; set; }
        public DbSet<PreferenciaTiempoComida> PreferenciaTiempoComida { get; set; }
        // Dieta
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<Dieta> Dieta { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Recomendacion> Recomendacion { get; set; }
        public DbSet<SeConforma> SeConforma { get; set; }
        public DbSet<SeRecomienda> SeRecomienda { get; set; }
        public DbSet<TiempoDeComida> TiempoDeComida { get; set; }
        public DbSet<Tiene> Tiene { get; set; }
        // Rutinas
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<Ejercicio> Ejercicio { get; set; }
        public DbSet<Actividad> Actividad { get; set; }

        public MyGymContext()
            : base()
        {
            Database.SetInitializer<MyGymContext>(new MyGymInitializer());
        }
    }
    public class MyGymInitializer : DropCreateDatabaseIfModelChanges<MyGymContext>
    {
        protected override void Seed(MyGymContext context)
        {
            // Usuarios
            context.Usuario.Add(new Usuario() { 
                ComplexionFisica = ComplexionFisica.Mediana,
                Email = "yerson_kira@hotmail.com",
                Estatura = 1.75,
                FechaNacimiento = new DateTime(1991, 1, 25),
                Materno = "Pariapaza",
                Nick = "Yerson",
                Nombre = "Yerson Marvin",
                Password = "123456",
                Paterno = "Copa",
                Peso = 59,
                Sexo = Common.Enum.Sexo.Masculino,
            });
            context.SaveChanges();

            // Actividades
            
            // Tiempo de Comida
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Desayuno,
                HoraInicio = new TimeSpan(6, 0, 0),
                HoraFinal = new TimeSpan(10, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Merienda,
                HoraInicio = new TimeSpan(10, 0, 0),
                HoraFinal = new TimeSpan(12, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Almuerzo,
                HoraInicio = new TimeSpan(12, 0, 0),
                HoraFinal = new TimeSpan(14, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Merienda,
                HoraInicio = new TimeSpan(14, 0, 0),
                HoraFinal = new TimeSpan(18, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Cena,
                HoraInicio = new TimeSpan(18, 0, 0),
                HoraFinal = new TimeSpan(20, 0, 0)
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
