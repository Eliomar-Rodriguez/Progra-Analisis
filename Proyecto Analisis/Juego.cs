﻿using System;
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
            for (int j = 0; j < n; j++)
            {
                matrizRespuesta.Add(new List<Cuadro>());
                matrizFichas.Add(new List<Cuadro>());
                for (int l = 0; l < n; l++)
                {
                    matrizRespuesta[j].Add(new Cuadro());
                    matrizFichas[j].Add(matrizRespuesta[j][matrizRespuesta[j].Count - 1]); ;


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
                            matrizRespuesta[j][l].up = matrizRespuesta[j - 1][l].down;
                            matrizRespuesta[j][l].left = rnd.Next(10);
                            matrizRespuesta[j][l].right = rnd.Next(10);
                            continue;
                        }
                        matrizRespuesta[j][l].down = rnd.Next(10);
                        matrizRespuesta[j][l].up = matrizRespuesta[j - 1][l].down;
                        matrizRespuesta[j][l].left = matrizRespuesta[j][l - 1].right;
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
                    Console.Write(matriz[i][j].right + " "); //Escribe en una sola linea    
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

            for (int veces = 0; veces < 5; veces++) // este otro ciclo es opcional, pero si solamente se utilizando los dos ciclos no queda bien resuelto porque normalmente quedan acomodadas siguiendo un patron
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


        private bool fuerzaBruta(List<Cuadro> fichas, int i, int j)
        {
            comparaciones++;
            if (j == n)
            {
                asignaciones += 2;
                i++;
                j = 0;
            }
            comparaciones += 2;
            if ((i == n - 1) & (j == n - 1))
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
                comparaciones += fichas.Count + 1;
                asignaciones += fichas.Count;
                for (int count = 0; count < fichas.Count; count++)
                {
                    asignaciones++;
                    Cuadro ficha = fichas[0];
                    asignaciones++;
                    matrizFichas[i][j] = ficha;
                    fichas.RemoveAt(0);
                    comparaciones++;
                    if (fuerzaBruta(fichas, i, j + 1))
                    {
                        return true;
                    }
                    fichas.Add(ficha);
                }
                return false;
            }
        }

        public bool Comprobar()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrizFichas[i][j] != matrizRespuesta[i][j])
                        return false;
                }
            }
            return true;
        }

        public void fuerzaBruta()
        {
            List<Cuadro> fichas = crearLista();
            fuerzaBruta(fichas, 0, 0);
        }

        public void algoritmoSelectivo()
        {
            List<Cuadro> fichas = crearLista();
            List<Cuadro>[] arreglo = new List<Cuadro>[10];
            for (int c = 0; c < 10; c++)
            {
                arreglo[c] = new List<Cuadro>();
            }
            foreach (Cuadro f in fichas)
            {
                arreglo[f.left].Add(f);
            }
            subordinadoSelectivo(0, 0, arreglo, 0);

        }

        private bool subordinadoSelectivo(int i, int j,List<Cuadro>[] arreglo, int anterior)
        {
            if (j == n)
            {
                i=i+1;
                j = 0;
            }
            if ((i == n - 1) && (j == n - 1))
            {
                for(int a=0; a<10; a++)
                {
                    if (arreglo[a].Count > 0)
                    {
                        matrizFichas[i][j] = arreglo[a][0];
                        break;
                    }
                
                }
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
                if (j == 0)
                {
                    for(int a =0;a<10;a++)
                    {
                        for(int m=0; m<arreglo[a].Count;m++)
                        {
                            Cuadro tmp = arreglo[a][0];
                            arreglo[a].RemoveAt(0);
                            if (i!=0)
                            {
                                if (tmp.up != matrizFichas[i - 1][j].down)
                                {
                                    arreglo[a].Add(tmp);
                                    continue;
                                }
                                    
                            }
                            matrizFichas[i][j] = tmp;
                            if (subordinadoSelectivo(i, j + 1, arreglo, tmp.right))
                            {
                                return true;
                            }
                            arreglo[a].Add(tmp);
                           
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < arreglo[anterior].Count; k++)
                    {
                        Cuadro tmp = arreglo[anterior][0];
                        arreglo[anterior].RemoveAt(0);
                        if (i != 0)
                        {
                            if (tmp.up != matrizFichas[i - 1][j].down)
                            {
                                arreglo[anterior].Add(tmp);
                                continue;
                            }
                        }
                        matrizFichas[i][j] = tmp;
                        if (subordinadoSelectivo(i, j + 1, arreglo, tmp.right))
                        {
                            return true;
                        }
                        arreglo[anterior].Add(tmp);


                    }
                }
            }
            return false;  
        }

        public List<Cuadro> crearLista()
        {
            List<Cuadro> fichas = new List<Cuadro>();
            foreach (List<Cuadro> lista in matrizFichas)
            {
                foreach (Cuadro ficha in lista)
                {
                    fichas.Add(ficha);
                }
            }
            return fichas;
        }

    }
}
