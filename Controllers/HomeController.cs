using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4.Models;

namespace TP4.Controllers;

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

    
    public IActionResult Partida(char guess)
    {
        Juego.InicializarPalabra();
        Juego.intentos++;
        List<int> indexAciertos = new List<int>();
        bool guessCorrecto = false;
        for (int i = 0; i < Juego.palabra.Length; i++)
        {
            if(Juego.palabra[i] == guess){
                indexAciertos.Add(i);
                guessCorrecto = true;
            }
        }
        if(guessCorrecto) Juego.aciertos.Add(guess);
        else Juego.errores.Add(guess);
        return Partida();
    }

    public IActionResult Resultado(bool res)
        {
            ViewBag.resultado = res;
            return Resultado();
        }
}
