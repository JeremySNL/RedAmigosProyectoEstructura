using RedAmigosProyectoEstructura;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    public static ConsoleKeyInfo ImprimirMenuPrincipal(RedSocialListaDC redSocial)
    {
        ConsoleKeyInfo opcion;
        Console.WriteLine($"Total de personas en la red: {redSocial.CantidadPersonas}\n");
        Console.WriteLine("Opciones:\n");
        Console.WriteLine("1. Agregar persona a la red social");
        Console.WriteLine("2. Seleccionar persona");
        Console.WriteLine("3. Imprimir listado de personas en orden ascendente");
        Console.WriteLine("4. Imprimir listado de personas en orden descendente");
        Console.WriteLine("5. Imprimir factor de carga del directorio");
        Console.WriteLine("6. Salir\n");
        return opcion = Console.ReadKey();
    }
    public static ConsoleKeyInfo ImprimirMenuAcciones(PersonaNodo persona, RedSocialListaDC redSocial)
    {
        ConsoleKeyInfo opcion;
        int cantidadPersonas = redSocial.CantidadAmigos();
        Console.WriteLine("Persona seleccionada:\n");
        Console.WriteLine($"Nombre:            {persona.Nombre}");
        Console.WriteLine($"Apellido:          {persona.Apellido}");
        Console.WriteLine($"Edad:              {persona.Edad}");
        Console.WriteLine($"Número Telefónico: {persona.NumeroTelefonico}");
        Console.WriteLine($"Email:             {persona.Email}");
        Console.WriteLine($"\nCantidad de amigos: {cantidadPersonas}");
        
        Console.WriteLine("\nAcciones:\n");
        Console.WriteLine("1. Agregar amigo");
        Console.WriteLine("2. Imprimir lista de amigos aceptados");
        Console.WriteLine("3. Imprimir lista de amigos mutuos");
        Console.WriteLine("4. Imprimir lista de amigos no correspondido");
        Console.WriteLine("5. Responder solicitudes de amistad");
        Console.WriteLine("6. Armar arbol con sus amigos");
        Console.WriteLine("7. Salir\n");
        return opcion = Console.ReadKey();
    }
    public static void MenuAcciones(PersonaNodo persona, RedSocialListaDC redSocial)
    {
        Console.Clear();
        while (true)
        {
            ConsoleKeyInfo opcion = ImprimirMenuAcciones(persona, redSocial);
            if (opcion.Key == ConsoleKey.D1 || opcion.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Console.Write("Digite el email de la persona: ");
                string email = Console.ReadLine() ?? "";
                redSocial.AgregarAmigo(email);
            }
            else if (opcion.Key == ConsoleKey.D2 || opcion.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                redSocial.ImprimirAmigosAceptados();
            }
            else if (opcion.Key == ConsoleKey.D3 || opcion.Key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                redSocial.ImprimirAmigosMutuos();
            }
            else if (opcion.Key == ConsoleKey.D4 || opcion.Key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                redSocial.ImprimirAmigosNoCorrespondidos();
            }
            else if (opcion.Key == ConsoleKey.D5 || opcion.Key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                redSocial.ResponderSolicitudes();
            }
            else if (opcion.Key == ConsoleKey.D6 || opcion.Key == ConsoleKey.NumPad6)
            {
                Console.Clear();
                redSocial.ArmarArbol(redSocial);
            }
            else if (opcion.Key == ConsoleKey.D7 || opcion.Key == ConsoleKey.NumPad7)
                return;
            else
                Console.WriteLine("\nOpcion invalida!");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public static void AgregarPersona(RedSocialListaDC redSocial)
    {
        string nombre, apellido, numeroTelefonico, email;
        int edad;
        Console.Write("Nombre:            ");
        nombre = Console.ReadLine() ?? "";
        Console.Write("Apellido:          ");
        apellido = Console.ReadLine() ?? "";
        Console.Write("Edad:              ");
        edad = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Número Telefónico: ");
        numeroTelefonico = Console.ReadLine() ?? "";
        Console.Write("Email:             ");
        email = Console.ReadLine() ?? "";
        redSocial.AgregarPersona(nombre, apellido, edad, numeroTelefonico, email);
    }
    static void Main()
    {
        RedSocialListaDC redSocial = new RedSocialListaDC();

        redSocial.AgregarPersona("Jeremy", "Sanchez", 18, "8909", "nino");
        redSocial.AgregarPersona("Joel", "Escano", 18, "89", "joel");
        redSocial.AgregarPersona("David", "Yostin", 18, "09", "yostin");
        redSocial.AgregarPersona("Hosmely", "Marte", 18, "829", "hosmely");
        redSocial.AgregarPersona("Bryan", "Rosa", 18, "1111", "bryan");
        redSocial.AgregarPersona("Juan", "Perez", 18, "2222", "juan");

        while (true)
        {
            ConsoleKeyInfo opcion = ImprimirMenuPrincipal(redSocial);
            if (opcion.Key == ConsoleKey.D1 || opcion.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                AgregarPersona(redSocial);
            }
            else if (opcion.Key == ConsoleKey.D2 || opcion.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                PersonaNodo personaSeleccionada = redSocial.ExplorarLista();
                if (personaSeleccionada != null)
                    MenuAcciones(personaSeleccionada, redSocial);
            }
            else if (opcion.Key == ConsoleKey.D3 || opcion.Key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                redSocial.MostrarAscendente();
            }
            else if (opcion.Key == ConsoleKey.D4 || opcion.Key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                redSocial.MostrarDescendente();
            }
            else if (opcion.Key == ConsoleKey.D5 || opcion.Key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                Console.WriteLine($"Factor de carga del directorio: {redSocial.FactorCarga()}");
            }
            else if (opcion.Key == ConsoleKey.D6 || opcion.Key == ConsoleKey.NumPad6)
                return;
            else
                Console.WriteLine("\nOpcion invalida!");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}



