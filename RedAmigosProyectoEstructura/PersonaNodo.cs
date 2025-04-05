using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAmigosProyectoEstructura
{
    internal class PersonaNodo
    {
        //Atributos
        public string _nombre;
        public string _apellido;
        public int _edad;
        public string _numeroTelefonico;
        public string _email;
        public int _cantidadAmigos;
        public ListaEnlazadaSimple _listaAmigos;
        public Cola _bandejaSolicitudes;
        public PersonaNodo _siguiente;
        public PersonaNodo _anterior;

        //Método Constructor
        public PersonaNodo(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            _nombre = nombre;
            _apellido = apellido;
            _edad = edad;
            _numeroTelefonico = numeroTelefonico;
            _email = email;
            _listaAmigos = new ListaEnlazadaSimple();
            _bandejaSolicitudes = new Cola();
            _cantidadAmigos = 0;
        }
    }
}
