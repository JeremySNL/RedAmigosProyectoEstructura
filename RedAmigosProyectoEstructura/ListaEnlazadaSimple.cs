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
        public void AgregarPorCola(PersonaNodo nuevaPersona)
        {
            if (_cabeza == null)
            {
                _cabeza = nuevaPersona;
                _cola = nuevaPersona;
            }
            else
            {
                _cola._siguiente = nuevaPersona;
                _cola = nuevaPersona;
            }
        }
        public void AgregarPorCabeza(PersonaNodo nuevaPersona)
        {
            if (_cabeza == null)
            {
                _cabeza = nuevaPersona;
                _cola = nuevaPersona;
            }
            else
            {
                nuevaPersona._siguiente = _cabeza;
                _cabeza = nuevaPersona;
            }
        }
        public bool BuscarNumero(string numeroTelefonico)
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
        public bool BuscarEmail(string email)
        {
            if (_cabeza == null)
                return false;
            //Si la cola es el numero telefonico que busca, la complejidad se vuelve O(1)
            if (_cola._email == email)
            {
                return true;
            }
            //Este bucle busca el numero telefonico en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            while (aux != null)
            {
                if (aux._email == email)
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
