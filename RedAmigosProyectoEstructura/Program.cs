using RedAmigosProyectoEstructura;
class Program
{
    static void Main(string[] args)
    {
        int opcion, edad;
        string nombre, apellido, numeroTelefonico, email;
        RedSocialListaDC redSocial = new RedSocialListaDC();
        while (true)
        {
            Console.WriteLine($"Total de personas en la red: {redSocial._cantidadPersonas}\n");
            Console.WriteLine("Opciones:\n1. Agregar persona a la red social\n2. Agregar un amigo\n3. Imprimir lista de amigos\n4. Imprimir lista de amigos mutuos\n5. Imprimir lista de amigos\n6. Revisar la bandeja de solicitudes de amistad\n7. Imprimir arbol de amigos\n8. Imprimir listado de personas en orden ascendente\n9. Imprimir listado de personas en orden descendente\n10. Imprimir factor de carga del directorio\n11. Salir");
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
            else if(opcion == 2)
            {
                Console.Clear();
            }
            else if (opcion == 3)
            {
                Console.Clear();
            }
            else if (opcion == 4)
            {
                Console.Clear();
            }
            else if (opcion == 5)
            {
                Console.Clear();
            }
            else if (opcion == 6)
            {
                Console.Clear();
            }
            else if (opcion == 7)
            {
                Console.Clear();
            }
            else if (opcion == 8)
            {
                Console.Clear();
                redSocial.MostrarAscendente();
            }
            else if (opcion == 9)
            {
                Console.Clear();
                redSocial.MostrarDescendente();
            }
            else if (opcion == 10)
            {
                Console.Clear();
                Console.WriteLine($"Factor de carga del directorio: {redSocial.FactorCarga()}");
            }
            else if(opcion == 11)
                return;
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        redSocial.AgregarPersona("Jeremy", "Sanchez Cabrera", 18, "809-393-7191", "elninogeremy@gmail.com");
        
        
    }
}