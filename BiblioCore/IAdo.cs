namespace BiblioCore;

public interface IAdo
{
    void AltaUsuario(Usuario usuario);
    List<Usuario> ObtenerUsuarios();
    void AltaLibro(Libro libro);
    List<Libro> ObtenerLibro();
    void AltaAutor(Autor autor);
    List<Autor> ObtenerAutores();
    void AltaPrestamo(Prestamo prestamo);
    List<Prestamo> ObtenerPrestamos();
}