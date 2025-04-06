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
        private PersonaNodo? _cabeza;
        private PersonaNodo? _cola;
        private PersonaNodo? _personaSeleccionada;
        private TablaHash _directorio;
        public int CantidadPersonas;

        //Médoto constructor
        public RedSocialListaDC()
        {
            _cabeza = _cola = _personaSeleccionada = null;
            CantidadPersonas = 0;
            _directorio = new TablaHash(50);
        }
        public bool EsVacia()
        {
            return _cabeza == null && _cola == null;
        }

        //Esta método agrega la persona por cola para tener un registro ascendente en orden de entrada
        public void AgregarPersona(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            PersonaNodo nuevoNodo = new PersonaNodo(nombre, apellido, edad, numeroTelefonico, email);
            //Si la lista esta vacía se agrega el nodo
            if (EsVacia())
            {
                CantidadPersonas++;
                _directorio.AgregarTelefono(nuevoNodo);

                _cabeza = _cola = nuevoNodo;
                _cola.Siguiente = _cabeza;
                _cola.Anterior = _cabeza;
                //Para seleccionar en ExplorarLista()
                _personaSeleccionada = _cabeza;

                Console.WriteLine($"\nLa persona {nuevoNodo.Nombre} ha sido agregado");
                return;
            }
            //Buscando telefonos duplicados
            if (_directorio.BuscarNumero(nuevoNodo.NumeroTelefonico))
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
            CantidadPersonas++;
            _cola.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = _cola;
            _cola = nuevoNodo;
            _cola.Siguiente = _cabeza;
            _cabeza.Anterior = _cola;
            Console.WriteLine($"\nLa persona {nuevoNodo.Nombre} ha sido agregado");
        }
        public PersonaNodo ExplorarLista()
        {
            if (EsVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return null;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Mostrando: {_personaSeleccionada.Nombre} {_personaSeleccionada.Apellido} - {_personaSeleccionada.Edad} - {_personaSeleccionada.NumeroTelefonico} - {_personaSeleccionada.Email}");
                Console.WriteLine("\nOpciones:\n");
                Console.WriteLine("1. Siguiente");
                Console.WriteLine("2. Anterior");
                Console.WriteLine("3. Seleccionar");

                ConsoleKeyInfo opcion = Console.ReadKey();
                //Siguiente
                if (opcion.Key == ConsoleKey.D1 || opcion.Key == ConsoleKey.NumPad1)
                    _personaSeleccionada = _personaSeleccionada.Siguiente;
                //Anterior
                else if (opcion.Key == ConsoleKey.D2 || opcion.Key == ConsoleKey.NumPad2)
                    _personaSeleccionada = _personaSeleccionada.Anterior;
                //Seleccionar
                else if (opcion.Key == ConsoleKey.D3 || opcion.Key == ConsoleKey.NumPad3)
                    return new PersonaNodo(_personaSeleccionada.Nombre, _personaSeleccionada.Apellido, _personaSeleccionada.Edad, _personaSeleccionada.NumeroTelefonico, _personaSeleccionada.Email);
                else
                {
                    Console.WriteLine("\nOpcion invalida!");
                    continue;
                }
            }
        }
        public bool BuscarEmail(string email)
        {
            if (EsVacia())
            {
                return false;
            }
            //Si la cola es el email que busca, la complejidad se vuelve O(1)
            if (_cola.Email == email)
            {
                return true;
            }
            //Este bucle busca el email en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux.Email == email)
                    return true;
                aux = aux.Siguiente;
            } while (aux != _cabeza);
            //Si no encuentra el email
            return false;
        }
        private PersonaNodo? BuscarEmailNodo(string email)
        {
            if (EsVacia())
            {
                return null;
            }
            //Si la cola es el email que busca, la complejidad se vuelve O(1)
            if (_cola.Email == email)
            {
                return _cola;
            }
            //Este bucle busca el email en la cabeza y despues los del medio
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux.Email == email)
                    return aux;
                aux = aux.Siguiente;
            } while (aux != _cabeza);
            //Si no encuentra el email
            return null;
        }
        public void MostrarAscendente()
        {
            if (EsVacia())
            {
                Console.WriteLine("Null");
                return;
            }
            PersonaNodo aux = _cabeza;
            Console.Write("... <-> ");
            do
            {
                Console.Write($"{aux.Nombre} <-> ");
                aux = aux.Siguiente;
            } while (aux != _cabeza);
            Console.Write("...\n");
        }
        public void MostrarDescendente()
        {
            if (EsVacia())
            {
                Console.WriteLine("Null");
                return;
            }
            PersonaNodo aux = _cola;
            Console.Write("... <-> ");
            do
            {
                Console.Write($"{aux.Nombre} <-> ");
                aux = aux.Anterior;
            } while (aux != _cola);
            Console.Write("...\n");
        }
        public double FactorCarga()
        {
            return _directorio.MostrarFactorCarga();
        }
        public void AgregarAmigo(string email)
        {
            if (EsVacia())
            {
                Console.WriteLine("\nRed Social vacia!");
                return;
            }
            if (!BuscarEmail(email))
            {
                Console.WriteLine("\nEsta persona no existe.");
                return;
            }
            if (BuscarEmailNodo(email) == _personaSeleccionada)
            {
                Console.WriteLine("\nNo puedes mandar una solicitud de amistad a ti mismo.");
                return;
            }
            if (BuscarEmailNodo(email).ListaAmigos.BuscarEmail(_personaSeleccionada.Email))
            {
                Console.WriteLine("\nEsta persona ya existe como amigo.");
                return;
            }
            if (BuscarEmailNodo(email).BandejaSolicitudes.BuscarEmail(_personaSeleccionada.Email))
            {
                Console.WriteLine("\nSolicitud de amistad duplicada.");
                return;
            }
            PersonaNodo aux = BuscarEmailNodo(email);
            aux.BandejaSolicitudes.Push(new PersonaNodo(_personaSeleccionada.Nombre, _personaSeleccionada.Apellido, _personaSeleccionada.Edad, _personaSeleccionada.NumeroTelefonico, _personaSeleccionada.Email));
            Console.WriteLine($"\nSolicitud de amistad enviada a : {aux.Nombre}.");
        }
        public void ResponderSolicitudes()
        {
            if (EsVacia())
            {
                Console.WriteLine("\nRed social vacia!");
                return;
            }
            PersonaNodo aux = _personaSeleccionada.BandejaSolicitudes.Pop();
            while (aux != null)
            {
                Console.WriteLine($"{aux.Nombre}\n\n1. Aceptar\n2. Rechazar");
                ConsoleKeyInfo opcion = Console.ReadKey();
                if (opcion.Key == ConsoleKey.D1)
                {
                    Console.WriteLine($"\nHas aceptado la solicitud de {aux.Nombre}.");
                    _personaSeleccionada.ListaAmigos.AgregarPorCola(new PersonaNodo(aux.Nombre, aux.Apellido, aux.Edad, aux.NumeroTelefonico, aux.Email));
                    _personaSeleccionada.CantidadAmigos++;
                }
                else if (opcion.Key == ConsoleKey.D1)
                {
                    Console.WriteLine($"\nHas rechazada la solicitud de {aux.Nombre}.");
                }
                else
                {
                    Console.WriteLine("\nOpcion invalida!");
                }
                aux = _personaSeleccionada.BandejaSolicitudes.Pop();
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ImprimirAmigosAceptados()
        {
            if (EsVacia())
            {
                Console.WriteLine("\nRed social vacia!");
                return;
            }
            _personaSeleccionada.ListaAmigos.Mostrar();
        }
        public void ImprimirAmigosMutuos()
        {
            if (EsVacia())
            {
                Console.WriteLine("\nRed social vacia!");
                return;
            }
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux.ListaAmigos.BuscarEmail(_personaSeleccionada.Email) && _personaSeleccionada.ListaAmigos.BuscarEmail(aux.Email))
                {
                    Console.Write($"{aux.Nombre} -> ");
                }
                aux = aux.Siguiente;
            } while (aux != _cabeza);
            Console.Write("Null\n");
        }
        public void ImprimirAmigosNoCorrespondidos()
        {
            if (EsVacia())
            {
                Console.WriteLine("\nRed social vacia!");
                return;
            }
            PersonaNodo aux = _cabeza;
            do
            {
                if (aux.ListaAmigos.BuscarEmail(_personaSeleccionada.Email) && !_personaSeleccionada.ListaAmigos.BuscarEmail(aux.Email))
                {
                    Console.Write($"{aux.Nombre} -> ");
                }
                aux = aux.Siguiente;
            } while (aux != _cabeza);
            Console.Write("Null\n");
        }
        public int CantidadAmigos()
        {
            if (EsVacia())
            {
                Console.WriteLine("\nRed social vacia!");
                return 0;
            }
            return _personaSeleccionada.CantidadAmigos;
        }
        public void ArmarArbol(RedSocialListaDC redSocial)
        {
            if (EsVacia())
            {
                Console.WriteLine("Red social vacia!");
                return;
            }
            TablaHash visitados = new TablaHash(50);
            NodoArbol raiz = NodoArbol.ConstruirArbol(_personaSeleccionada, visitados, redSocial);
            Console.WriteLine($"Representación de lista de los amigos de {_personaSeleccionada.Nombre}: \n");
            raiz.ImprimirArbol(raiz);
            Console.WriteLine();
        }
        public PersonaNodo ActualizarPersona(PersonaNodo persona)
        {
            if (EsVacia())
            {
                Console.WriteLine("Red social vacia!");
                return null;
            }
            return BuscarEmailNodo(persona.Email);
        }
    }
}
