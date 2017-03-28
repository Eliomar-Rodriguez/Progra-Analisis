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
            /*
            Console.WriteLine("Fichas resueltas\n");
            ejemplo.ImprimirFichas(ejemplo.getMatrizResuelta());
            Console.WriteLine("\n\nFichas desordenadas\n");
            ejemplo.DesordenarFichas();
            ejemplo.ImprimirFichas(ejemplo.getMatrizFichas());
            
            Console.ReadKey();*/

            //Juego ejemplo = new Juego(orden);

            ejemplo.ImprimirFichas(ejemplo.getMatrizResuelta());

            ejemplo.DesordenarFichas();

            ejemplo.ImprimirFichas(ejemplo.getMatrizFichas());

            Console.Write("Comenzando fuerza bruta");
            Console.ReadLine();
            
            List<Cuadro> fichas = new List<Cuadro>();
            foreach (List<Cuadro>lista in ejemplo.getMatrizFichas())
            {
                foreach(Cuadro ficha in lista)
                {
                    fichas.Add(ficha);
                }
            }
            ejemplo.FuerzaBruta(fichas,0,0);
            
        }
    }
}
