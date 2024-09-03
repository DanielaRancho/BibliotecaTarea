using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    class MiBiblioteca
    {
        private List<Libro> Libros;

        public MiBiblioteca()
        {
            Libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
            LibroAgregado(libro);
        }

        public void AgregarLibro(string titulo, string autor, int? anioPublicacion = null, string? isbn = null)
        {
            Libro nuevoLibro;

            if (anioPublicacion.HasValue && isbn != null)
            {
                nuevoLibro = new Libro(titulo, autor, anioPublicacion, isbn);
            }
            else if (anioPublicacion.HasValue)
            {
                nuevoLibro = new Libro(titulo, autor, anioPublicacion);
            }
            else if (isbn != null)
            {
                nuevoLibro = new Libro(titulo, autor, isbn: isbn);
            }
            else
            {
                nuevoLibro = new Libro(titulo, autor);
            }

            Libros.Add(nuevoLibro);
            LibroAgregado(nuevoLibro);
        }
        private void LibroAgregado(Libro libro)
        {
            Console.WriteLine($"--- Libro: '{libro.Titulo}' agregado a la biblioteca");
        }

        public void ListarLibros()
        {
            Console.WriteLine("--- Libros disponibles en la biblioteca:");
            foreach (Libro libro in Libros)
            {
                Console.WriteLine(libro.ObtenerInformacion());
            }
        }

        public void EliminarLibro(string titulo) 
        {
            Libro libroAEliminar = Libros.FirstOrDefault(libro => libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libroAEliminar != null)
            {
                Libros.Remove(libroAEliminar);
                Console.WriteLine($"--- Se eliminó: '{titulo}'  de la biblioteca");
            }
            else
            {
                Console.WriteLine($"--- Libro '{titulo}' no encontrado en la biblioteca");
            }
        }
        public void BuscarLibro(string autor) 
        {
            var librosEncontrados = Libros.Where(libro => libro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosEncontrados.Any())
            {
                Console.WriteLine($"--- Libros encontrados de {autor}:");
                foreach (var libro in librosEncontrados)
                {
                    Console.WriteLine(libro.ObtenerInformacion());
                }
            }
            else
            {
                Console.WriteLine($"--- No se encontraron libros de: {autor}");
            }
        }
    }
}
