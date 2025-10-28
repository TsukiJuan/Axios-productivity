using Axios.Models;
using Microsoft.EntityFrameworkCore;

namespace Axios.Data
{
    public class AxiosContext : DbContext
    {
        public AxiosContext(DbContextOptions<AxiosContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alarma>().HasData(
            new Alarma
            {
                Id_Alarma = 1,
                Nombre = "",
                Ruta = "",
            },
            new Alarma
            {
                Id_Alarma = 2,
                Nombre = "Zumbido",
                Ruta = "xxxxx/Zumbido.mp3",
            },
            new Alarma
            {
                Id_Alarma = 3,
                Nombre = "Pitido",
                Ruta = "xxxxx/Pitido.mp3",
            },
            new Alarma
            {
                Id_Alarma = 4,
                Nombre = "Himno",
                Ruta = "xxxxx/Colombia.mp3",
            }
            );

            modelBuilder.Entity<Tarea>().HasData(
            new Tarea
            {
                Id_Tarea = 1,
                Titulo = "Cita Odontologica",
                Descripcion = "Tengo que salir por más tardar a esta hora para llegar",
                Fecha_Limite = new DateOnly(2025, 10, 28),
                Hora = new TimeOnly(12, 30),
                ID_Usuario = 1,
                ID_Alarma = 0,
            },
            new Tarea
            {
                Id_Tarea = 2,
                Titulo = "Examen Estadistica",
                Descripcion = "El Examen comienza a esta hora",
                Fecha_Limite = new DateOnly(2025, 12, 05),
                Hora = new TimeOnly(10, 00),
                ID_Usuario = 2,
                ID_Alarma = 1,
            },
            new Tarea
            {
                Id_Tarea = 3,
                Titulo = "Pastillas para presión",
                Descripcion = "A esta hora tengo que tomar mis pastillas",
                Fecha_Limite = new DateOnly(2025, 10, 15),
                Hora = new TimeOnly(9, 30),
                ID_Usuario = 3,
                ID_Alarma = 2,
            }
            );

            modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id_Usuario = 1,
                Nombre = "Fernando José",
                Correo = "Fernando.buelvas176@pascualbravo.edu.co",
                Contraseña = "DispositivosMoviles",
            },
            new Usuario
            {
                Id_Usuario = 2,
                Nombre = "Juan Calderon",
                Correo = "Juan.Calderon698@pascualbravo.edu.co",
                Contraseña = "DispositivosMoviles123",
            },
            new Usuario
            {
                Id_Usuario = 3,
                Nombre = "Omar Andres",
                Correo = "Omar.Cardona@pascualbravo.edu.co",
                Contraseña = "Cardona"
            }
            );

        }

        public DbSet<Alarma> Alarmas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
