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
        private PersonaNodo _puntero;
        private DirectorioTelefonicoHash _directorio;
        public int _cantidadPersonas;

        //Médoto constructor
        public RedSocialListaDC()
        {
            _cabeza = _cola = _puntero = null;
            _cantidadPersonas = 0;
            _directorio = new DirectorioTelefonicoHash(10);
        }
        //Esta método agrega la persona por cola para tener un registro ascendente en orden de entrada
        public void AgregarPersona(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            PersonaNodo nuevoNodo = new PersonaNodo(nombre, apellido, edad, numeroTelefonico, email);
            //Si la lista esta vacía se agrega el nodo
            if (_cabeza == null)
            {
                _cantidadPersonas++;
                _directorio.AgregarTelefono(nuevoNodo);
                _cabeza = _cola = nuevoNodo;
                _cola._siguiente = _cabeza;
                _cola._anterior = _cabeza;
                _puntero = _cabeza;
                Console.WriteLine($"\nLa persona {nuevoNodo._nombre} ha sido agregado");
                return;
            }
            //Buscando telefonos duplicados
            if (_directorio.BuscarNumero(nuevoNodo._numeroTelefonico))
            {
                //Mensaje si encuentra una persona con el mismo numero telefónico y no se agrega
                Console.WriteLine("\nYa existe una persona con ese número de telefono en la Red Social.");
                return;
            }
            //Buscando correos duplicados
            if (BuscarEmail(email))
            {
                //Mensaje si encuentra una persona con el mismo email y no se agrega
                Console.WriteLine("\nYa existe una persona con ese correo electrónico en la Red Social.");
                return;
            }
            //Si el método BuscarEmail() no encuentra persona con ese email, se agrega el nodo
            _directorio.AgregarTelefono(nuevoNodo);
            _cantidadPersonas++;
            _cola._siguiente = nuevoNodo;
            nuevoNodo._anterior = _cola;
            _cola = nuevoNodo;
            _cola._siguiente = _cabeza;
            _cabeza._anterior = _cola;
            Console.WriteLine($"\nLa persona {nuevoNodo._nombre} ha sido agregado");
        }
        public PersonaNodo ExplorarLista()
        {
            if (_cabeza == null)
            {
                Console.WriteLine("La lista está vacía.");
                return null;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Mostrando: {_puntero._nombre} {_puntero._apellido} - {_puntero._edad} - {_puntero._numeroTelefonico} - {_puntero._email}");
                Console.WriteLine("\nOpciones:\n");
                Console.WriteLine("1. Siguiente");
                Console.WriteLine("2. Anterior");
                Console.WriteLine("3. Seleccionar");

                int opcion = int.Parse(Console.ReadLine());
                //Siguiente
                if (opcion == 1)
                    _puntero = _puntero._siguiente;
                //Anterior
                else if (opcion == 2)
                    _puntero = _puntero._anterior;
                //Seleccionar
                else if (opcion == 3)
                    return new PersonaNodo(_puntero._nombre, _puntero._apellido, _puntero._edad, _puntero._numeroTelefonico, _puntero._email);
            }
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
        private PersonaNodo BuscarEmailNodo(string email)
        {
            //Si la cola es el email que busca, la complejidad se vuelve O(1)
            if (_cola._email == email)
            {
                return _cola;
            }
            //Este bucle busca el email en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux._email == email)
                    return aux;
                aux = aux._siguiente;
            } while (aux != _cabeza);
            //Si no encuentra el email
            return null;
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
        public double FactorCarga()
        {
            return _directorio.MostrarFactorCarga();
        }
        public void AgregarAmigo(string email)
        {
            if (!BuscarEmail(email))
            {
                Console.WriteLine("\nEsta persona no existe.");
                return;
            }
            if (BuscarEmailNodo(email) == _puntero)
            {
                Console.WriteLine("\nNo puedes mandar una solicitud de amistad a ti mismo.");
                return;
            }
            if (BuscarEmailNodo(email)._listaAmigos.BuscarEmail(_puntero._email))
            {
                Console.WriteLine("\nEsta persona ya existe como amigo.");
                return;
            }
            if (BuscarEmailNodo(email)._bandejaSolicitudes.BuscarEmail(_puntero._email))
            {
                Console.WriteLine("\nSolicitud de amistad duplicada.");
                return;
            }
            PersonaNodo aux = BuscarEmailNodo(email);
            aux._bandejaSolicitudes.Push(new PersonaNodo(_puntero._nombre, _puntero._apellido, _puntero._edad, _puntero._numeroTelefonico, _puntero._email));
            Console.WriteLine($"\nSolicitud de amistad enviada a : {aux._nombre}.");
        }
        public void ResponderSolicitudes()
        {
            PersonaNodo aux = _puntero._bandejaSolicitudes.Pop();
            int opcion;
            while (aux != null)
            {
                Console.WriteLine($"{aux._nombre}\n\n1. Aceptar\n2. Rechazar");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.WriteLine($"\nHas aceptado la solicitud de {aux._nombre}.");
                    _puntero._listaAmigos.AgregarPorCabeza(new PersonaNodo(aux._nombre, aux._apellido, aux._edad, aux._numeroTelefonico, aux._email));
                }
                else if (opcion == 2)
                {
                    Console.WriteLine($"\nHas rechazada la solicitud de {aux._nombre}.");
                }
                else
                {
                    Console.WriteLine("\nOpcion invalida!");
                    continue;
                }
                aux = _puntero._bandejaSolicitudes.Pop();
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ImprimirAmigosAceptados()
        {
            _puntero._listaAmigos.Mostrar();
        }
        public void ImprimirAmigosMutuos()
        {
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux != _puntero && aux._listaAmigos.BuscarEmail(_puntero._email) && _puntero._listaAmigos.BuscarEmail(aux._email))
                {
                    Console.Write($"{aux._nombre} -> ");
                }
                aux = aux._siguiente;
            } while (aux != _cabeza);
            Console.Write("Null\n");
        }
        public void ImprimirAmigosNoCorrespondidos()
        {
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux != _puntero && aux._listaAmigos.BuscarEmail(_puntero._email) && !_puntero._listaAmigos.BuscarEmail(aux._email))
                {
                    Console.Write($"{aux._nombre} -> ");
                }
                aux = aux._siguiente;
            } while (aux != _cabeza);
            Console.Write("Null\n");
        }
    }
}
