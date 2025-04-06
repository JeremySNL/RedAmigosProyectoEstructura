using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAmigosProyectoEstructura;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedAmigosProyectoEstructura
{
    public class Cola
    {
        private PersonaNodo _cima;
        private PersonaNodo _cola;
        public Cola()
        {
            _cima = null;
            _cola = null;
        }
        public void Push(PersonaNodo persona)
        {
            if (_cima == null)
            {
                _cima = _cola = persona;
                return;
            }
            _cola.Siguiente = persona;
            _cola = persona;
        }
        public PersonaNodo Pop()
        {
            if (_cima == null)
            {
                Console.WriteLine("\nBandeja de solicitud de amistad vacia!");
                return null;
            }
            PersonaNodo PersonaNodo = new PersonaNodo(_cima.Nombre, _cima.Apellido, _cima.Edad, _cima.NumeroTelefonico, _cima.Email);
            _cima = _cima.Siguiente;
            return PersonaNodo;
        }
        public PersonaNodo PeekNodo()
        {
            if (_cima == null)
            {
                Console.WriteLine("\nBandeja de solicitud de amistad vacia!");
                return null;
            }
            return new PersonaNodo(_cima.Nombre, _cima.Apellido, _cima.Edad, _cima.NumeroTelefonico, _cima.Email);
        }

        public void Show()
        {
            if (_cima == null)
            {
                Console.WriteLine("\nBandeja de solicitud de amistad vacia!");
                return;
            }
            PersonaNodo aux = _cima;
            while (aux != null)
            {
                Console.Write($"{aux.Nombre} -> ");
                aux = aux.Siguiente;
            }
            Console.Write("Null\n");
        }
        public bool BuscarEmail(string email)
        {
            if (_cima == null)
                return false;
            //Si la cola es el numero telefonico que busca, la complejidad se vuelve O(1)
            if (_cola.Email == email)
            {
                return true;
            }
            //Este bucle busca el numero telefonico en la cabeza y despues los del medio
            PersonaNodo aux = _cima;
            while (aux != null)
            {
                if (aux.Email == email)
                    return true;
                aux = aux.Siguiente;
            }
            //Si no encuentra el numero telefonico
            return false;
        }
    }
}
