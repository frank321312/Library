using BiblioCore;

namespace BiblioTest;

public class AdoTestLibro : AdoTest
{
    public AdoTestLibro() : base() {}
    [Theory]
    [InlineData(9788437, "Cien años de soledad")]

    public void TraerLibros(long isbn, string titulo)
    {
        var libros = Ado.ObtenerLibro();
        Assert.Contains(libros, a => a.ISBN == isbn && a.Titulo == titulo);
    }

    [Fact]
    public void AltaLibro()
    {
        var HymmFor = new Libro(9323126, "Night HymmFor");
        Ado.AltaLibro(HymmFor);
    }
}
