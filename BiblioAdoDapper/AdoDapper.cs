using BiblioCore;
using System.Data;
using Dapper;
using MySqlConnector;

namespace BiblioAdoDapper;

public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;
    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);
    private static readonly string _queryAutores
        = "SELECT * FROM Autor ORDER BY Apellido ASC,Nombre ASC";
    private static readonly string _queryLibro
        = "SELECT * FROM Libro ORDER BY ISBN ASC";
    private static readonly string _queryUsuario
        = "SELECT * FROM Usuario ORDER BY Nombre ASC, Email ASC";
    private static readonly string _queryPrestamo
        = "SELECT * FROM Prestamo";
    
    #region Autor
    public void AltaAutor(Autor autor)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unNombre", autor.Nombre);
        parametros.Add("@unApellido", autor.Apellido);
        parametros.Add("@unIdAutor", direction: ParameterDirection.Output);    

        _conexion.Execute("AltaAutor", parametros, commandType: CommandType.StoredProcedure);  
        
        autor.IdAutor = parametros.Get<int>("unIdAutor");
    }

    public List<Autor> ObtenerAutores()
        => _conexion.Query<Autor>(_queryAutores).ToList();

    #endregion

    #region Usuario
    public void AltaUsuario(Usuario usuario)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unNombre", usuario.Nombre);
        parametros.Add("@unEmail", usuario.Email);
        parametros.Add("@unIdUsuario", direction: ParameterDirection.Output);

        _conexion.Execute("AltaUsuario", parametros, commandType: CommandType.StoredProcedure);  
    
        usuario.IdUsuario = parametros.Get<int>("unIdUsuario");
    }

    public List<Usuario> ObtenerUsuarios()
        => _conexion.Query<Usuario>(_queryUsuario).ToList();
    
    #endregion

    #region Libro
    public void AltaLibro(Libro libro)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unISBN", libro.ISBN);
        parametros.Add("@unTitulo", libro.Titulo);

        _conexion.Execute("AltaLibro", parametros, commandType: CommandType.StoredProcedure);  
    }

    public List<Libro> ObtenerLibro()
        => _conexion.Query<Libro>(_queryLibro).ToList();

    #endregion

    #region Prestamo
    public void AltaPrestamo(Prestamo prestamo)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdUsuario", prestamo.UsuarioPrestamo);
        parametros.Add("@ISBN", prestamo.LibroPrestamo);
        parametros.Add("@unIdPrestamo", direction: ParameterDirection.Output);

        _conexion.Execute("AltaPrestamo", parametros, commandType: CommandType.StoredProcedure);  
    
        prestamo.IdPrestamo = parametros.Get<int>("unIdPrestamo");
    }

    public List<Prestamo> ObtenerPrestamos()
        => _conexion.Query<Prestamo>(_queryPrestamo).ToList();

    #endregion
}