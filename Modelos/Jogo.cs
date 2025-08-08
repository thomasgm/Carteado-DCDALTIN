namespace Modelos;

class Jogo
{
    Baralho Baralho;
    Jogador Jogador1;
    Jogador Jogador2;
    bool UsarMultiplicador;

    public Jogo()
    {
        Baralho = new Baralho();
        Jogador1 = new Jogador();
        Jogador2 = new Jogador();
    }

    public Jogo(Baralho baralho)
    {
        Baralho = baralho;
        Jogador1 = new Jogador();
        Jogador2 = new Jogador();
    }

    public Jogo(Baralho baralho, Jogador jogador1, Jogador jogador2)
    {
        Baralho = baralho;
        Jogador1 = jogador1;
        Jogador2 = jogador2;
    }

    public Jogo(bool usarMultiplicador = false)
    {
        UsarMultiplicador = usarMultiplicador;
        Baralho = new Baralho(usarMultiplicador,100);
        Jogador1 = new Jogador();
        Jogador2 = new Jogador();
    }

    public void Jogar()
    {
        Baralho.Embaralhar();
        Jogador1.Carta = Baralho.DarCarta();
        Jogador2.Carta = Baralho.DarCarta();

        VerificarGanhador();
    }

    private void VerificarGanhador()
    {
        int pontosJogador1 = Pontuacao(Jogador1.Carta);
        int pontosJogador2 = Pontuacao(Jogador2.Carta);

        if (pontosJogador1 > pontosJogador2)
        {
            Console.WriteLine($"Jogador 1 ganhou! Pontos: {pontosJogador1} vs Pontos: {pontosJogador2}");
        }
        else if (pontosJogador2 > pontosJogador1)
        {
            Console.WriteLine($"Jogador 2 ganhou! Pontos: {pontosJogador2} vs Pontos: {pontosJogador1}");
        }
        else
        {
            Console.WriteLine($"Empate! Pontos: {pontosJogador1} vs Pontos: {pontosJogador2}");
        }
    }

    private int Pontuacao(Carta carta)
    {
        if (UsarMultiplicador && carta is CartaComMultiplicador cartaMult)
        {
            return cartaMult.Valor * cartaMult.Multiplicador;
        }
        return carta.Valor;
    }
}
