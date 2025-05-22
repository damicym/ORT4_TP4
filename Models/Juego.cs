namespace TP4.Models;

static class Juego
{
    public static int intentos;
    public static List<char> aciertos;
    public static List<char> errores;
    public static string palabra { get; private set; }
    private static List<string> palabras;
    public static List<char> render;
    public static void InicializarPalabra(){
        palabras = new List<string> {"palabra", "estanca", "informatica", "labo", "debug", "milanesa", "turbina", "carnicero", "jaz", "motherboard", "canelones", "aura"};
        Random random = new Random();
        palabra =  palabras[random.Next(0, palabras.Count - 1)];
        render = new List<char>();
        aciertos = new List<char>();
        errores = new List<char>();
        foreach (char letra in palabra)
        {
            render.Add('_');
        }
        intentos = 0;
    }
}