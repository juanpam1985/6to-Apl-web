namespace Semana1_Tarea1.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public decimal Calcular(decimal numero1, decimal numero2, string operacion)
        {
            return operacion switch
            {
                "Sumar" => numero1 + numero2,
                "Restar" => numero1 - numero2,
                "Multiplicar" => numero1 * numero2,
                "Dividir" => numero2 == 0
                    ? throw new DivideByZeroException("No se puede dividir para cero.")
                    : numero1 / numero2,
                _ => throw new ArgumentException("Operación no válida.")
            };
        }

        public string ObtenerResultadoTexto(decimal numero1, decimal numero2, string operacion, decimal resultado)
        {
            var simbolo = operacion switch
            {
                "Sumar" => "+",
                "Restar" => "-",
                "Multiplicar" => "×",
                "Dividir" => "÷",
                _ => "?"
            };

            return $"{numero1} {simbolo} {numero2} = {resultado}";
        }
    }
}
