using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedAmigosProyectoEstructura
{
    internal class RedSocialListaDC
    {
        //Atributos
        private PersonaNodo _cabeza;
        private PersonaNodo _cola;
        public int _cantidadPersonas;

        //Médoto constructor
        public RedSocialListaDC()
        {
            _cabeza = _cola = null;
            _cantidadPersonas = 0;
        }

        //Esta método agrega la persona por cola para tener un registro ascendente en orden de entrada
        public void AgregarPersona(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            PersonaNodo nuevoNodo = new PersonaNodo(nombre, apellido, edad, numeroTelefonico, email);
            //Si la lista esta vacía se agrega el nodo
            if (_cabeza == null)
            {
                _cantidadPersonas++;
                _cabeza = _cola = nuevoNodo;
                _cola._siguiente = _cabeza;
                return;
            }
            //Si el método BuscarEmail() no encuentra persona con ese email, se agrega el nodo
            if (!BuscarEmail(email))
            {
                _cantidadPersonas++;
                _cola._siguiente = nuevoNodo;
                nuevoNodo._anterior = _cola;
                _cola = nuevoNodo;
                _cola._siguiente = _cabeza;
                _cabeza._anterior = _cola;
                return;
            }
            //Mensaje si encuentra una persona con el mismo email y no se agrega
            Console.WriteLine("La persona ya ha sido agregada en la Red Social.");
        }
        public bool BuscarEmail(string email)
        {
            //Si la cola es el email que busca, la complejidad se vuelve O(1)
            if (_cola._email == email)
            {
                return true;
            }
            //Este bucle busca el email en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux._email == email)
                    return true;
                aux = aux._siguiente;
            } while (aux != _cabeza);
            //Si no encuentra el email
            return false;
        }
        public void MostrarAscendente()
        {
            if (_cabeza == null)
            {
                Console.WriteLine("Null");
                return;
            }
            PersonaNodo aux = _cabeza;
            Console.Write("... <-> ");
            do
            {
                Console.Write($"{aux._nombre} <-> ");
                aux = aux._siguiente;
            } while (aux != _cabeza);
            Console.Write("...\n");
        }
        public void MostrarDescendente()
        {
            if (_cabeza == null)
            {
                Console.WriteLine("Null");
                return;
            }
            PersonaNodo aux = _cola;
            Console.Write("... <-> ");
            do
            {
                Console.Write($"{aux._nombre} <-> ");
                aux = aux._anterior;
            } while (aux != _cola);
            Console.Write("...\n");
        }
        /*public void AgregarPorCabeza(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            PersonaNodo nuevoNodo = new PersonaNodo(nombre, apellido, edad, numeroTelefonico, email);
            _cantidadPersonas++;
            if (_cabeza == null)
            {
                _cabeza = _cola = nuevoNodo;
                _cola._siguiente = _cabeza;
                return;
            }
            nuevoNodo._siguiente = _cabeza;
            _cabeza._anterior = nuevoNodo;
            _cabeza = nuevoNodo;
            _cola._siguiente = _cabeza;
            _cabeza._anterior = _cola;
        }
        public void Eliminar(int dato)
        {
            if (_cabeza == null)
                return;
            if (_cabeza._dato == dato)
            {
                if (_cabeza == _cola)
                {
                    _cabeza = _cola = null;
                    return;
                }
                _cabeza = _cabeza._siguiente;
                _cola._siguiente = _cabeza;
                _cabeza._anterior = _cola;
                return;
            }
            if (_cola._dato == dato)
            {
                _cola = _cola._anterior;
                _cola._siguiente = _cabeza;
                _cabeza._anterior = _cola;
                return;
            }
            Persona aux = _cabeza;
            do
            {
                if (aux._siguiente._dato == dato)
                {
                    Persona temp = aux._siguiente;
                    aux._siguiente = temp._siguiente;
                    temp._siguiente._anterior = aux;
                    temp._siguiente = temp._anterior = null;
                    return;
                }
                aux = aux._siguiente;
            } while (aux._siguiente != _cabeza);
        }
        */
    }
}
