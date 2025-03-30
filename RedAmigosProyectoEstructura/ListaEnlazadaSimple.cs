using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using RedAmigosProyectoEstructura;

namespace RedAmigosProyectoEstructura
{
    internal class ListaEnlazadaSimple
    {
        private PersonaNodo _cabeza;
        private PersonaNodo _cola;
        public ListaEnlazadaSimple()
        {
            _cabeza = null;
            _cola = null;
        }
        public void AgregarPorCola(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            PersonaNodo nuevoPersonaNodo = new PersonaNodo(nombre, apellido, edad, numeroTelefonico, email);
            if (_cabeza == null)
            {
                _cabeza = nuevoPersonaNodo;
                _cola = nuevoPersonaNodo;
            }
            else
            {
                _cola._siguiente = nuevoPersonaNodo;
                _cola = nuevoPersonaNodo;
            }
        }
        public bool Buscar(string numeroTelefonico)
        {
            if (_cabeza == null)
                return false;
            //Si la cola es el numero telefonico que busca, la complejidad se vuelve O(1)
            if (_cola._numeroTelefonico == numeroTelefonico)
            {
                return true;
            }
            //Este bucle busca el numero telefonico en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            while (aux != null)
            {
                if (aux._numeroTelefonico == numeroTelefonico)
                    return true;
                aux = aux._siguiente;
            } 
            //Si no encuentra el numero telefonico
            return false;
        }
        public void Mostrar()
        {
            PersonaNodo aux = _cabeza;
            while (aux != null)
            {
                Console.Write($"{aux._nombre} -> ");
                aux = aux._siguiente;
            }
            Console.Write("Null\n");
        }
    }
}
