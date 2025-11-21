using Gestión_de_Reservas___Laboratorios_de_Cómputo.Models;

namespace Gestión_de_Reservas___Laboratorios_de_Cómputo.Data
{
    public class ReservaRepo
    {
        private static readonly List<Reserva> _reservas = new():
            private static int _nextId = 1;
        public static IReadOnlyList<Reserva> ObtenerTodos() => _reservas.AsReadOnly();
        public static void Agregar(Reserva p)
        {
            p.Id = _nextId++;
            _reservas.Add(p);
        }
    }
}
