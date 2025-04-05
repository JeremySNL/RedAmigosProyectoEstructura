using RedAmigosProyectoEstructura;
class Program
{
    public static void MenuAcciones(PersonaNodo persona, RedSocialListaDC redSocial)
    {
        int opcion;
        Console.Clear();
        while (true)
        {
            Console.WriteLine($"Persona seleccionada:\n\nNombre:            {persona._nombre}\nApellido:          {persona._apellido}\nEdad:              {persona._edad}\nNúmero Telefónico: {persona._numeroTelefonico}\nEmail:             {persona._email}");
            Console.WriteLine("\nAcciones:\n1. Agregar amigo\n2. Imprimir lista de amigos aceptados\n3. Imprimir lista de amigos mutuos\n4. Imprimir lista de amigos no correspondido\n5. Responder solicitudes de amistad\n6. Armar arbol con sus amigos\n7. Salir");
            opcion = int.Parse(Console.ReadLine());
            if (opcion == 1)
            {
                Console.Clear();
                Console.Write("Digite el email de la persona: ");
                string email = Console.ReadLine();
                redSocial.AgregarAmigo(email);
            }
            else if (opcion == 2)
            {
                Console.Clear();
                redSocial.ImprimirAmigosAceptados();
            }
            else if (opcion == 3)
            {
                Console.Clear();
                redSocial.ImprimirAmigosMutuos();
            }
            else if (opcion == 4)
            {
                Console.Clear();
                redSocial.ImprimirAmigosNoCorrespondidos();
            }
            else if (opcion == 5)
            {
                Console.Clear();
                redSocial.ResponderSolicitudes();
            }
            else if (opcion == 6)
            {
                Console.Clear();
            }
            else if (opcion == 7)
                return;
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    static void Main(string[] args)
    {
        int opcion, edad;
        string nombre, apellido, numeroTelefonico, email;
        RedSocialListaDC redSocial = new RedSocialListaDC();
        /*redSocial.AgregarPersona("Jeremy", "Sanchez Cabrera", 18, "809-393-7191", "elninogeremy@gmail.com");
        redSocial.AgregarPersona("Jeremy", "Sanchez Cabrera", 18, "809-39-7191", "elninoremy@gmail.com");
        redSocial.AgregarPersona("Jeremy", "Sanchez Cabrera", 18, "809-393-71", "elninogeremymail.com");
*/

        while (true)
        {
            Console.WriteLine($"Total de personas en la red: {redSocial._cantidadPersonas}\n");
            Console.WriteLine("Opciones:\n1. Agregar persona a la red social\n2. Seleccionar persona\n3. Imprimir listado de personas en orden ascendente\n4. Imprimir listado de personas en orden descendente\n5. Imprimir factor de carga del directorio\n6. Salir");
            opcion = int.Parse(Console.ReadLine());
            if (opcion == 1)
            {
                Console.Clear();
                Console.Write("Nombre:            ");
                nombre = Console.ReadLine();
                Console.Write("Apellido:          ");
                apellido = Console.ReadLine();
                Console.Write("Edad:              ");
                edad = int.Parse(Console.ReadLine());
                Console.Write("Número Telefónico: ");
                numeroTelefonico = Console.ReadLine();
                Console.Write("Email:             ");
                email = Console.ReadLine();
                redSocial.AgregarPersona(nombre, apellido, edad, numeroTelefonico, email);
            }
            else if (opcion == 2)
            {
                Console.Clear();
                PersonaNodo actual = redSocial.ExplorarLista();
                if (actual != null)
                    MenuAcciones(actual, redSocial);
            }
            else if (opcion == 3)
            {
                Console.Clear();
                redSocial.MostrarAscendente();
            }
            else if (opcion == 4)
            {
                Console.Clear();
                redSocial.MostrarDescendente();
            }
            else if (opcion == 5)
            {
                Console.Clear();
                Console.WriteLine($"Factor de carga del directorio: {redSocial.FactorCarga()}");
            }
            else if (opcion == 6)
                return;
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}