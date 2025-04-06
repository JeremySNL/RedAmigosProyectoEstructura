using System.IO;
using RedAmigosProyectoEstructura;

public class TablaHash
{
    //Atrivutos
    private int _cantidadEmails;
    private int _tamanoTabla;
    private double _factorCarga;
    private ListaEnlazadaSimple[] _listaColision;
    //Constructor
    public TablaHash(int tamañoTabla)
    {
        _tamanoTabla = tamañoTabla;
        _factorCarga = 0;
        _cantidadEmails = 0;
        _listaColision = new ListaEnlazadaSimple[_tamanoTabla];
        for (int j = 0; j < _tamanoTabla; j++)
            _listaColision[j] = null;
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
    //Es la funcion que se encarga de crear el indice (Aritmetica Modular)
    public int FuncionHash(string clave)
    {
        int claveTrans = Transformar(clave);
        return (int)claveTrans % _tamanoTabla;
    }
    public void Agregar(PersonaNodo persona)
    {
        int indice = FuncionHash(persona.NumeroTelefonico);
        //Si no hay una lista inicializada en el Indice, se inicializa
        if (_listaColision[indice] == null)
        {
            _listaColision[indice] = new ListaEnlazadaSimple();
        }
        //Si ya hay una lista inicializada, se le agrega el nodo por cola
        if (!_listaColision[indice].BuscarNumero(persona.Email))
        {
            _listaColision[indice].AgregarPorCola(new PersonaNodo(persona.Nombre, persona.Apellido, persona.Edad, persona.NumeroTelefonico, persona.Email));
            _cantidadEmails++;
            _factorCarga = (double)_cantidadEmails / _tamanoTabla;
        }
        else
            Console.WriteLine("El Email ya está registrado!");
    }
    public void MostrarTabla()
    {
        if (_cantidadEmails == 0)
        {
            Console.WriteLine("El directorio está vacio!");
            return;
        }
        for (int i = 0; i < _tamanoTabla; i++)
        {
            if (_listaColision[i] != null)
            {
                _listaColision[i].Mostrar();
            }
        }
    }

    public bool BuscarEmail(string numeroTelefonico)
    {
        if (_cantidadEmails == 0)
        {
            Console.WriteLine("El directorio está vacio!");
            return false;
        }
        bool centinela = false;
        for (int i = 0; i < _tamanoTabla && !centinela; i++)
        {
            if (_listaColision[i] != null)
            {
                centinela = _listaColision[i].BuscarEmail(numeroTelefonico);
            }
        }
        return centinela;
    }
}