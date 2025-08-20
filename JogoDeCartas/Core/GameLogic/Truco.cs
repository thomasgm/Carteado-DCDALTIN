using JogoDeCartas.Models;
using JogoDeCartas.Core.Services;

namespace JogoDeCartas.Core.GameLogic
{
    public class Truco : GerenciadorDeJogo
    {
        private List<Equipe> equipes;
        private MesaDeTruco mesa;
        private Equipe? equipeAtual;
        private int pontosEquipe1;
        private int pontosEquipe2;
        private int jogadorAtual;

        public Truco()
        {
            equipes = new List<Equipe>();
            mesa = new MesaDeTruco();
            pontosEquipe1 = 0;
            pontosEquipe2 = 0;
        }

        public override void IniciarRodada()
        {

            Console.WriteLine("\n=== INÍCIO DO TRUCO ===");
            foreach (var jogador in jogadores)
            {
                Console.WriteLine($"\nCartas do {jogador.Nome}:");
                jogador.MostrarMao();
            }
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
                for (int i = 0; i < 3; i++) // Distribui 3 cartas para cada jogador
                {
                    jogador.ReceberCarta(baralho.DistribuirCarta());
                }
            }
        }

        private void AvancarProximoJogador()
        {
            jogadorAtual = (jogadorAtual + 1) % jogadores.Count;
            Console.WriteLine($"\nÉ a vez do jogador: {jogadorAtual + 1} - {jogadores[jogadorAtual].Nome}");
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

        private void FinalizarRodada()
        {
            Console.WriteLine("\n=== FIM DA RODADA ===");
            MostrarPlacar();

            // Verifica se alguma equipe atingiu 12 pontos
            var vencedor = jogadores.OrderByDescending(j => j.Pontos).First();
            var perdedor = jogadores.OrderBy(j => j.Pontos).First();
            if (vencedor.Pontos >= 12)
            {
                Console.WriteLine($"\n{vencedor.Nome} venceu! (atingiu 12 pontos)");
            }
            else if (perdedor.Pontos < 0)
            {
                Console.WriteLine($"\n{perdedor.Nome} perdeu! (ficou negativo)");
            }
            else
            {
                Console.WriteLine($"\n{vencedor.Nome} está liderando!");
            }

            // Reinicia a mesa e as cartas dos jogadores
            mesa.CartasNaMesa.Clear();
            foreach (var jogador in jogadores)
            {
                jogador.Mao.Clear();
            }
        }

        public override void RealizarTurnoDoJogador(int indiceJogador)
        {
            var jogadorAtual = jogadores[indiceJogador];
            Console.WriteLine($"\nVez do jogador: {jogadorAtual.Nome}");

            Console.WriteLine("\nOpções:");
            Console.WriteLine("1 - Jogar carta");
            Console.WriteLine("2 - Trucar");
            Console.WriteLine("3 - Passar a vez");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    JogarCarta(jogadorAtual);
                    break;
                case "2":
                    VerificarTruco(jogadorAtual);
                    break;
                case "3":
                    VerificarEnchente(jogadorAtual);
                    break;
            }
        }

        private void VerificarTruco(Jogador jogador)
        {
            Console.WriteLine("\nVocê quer trucar? (s/n)");
            string resposta = Console.ReadLine();

            if (resposta.ToLower() == "s")
            {
                // Implementar lógica do truco
                Console.WriteLine("Truco!");
            }
            else
            {
                Console.WriteLine("Passou o truco.");
            }
        }

        private void VerificarEnchente(Jogador jogador)
        {
            Console.WriteLine("\nVocê quer fazer enchente? (s/n)");
            string resposta = Console.ReadLine();

            if (resposta.ToLower() == "s")
            {
                // Implementar lógica da enchente
                Console.WriteLine("Enchente!");
            }
            else
            {
                Console.WriteLine("Não foi enchente.");
            }
        }

        public override bool VerificarFimDaRodada()
        {
            // Verificar se alguma equipe atingiu 12 pontos
            foreach (var jogador in jogadores)
            {
                if (jogador.Pontos >= 12 || jogador.Pontos < 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
