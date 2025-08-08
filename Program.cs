namespace Carteado
{
    using Modelos;

    class Program
    {
        static void Main(string[] args)
        {
            var jogoNormal = new Jogo(); // sem multiplicador
            var jogoComMultiplicador = new Jogo(true); // com multiplicador
            jogoComMultiplicador.Jogar();

            // jogo.VerificarGanhador(); é inacessível porque é private
        }
    }
}
