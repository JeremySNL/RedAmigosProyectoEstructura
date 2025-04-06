using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAmigosProyectoEstructura;

namespace RedAmigosProyectoEstructura
{
    public class PersonaNodo
    {
        //Atributos
        public string Nombre;
        public string Apellido;
        public int Edad;
        public string NumeroTelefonico;
        public string Email;
        public int CantidadAmigos;
        public ListaEnlazadaSimple ListaAmigos;
        public Cola BandejaSolicitudes;
        public PersonaNodo Siguiente;
        public PersonaNodo Anterior;

        //Método Constructor
        public PersonaNodo(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            NumeroTelefonico = numeroTelefonico;
            Email = email;
            ListaAmigos = new ListaEnlazadaSimple();
            BandejaSolicitudes = new Cola();
            CantidadAmigos = 0;
        }
    }
}
