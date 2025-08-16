using JogoDeCartas.Core.Services;
using JogoDeCartas.Models;

namespace JogoDeCartas.Core.GameLogic
{
    public class GerenciadorDeJogo
    {
        private List<Jogador> jogadores;
        private Baralho baralho;
        private int jogadorAtual;

        public GerenciadorDeJogo()
        {
            jogadores = new List<Jogador>();
            baralho = new Baralho();
        }

        public void AdicionarJogador(string nome)
        {
            jogadores.Add(new Jogador(nome));
        }

        public void IniciarRodada()
        {
            DistribuirCartasIniciais();

            while (!VerificarFimDaRodada())
            {
                RealizarTurnoDoJogador(jogadorAtual);

                if (!VerificarFimDaRodada())
                    AvancarProximoJogador();
            }

            FinalizarRodada();
        }

        private void DistribuirCartasIniciais()
        {
            foreach (var jogador in jogadores)
            {
                for (int i = 0; i < 5; i++) // Distribui 5 cartas para cada jogador
                {
                    jogador.ReceberCarta(baralho.DistribuirCarta());
                }
            }
        }
        private void MostrarPlacar()
        {
            Console.WriteLine("\n=== PLACAR ===");
            foreach (var jogador in jogadores)
            {
                Console.WriteLine($"{jogador.Nome}: {jogador.Pontos} pontos");
            }
            Console.WriteLine("=============");
        }

        private void RealizarTurnoDoJogador(int indiceJogador)
        {
            var jogadorAtual = jogadores[indiceJogador];

            Console.WriteLine($"\nVez do jogador: {jogadorAtual.Nome}");
            jogadorAtual.MostrarMao();

            MostrarOpcoesDoJogador(jogadorAtual);
        }

        private void AvancarProximoJogador()
        {
            jogadorAtual = (jogadorAtual + 1) % jogadores.Count;
        }

        private void JogarCarta(Jogador jogador)
        {
            Console.WriteLine("\nEscolha uma carta para jogar:");
            for (int i = 0; i < jogador.Mao.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {jogador.Mao[i]}");
            }

            int escolha = Convert.ToInt32(Console.ReadLine()) - 1;
            if (escolha >= 0 && escolha < jogador.Mao.Count)
            {
                var cartaJogada = jogador.Mao[escolha];
                jogador.Mao.RemoveAt(escolha);

                // Adicionar pontos ao jogador
                jogador.Pontos += CalcularPontosDaCarta(cartaJogada);

                Console.WriteLine($"Você jogou: {cartaJogada} (+{CalcularPontosDaCarta(cartaJogada)} pontos)");
                MostrarPlacar();
            }
        }

        private int CalcularPontosDaCarta(Carta carta)
        {
            int pontos = 0;

            switch (carta.Valor)
            {
                case "A":
                    pontos = 11;
                    break;
                case "K":
                case "Q":
                case "J":
                    pontos = 10;
                    break;
                case "10":
                    pontos = 10;
                    break;
                default:
                    pontos = int.Parse(carta.Valor);
                    break;
            }

            return pontos;
        }

        private void MostrarOpcoesDoJogador(Jogador jogador)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Jogar carta (ganha pontos da carta)");
            Console.WriteLine("2 - Pegar carta do baralho (risco: pode perder pontos se for uma carta alta!)");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    JogarCarta(jogador);
                    break;
                case "2":
                    PegarCarta(jogador);
                    break;
            }
        }

        private void PegarCarta(Jogador jogador)
        {
            if (baralho.CartasRestantes > 0)
            {
                var novaCarta = baralho.DistribuirCarta();
                jogador.Mao.Add(novaCarta);
                // Se a carta for alta (10 ou mais), perde pontos!
                int pontosCarta = CalcularPontosDaCarta(novaCarta);
                if (pontosCarta >= 10)
                {
                    jogador.Pontos -= pontosCarta;
                    Console.WriteLine($"Ops! Você pegou {novaCarta} e perdeu {pontosCarta} pontos!");
                }
                else
                {
                    jogador.Pontos += pontosCarta;
                    Console.WriteLine($"Você pegou {novaCarta} e ganhou {pontosCarta} pontos!");
                }
                MostrarPlacar();
            }
            else
            {
                Console.WriteLine("Não há mais cartas no baralho!");
            }
        }

        private bool VerificarFimDaRodada()
        {
            // Rodada termina quando alguém atingir 50 pontos ou ficar negativo
            foreach (var jogador in jogadores)
            {
                if (jogador.Pontos >= 50 || jogador.Pontos < 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void FinalizarRodada()
        {
            Console.WriteLine("\n=== FIM DA RODADA ===");
            MostrarPlacar();
            // Verificar quem ganhou
            var vencedor = jogadores.OrderByDescending(j => j.Pontos).First();
            var perdedor = jogadores.OrderBy(j => j.Pontos).First();
            if (vencedor.Pontos >= 50)
            {
                Console.WriteLine($"\n{vencedor.Nome} venceu! (atingiu 50 pontos)");
            }
            else if (perdedor.Pontos < 0)
            {
                Console.WriteLine($"\n{perdedor.Nome} perdeu! (ficou negativo)");
            }
            else
            {
                Console.WriteLine($"\n{vencedor.Nome} está liderando!");
            }
        }
    }
}
