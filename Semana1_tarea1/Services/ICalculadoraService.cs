namespace Semana1_Tarea1.Services
{
    public interface ICalculadoraService
    {
        decimal Calcular(decimal numero1, decimal numero2, string operacion);
        string ObtenerResultadoTexto(decimal numero1, decimal numero2, string operacion, decimal resultado);
    }
}
