using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAmigosPersonal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedAmigosProyectoEstructura
{
    internal class RedSocial
    {
        private Persona _cabeza;
        private Persona _cola;
        public int _cantidadPersonas;
        public RedSocial()
        {
            _cabeza = _cola = null;
            _cantidadPersonas = 0;
        }
        public void AgregarPorCabeza(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            Persona nuevoNodo = new Persona(nombre, apellido, edad, numeroTelefonico, email);
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
        public void AgregarPorCola(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            Persona nuevoNodo = new Persona(nombre, apellido, edad, numeroTelefonico, email);
            _cantidadPersonas++;
            if (_cabeza == null)
            {
                _cabeza = _cola = nuevoNodo;
                _cola._siguiente = _cabeza;
                return;
            }
            _cola._siguiente = nuevoNodo;
            nuevoNodo._anterior = _cola;
            _cola = nuevoNodo;
            _cola._siguiente = _cabeza;
            _cabeza._anterior = _cola;
        }
        /*public void Eliminar(int dato)
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
        public int Buscar(int dato)
        {
            int indice = 0;
            if (_cola._dato == dato)
            {
                return _cantidadPersonas - 1;
            }
            Persona aux = _cabeza;
            do
            {
                if (aux._dato == dato)
                    return indice;
                indice++;
                aux = aux._siguiente;
            } while (aux != _cabeza);
            return -1;
        }
        public void Mostrar()
        {
            if (_cabeza == null)
            {
                Console.WriteLine("Null");
                return;
            }
            Persona aux = _cabeza;
            Console.Write("... <-> ");
            do
            {
                Console.Write($"{aux._dato} <-> ");
                aux = aux._siguiente;
            } while (aux != _cabeza);
            Console.Write("...\n");
        }*/
    }
}
