using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha
{
    class Jogo
    {
        public int Quantidade_Jogos { get; set; }

        private List<(int, int)> _jogadas = new List<(int, int)>();

        public Jogo()
        {
            Quantidade_Jogos = 0;
        }

        public override string ToString()
        {
            return $"Rodada: {Quantidade_Jogos}";
        }

        public void ImprimeTabuleiro(List<(int, int)> jogadas_jogador1, List<(int, int)> jogadas_jogador2)
        {
            int linha1, coluna1, linha2, coluna2;
            linha2 = coluna2 = 1;

            for (linha1 = 1; linha1 <= 5; linha1++)
            {
                if(linha1 > 1)
                {
                    Console.WriteLine("");
                }

                for(coluna1 = 1; coluna1 <= 11; coluna1++)
                {
                    if((linha1 % 2) == 0)
                    {
                        Console.Write("-");
                        continue;
                    }

                    if ((coluna1 % 4) == 0)
                    {
                        Console.Write("|");
                        continue;
                    }

                    if ((coluna1 % 2) == 1)
                    {
                        Console.Write(" ");
                        continue;
                    }

                    if(jogadas_jogador1.Contains((linha2, coluna2)))
                    {
                        Console.Write("X");
                    }else if (jogadas_jogador2.Contains((linha2, coluna2)))
                    {
                        Console.Write("O");
                    }else
                    {
                        Console.Write(" ");
                    }

                    if(coluna2 == 3)
                    {
                        coluna2 = 1;
                        linha2 += 1;
                    }else
                    {
                        coluna2 += 1;
                    }
                }
            }
            Console.WriteLine("");
        }

        public bool VerificaJogadaValida(int linha, int coluna)
        {
            if(linha <= 0 || linha >= 4 || coluna <= 0 || coluna >= 4)
            {
                return false;
            }
            
            if(_jogadas.Contains((linha, coluna)))
            {
                return false;
            }

            _jogadas.Add((linha, coluna));
            return true;
        }

    }
}
