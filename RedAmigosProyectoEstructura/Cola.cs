using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAmigosProyectoEstructura;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedAmigosProyectoEstructura
{
    internal class Cola
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
            _cola._siguiente = persona;
            _cola = persona;
        }
        public PersonaNodo Pop()
        {
            if (_cima == null)
            {
                Console.WriteLine("La cola está vacia!!!");
                return null;
            }
            PersonaNodo PersonaNodo = new PersonaNodo(_cima._nombre, _cima._apellido, _cima._edad, _cima._numeroTelefonico, _cima._email);
            _cima = _cima._siguiente;
            return PersonaNodo;
        }
        public PersonaNodo PeekNodo()
        {
            if (_cima == null)
            {
                Console.WriteLine("La cola está vacia!!!");
                return null;
            }
            return new PersonaNodo(_cima._nombre, _cima._apellido, _cima._edad, _cima._numeroTelefonico, _cima._email);
        }
        public void Show()
        {
            if (_cima == null)
            {
                Console.WriteLine("La cola está vacia!!!");
                return;
            }
            PersonaNodo aux = _cima;
            while (aux != null)
            {
                Console.Write($"{aux._nombre} -> ");
                aux = aux._siguiente;
            }
            Console.Write("Null\n");
        }
    }
}
