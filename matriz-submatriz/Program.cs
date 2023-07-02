using System.Text;

namespace matriz_submatriz
{
    internal class Program
    {
        const int LIN_MATRIZ = 4;
        const int COL_MATRIZ = 3;
        const int LIN_SUBMATRIZ = 3;
        const int COL_SUBMATRIZ = 2;

        public static int Resposta(int[,] MatrizPrincipal, int[,] SubMatriz)
        {
            int[] VetOcorrencias = new int[LIN_SUBMATRIZ * COL_SUBMATRIZ];
            int Indice = 0;

            for (int i = 0; i < LIN_SUBMATRIZ; i++)
            {
                for (int j = 0; j < COL_SUBMATRIZ; j++)
                {
                    for (int x = 0; x < LIN_MATRIZ; x++)
                    {
                        for (int y = 0; y < COL_MATRIZ; y++)
                        {
                            if (SubMatriz[i, j] == MatrizPrincipal[x, y])
                                VetOcorrencias[Indice] += 1;
                        }
                    }
                    Indice++;
                }
            }

            List<int> QtdOcorrencias = VetOcorrencias.ToList();
            QtdOcorrencias.Sort();

            return QtdOcorrencias.FirstOrDefault();            
        }

        static void Main(string[] args)
        {
            int[,] MatrizPrincipal = new int[LIN_MATRIZ, COL_MATRIZ]
            {
                { 1, 2, 3 },
                { 4, 3, 2 },
                { 4, 2, 1 },
                { 3, 1, 2 }
            };

            int[,] SubMatriz = new int[LIN_SUBMATRIZ, COL_SUBMATRIZ]
           {
                { 1, 2 },
                { 4, 3 },
                { 4, 2 }
           };


            int TotalOcorrencias = Resposta(MatrizPrincipal, SubMatriz);
            
            Console.WriteLine(TotalOcorrencias);
        }
    }
}