using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAmigosProyectoEstructura;

namespace RedAmigosProyectoEstructura
{
    internal class NodoArbol
    {
        public PersonaNodo persona;
        public NodoHijo primerHijo;

        public NodoArbol(PersonaNodo p)
        {
            persona = p;
            primerHijo = null;
        }

        public static void AgregarHijo(NodoArbol padre, NodoArbol hijo)
        {
            NodoHijo nuevo = new NodoHijo(hijo);
            if (padre.primerHijo == null)
            {
                padre.primerHijo = nuevo;
            }
            else
            {
                NodoHijo aux = padre.primerHijo;
                while (aux.Siguiente != null)
                {
                    aux = aux.Siguiente;
                }
                aux.Siguiente = nuevo;
            }
        }
        public static NodoArbol ConstruirArbol(PersonaNodo raiz, TablaHash tablaVisitados, RedSocialListaDC redSocial)
        {
            //Actualizando los valores de la PersonaNodo (especialmente su lista de amigos)
            raiz = redSocial.BuscarEmailNodo(raiz.Email);
            NodoArbol nodoRaiz = new NodoArbol(raiz);
            tablaVisitados.AgregarEmail(raiz);

            PersonaNodo actual = raiz.ListaAmigos._cabeza;
            while (actual != null)
            {
                if (!tablaVisitados.BuscarEmail(actual.Email))
                {
                    NodoArbol nodoHijo = ConstruirArbol(actual, tablaVisitados, redSocial);
                    AgregarHijo(nodoRaiz, nodoHijo);
                }
                actual = actual.Siguiente;
            }
            return nodoRaiz;
        }
        public void ImprimirArbol(NodoArbol nodo)
        {
            if (nodo == null) return;

            Console.Write(nodo.persona.Nombre + " " + nodo.persona.Apellido);

            NodoHijo actual = nodo.primerHijo;

            if (actual != null)
            {
                Console.Write(" (");
                while (actual != null)
                {
                    ImprimirArbol(actual.Hijo);
                    if (actual.Siguiente != null)
                        Console.Write(", ");
                    actual = actual.Siguiente;
                }
                Console.Write(")");
            }
        }
    }
}