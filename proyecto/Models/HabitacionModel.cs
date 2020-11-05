using Entity;

namespace HabitacionModel
{
    public class HabitacionInputModel
    {
        public string IdHabitacion { get; set; }
        public string Tipo { get; set; }
        public int nPersonas { get; set; }
        public string Estado { get; set; }
        public int Precio { get; set; }
    }

    public class HabitacionViewModel : HabitacionInputModel
    {
        public HabitacionViewModel(Habitacion habitacion)
        {
            IdHabitacion = habitacion.IdHabitacion;
            Tipo = habitacion.Tipo;
            nPersonas = habitacion.nPersonas;
            Estado = habitacion.Estado;
            Precio = habitacion.Precio;
        }
    }
}