using System;

namespace JogoDaVelha
{
    class Program
    {
        static bool FimDeJogo(string resultado, Jogador jogador1, Jogador jogador2, Jogo jogo)
        {
            Console.Clear();
            jogo.ImprimeTabuleiro(jogador1.Jogadas, jogador2.Jogadas);

            jogo.Quantidade_Jogos += 1;

            if (resultado == "empate")
            {
                jogador1.Empates += 1;
                jogador2.Empates += 1;
                Console.WriteLine("Fim de jogo: Empate");
            }else if (resultado == "vitoria_jogador_1")
            {
                jogador1.Vitorias += 1;
                jogador2.Derrotas += 1;
                Console.WriteLine("Fim de jogo: Vitória Jogador 1");
            }else
            {
                jogador1.Derrotas += 1;
                jogador2.Vitorias += 1;
                Console.WriteLine("Fim de jogo: Vitória Jogador 2");
            }

            Console.WriteLine("Novo Jogo? s/n");

            if(char.Parse(Console.ReadLine()) == 's')
            {
                jogador1.Jogadas.Clear();
                jogador2.Jogadas.Clear();
                jogo.Jogadas.Clear();
                return true;
            }else
            {
                Console.Clear();
                if (jogador1.Vitorias > jogador2.Vitorias)
                {
                    Console.WriteLine("Jogador 1 venceu");
                }else if (jogador2.Vitorias > jogador1.Vitorias)
                {
                    Console.WriteLine("Jogador 2 venceu");
                }else
                {
                    Console.WriteLine("Empate entre os jogadores");
                }
                Console.WriteLine($"Jogador 1: {jogador1}");
                Console.WriteLine($"Jogador 2: {jogador2}");
                return false;
            }
        }

        static void Main(string[] args)
        {
            int rodada, linha, coluna;
            bool status;

            rodada = 0;

            Jogador jogador1 = new Jogador();
            Jogador jogador2 = new Jogador();
            Jogo jogo = new Jogo();

            while (true)
            {
                Console.Clear();
                jogo.ImprimeTabuleiro(jogador1.Jogadas, jogador2.Jogadas);

                if(((rodada > 8) && ((jogo.Quantidade_Jogos % 2) == 0)) || ((rodada > 9) && ((jogo.Quantidade_Jogos % 2) != 0)))
                {
                    rodada = 0;
                    if(!FimDeJogo("empate", jogador1, jogador2, jogo))
                    {
                        break;
                    }
                    continue;
                }

                if ((((rodada % 2) == 0) && ((jogo.Quantidade_Jogos % 2) == 0)) || ((rodada % 2) != 0) && ((jogo.Quantidade_Jogos % 2) == 1))
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

                if ((((rodada % 2) == 0) && ((jogo.Quantidade_Jogos % 2) == 0)) || ((rodada % 2) != 0) && ((jogo.Quantidade_Jogos % 2) == 1))
                {
                    jogador1.Jogadas.Add((linha, coluna));
                    if(jogador1.ChecaVitoria())
                    {
                        rodada = 0;
                        if (!FimDeJogo("vitoria_jogador_1", jogador1, jogador2, jogo))
                        {
                            break;
                        }
                         continue;
                    }
                }else
                {
                    jogador2.Jogadas.Add((linha, coluna));
                    if (jogador2.ChecaVitoria())
                    {
                        rodada = 0;
                        if (!FimDeJogo("vitoria_jogador_2", jogador1, jogador2, jogo))
                        {
                            break;
                        }
                        continue;
                    }
                }

                rodada += 1;
            }
        }
    }
}
