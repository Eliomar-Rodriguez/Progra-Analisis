using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Analisis
{
    class Program
    {
        /// <summary>
        /// Mostrara el inicio del programa, menu, etc
        /// </summary>
        static void Inicio()
        {
            Console.WriteLine("     Matrices     \n1) Correr programa y solucionar");
        }
        static void Main(string[] args)
        {
            /*
            // prueba para ver la funcionalidad de los objetos
            Cuadro cuadro = new Cuadro();
            cuadro.up = 9;
            cuadro.right = 8;
            Inicio();
            Console.WriteLine("\nUp "+cuadro.up+"\nDown"+cuadro.down+"\nRight "+cuadro.right+"\nLeft"+cuadro.left);
            Console.ReadKey();
            */
            Juego ejemplo = new Juego(3);
            ejemplo.imprimir();
        }
    }
}
