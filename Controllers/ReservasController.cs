using Microsoft.AspNetCore.Mvc;
using Gestión_de_Reservas___Laboratorios_de_Cómputo.Data;
using Gestión_de_Reservas___Laboratorios_de_Cómputo.Models;
using System.Collections.Generic;

namespace Gestión_de_Reservas___Laboratorios_de_Cómputo.Controllers
{
    public class ReservasController : Controller
    {
        public IActionResult Index()
        {
            var reservas = ReservaRepo.ObtenerTodos();
            return View(reservas);
        }

        public IActionResult Create()
        {
            CargarLaboratorios();
            return View(new Reserva());
        }

        [HttpPost]
        public IActionResult Create(Reserva model)
        {
            CargarLaboratorios();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!model.ValidarHoras())
            {
                ModelState.AddModelError(nameof(model.HoraFin),
                    "La hora de fin debe ser mayor que la hora de inicio.");
            }

            if (ReservaRepo.ExisteCodigo(model.CodReserva))
            {
                ModelState.AddModelError(nameof(model.CodReserva),
                    "El código de reserva ya existe. Debe ser único.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ReservaRepo.Agregar(model);

            TempData["Mensaje"] = $"Reserva '{model.NombreProfesor}' registrada correctamente";

            return RedirectToAction(nameof(Index));
        }

        private void CargarLaboratorios()
        {
            ViewBag.Laboratorios = new List<string>
            {
                "Seleccione...",
                "Lab-01",
                "Lab-02",
                "Lab-03",
                "Lab-Redes",
                "Lab-IA"
            };
        }
    }
}
