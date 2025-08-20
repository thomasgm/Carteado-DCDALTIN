using JogoDeCartas.Models;
using JogoDeCartas.Core.Services;

namespace JogoDeCartas.Core.GameLogic
{
    public class Equipe
    {
        public string Nome { get; set; }
        public List<Jogador> Jogadores { get; set; }
        public int Pontos { get; set; }
        public bool Trucou { get; set; }
        public bool AceitouTruco { get; set; }
        public bool FezEnchente { get; set; }

        public Equipe(string nome)
        {
            Nome = nome;
            Jogadores = new List<Jogador>();
            Pontos = 0;
            Trucou = false;
            AceitouTruco = false;
            FezEnchente = false;
        }
    }

    // MesaDeTruco.cs
    public class MesaDeTruco
    {
        public List<Carta> CartasNaMesa { get; private set; }

        public MesaDeTruco()
        {
            CartasNaMesa = new List<Carta>();
        }

        public void AdicionarCarta(Carta carta)
        {
            CartasNaMesa.Add(carta);
        }

        public void MostrarCartasNaMesa()
        {
            Console.WriteLine("\nCartas na mesa:");
            foreach (var carta in CartasNaMesa)
            {
                Console.WriteLine($"  {carta}");
            }
        }
    }
}
