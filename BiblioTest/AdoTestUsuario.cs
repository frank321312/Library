using BiblioCore;

namespace BiblioTest;

public class AdoTestUsuario : AdoTest
{
    public AdoTestUsuario() : base() {}
    [Theory]
    [InlineData("Anonimo", "anonimo12@gnail.com")]    

    public void TraerUsuario(string nombre, string email)
    {
        var usuarios = Ado.ObtenerUsuarios();
        Assert.Contains(usuarios, a => a.Nombre == nombre && a.Email == email);
    }

    [Fact]
    public void AltaUsuarioTest()
    {
        var Pepe = new Usuario("Pepe", "pepe@gmail.com");

        Assert.Equal(0, Pepe.IdUsuario);
        Ado.AltaUsuario(Pepe);

        Assert.NotEqual(0, Pepe.IdUsuario);
    }
}
