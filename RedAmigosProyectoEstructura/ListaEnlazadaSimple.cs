using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using RedAmigosProyectoEstructura;

namespace RedAmigosProyectoEstructura
{
    public class ListaEnlazadaSimple
    {
        public PersonaNodo _cabeza;
        public PersonaNodo _cola;
        public ListaEnlazadaSimple()
        {
            _cabeza = null;
            _cola = null;
        }
        public bool EsVacia()
        {
            return _cabeza == null && _cola == null;
        }
        public void AgregarPorCola(PersonaNodo nuevaPersona)
        {
            if (EsVacia())
            {
                _cabeza = nuevaPersona;
                _cola = nuevaPersona;
            }
            else
            {
                _cola.Siguiente = nuevaPersona;
                _cola = nuevaPersona;
            }
        }
        public void AgregarPorCabeza(PersonaNodo nuevaPersona)
        {
            if (EsVacia())
            {
                _cabeza = nuevaPersona;
                _cola = nuevaPersona;
            }
            else
            {
                nuevaPersona.Siguiente = _cabeza;
                _cabeza = nuevaPersona;
            }
        }
        public bool BuscarNumero(string numeroTelefonico)
        {
            if (EsVacia())
                return false;
            //Si la cola es el numero telefonico que busca, la complejidad se vuelve O(1)
            if (_cola.NumeroTelefonico == numeroTelefonico)
            {
                return true;
            }
            //Este bucle busca el numero telefonico en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            while (aux != null)
            {
                if (aux.NumeroTelefonico == numeroTelefonico)
                    return true;
                aux = aux.Siguiente;
            } 
            //Si no encuentra el numero telefonico
            return false;
        }
        public bool BuscarEmail(string email)
        {
            if (EsVacia())
                return false;
            //Si la cola es el numero telefonico que busca, la complejidad se vuelve O(1)
            if (_cola.Email == email)
            {
                return true;
            }
            //Este bucle busca el numero telefonico en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            while (aux != null)
            {
                if (aux.Email == email)
                    return true;
                aux = aux.Siguiente;
            }
            //Si no encuentra el numero telefonico
            return false;
        }
        public void Mostrar()
        {
            PersonaNodo aux = _cabeza;
            while (aux != null)
            {
                Console.Write($"{aux.Nombre} -> ");
                aux = aux.Siguiente;
            }
            Console.Write("Null\n");
        }
    }
}
