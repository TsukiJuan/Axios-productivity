using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace Axios.Models
{
    public class Tarea
    {
        [Key]
        public int Id_Tarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateOnly Fecha_Limite { get; set; }
        public TimeOnly Hora { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Alarma { get; set; }
    }
}
