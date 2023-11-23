using BiblioCore;

namespace BiblioTest;

public class AdoTestAutor : AdoTest
{
    public AdoTestAutor() : base() {}
    [Theory]
    [InlineData("Gabriel", "Garcia Márquez")]

    public void TraerAutores(string nombre, string apellido)
    {
        var autores = Ado.ObtenerAutores();
        Assert.Contains(autores, a => a.Nombre == nombre && a.Apellido == apellido);
    }

    [Fact]
    public void altaAutor()
    {
        var Marcos = new Autor("Marcos", "Garcia");

        Assert.Equal(0, Marcos.IdAutor);
        Ado.AltaAutor(Marcos);

        Assert.NotEqual(0, Marcos.IdAutor);
    }
}
