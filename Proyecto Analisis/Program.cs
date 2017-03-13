using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Analisis
{
    class Program
    {
        static List<List<Cuadro>> matrizRespuesta = new List<List<Cuadro>>();
        /// <summary>
        /// Mostrara el inicio del programa, menu, etc
        /// </summary>
        static void Inicio()
        {
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("|\t\tMenú Principal de Tetravex\t\t  |\n - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n\t1) Solucionar con algoritmo fuerza brutan\t2)");
        }
        static void Main(string[] args)
        {
            /*
            // prueba para ver la funcionalidad de los objetos
            Cuadro cuadro = new Cuadro();
            cuadro.up = 9;
            cuadro.right = 8;
            Inicio();

            Console.WriteLine("\nUp "+cuadro.Up+"\nDown"+cuadro.Down+"\nRight "+cuadro.Right+"\nLeft"+cuadro.Left);

            Console.ReadKey();
            */
            Juego ejemplo = new Juego(3);
            ejemplo.imprimir();
        }
    }
}
