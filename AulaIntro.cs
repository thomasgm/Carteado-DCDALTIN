class AulaIntro
{
    public void Rodar()
    {
        int tamanhoBaralho = 100;

        List<int> criarBaralho(int tamanho)
        {
            var baralho = new List<int>();

            for (int i = 1; i <= tamanho; i++)
            {
                baralho.Add(i);
            }
            return baralho;
        }

        List<int> embaralhar(List<int> baralho)
        {
            var rand = new Random();
            return baralho.OrderBy(x => rand.Next()).ToList();
        }

        int darCarta(List<int> baralho)
        {
            int posicaoPrimeiraCarta = 0;
            int carta = baralho[posicaoPrimeiraCarta];
            baralho.RemoveAt(posicaoPrimeiraCarta);
            return carta;
        }

        var baralho = criarBaralho(tamanhoBaralho);

        List<int> baralhoEmbaralhado = embaralhar(baralho);

        int carta1 = darCarta(baralhoEmbaralhado);
        int carta2 = darCarta(baralhoEmbaralhado);

        var jogador1 = carta1;
        var jogador2 = carta2;

        if (jogador1 > jogador2)
        {
            Console.WriteLine($"Jogador 1 ganhou! Carta: {jogador1} vs Carta: {jogador2}");
        }
        else if (jogador2 > jogador1)
        {
            Console.WriteLine($"Jogador 2 ganhou! Carta: {jogador1} vs Carta: {jogador2}");
        }
        else
        {
            Console.WriteLine($"Empate! Carta: {jogador1} vs Carta: {jogador2}");
        }
    }
}
