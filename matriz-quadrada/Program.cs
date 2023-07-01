using System.Text;

namespace matriz_quadrada
{
    internal class Program
    {
        const int TAM_MATRIZ = 4;
        public static void Resultado(StringBuilder StrB, string Nome, int[,] Matriz)
        {
            StrB.Append(Nome + Environment.NewLine);
            for (int i = 0; i < TAM_MATRIZ; i++)
            {
                for (int j = 0; j < TAM_MATRIZ; j++)
                {
                    StrB.Append(" " + Matriz[i, j].ToString() + " ");
                }
                StrB.Append(Environment.NewLine);
            }
        }

        public static int[,] MatrizResposta(int[,] MatrizPrincipal)
        {
            int x = TAM_MATRIZ, y = TAM_MATRIZ;
            int[,] MatrizResultante = new int[TAM_MATRIZ, TAM_MATRIZ]
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };

            object o;

            o = MatrizPrincipal.Clone();
            MatrizResultante = (int[,])o;

            // Inverter todas as diagonais
            //Diagonal secundária - DS
            // (0,3) (1,2) (2,1) (3,0)
            int j = TAM_MATRIZ - 1;
            for (int i = 0; i < TAM_MATRIZ; i++)
            {
                MatrizResultante[j, i] = MatrizPrincipal[i, j];
                j--;
            }

            //Diagonal principal - DP
            for (int i = 0; i < TAM_MATRIZ; i++)
            {
                for (j = 0; j < TAM_MATRIZ; j++)
                {
                    if (i == j)
                    {
                        MatrizResultante[--x, --y] = MatrizPrincipal[i, j];
                    }
                }

            }

            return MatrizResultante;
        }

        static void Main(string[] args)
        {
            /*
             * Exemplo
             * [1, 2, 3, 4]
             * [4, 3, 2, 1]
             * [4, 2, 1, 3]
             * [3, 1, 2, 4]
             */
            int[,] MatrizPrincipal = new int[TAM_MATRIZ,TAM_MATRIZ]
            {
                { 1, 2, 3, 4 },
                { 4, 3, 2, 1 },
                { 4, 2, 1, 3 },
                { 3, 1, 2, 4 }
            };

            int[,] MatrizResp = MatrizResposta(MatrizPrincipal);

            StringBuilder Texto = new StringBuilder();
            Resultado(Texto, "Matriz Principal", MatrizPrincipal);
            Texto.Append(Environment.NewLine);
            Resultado(Texto, "Matriz Resultante", MatrizResp);

            Console.WriteLine(Texto);
        }
    }
}