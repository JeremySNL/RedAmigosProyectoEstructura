using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAmigosProyectoEstructura;

namespace RedAmigosProyectoEstructura
{
    internal class DirectorioTelefonicoHash
    {
        //Atributos
        private int _cantidadTelefonos;
        private int _tamanoTabla;
        private double _factorCarga;
        private ListaEnlazadaSimple[] directorio;

        //Método Constructor
        public DirectorioTelefonicoHash(int tamañoTabla)
        {
            _tamanoTabla = tamañoTabla;
            _factorCarga = 0;
            _cantidadTelefonos = 0;
            directorio = new ListaEnlazadaSimple[_tamanoTabla];
            for (int j = 0; j < _tamanoTabla; j++)
                directorio[j] = null;
        }
        //Convierte de texto a números
        public int Transformar(string clave)
        {
            int acumulador = 0;
            for (int i = 0; i < clave.Length; i++)
            {
                acumulador += clave[i] * (i + 1);
            }
            return acumulador;
        }
        //Es la función que se encarga de crear el índice
        public int FuncionHash(string clave)
        {
            int claveTrans = Transformar(clave);
            return (int) claveTrans % _tamanoTabla;
        }
        //
        public void AgregarTelefono(PersonaNodo persona)
        {
            int indice = FuncionHash(persona._numeroTelefonico);
            //Si no hay una lista inicializada en el índice, se inicializa
            if (directorio[indice] == null)
            {
                directorio[indice] = new ListaEnlazadaSimple();
            }
            //Si ya hay una lista inicializada, se le agrega el nodo por cola
            if (!directorio[indice].Buscar(persona._numeroTelefonico))
            {
                directorio[indice].AgregarPorCola(persona._nombre, persona._apellido, persona._edad, persona._numeroTelefonico, persona._email);
                Console.WriteLine($"El Nodo de {persona._nombre} ha sido agregado");
                _cantidadTelefonos++;
                _factorCarga = (double)_cantidadTelefonos / _tamanoTabla;
            }
            else
            {
                Console.WriteLine("El número telefónico ya está registrado!");
            }
        }
        public void MostrarTabla()
        {
            if (_cantidadTelefonos == 0)
            {
                Console.WriteLine("El directorio está vacio!");
                return;
            }
            for (int i = 0; i < _tamanoTabla; i++)
            {
                if (directorio[i] != null)
                {
                    directorio[i].Mostrar();
                }
            }
        }
        public bool BuscarNumero(string numeroTelefonico)
        {
            if (_cantidadTelefonos == 0)
            {
                Console.WriteLine("El directorio está vacio!");
                return false;
            }
            bool centinela = false;
            for (int i = 0; i < _tamanoTabla && !centinela; i++)
            {
                if (directorio[i] != null)
                {
                    centinela = directorio[i].Buscar(numeroTelefonico);
                }
            }
            return centinela;
        }
    }
}
