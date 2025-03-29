using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAmigosPersonal
{
    internal class PersonaNodo
    {
        public string _nombre;
        public string _apellido;
        public int _edad;
        public string _numeroTelefonico;
        public string _email;
        public PersonaNodo _siguiente;
        public PersonaNodo _anterior;
        public PersonaNodo(string nombre, string apellido, int edad, string numeroTelefonico, string email)
        {
            _nombre = nombre;
            _apellido = apellido;
            _edad = edad;
            _numeroTelefonico = numeroTelefonico;
            _email = email;
        }
    }
}
