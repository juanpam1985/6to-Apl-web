using Microsoft.AspNetCore.Mvc;
using Semana1_Tarea1.Models;
using Semana1_Tarea1.Services;

namespace Semana1_Tarea1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculadoraService _calculadoraService;

        public HomeController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var modelo = new CalculadoraViewModel
            {
                Operacion = "Sumar"
            };

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CalculadoraViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            try
            {
                var resultado = _calculadoraService.Calcular(
                    modelo.Numero1,
                    modelo.Numero2,
                    modelo.Operacion
                );

                modelo.Resultado = resultado;
                modelo.ResultadoTexto = _calculadoraService.ObtenerResultadoTexto(
                    modelo.Numero1,
                    modelo.Numero2,
                    modelo.Operacion,
                    resultado
                );
            }
            catch (DivideByZeroException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(modelo);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
