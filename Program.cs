using Biblioteca.Clases;

namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BIENVENIDO A LA BIBLIOTECA DE LA MEDIANOCHE");

            MiBiblioteca miBiblioteca = new MiBiblioteca();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Eliminar libro");
                Console.WriteLine("3. Buscar libro por autor");
                Console.WriteLine("4. Listar libros");
                Console.WriteLine("5. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el título del libro:");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Ingrese el autor del libro:");
                        string autor = Console.ReadLine();

                        Console.WriteLine("Ingrese el año de publicación (opcional):");
                        string inputAnio = Console.ReadLine();
                        int? anioPublicacion = null;
                        if (!string.IsNullOrEmpty(inputAnio) && int.TryParse(inputAnio, out int anio))
                        {
                            anioPublicacion = anio;
                        }

                        Console.WriteLine("Ingrese el ISBN (opcional):");
                        string isbn = Console.ReadLine();
                        if (string.IsNullOrEmpty(isbn))
                        {
                            isbn = null;
                        }

                        miBiblioteca.AgregarLibro(titulo, autor, anioPublicacion, isbn);
                        break;

                    case "2":
                        Console.WriteLine("Ingrese el título del libro a eliminar:");
                        string tituloEliminar = Console.ReadLine();
                        miBiblioteca.EliminarLibro(tituloEliminar);
                        break;

                    case "3":
                        Console.WriteLine("Ingrese el autor del libro a buscar:");
                        string autorBuscar = Console.ReadLine();
                        miBiblioteca.BuscarLibro(autorBuscar);
                        break;

                    case "4":
                        miBiblioteca.ListarLibros();
                        break;

                    case "5":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }

            Console.WriteLine("Gracias por usar la biblioteca.");
        }
    }
}
