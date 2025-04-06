using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAmigosProyectoEstructura;

namespace RedAmigosProyectoEstructura
{
    internal class NodoHijo
    {
        public NodoArbol Hijo;
        public NodoHijo Siguiente;

        public NodoHijo(NodoArbol h)
        {
            Hijo = h;
            Siguiente = null;
        }
    }

}
