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
    public IActionResult GuessLetra(char guess)
    {
        const int MAX_INTENTOS = 6;
        guess = char.ToLower(guess);
        ViewBag.intentos = Juego.intentos;
        if(!Juego.aciertos.Contains(guess) && !Juego.errores.Contains(guess)){
            Juego.intentos++;
            ViewBag.intentos = Juego.intentos;
            List<int> indexAciertos = new List<int>();
            bool guessCorrecto = false;
            if(Juego.errores.Count >= MAX_INTENTOS){
                ViewBag.mensaje = $"Parece que {Juego.intentos} intentos no fueron suficientes";
                ViewBag.resultado = guessCorrecto;
                return View("Resultado");
            }
            ViewBag.mensaje = null;
            for (int i = 0; i < Juego.palabra.Length; i++)
            {
                if (char.ToLower(Juego.palabra[i]) == guess)
                {
                    indexAciertos.Add(i);
                    guessCorrecto = true;
                    
                }
            }
            if (guessCorrecto)
            {
                Juego.aciertos.Add(guess);
                foreach (int index in indexAciertos)
                {
                    Juego.render[index] = guess;
                }
            }
            else Juego.errores.Add(guess);
            int j = -1;
            do
            {
                j++;
            } while (j < Juego.palabra.Length && Juego.palabra[j] == Juego.render[j]);
            if (j >= Juego.palabra.Length)
            {
                ViewBag.resultado = true;
                return View("Resultado");
            }
            else
            {
                ViewBag.aciertos = Juego.aciertos;
                ViewBag.errores = Juego.errores;
                ViewBag.render = Juego.render;
                return View("Partida");
            }
        }else{
            ViewBag.mensaje = "Ya intentaste con esa letra";
            ViewBag.aciertos = Juego.aciertos;
            ViewBag.errores = Juego.errores;
            ViewBag.render = Juego.render;
            return View("Partida");
        }
    }
    public IActionResult GuessPalabra(string guessPalabra)
    {
        Juego.intentos++;
        bool guessCorrecto = guessPalabra.ToLower() == Juego.palabra.ToLower();
        ViewBag.intentos = Juego.intentos;
        ViewBag.palabra = Juego.palabra;
        ViewBag.resultado = guessCorrecto;
        if (!guessCorrecto) ViewBag.mensaje = "Ayy casi!";
        return View("Resultado");
    }
    public IActionResult EmpezarPartida()
    {
        Juego.InicializarPalabra();
        ViewBag.intentos = Juego.intentos;
        ViewBag.aciertos = Juego.aciertos;
        ViewBag.errores = Juego.errores;
        ViewBag.render = Juego.render;
        return View("Partida");
    }
}
