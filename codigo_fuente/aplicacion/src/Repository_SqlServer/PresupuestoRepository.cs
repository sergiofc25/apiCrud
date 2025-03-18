using Model.Entitie;
using Repository_Interface;
using System.Data;
using System.Data.SqlClient;

namespace Repository_SqlServer;

public class PresupuestoRepository: Repository, IPresupuestoRepository
{
    public PresupuestoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public (int, int, bool, bool, IEnumerable<Ent_Presupuesto>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorNombre)
    {
        var Lst_Ent_Presupuesto = new List<Ent_Presupuesto>();

        using var oCmd = CreateCommand("SP_Presupuesto_Obten_Paginado");

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

            Lst_Ent_Presupuesto.Add(new Ent_Presupuesto
            {
                Pre_Id = oDR.GetInt32(oDR.GetOrdinal("Pre_Id")),
                Pre_Codigo = oDR.IsDBNull(oDR.GetOrdinal("Pre_Codigo")) ? string.Empty : oDR.GetString(oDR.GetOrdinal("Pre_Codigo")),
                //Pre_Codigo = oDR.GetString(oDR.GetOrdinal("Pre_Codigo")),
                eUsuario = new()
                {
                    Usu_NomApellidos = oDR.GetString(oDR.GetOrdinal("Usu_NomApellidos")),

                },
                Pre_Nombre = oDR.GetString(oDR.GetOrdinal("Pre_Nombre")),
                eCliente = new()
                {
                    Cli_NomApeRazSocial = oDR.GetString(oDR.GetOrdinal("Cli_NomApeRazSocial")),

                },
                eUbicacion = new()
                {
                    Ubi_Departamento = oDR.GetString(oDR.GetOrdinal("Ubi_Departamento")),
                    Ubi_Provincia = oDR.GetString(oDR.GetOrdinal("Ubi_Provincia")),
                    Ubi_Distrito = oDR.GetString(oDR.GetOrdinal("Ubi_Distrito")),

                },
                Pre_Jornal = oDR.GetDecimal(oDR.GetOrdinal("Pre_Jornal")),
                Pre_FecHorRegistro = oDR.GetDateTime(oDR.GetOrdinal("Pre_FecHorRegistro")),
                Pre_Estado = oDR.GetByte(oDR.GetOrdinal("Pre_Estado")) != 0 ? true : false,
            });

        oDR.NextResult();

        return (Convert.ToInt32(oCmd.Parameters["TotalPagina"].Value),
            Convert.ToInt32(oCmd.Parameters["TotalRegistro"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaAnterior"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaProximo"].Value),
            Lst_Ent_Presupuesto);
    }



    public Ent_Presupuesto Obten_x_Id(int Pre_Id)
    {
        using var oCmd = CreateCommand("SP_Presupuesto_Obten_x_Id");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pre_Id", Pre_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Presupuesto
            {
                Pre_Id = oDR.GetInt32(oDR.GetOrdinal("Pre_Id")),
                Pre_Codigo = oDR.IsDBNull(oDR.GetOrdinal("Pre_Codigo"))
                ? string.Empty
                : oDR.GetString(oDR.GetOrdinal("Pre_Codigo")),
                eUsuario = new()
                {
                    Usu_NomApellidos = oDR.GetString(oDR.GetOrdinal("Usu_NomApellidos"))
                },
                Pre_Nombre = oDR.GetString(oDR.GetOrdinal("Pre_Nombre")),
                eCliente = new()
                {
                    Cli_NomApeRazSocial = oDR.GetString(oDR.GetOrdinal("Cli_NomApeRazSocial"))
                },
                eUbicacion = new()
                {
                    Ubi_Departamento = oDR.GetString(oDR.GetOrdinal("Ubi_Departamento")),
                    Ubi_Provincia = oDR.GetString(oDR.GetOrdinal("Ubi_Provincia")),
                    Ubi_Distrito = oDR.GetString(oDR.GetOrdinal("Ubi_Distrito"))
                },
                Pre_Jornal = oDR.GetDecimal(oDR.GetOrdinal("Pre_Jornal")),
                Pre_Estado = oDR.GetByte(oDR.GetOrdinal("Pre_Estado")) != 0 ? true : false,
            };
        }

