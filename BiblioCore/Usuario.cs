using System.Diagnostics.CodeAnalysis;

namespace BiblioCore;

public class Usuario
{
    public required string Nombre { get; set; }
    public required string Email { get; set; }
    public int IdUsuario { get; set; }
    public List<Prestamo> Prestamos { get; set; }

    public Usuario()
    {
        
    }

    [SetsRequiredMembers]
    public Usuario(string nombre, string email)
    {
        Nombre = nombre;
        Email = email;
        Prestamos = new List<Prestamo>();
    }

    [SetsRequiredMembers]
    public Usuario(string nombre, string email, int unIdUsuario) : this(nombre, email) 
        => IdUsuario = unIdUsuario; 
}