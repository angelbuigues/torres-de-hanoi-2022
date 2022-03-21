using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Program
    {
        //inicio Main
        static void Main(string[] args)
        {
            //por si el usuario quiere seguir con el programa
            bool continuar = true;

            bool iterativo = false;
            bool recursivo = false;

            Console.WriteLine("Inicio Programa TORRES DE HANOI");

            while (continuar)
            {
                // Pedimos al usuario el numero de discos
                Console.WriteLine("Introduzca numero de piezas: ");



                //convertimos m en un numero entero
                int n = Convert.ToInt32(Console.ReadLine());

                // iniciamos las tres pilas
                Pila p1 = new Pila("Pila INICIAL");

                Pila p2 = new Pila("Pila FINAL");

                Pila p3 = new Pila("Pila AUXILIAR");

                Hanoi h = new Hanoi();

                //añadimos el numero de discos a la pila inicial
                for (int i = n; i >= 1; i--)
                {
                    p1.push(new Disco(i));
                }

                Console.WriteLine(p1.ToString());
                Console.WriteLine(p3.ToString());
                Console.WriteLine(p2.ToString());

                Console.WriteLine("Pulse '1' para usar el método iterativo y '2' el método recursivo");

                char c = Console.ReadLine()[0];
                //METODO ITERATIVO
                if (c.Equals('1'))
                {
                    iterativo = true;
                    Console.WriteLine("El resultado final fue de: " + h.iterativo(p1.Elementos.Count, p1, p2, p3) + " movimientos  (Metodo Iterativo)");
                }


                //METODO RECURSIVO
                if (c.Equals('2'))
                {
                    recursivo = true;
                    Console.WriteLine("El resultado final fue de: " + h.recursivo(p1.Elementos.Count, p1, p2, p3) + " movimientos (Metodo Recursivo)");
                }

                //calculamos matemáticamente el resultado(dos elevado al numero de piezas menos uno
                Console.WriteLine("La solución para " + n + " piezas es: " + (Math.Pow(2, n) - 1));


                //continuar con el programa
                Console.WriteLine("Pulse '0' para salir o si quiere seguir con el programa cualquier otra letra");

                char f = Console.ReadLine()[0];

                //si pulsa 0
                if (f.Equals('0'))
                {
                    //el programa ya no sigue
                    continuar = false;
                }
            }


        }
    }
}
