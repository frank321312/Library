using BiblioCore;

namespace BiblioTest;

public class AdoTest
{
    protected readonly IAdo Ado;
    private static readonly string _cadena =
        @"Server=localhost;Database=5to_Biblioteca;Uid=root;pwd=root;Allow User Variables=True";

    public AdoTest()
    {
        Ado = new BiblioAdoDapper.AdoDapper(_cadena);
    }

    public AdoTest(string cadena)
    {
        Ado = new BiblioAdoDapper.AdoDapper(cadena);
    }
}