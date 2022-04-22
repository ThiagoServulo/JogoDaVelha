using System;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            int rodada, linha, coluna;
            bool status;

            rodada = 0;

            Jogador jogador1 = new Jogador();
            Jogador jogador2 = new Jogador();
            Jogo jogo = new Jogo();

            while(true)
            {
                Console.Clear();
                jogo.ImprimeTabuleiro(jogador1.Jogadas, jogador2.Jogadas);

                if(rodada > 8)
                {
                    jogo.Quantidade_Jogos += 1;
                    jogador1.Empates += 1;
                    jogador2.Empates += 1;
                    Console.WriteLine("Fim de jogo: Empate");
                    break;
                }

                if ((rodada % 2) == 0)
                {
                    Console.WriteLine("\nJogador 1");
                }else
                {
                    Console.WriteLine("\nJogador 2");
                }

                do
                {
                    Console.WriteLine("Escolha o número da linha: ");
                    linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Escolha o número da coluna: ");
                    coluna = int.Parse(Console.ReadLine());
                    status = jogo.VerificaJogadaValida(linha, coluna);

                    if(status)
                    {
                        break;
                    }else
                    {
                        Console.WriteLine("Jogada Inválida");
                    }

                } while (true);

                if ((rodada % 2) == 0)
                {
                    jogador1.Jogadas.Add((linha, coluna));
                    if(jogador1.ChecaVitoria())
                    {
                        Console.Clear();
                        jogo.ImprimeTabuleiro(jogador1.Jogadas, jogador2.Jogadas);
                        Console.WriteLine("Jogador 1 venceu");
                        break;
                    }
                }
                else
                {
                    jogador2.Jogadas.Add((linha, coluna));
                    if (jogador2.ChecaVitoria())
                    {
                        Console.Clear();
                        jogo.ImprimeTabuleiro(jogador1.Jogadas, jogador2.Jogadas);
                        Console.WriteLine("Jogador 2 venceu");
                        break;
                    }
                }

                rodada += 1;
            }
        }
    }
}
