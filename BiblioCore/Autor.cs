using System.Diagnostics.CodeAnalysis;

namespace BiblioCore;

public class Autor
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public int IdAutor { get; set; }
    public List<Libro> Libro { get; set; }

    public Autor()
    {
    }

    [SetsRequiredMembers]
    public Autor(string nombre, string apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
        Libro = new List<Libro>();
    }

    [SetsRequiredMembers]
    public Autor(string nombre, string apellido, int unIdAutor) : this(nombre, apellido) 
        => IdAutor = unIdAutor;

}