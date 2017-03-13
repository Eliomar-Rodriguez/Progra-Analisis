using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Analisis
{
    class Juego
    {
        int n;
        List<List<Cuadro>> matrizInicial = new List<List<Cuadro>>();
        List<List<Cuadro>> matrizResuelta = new List<List<Cuadro>>();

        public Juego(int n)
        {
            this.n = n;
           Random rnd = new Random();
            
            for(int j=0; j<n; j++)
            {
                matrizInicial.Add(new List<Cuadro>());
                for (int l=0; l<n; l++ )
                {
                    matrizInicial[j].Add(new Cuadro());
                    if ((j == 0) && (l == 0))
                    {
                        matrizInicial[j][l].down = rnd.Next(10);
                        matrizInicial[j][l].up = rnd.Next(10);
                        matrizInicial[j][l].left = rnd.Next(10);
                        matrizInicial[j][l].right = rnd.Next(10);

                    }
                    else
                    {
                        if (j == 0)
                        {
                            matrizInicial[j][l].down = rnd.Next(10);
                            matrizInicial[j][l].up = rnd.Next(10);
                            matrizInicial[j][l].left = matrizInicial[j][l - 1].right;
                            matrizInicial[j][l].right = rnd.Next(10);
                            continue;
                        }
                        if (l == 0)
                        {
                            matrizInicial[j][l].down = rnd.Next(10);
                            matrizInicial[j][l].up = matrizInicial[j-1][l].down;
                            matrizInicial[j][l].left = rnd.Next(10);
                            matrizInicial[j][l].right = rnd.Next(10);
                            continue;
                        }
                        matrizInicial[j][l].down = rnd.Next(10);
                        matrizInicial[j][l].up = matrizInicial[j - 1][l].down;
                        matrizInicial[j][l].left = matrizInicial[j][l-1].right;
                        matrizInicial[j][l].right = rnd.Next(10);
                    }


                }

            }
         
        }

        public void imprimir()
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrizInicial[i][j].up); //Escribe en una sola linea
                    Console.Write(matrizInicial[i][j].down); //Escribe en una sola linea 
                    Console.Write(matrizInicial[i][j].left); //Escribe en una sola linea 
                    Console.Write(matrizInicial[i][j].right + " "); //Escribe en una sola linea     
                }
                Console.WriteLine(); //Genera el salto de linea 
            }
            Console.ReadLine();
        }

    }
}
