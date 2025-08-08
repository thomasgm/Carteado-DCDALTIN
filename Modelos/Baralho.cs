namespace Modelos;

class Baralho
{
    List<Carta> Cartas;

    public Baralho()
    {
        var baralho = new List<Carta>();

        for (int i = 1; i <= 100; i++)
        {
            baralho.Add(new Carta(i));
        }
        Cartas = baralho;
    }

    public Baralho(int tamanho)
    {
        var baralho = new List<Carta>();

        for (int i = 1; i <= tamanho; i++)
        {
            baralho.Add(new Carta(i));
        }
        Cartas = baralho;
    }

    public Baralho(bool usarMultiplicador = false, int tamanho = 10)
    {
        var baralho = new List<Carta>();
        var rand = new Random();

        for (int i = 1; i <= tamanho; i++)
        {
            if (usarMultiplicador)
            {
                // Multiplicador aleatório entre 1 e 3 (pode ajustar conforme desejar)
                int multiplicador = rand.Next(1, 4);
                baralho.Add(new CartaComMultiplicador(i, multiplicador));
            }
            else
            {
                baralho.Add(new Carta(i));
            }
        }
        Cartas = baralho;
    }

    public Carta DarCarta()
    {
        int posicaoPrimeiraCarta = 0;
        Carta carta = Cartas[posicaoPrimeiraCarta];
        Cartas.RemoveAt(posicaoPrimeiraCarta);
        return carta;
    }

    public void Embaralhar()
    {
        var rand = new Random();
        Cartas = Cartas.OrderBy(x => rand.Next()).ToList();
    }

}
