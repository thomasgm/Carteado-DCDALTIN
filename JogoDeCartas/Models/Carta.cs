using JogoDeCartas.Enums;

namespace JogoDeCartas.Models
{
    public class Carta
    {
        public Naipe Naipe { get; set; }
        public string Valor { get; set; }

        public Carta(Naipe naipe, string valor)
        {
            Naipe = naipe;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"{Valor} de {Naipe}";
        }
    }
}
