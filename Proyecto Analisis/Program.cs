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
            // prueba para ver la funcionalidad de los objetos
            Cuadro cuadro = new Cuadro();
            cuadro.Up = 9;
            cuadro.Right = 8;
            Inicio();
            Console.WriteLine("\nUp "+cuadro.Up+"\nDown"+cuadro.Down+"\nRight "+cuadro.Right+"\nLeft"+cuadro.Left);
            Console.ReadKey();
        }
    }
}
