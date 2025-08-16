using System;
using JogoDeCartas.Core;
using JogoDeCartas.Core.GameLogic;
using JogoDeCartas.Models;
using JogoDeCartas.Enums;
class Program
{
    static void Main(string[] args)
    {
        var jogo = new GerenciadorDeJogo();

        Console.Write("Digite o nome do primeiro jogador: ");
        jogo.AdicionarJogador(Console.ReadLine());

        Console.Write("Digite o nome do segundo jogador: ");
        jogo.AdicionarJogador(Console.ReadLine());

        jogo.IniciarRodada();
    }
}
