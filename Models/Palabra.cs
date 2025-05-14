namespace TP4_Ahorcado.Models;

static class Palabra
{
    public static string palabra { get; private set; }
    private static List<string> palabras;
    public static void InicializarPalabra(){
        palabras = new List<string> {"Palabra"};
        Random random = new Random();
        palabra =  palabras[random.Next(0, palabras.Count - 1)];
    }
}