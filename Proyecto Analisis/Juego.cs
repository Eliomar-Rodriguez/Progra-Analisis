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
        /// <summary>
        /// Matriz con las fichas para iniciar el juego, fichas desordenadas
        /// </summary>
        List<List<Cuadro>> matrizFichas = new List<List<Cuadro>>();
        /// <summary>
        /// Matriz que contiene todas las fichas en las posiciones a las que pertenecen, el juego esta resuelto
        /// </summary>
        List<List<Cuadro>> matrizRespuesta = new List<List<Cuadro>>();
        int asignaciones = 0, comparaciones = 0;

        public Juego(int n)
        {
            this.n = n;

           Random rnd = new Random();
            
            // llenando la matriz respuesta
            for(int j=0; j<n; j++)
            {
                matrizRespuesta.Add(new List<Cuadro>());
                matrizFichas.Add(new List<Cuadro>());
                for (int l=0; l<n; l++ )
                {
                    matrizRespuesta[j].Add(new Cuadro());
                    matrizFichas[j].Add(matrizRespuesta[j][matrizRespuesta[j].Count-1]); ;
         

                    if ((j == 0) && (l == 0))
                    {
                        matrizRespuesta[j][l].down = rnd.Next(10);
                        matrizRespuesta[j][l].up = rnd.Next(10);
                        matrizRespuesta[j][l].left = rnd.Next(10);
                        matrizRespuesta[j][l].right = rnd.Next(10);

                    }
                    else
                    {
                        if (j == 0)
                        {
                            matrizRespuesta[j][l].down = rnd.Next(10);
                            matrizRespuesta[j][l].up = rnd.Next(10);
                            matrizRespuesta[j][l].left = matrizRespuesta[j][l - 1].right;
                            matrizRespuesta[j][l].right = rnd.Next(10);
                            continue;
                        }
                        if (l == 0)
                        {
                            matrizRespuesta[j][l].down = rnd.Next(10);
                            matrizRespuesta[j][l].up = matrizRespuesta[j-1][l].down;
                            matrizRespuesta[j][l].left = rnd.Next(10);
                            matrizRespuesta[j][l].right = rnd.Next(10);
                            continue;
                        }
                        matrizRespuesta[j][l].down = rnd.Next(10);
                        matrizRespuesta[j][l].up = matrizRespuesta[j - 1][l].down;
                        matrizRespuesta[j][l].left = matrizRespuesta[j][l-1].right;
                        matrizRespuesta[j][l].right = rnd.Next(10);
                    }

                }
            }
        }
        /// <summary>
        /// Imprime todas las fichas de la matriz que se envia
        /// </summary>
        /// <param name="m">Matriz a imprimir fichas</param>
        public void ImprimirFichas(List<List<Cuadro>> matriz)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matriz[i][j].up); //Escribe en una sola linea
                    Console.Write(matriz[i][j].left); //Escribe en una sola linea 
                    Console.Write(matriz[i][j].down); //Escribe en una sola linea
                    Console.Write(matriz[i][j].right+" "); //Escribe en una sola linea    
                }
                Console.WriteLine(); //Genera el salto de linea 
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Funcion que se encarga de revolver las fichas para iniciar el juego
        /// </summary>     
        public void DesordenarFichas()
        {

            Random randNum = new Random();
            Cuadro aux = null;
            int fls = 0, clmn = 0;

            for(int veces = 0; veces < 5; veces++) // este otro ciclo es opcional, pero si solamente se utilizando los dos ciclos no queda bien resuelto porque normalmente quedan acomodadas siguiendo un patron
            {
                for (int f = 0; f < matrizFichas.Count; f++)
                {
                    for (int c = 0; c < matrizFichas.Count; c++)
                    {
                        fls = randNum.Next(0, matrizFichas.Count);
                        clmn = randNum.Next(0, matrizFichas.Count);

                        // intercambio de objetos para desordenar
                        aux = matrizFichas[f][c]; // respaldo el objeto de esa posicion
                        matrizFichas[f][c] = matrizFichas[fls][clmn]; // asigno un objeto de una posicion aleatoria
                        matrizFichas[fls][clmn] = aux;
                    }
                }
            }
        }
        public List<List<Cuadro>> getMatrizFichas()
        {
            return matrizFichas;
        }

        public List<List<Cuadro>> getMatrizResuelta()
        {
            return matrizRespuesta;
        }


        public bool FuerzaBruta(List<Cuadro> fichas, int i, int j)
        {
            comparaciones++;
            if (j == n)
            {
                asignaciones += 2;
                i++;
                j = 0;
            }
            comparaciones += 2;
            if ((i == n - 1)&(j == n - 1))
            {
                asignaciones++;
                matrizFichas[i][j] = fichas[0];
                comparaciones++;
                if (Comprobar())
                {
                    ImprimirFichas(matrizFichas);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                asignaciones++;
                comparaciones += fichas.Count+1;
                asignaciones += fichas.Count;
                for (int count=0;count<fichas.Count;count++)
                {
                    asignaciones++;
                    Cuadro ficha = fichas[0];
                    asignaciones++;
                    matrizFichas[i][j] = ficha;
                    fichas.RemoveAt(0);
                    comparaciones++;
                    if (FuerzaBruta(fichas, i, j+1))
                    {
                        return true;
                    }
                    fichas.Add(ficha);
                }
                return false;
            }
           return false; 
        }

        public bool Comprobar()
        {
            for (int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    if (matrizFichas[i][j] != matrizRespuesta[i][j])
                        return false;
                }
            }
            return true;
        }
    }
}
