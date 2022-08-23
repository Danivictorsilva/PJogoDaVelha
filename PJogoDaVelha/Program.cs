using System;
namespace PJogoDaVelha
{
    internal class Program
    {
        const int N = 3;
        static void Main(string[] args)
        {
            string[,] tabuleiro = new string[3, 3] { {"1", "2", "3" }, {
                "4", "5", "6"}, {
                "7", "8", "9"} };
            int wnr;

            wnr = IniciarJogo(tabuleiro);
            Console.Clear();
            ExibirTabuleiro(tabuleiro);
            if (wnr == 1) Console.WriteLine("O vencedor e o jogador 1!");
            else if (wnr == 2) Console.WriteLine("O vencedor e o jogador 2!");
            else if (wnr == 0) Console.WriteLine("Velha!");
            else Console.WriteLine("ERRO");
        }

        static void ExibirTabuleiro(string[,] m)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write("[");
                for (int j = 0; j < N; j++)
                {
                    Console.Write(m[i, j]);
                    if (j != N - 1) Console.Write(", ");
                }
                Console.Write("]");
                if (i != N - 1) Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void Menu(string[,] m)
        {
            Console.Clear();
            Console.WriteLine("********************** Jogo da Velha **********************");
            ExibirTabuleiro(m);
            Console.Write("Digite o numer o da posicao em que deseja marcar 'X' ou 'O': ");
        }

        static int RealizarJogada(string[,] m, string letra)
        {
            string op;

            do
            {
                op = Console.ReadLine();
            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "7" && op != "8" && op != "9");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (op == m[i, j])
                    {
                        m[i, j] = letra;
                        return 0;
                    }
                }
            }
            return 1;
        }
        static bool VerificarSituacao(string[,] m)
        {
            return (VerificarLinhas(m) || VerificarColunas(m) || VerificarDiagonais(m));
        }

        static bool VerificarLinhas(string[,] m)
        {
            return ((m[0, 0] == m[0, 1] && m[0, 1] == m[0, 2]) || (m[1, 0] == m[1, 1] && m[1, 1] == m[1, 2]) || (m[2, 0] == m[2, 1] && m[2, 1] == m[2, 2]));
        }
        static bool VerificarColunas(string[,] m)
        {
            return ((m[0, 0] == m[1, 0] && m[1, 0] == m[2, 0]) || (m[0, 1] == m[1, 1] && m[1, 1] == m[2, 1]) || (m[0, 2] == m[1, 2] && m[1, 2] == m[2, 2]));
        }
        static bool VerificarDiagonais(string[,] m)
        {
            return ((m[0, 0] == m[1, 1] && m[1, 1] == m[2, 2]) || (m[0, 2] == m[1, 1] && m[1, 1] == m[2, 0]));
        }

        static int IniciarJogo(string[,] m)
        {
            int aux = 0;
            do
            {
                Menu(m);
                int aux2;
                do
                {
                    aux2 = RealizarJogada(m, "X");
                    if (aux2 == 1) Console.WriteLine("Jogada invalida!");
                } while (aux2 == 1);
                if (VerificarSituacao(m)) return 1;
                if (aux == 4) break;
                Menu(m);
                do
                {
                    aux2 = RealizarJogada(m, "O");
                    if (aux2 == 1) Console.WriteLine("Jogada invalida!");
                } while (aux2 == 1);
                if (VerificarSituacao(m)) return 2;
                aux++;
            } while (!VerificarSituacao(m));
            return 0;
        }
    }
}