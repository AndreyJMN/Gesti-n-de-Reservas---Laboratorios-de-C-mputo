using Gestión_de_Reservas___Laboratorios_de_Cómputo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gestión_de_Reservas___Laboratorios_de_Cómputo.Data
{
    public static class ReservaRepo
    {
        private static readonly List<Reserva> _reservas = new();
        private static int _nextId = 1;

        public static IEnumerable<Reserva> ObtenerTodos()
        {
            return _reservas;
        }

        public static void Agregar(Reserva reserva)
        {
            reserva.Id = _nextId++;
            _reservas.Add(reserva);
        }


        public static bool ExisteCodigo(string codReserva)
        {
            return _reservas.Any(r => r.CodReserva == codReserva);
        }
    }
}

