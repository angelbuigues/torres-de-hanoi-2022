using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Pila
    {

        //VARIABLES
        private List<Disco> elementos;
        private int top;
        private string posicion;


        public int Size
        {
            get
            {
                return elementos.Count();
            }
        }/*{ get; set; }*/

        /* TODO: Elegir tipo de Top
        public int Top { get; set; }
        public String Top { get; set; }        
        */
        /* TODO: Elegir tipo de Elementos
        public Disco[] Elementos { get; set; }
        public List<Disco> Elementos { get; set; }
        */

        /* TODO: Implementar métodos */

        public List<Disco> Elementos
        {
            get
            {
                return elementos;
            }
        }

        // Para saber la posicion de la pila
        public string Posicion
        {
            get
            {
                return posicion;
            }
            set
            {
                posicion = value;
            }
        }
        // para el disco en el top de la pila saber el tamaño
        public int Top
        {
            get { return top; }
            set { top = value; }
        }


        public Pila(string nombre)
        {
            this.posicion = nombre;//para saber en la posicion el nombre
            top = -1;//al de top se le resta -1
            elementos = new List<Disco>();//devolvemos una lista 
        }

        //Para sacar un disco
        public Disco pop()
        {
            Disco discoExtraido = elementos.Last();
            elementos.Remove(discoExtraido);

            if (!isEmpty())
            {
                top = elementos.Last().Valor;
            }
            else
            {
                top = -1;// si al borrar el disco esta vacio se le resta 1 al top
            }
            return discoExtraido;
        }

        //Para añadir un disco
        public void push(Disco d)
        {
            top = d.Valor;
            elementos.Add(d);
        }

        //Si esta vacia la pila
        public bool isEmpty()
        {

            return elementos.Count() == 0;
        }

        public string ToString()
        {
            //si esta vacia 
            string res = posicion + ": ";
            if (isEmpty())
            {
                res += "Vacia.";
            }
            else
            {
                foreach (Disco d in elementos)
                {
                    //sino esta vacio cogemos el valor
                    res += d.Valor + ", ";
                }
            }

            //devolvemos el resultado
            return res;
        }

    }
}
