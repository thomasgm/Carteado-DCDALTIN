using JogoDeCartas.Models;
using JogoDeCartas.Enums;

namespace JogoDeCartas.Core.Services
{
    public class Baralho
    {
        private List<Carta> cartas;

        public Baralho()
        {
            cartas = new List<Carta>();
            InicializarBaralho();
        }

        private void InicializarBaralho()
        {
            string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (var naipe in Enum.GetValues(typeof(Naipe)))
            {
                foreach (var valor in valores)
                {
                    cartas.Add(new Carta((Naipe)naipe, valor));
                }
            }
        }

        public int CartasRestantes => cartas.Count;

        public void Embaralhar()
        {
            Random rng = new Random();
            int n = cartas.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carta cartaTemp = cartas[k];
                cartas[k] = cartas[n];
                cartas[n] = cartaTemp;
            }
        }

        public Carta DistribuirCarta()
        {
            if (cartas.Count == 0)
                throw new InvalidOperationException("O baralho está vazio!");

            var carta = cartas[cartas.Count - 1];
            cartas.RemoveAt(cartas.Count - 1);
            return carta;
        }
    }
}
