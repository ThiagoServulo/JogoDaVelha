using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha
{
    class Jogador
    {
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }

        public List<(int, int)> Jogadas = new List<(int, int)>();

        public Jogador()
        {
            Vitorias = Empates = Derrotas = 0;
        }

        public override string ToString()
        {
            return $"Vitrórias: {Vitorias}, Empates: {Empates}, Derrotas: {Derrotas}";
        }

        public bool ChecaVitoria()
        {
            if((Jogadas.Contains((1, 1)) && Jogadas.Contains((1, 2)) && Jogadas.Contains((1, 3))) ||
               (Jogadas.Contains((2, 1)) && Jogadas.Contains((2, 2)) && Jogadas.Contains((2, 3))) ||
               (Jogadas.Contains((3, 1)) && Jogadas.Contains((3, 2)) && Jogadas.Contains((3, 3))) ||
               (Jogadas.Contains((1, 1)) && Jogadas.Contains((2, 1)) && Jogadas.Contains((3, 1))) ||
               (Jogadas.Contains((1, 2)) && Jogadas.Contains((2, 2)) && Jogadas.Contains((3, 2))) ||
               (Jogadas.Contains((1, 3)) && Jogadas.Contains((2, 3)) && Jogadas.Contains((3, 3))) ||
               (Jogadas.Contains((1, 1)) && Jogadas.Contains((2, 2)) && Jogadas.Contains((3, 3))) ||
               (Jogadas.Contains((3, 1)) && Jogadas.Contains((2, 2)) && Jogadas.Contains((1, 3))))
            {
                return true;
            }else
            {
                return false;
            } 
        }
    }
}
