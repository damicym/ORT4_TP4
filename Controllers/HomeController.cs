using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4_Ahorcado.Models;

namespace TP4_Ahorcado.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Partida(string palabra, List<char> aciertos, List<char> errores, int intentos, string guess)
    {
        ViewBag.aciertos = aciertos;
        ViewBag.errores = errores;
        ViewBag.intentos = intentos;
        ViewBag.guess = guess;
        // ViewBag.hidden;

        foreach (char letra in palabra)
        {
            if(letra == guess)
        }
        return Partida();
    }

    public IActionResult Resultado(bool res)
        {
            ViewBag.resultado = res;
            return Resultado();
        }
}
