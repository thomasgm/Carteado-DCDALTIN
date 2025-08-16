using JogoDeCartas.Models;

namespace JogoDeCartas.Core.Services
{
    public class Jogador
    {
        public string Nome { get; set; }
        public List<Carta> Mao { get; private set; }
        public int Pontos { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Mao = new List<Carta>();
            Pontos = 0;
        }

        public void ReceberCarta(Carta carta)
        {
            Mao.Add(carta);
        }

        public void MostrarMao()
        {
            Console.WriteLine($"Mão do jogador {Nome}:");
            foreach (var carta in Mao)
            {
                Console.WriteLine($"  {carta}");
            }
        }
    }
}
