using Model.Entitie;
using Repository_Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_SqlServer;

public class UsuarioRepository: Repository, IUsuarioRepository
{
    public UsuarioRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public int Obten_Login(string Usu_Correo, string Usu_Clave)
    {
        using var oCmd = CreateCommand("SP_Usuario_Obten_Login");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Correo", Usu_Correo);
        oCmd.Parameters.AddWithValue("Usu_Clave", Usu_Clave);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        oDR.Read();

        return oDR.GetInt32(oDR.GetOrdinal("CANTIDAD"));
    }
    public Ent_Usuario Obten_x_Correo(string Usu_Correo)
    {
        using var oCmd = CreateCommand("SP_Usuario_Obten_x_Correo");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Correo", Usu_Correo);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Usuario
            {
                Usu_Correo = oDR.GetString(oDR.GetOrdinal("Usu_Correo")),
                Usu_NomApellidos = oDR.GetString(oDR.GetOrdinal("Usu_NomApellidos")),
                eRol = new()
                {
                    Rol_Nombre = oDR.GetString(oDR.GetOrdinal("Rol_Nombre")),
                },
                Usu_FecHoraRegistro = oDR.GetDateTime(oDR.GetOrdinal("Usu_FecHoraRegistro")),
                Usu_Estado = oDR.GetByte(oDR.GetOrdinal("Usu_Estado")) != 0 ? true : false,
            };
        }
        
