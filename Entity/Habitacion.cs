using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class Habitacion
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdHabitacion { get; set; }
        [Column(TypeName = "varchar(8)")]
        public string Tipo { get; set; }
        [Column(TypeName = "int")]
        public int NMinPersonas { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string Estado { get; set; }
        [Column(TypeName = "int")]
        public int Precio { get; set; }
    }
}