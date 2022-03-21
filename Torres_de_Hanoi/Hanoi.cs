using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Hanoi
    {

        //METODO PARA MOVER DISCO
        public void mover_disco(Pila a, Pila b)
        {


            //SI A ESTA VACIO Y B NO
            if (a.isEmpty() && !b.isEmpty())
            {
                // MOVEMOS DE B A A
                Disco dB = b.pop();//QUITAMOS EL DISCO DE B
                a.push(dB);// LO PONEMOS EN A

                //ESCRIBIMOS EL MOVIMIENTO
                Console.WriteLine("Se desplaza: " + dB.Valor + " de " + b.Posicion + " a " + a.Posicion);

            }

            //SI A NO ESTA VACIO Y B ESTA VACIO
            else if (!a.isEmpty() && b.isEmpty())
            {
                //MOVEMOS DE A A B
                Disco dA = a.pop();//QUITAMOS EL DISCO DE A
                b.push(dA);// LO PONEMOS EN B

                //ESCRIBIMOS EL MOVIMIENTO
                Console.WriteLine("Se desplaza: " + dA.Valor + " de " + a.Posicion + " a " + b.Posicion);
            }
            else
            {
                //Inicamos topA y topB
                int topA = a.Top;
                int topB = b.Top;

                //si el top de A es mayor que el top de B
                if (topA > topB)
                {

                    // MOVEMOS DE B A A
                    Disco dB = b.pop();//QUITAMOS EL DISCO DE B
                    a.push(dB);// LO PONEMOS EN A

                    //ESCRIBIMOS EL DESPLAZAMIENTO
                    Console.WriteLine("Se desplaza: " + dB.Valor + " de " + b.Posicion + " a " + a.Posicion);
                }
                else
                {
                    //MOVEMOS DE A A B
                    Disco dA = a.pop();//QUITAMOS EL DISCO DE A
                    b.push(dA);// LO PONEMOS EN B

                    //ESCRIBIMOS EL DESPLAZAMIENTO
                    Console.WriteLine("Se desplaza: " + dA.Valor + " de " + a.Posicion + " a " + b.Posicion);
                }

            }
        }
        //PARA COMPROBAR SOLUCION
        private bool checkSolution(int n, Pila fin)
        {
            //SIN TODAS LAS PIEZAS = FALSE
            if (fin.Tamaño != n)
            {
                return false;
            }

            bool estaOrdenada = true;

            // ORDEN CORRECTO
            for (int i = fin.Elementos.Count; i < 1; i++)
            {
                if (fin.Elementos[i].Valor > fin.Elementos[i - 1].Valor)
                {
                    estaOrdenada = false;
                    break;
                }
            }
            //devolvemos si esta ordenada
            return estaOrdenada;
        }

        //METODO ITERATIVO
        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {

            bool Solucion = false;
            int movimientos = 0;

            // N IMPAR
            if (n % 2 == 1)
            {
                while (!Solucion)//mientras busquemos la Solucion
                {
                    mover_disco(ini, fin);//movemos el disco

                    movimientos++;//añadimos un movimiento

                    //comprobamos solucion
                    Solucion = checkSolution(n, fin);

                    //imprimimos las pilas
                    Console.WriteLine(ini.ToString());
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(fin.ToString());


                    if (Solucion)
                    {
                        break; //si es la solucion paramos
                    }


                    mover_disco(ini, aux);//movemos el disco

                    movimientos++;//añadimos un movimiento

                    //comprobamos solucion
                    Solucion = checkSolution(n, fin);

                    //imprimimos las pilas
                    Console.WriteLine(ini.ToString());
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(fin.ToString());

                    if (Solucion)
                    {
                        break; //si es la solucion paramos
                    }

                    mover_disco(aux, fin);//movemos el disco

                    movimientos++;//añadimos un movimiento

                    //comprobamos solucion
                    Solucion = checkSolution(n, fin);

                    //imprimimos las pilas
                    Console.WriteLine(ini.ToString());
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(fin.ToString());

                    if (Solucion)
                    {
                        break; //si es la solucion paramos
                    }
                }

            }
            // N ES PAR
            else
            {
                while (!Solucion)//mientras busquemos la solucion
                {
                    mover_disco(ini, aux);//movemos el disco

                    movimientos++;//añadimos un movimiento

                    //Comprobamos la solucion
                    Solucion = checkSolution(n, fin);

                    //imprimimos las pilas
                    Console.WriteLine(ini.ToString());
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(fin.ToString());

                    if (Solucion)
                    {
                        break;//si es la solucion paramos
                    }

                    mover_disco(ini, fin);//movemos el disco

                    movimientos++;//añadimos un movimiento

                    //Comprobamos la solucion
                    Solucion = checkSolution(n, fin);

                    //imprimimos las pilas
                    Console.WriteLine(ini.ToString());
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(fin.ToString());

                    if (Solucion)
                    {
                        break; //si es la solucion paramos
                    }

                    mover_disco(aux, fin);//movemos el disco

                    movimientos++;//añadimos un movimiento

                    //Comprobamos la solucion
                    Solucion = checkSolution(n, fin);

                    //imprimimos las pilas
                    Console.WriteLine(ini.ToString());
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(fin.ToString());

                    if (Solucion)
                    {
                        break;//si es la solucion paramos
                    }


                }
            }

            //DEVOLVEMOS MOVIMIENTOS TOTALES
            return movimientos;
        }

        //METODO RECURSIVO
        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {
            //declaramos movimientos a 0
            int movimientos = 0;
            if (n == 1)//si n es 1
            {
                mover_disco(ini, fin);//movemos el disco


                movimientos++;//añadimos un movimiento


                //imprimimos las pilas
                Console.WriteLine(ini.ToString());
                Console.WriteLine(aux.ToString());
                Console.WriteLine(fin.ToString());
            }
            else//si no
            {
                recursivo(n - 1, ini, aux, fin);


                mover_disco(ini, fin);//movemos el disco


                movimientos++;//añadimos un movimiento

                //imprimimos las pilas
                Console.WriteLine(ini.ToString());
                Console.WriteLine(aux.ToString());
                Console.WriteLine(fin.ToString());

                recursivo(n - 1, aux, fin, ini);
            }

            //DEVOLVEMOS MOVIMIENTOS TOTALES
            return movimientos;
        }


    }
}