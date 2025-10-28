using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Axios.Models
{
    public class Alarma
    {
        [Key]
        public int Id_Alarma{get; set; }
        public string Nombre { get; set; }
        public string Ruta {get; set; }
}
}
