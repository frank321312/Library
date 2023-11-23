using System.Diagnostics.CodeAnalysis;
namespace BiblioCore;

public class Prestamo
{
    public int IdPrestamo { get; set; }
    public required Usuario UsuarioPrestamo { get; set; }
    public required Libro LibroPrestamo { get; set; }
    // public DateTime FechaPrestamo { get; set; }

    [SetsRequiredMembers]
    public Prestamo(int unIdPrestamo, Usuario unUsuarioPrestamo, Libro unLibroPrestamo)
    {
        IdPrestamo = unIdPrestamo;
        UsuarioPrestamo = unUsuarioPrestamo;
        LibroPrestamo = unLibroPrestamo;
        // FechaPrestamo = DateTime.MinValue;    
    }
}