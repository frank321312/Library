using System.Diagnostics.CodeAnalysis;

namespace BiblioCore;

public class Libro
{
    public required long ISBN { get; set; }
    public required string Titulo { get; set; }

    public Libro()
    {
    }

    [SetsRequiredMembers]
    public Libro(long isbn, string titulo)
    {
        ISBN = isbn;
        Titulo = titulo;
    }
}