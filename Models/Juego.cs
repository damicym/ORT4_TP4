namespace TP4.Models;

static class Juego
{
    public static int intentos;
    public static List<char> aciertos;
    public static List<char> errores;
    public static string palabra { get; private set; }
    private static List<string> palabras;
    public static void InicializarPalabra(){
        // palabras = new List<string> {"Palabra"};
        // Random random = new Random();
        // palabra =  palabras[random.Next(0, palabras.Count - 1)];
        palabra = "Palabra";
    }
}