        return null;
    }
    public Ent_Usuario Obten_Token_x_Correo(string Usu_Correo)
    {
        using var oCmd = CreateCommand("SP_Usuario_Obten_Token_x_Correo");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Correo", Usu_Correo);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Usuario
            {
                Usu_Correo = oDR.GetString(oDR.GetOrdinal("Usu_Correo")),
                Usu_NomApellidos = oDR.GetString(oDR.GetOrdinal("Usu_NomApellidos")),
                eRol = new()
                {
                    Rol_Nombre = oDR.GetString(oDR.GetOrdinal("Rol_Nombre")),
                },
                Usu_FecHoraRegistro = oDR.GetDateTime(oDR.GetOrdinal("Usu_FecHoraRegistro")),
                Usu_Estado = oDR.GetByte(oDR.GetOrdinal("Usu_Estado")) != 0 ? true : false,
                Usu_TokenActualizado = oDR.GetString(oDR.GetOrdinal("Usu_TokenActualizado")),
                Usu_FecHoraTokenActualizado = oDR.GetDateTime(oDR.GetOrdinal("Usu_FecHoraTokenActualizado")),
            };
        }

        return null;
    }

    public bool Actualiza_Token(Ent_Usuario Usuario)
    {
        using var oCmd = CreateCommand("SP_Usuario_Actualiza_Token");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_TokenActualizado", Usuario.Usu_TokenActualizado);
        oCmd.Parameters.AddWithValue("Usu_FecHoraTokenActualizado", Usuario.Usu_FecHoraTokenActualizado);
        oCmd.Parameters.AddWithValue("Usu_Correo", Usuario.Usu_Correo);

        return oCmd.ExecuteNonQuery() > 0 ? true : false;
    }

    public (int, int, bool, bool, IEnumerable<Ent_Usuario>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorNombre)
    {
        var Lst_Ent_Usuario = new List<Ent_Usuario>();

        using var oCmd = CreateCommand("SP_Usuario_Obten_Paginado");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("RegistroPagina", RegistroPagina);
        oCmd.Parameters.AddWithValue("NumeroPagina", NumeroPagina);
        oCmd.Parameters.AddWithValue("PorNombre", PorNombre != null ? (object)PorNombre : DBNull.Value);
        oCmd.Parameters.AddWithValue("TotalPagina", 0).Direction = ParameterDirection.Output;
        oCmd.Parameters.AddWithValue("TotalRegistro", 0).Direction = ParameterDirection.Output;
        oCmd.Parameters.AddWithValue("TienePaginaAnterior", 0).Direction = ParameterDirection.Output;
        oCmd.Parameters.AddWithValue("TienePaginaProximo", 0).Direction = ParameterDirection.Output;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Ent_Usuario.Add(new Ent_Usuario
            {
                Usu_Id = oDR.GetInt32(oDR.GetOrdinal("Usu_Id")),
                Usu_Correo = oDR.GetString(oDR.GetOrdinal("Usu_Correo")),
                Usu_NomApellidos = oDR.GetString(oDR.GetOrdinal("Usu_NomApellidos")),
                eRol = new()
                {
                    Rol_Nombre = oDR.GetString(oDR.GetOrdinal("Rol_Nombre")),

                },
                Usu_FecHoraRegistro = oDR.GetDateTime(oDR.GetOrdinal("Usu_FecHoraRegistro")),
                Usu_Observacion = oDR.IsDBNull(oDR.GetOrdinal("Usu_Observacion")) ? "" : oDR.GetString(oDR.GetOrdinal("Usu_Observacion")),
                Usu_Estado = oDR.GetByte(oDR.GetOrdinal("Usu_Estado")) != 0 ? true : false,
            });

        oDR.NextResult();

        return (Convert.ToInt32(oCmd.Parameters["TotalPagina"].Value),
            Convert.ToInt32(oCmd.Parameters["TotalRegistro"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaAnterior"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaProximo"].Value),
            Lst_Ent_Usuario);
    }
    public Ent_Usuario Obten_x_Id(int Usu_Id)
    {
        using var oCmd = CreateCommand("SP_Usuario_Obten_x_Id");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Id", Usu_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Usuario
            {
                Usu_Id = oDR.GetInt32(oDR.GetOrdinal("Usu_Id")),
                Usu_Correo = oDR.GetString(oDR.GetOrdinal("Usu_Correo")),
                Usu_NomApellidos = oDR.GetString(oDR.GetOrdinal("Usu_NomApellidos")),
                eRol = new()
                {
                    Rol_Nombre = oDR.GetString(oDR.GetOrdinal("Rol_Nombre")),
                },
                Usu_FecHoraRegistro = oDR.GetDateTime(oDR.GetOrdinal("Usu_FecHoraRegistro")),
                Usu_Estado = oDR.GetByte(oDR.GetOrdinal("Usu_Estado")) != 0 ? true : false,
            };
        }

        return null;
    }
    public int Existe(string Usu_Correo, bool Usu_Estado)
    {
        using var oCmd = CreateCommand("SP_Usuario_Existe");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Correo", Usu_Correo);
        oCmd.Parameters.AddWithValue("Usu_Estado", Usu_Estado);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        oDR.Read();

        return oDR.GetInt32(oDR.GetOrdinal("CANTIDAD"));
    }
    public int Crea(Ent_Usuario Ent_Usuario)
    {
        using var oCmd = CreateCommand("SP_Usuario_Crea");

        oCmd.CommandType = CommandType.StoredProcedure;
        
        oCmd.Parameters.AddWithValue("Usu_Correo", Ent_Usuario.Usu_Correo);
        oCmd.Parameters.AddWithValue("Usu_Clave", Ent_Usuario.Usu_Clave);
        oCmd.Parameters.AddWithValue("Usu_NomApellidos", Ent_Usuario.Usu_NomApellidos);
        oCmd.Parameters.AddWithValue("Rol_Nombre", Ent_Usuario.eRol.Rol_Nombre);

        // Parámetro de salida para el ID 
        var IdParam = new SqlParameter
        {
            ParameterName = "@Usu_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(IdParam);

        oCmd.ExecuteNonQuery();

        // Obtener el valor del parámetro de salida ID
        int Id = Convert.ToInt32(IdParam.Value);

        return Id;
    }
    public int Existente(int Usu_Id, string Usu_Correo, bool Usu_Estado)
    {
        using var oCmd = CreateCommand("SP_Usuario_Existente");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Id", Usu_Id);
        oCmd.Parameters.AddWithValue("Usu_Correo", Usu_Correo);
        oCmd.Parameters.AddWithValue("Usu_Estado", Usu_Estado);

        return Convert.ToInt32(oCmd.ExecuteScalar());
    }
    public int Actualiza(Ent_Usuario Ent_Usuario)
    {
        using var oCmd = CreateCommand("SP_Usuario_Actualiza");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Id", Ent_Usuario.Usu_Id);
        oCmd.Parameters.AddWithValue("Usu_Correo", Ent_Usuario.Usu_Correo);
        oCmd.Parameters.AddWithValue("Usu_Clave", Ent_Usuario.Usu_Clave);
        oCmd.Parameters.AddWithValue("Usu_NomApellidos", Ent_Usuario.Usu_NomApellidos);
        oCmd.Parameters.AddWithValue("Rol_Nombre", Ent_Usuario.eRol.Rol_Nombre);
        oCmd.Parameters.AddWithValue("Usu_Observacion", Ent_Usuario.Usu_Observacion);

        return oCmd.ExecuteNonQuery();
    }
    public int Actualiza_Condicion(int Usu_Id, bool Usu_Estado)
    {
        using var oCmd = CreateCommand("SP_Usuario_Actualiza_Estado");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_Id", Usu_Id);
        oCmd.Parameters.AddWithValue("Usu_Estado", Usu_Estado);
        return oCmd.ExecuteNonQuery();
    }
}

