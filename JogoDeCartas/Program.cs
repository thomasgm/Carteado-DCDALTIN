using System;
using JogoDeCartas.Core;
using JogoDeCartas.Core.GameLogic;
using JogoDeCartas.Models;
using JogoDeCartas.Enums;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao Jogo de Cartas! Qual jogo deseja jogar?");
        Console.WriteLine("1. Jogo de Cartas");
        Console.WriteLine("2. Jogo de Truco (em desenvolvimento)");

        string escolha = Console.ReadLine();
        if (escolha == "1")
        {
            var jogo = new GerenciadorDeJogo();

            Console.Write("Digite o nome do primeiro jogador: ");
            jogo.AdicionarJogador(Console.ReadLine());

            Console.Write("Digite o nome do segundo jogador: ");
            jogo.AdicionarJogador(Console.ReadLine());

            jogo.IniciarRodada();
        }
        else if (escolha == "2")
        {
            var truco = new Truco();
            Console.Write("Digite o nome do primeiro jogador: ");
            truco.AdicionarJogador(Console.ReadLine());
            Console.Write("Digite o nome do segundo jogador: ");
            truco.AdicionarJogador(Console.ReadLine());
            truco.IniciarRodada();
        }
        else
        {
            Console.WriteLine("Opção inválida. Encerrando o jogo.");
        }
        
    }
}