        return null;
    }
    public int Existe(string Pre_Nombre, bool Pre_Estado)
    {
        using var oCmd = CreateCommand("SP_Presupuesto_Existe");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pre_Nombre", Pre_Nombre);
        oCmd.Parameters.AddWithValue("Pre_Estado", Pre_Estado);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        oDR.Read();

        return oDR.GetInt32(oDR.GetOrdinal("CANTIDAD"));
    }
    
    public int Crea(Ent_Presupuesto Ent_Presupuesto)
    {
        using var oCmd = CreateCommand("SP_Presupuesto_Crea");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Usu_NomApellidos", Ent_Presupuesto.eUsuario.Usu_NomApellidos);
        oCmd.Parameters.AddWithValue("Pre_Nombre", Ent_Presupuesto.Pre_Nombre);
        oCmd.Parameters.AddWithValue("Cli_NomApeRazSocial", Ent_Presupuesto.eCliente.Cli_NomApeRazSocial);
        oCmd.Parameters.AddWithValue("Ubi_Departamento", Ent_Presupuesto.eUbicacion.Ubi_Departamento);
        oCmd.Parameters.AddWithValue("Ubi_Provincia", Ent_Presupuesto.eUbicacion.Ubi_Provincia);
        oCmd.Parameters.AddWithValue("Ubi_Distrito", Ent_Presupuesto.eUbicacion.Ubi_Distrito);
        oCmd.Parameters.AddWithValue("Pre_Jornal", Ent_Presupuesto.Pre_Jornal);

        var preIdParam = new SqlParameter
        {
            ParameterName = "@Pre_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(preIdParam);

        oCmd.ExecuteNonQuery();

        int preId = Convert.ToInt32(preIdParam.Value);

        return preId;
    }
    public int Existente(int Pre_Id, string Pre_Nombre, bool Pre_Estado)
    {
        using var oCmd = CreateCommand("SP_Presupuesto_Existente");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pre_Id", Pre_Id);
        oCmd.Parameters.AddWithValue("Pre_Nombre", Pre_Nombre);
        oCmd.Parameters.AddWithValue("Pre_Estado", Pre_Estado);

        return Convert.ToInt32(oCmd.ExecuteScalar());
    }
    public int Actualiza(Ent_Presupuesto Ent_Presupuesto)
    {
        using var oCmd = CreateCommand("SP_Presupuesto_Actualiza");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pre_Id", Ent_Presupuesto.Pre_Id);
        oCmd.Parameters.AddWithValue("Usu_NomApellidos", Ent_Presupuesto.eUsuario.Usu_NomApellidos);
        oCmd.Parameters.AddWithValue("Pre_Nombre", Ent_Presupuesto.Pre_Nombre);
        oCmd.Parameters.AddWithValue("Cli_NomApeRazSocial", Ent_Presupuesto.eCliente.Cli_NomApeRazSocial);
        oCmd.Parameters.AddWithValue("Ubi_Departamento", Ent_Presupuesto.eUbicacion.Ubi_Departamento);
        oCmd.Parameters.AddWithValue("Ubi_Provincia", Ent_Presupuesto.eUbicacion.Ubi_Provincia);
        oCmd.Parameters.AddWithValue("Ubi_Distrito", Ent_Presupuesto.eUbicacion.Ubi_Distrito);
        oCmd.Parameters.AddWithValue("Pre_Jornal", Ent_Presupuesto.Pre_Jornal);

        return oCmd.ExecuteNonQuery();
    }


    public int Actualiza_Condicion(int Pre_Id, bool Pre_Estado)
    {
        using var oCmd = CreateCommand("SP_Presupuesto_Actualiza_Estado");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pre_Id", Pre_Id);
        oCmd.Parameters.AddWithValue("Pre_Estado", Pre_Estado);
        return oCmd.ExecuteNonQuery();
    }
}

