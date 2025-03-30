using RedAmigosProyectoEstructura;
class Program
{
    static void Main(string[] args)
    {
        /*RedSocialListaDC redSocial = new RedSocialListaDC();
        redSocial.AgregarPersona("Jeremy", "Sanchez Cabrera", 18, "809-393-7191", "elninogeremy@gmail.com");
        redSocial.AgregarPersona("Andrea", "Garcia Rosa", 18, "809-757-0923", "andrea_garcias0977@gmail.com");
        redSocial.MostrarAscendente();
        redSocial.MostrarDescendente();*/
        DirectorioTelefonicoHash directorio = new DirectorioTelefonicoHash(10);
        PersonaNodo persona = new PersonaNodo("Jeremy", "Sanchez Cabrera", 18, "809-393-7191", "elninogeremy@gmail.com");
        directorio.AgregarTelefono(persona);

        PersonaNodo persona2 = new PersonaNodo("Ana", "Rosa Marte", 18, "809-393-7192", "elninogeremy@gmail.com");
        directorio.AgregarTelefono(persona2);

        PersonaNodo persona3 = new PersonaNodo("Carlos", "Rodríguez López", 30, "829-123-4567", "carlos.rodriguez@hotmail.com");
        directorio.AgregarTelefono(persona3);

        PersonaNodo persona4 = new PersonaNodo("María", "Fernández Castro", 22, "849-987-6543", "maria.fernandez@yahoo.com");
        directorio.AgregarTelefono(persona4);

        PersonaNodo persona5 = new PersonaNodo("Pedro", "García Ruiz", 27, "809-222-7890", "pedro.garcia@gmail.com");
        directorio.AgregarTelefono(persona5);

        PersonaNodo persona6 = new PersonaNodo("Laura", "Santos Peña", 19, "849-654-3210", "laura.santos@outlook.com");
        directorio.AgregarTelefono(persona6);

        PersonaNodo persona7 = new PersonaNodo("Sofía", "Jiménez Ortiz", 35, "829-321-9876", "sofia.jimenez@gmail.com");
        directorio.AgregarTelefono(persona7);

        PersonaNodo persona8 = new PersonaNodo("Ricardo", "Mendoza Torres", 40, "809-888-1111", "ricardo.mendoza@mail.com");
        directorio.AgregarTelefono(persona8);

        PersonaNodo persona9 = new PersonaNodo("Isabel", "Romero Vargas", 28, "849-777-2222", "isabel.romero@gmail.com");
        directorio.AgregarTelefono(persona9);

        PersonaNodo persona10 = new PersonaNodo("Javier", "Hernández Díaz", 32, "829-666-3333", "javier.hernandez@hotmail.com");
        directorio.AgregarTelefono(persona10);

        PersonaNodo persona11 = new PersonaNodo("Elena", "Castillo Gómez", 24, "809-555-4444", "elena.castillo@yahoo.com");
        directorio.AgregarTelefono(persona11);

        PersonaNodo persona12 = new PersonaNodo("Manuel", "Torres Ramírez", 29, "849-444-5555", "manuel.torres@gmail.com");
        directorio.AgregarTelefono(persona12);

        PersonaNodo persona13 = new PersonaNodo("Patricia", "Navarro Suárez", 21, "829-333-6666", "patricia.navarro@hotmail.com");
        directorio.AgregarTelefono(persona13);

        PersonaNodo persona14 = new PersonaNodo("Fernando", "López Méndez", 26, "809-111-7777", "fernando.lopez@mail.com");
        directorio.AgregarTelefono(persona14);

        PersonaNodo persona15 = new PersonaNodo("Gabriela", "Ortega Salazar", 31, "849-999-8888", "gabriela.ortega@gmail.com");
        directorio.AgregarTelefono(persona15);

        directorio.MostrarTabla();
    }
}