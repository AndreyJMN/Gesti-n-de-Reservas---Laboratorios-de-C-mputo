using System;
using System.ComponentModel.DataAnnotations;

namespace Gestión_de_Reservas___Laboratorios_de_Cómputo.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre del profesor debe tener al menos 3 caracteres.")]
        [Display(Name = "Nombre del profesor.")]
        public string NombreProfesor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo institucional es requerido.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        [RegularExpression(@"^[\w\-\.]+@campus\.edu$", ErrorMessage = "El correo debe pertenecer al dominio institucional @campus.edu.")]
        [Display(Name = "Correo institucional.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un laboratorio.")]
        [RegularExpression(@"^(Lab-01|Lab-02|Lab-03|Lab-Redes|Lab-IA)$",
        ErrorMessage = "Seleccione un laboratorio válido.")]
        public string Laboratorio { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de la reserva es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de reserva.")]
        [CustomValidation(typeof(Reserva), nameof(ValidarFecha))]
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de inicio.")]
        public TimeSpan? HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de fin.")]
        public TimeSpan? HoraFin { get; set; }

        [Required(ErrorMessage = "El motivo de la reserva es obligatorio.")]
        [MinLength(5, ErrorMessage = "El motivo debe tener al menos 5 caracteres.")]
        [MaxLength(200, ErrorMessage = "El motivo no puede superar 200 caracteres.")]
        [Display(Name = "Motivo / descripción de la reserva")]
        public string Motivo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código de reserva es obligatorio.")]
        [RegularExpression(@"^RES-\d{3}$", ErrorMessage = "El código debe tener el formato RES-###.")]
        [Display(Name = "Código de reserva")]
        public string CodReserva { get; set; } = string.Empty;

        public static ValidationResult ValidarFecha(DateTime? fecha, ValidationContext context)
        {

            if (!fecha.HasValue)
                return ValidationResult.Success;

            if (fecha.Value.Date < DateTime.Now.Date)
            {
                return new ValidationResult("La fecha de la reserva no puede ser en el pasado.");
            }

            return ValidationResult.Success;
        }

        public bool ValidarHoras()
        {
            if (!HoraInicio.HasValue || !HoraFin.HasValue)
                return true;

            return HoraFin.Value > HoraInicio.Value;
        }
    }
}
