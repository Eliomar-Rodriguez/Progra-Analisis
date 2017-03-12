using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Analisis
{
    class Cuadro
    {
        public int Up { get; set; }
        public int Down { get; set; }
        public int Right { get; set; }
        public int Left { get; set; } // atributos que van a representar los posibles numeros que estaran en los lados del cuadro

        /// <summary>
        /// Constructor de la clase cuadro
        /// </summary>
        /// <param name="up">Numero que va arriba (en el cuadro)</param>
        /// <param name="down">Numero que va abajo (en el cuadro)</param>
        /// <param name="right">Numero que va a la derecha (en el cuadro)</param>
        /// <param name="left">Numero que va a la izquierda (en el cuadro)</param>
        public Cuadro(int up, int down, int right, int left)
        {
            Up = up;
            Down = down;
            Right = right;
            Left = left;
            //Console.WriteLine("Up = {0} Down = {1}", this.Up, this.Down); // manera de imprimir en orden, dependiendo del numero que se ingrese entre las llaves como una lista
        }
        /// <summary>
        /// Constructor vacio, pongo -1 a todos los elementos de la vara porque no se le puede asignar null
        /// </summary>
        public Cuadro()
        {
            Up = -1;
            Down = -1;
            Right = -1;
            Left = -1;
        }
    }
}
