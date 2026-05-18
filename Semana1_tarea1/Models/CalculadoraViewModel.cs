using System.ComponentModel.DataAnnotations;

namespace Semana1_Tarea1.Models
{
    public class CalculadoraViewModel
    {
        [Display(Name = "Primer número")]
        [Required(ErrorMessage = "Ingrese el primer número.")]
        public decimal Numero1 { get; set; }

        [Display(Name = "Segundo número")]
        [Required(ErrorMessage = "Ingrese el segundo número.")]
        public decimal Numero2 { get; set; }

        [Display(Name = "Operación")]
        [Required(ErrorMessage = "Seleccione una operación.")]
        public string Operacion { get; set; } = "Sumar";

        public decimal? Resultado { get; set; }

        public string ResultadoTexto { get; set; } = string.Empty;
    }
}
