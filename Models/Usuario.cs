using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Axios.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario    { get; set; }
        public string Nombre     { get; set; }
        public string Correo     { get; set; }
        public string Contraseña { get; set; }
    }
}
