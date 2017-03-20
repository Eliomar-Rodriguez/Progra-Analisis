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
            Console.WriteLine("|\t\tMenú Principal de Tetravex\t\t  |\n - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
        }
        static void Main(string[] args)
        {
            int orden = 3; // tamanio de la matriz
            Inicio();
            
            Juego ejemplo = new Juego(orden);
            Console.WriteLine("Fichas resueltas\n");
            ejemplo.imprimir();
            Console.WriteLine("\n\nFichas desordenadas\n");
            ejemplo.desordenarFichas();
            ejemplo.imprimirFichas();
        }
    }
}
