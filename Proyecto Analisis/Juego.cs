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

            for (int j = 0; j < n; j++)
            {
                matrizInicial.Add(new List<Cuadro>());
                matrizResuelta.Add(new List<Cuadro>());
                for (int l = 0; l < n; l++)
                {
                    matrizInicial[j].Add(new Cuadro());
                    matrizResuelta[j].Add(matrizInicial[j][l]);
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
                            matrizInicial[j][l].up = matrizInicial[j - 1][l].down;
                            matrizInicial[j][l].left = rnd.Next(10);
                            matrizInicial[j][l].right = rnd.Next(10);
                            continue;
                        }
                        matrizInicial[j][l].down = rnd.Next(10);
                        matrizInicial[j][l].up = matrizInicial[j - 1][l].down;
                        matrizInicial[j][l].left = matrizInicial[j][l - 1].right;
                        matrizInicial[j][l].right = rnd.Next(10);
                    }
                    
                }
            }
        }

        public void mix()
        {
            Random rnd = new Random();
            int iAux;
            int jAux;
            Cuadro aux;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    iAux = rnd.Next(n);
                    jAux = rnd.Next(n);
                    aux = matrizInicial[i][j];
                    matrizInicial[i][j] = matrizInicial[iAux][jAux];
                    matrizInicial[iAux][jAux] = aux;
                }
            }
        }

        public void imprimir(List<List<Cuadro>> m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(m[i][j].up); //Escribe en una sola linea
                    Console.Write(m[i][j].left); //Escribe en una sola linea 
                    Console.Write(m[i][j].down); //Escribe en una sola linea
                    Console.Write(m[i][j].right); //Escribe en una sola linea     
                }
                Console.WriteLine(); //Genera el salto de linea 
            }
            Console.ReadLine();
        }

        public List<List<Cuadro>> getInicial()
        {
            return matrizInicial;
        }

        public List<List<Cuadro>> getResuelta()
        {
            return matrizResuelta;
        }


        public bool fuerzaBruta(List<Cuadro> fichas, int i, int j)
        {

            if (j == n)
            {
                i++;
                j = 0;
            }
            if ((i == n - 1)&(j == n - 1))
            {
                matrizInicial[i][j] = fichas[0];
                if (comprobar())
                {
                    imprimir(matrizInicial);
                    return true;
                    
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                
                for (int count=0;count<fichas.Count;count++)
                {
                    Cuadro ficha = fichas[0];
                    matrizInicial[i][j] = ficha;
                    fichas.RemoveAt(0);
                    
                    if (fuerzaBruta(fichas, i, j+1))
                    {
                        return true;
                    }
                       
                    fichas.Add(ficha);
                }
                return false;
            }
           return false; 
        }

        public bool comprobar()
        {
            for (int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    if (matrizInicial[i][j] != matrizResuelta[i][j])
                        return false;
                }
            }
            return true;
        }

    }
}
