using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int? AnioPublicacion {  get; set; }
        public string? ISBN { get; set; }

        // ? <- permite que la propiedad sea o no requerida, si está bueno y si no también :)

        public Libro(string titulo, string autor, int? anioPublicacion = null, string? isbn = null)
        {
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anioPublicacion;
            ISBN = isbn;
        }

        public string ObtenerInformacion()
        {
            string anioPublicacion = AnioPublicacion.HasValue ? AnioPublicacion.ToString() : "Desconocido";

            string isbn = ISBN != null ? ISBN : "Desconocido";

            return $"Título: {Titulo}, Autor: {Autor}, Año de publicación: {anioPublicacion}, ISBN: {isbn}";
        }
    }
}
