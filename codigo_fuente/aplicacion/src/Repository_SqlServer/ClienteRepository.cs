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

public class ClienteRepository: Repository, IClienteRepository
{
    public ClienteRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public (int, int, bool, bool, IEnumerable<Ent_Cliente>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre)
    {
        var Lst_Ent_Cliente = new List<Ent_Cliente>();

        using var oCmd = CreateCommand("SP_Cliente_Obten_Paginado");

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
            Lst_Ent_Cliente.Add(new Ent_Cliente
            {
                Cli_Id = oDR.GetInt32(oDR.GetOrdinal("Cli_Id")),
                Cli_NomApeRazSocial = oDR.GetString(oDR.GetOrdinal("Cli_NomApeRazSocial")),
                Cli_Abreviatura = oDR.GetString(oDR.GetOrdinal("Cli_Abreviatura")),
                eTipo_Documento = new()
                {
                    TipDoc_Nombre = oDR.GetString(oDR.GetOrdinal("TipDoc_Nombre")),
                        
                },
                Cli_NumDocumento = oDR.GetString(oDR.GetOrdinal("Cli_NumDocumento")),
                Cli_Estado = oDR.GetByte(oDR.GetOrdinal("Cli_Estado")) != 0 ? true : false,
            });

        oDR.NextResult();

        return (Convert.ToInt32(oCmd.Parameters["TotalPagina"].Value),
            Convert.ToInt32(oCmd.Parameters["TotalRegistro"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaAnterior"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaProximo"].Value),
            Lst_Ent_Cliente);
    }
    public IEnumerable<Ent_Cliente> Obten_Nombre()
    {
        var Lst_Cliente = new List<Ent_Cliente>();

        using var oCmd = CreateCommand("SP_Cliente_Obten_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Cliente.Add(new Ent_Cliente
            {
                Cli_NomApeRazSocial = oDR.GetString(oDR.GetOrdinal("Cli_NomApeRazSocial"))
            });
        return Lst_Cliente;
    }
    public IEnumerable<Ent_Cliente> Obten_x_Nombre(string Cli_NomApeRazSocial)
    {
        var Lst_Cliente = new List<Ent_Cliente>();

        using var oCmd = CreateCommand("SP_Cliente_Obten_x_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Cli_NomApeRazSocial", Cli_NomApeRazSocial);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        while (oDR.Read())
            Lst_Cliente.Add(new Ent_Cliente
            {
                Cli_NomApeRazSocial = oDR.GetString(oDR.GetOrdinal("Cli_NomApeRazSocial"))
            });
        return Lst_Cliente;
    }
    public Ent_Cliente Obten_x_Id(int Cli_Id)
    {
        using var oCmd = CreateCommand("SP_Cliente_Obten_x_Id");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Cli_Id", Cli_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Cliente
            {
                Cli_Id = oDR.GetInt32(oDR.GetOrdinal("Cli_Id")),
                Cli_NomApeRazSocial = oDR.GetString(oDR.GetOrdinal("Cli_NomApeRazSocial")),
                Cli_Abreviatura = oDR.GetString(oDR.GetOrdinal("Cli_Abreviatura")),
                eTipo_Documento = new()
                {
                    TipDoc_Nombre = oDR.GetString(oDR.GetOrdinal("TipDoc_Nombre")),
                },
                Cli_NumDocumento = oDR.GetString(oDR.GetOrdinal("Cli_NumDocumento")),
                Cli_Estado = oDR.GetByte(oDR.GetOrdinal("Cli_Estado")) != 0 ? true : false,
            };
        }

        return null;
    }
    public int Existe(string Cli_NumDocumento, bool Cli_Estado)
    {
        using var oCmd = CreateCommand("SP_Cliente_Existe");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Cli_NumDocumento", Cli_NumDocumento);
        oCmd.Parameters.AddWithValue("Cli_Estado", Cli_Estado);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        oDR.Read();

        return oDR.GetInt32(oDR.GetOrdinal("CANTIDAD"));
    }
    //public int Crea(Ent_Cliente Ent_Cliente)
    //{
    //    using var oCmd = CreateCommand("SP_Cliente_Crea");

    //    oCmd.CommandType = CommandType.StoredProcedure;

    //    oCmd.Parameters.AddWithValue("Cli_NomApeRazSocial", Ent_Cliente.Cli_NomApeRazSocial);
    //    oCmd.Parameters.AddWithValue("Cli_Abreviatura", Ent_Cliente.Cli_Abreviatura);
    //    oCmd.Parameters.AddWithValue("TipDoc_Nombre", Ent_Cliente.eTipo_Documento.TipDoc_Nombre);
    //    oCmd.Parameters.AddWithValue("Cli_NumDocumento", Ent_Cliente.Cli_NumDocumento);
    //    oCmd.Parameters.AddWithValue("Cli_Id", 0).Direction = ParameterDirection.Output;

    //    if (oCmd.ExecuteNonQuery() > 0)
    //        return Convert.ToInt32(oCmd.Parameters["Cli_Id"].Value);
    //    return 0;
    //}
    public int Crea(Ent_Cliente Ent_Cliente)
    {
        using var oCmd = CreateCommand("SP_Cliente_Crea");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Cli_NomApeRazSocial", Ent_Cliente.Cli_NomApeRazSocial);
        oCmd.Parameters.AddWithValue("Cli_Abreviatura", Ent_Cliente.Cli_Abreviatura);
        oCmd.Parameters.AddWithValue("TipDoc_Nombre", Ent_Cliente.eTipo_Documento.TipDoc_Nombre);
        oCmd.Parameters.AddWithValue("Cli_NumDocumento", Ent_Cliente.Cli_NumDocumento);

        // Parámetro de salida para el ID del cliente
        var cliIdParam = new SqlParameter
        {
            ParameterName = "@Cli_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(cliIdParam);

        oCmd.ExecuteNonQuery();

        // Obtener el valor del parámetro de salida Cli_Id
        int cliId = Convert.ToInt32(cliIdParam.Value);

        return cliId;
    }
    public int Existente(int Cli_Id, string Cli_NumDocumento, bool Cli_Estado)
    {
        using var oCmd = CreateCommand("SP_Cliente_Existente");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Cli_Id", Cli_Id);
        oCmd.Parameters.AddWithValue("Cli_NumDocumento", Cli_NumDocumento);
        oCmd.Parameters.AddWithValue("Cli_Estado", Cli_Estado);

        return Convert.ToInt32(oCmd.ExecuteScalar());
    }
    public int Actualiza(Ent_Cliente Ent_Cliente)
    {
        using var oCmd = CreateCommand("SP_Cliente_Actualiza");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Cli_Id", Ent_Cliente.Cli_Id);
        oCmd.Parameters.AddWithValue("Cli_NomApeRazSocial", Ent_Cliente.Cli_NomApeRazSocial);
        oCmd.Parameters.AddWithValue("Cli_Abreviatura", Ent_Cliente.Cli_Abreviatura);
        oCmd.Parameters.AddWithValue("TipDoc_Nombre", Ent_Cliente.eTipo_Documento.TipDoc_Nombre);
        oCmd.Parameters.AddWithValue("Cli_NumDocumento", Ent_Cliente.Cli_NumDocumento);

        return oCmd.ExecuteNonQuery();
    }
    //public int Actualiza(int Cli_Id, Ent_Cliente Ent_Cliente)
    //{
    //    using var oCmd = CreateCommand("SP_Cliente_Actualiza");

    //    oCmd.CommandType = CommandType.StoredProcedure;

    //    oCmd.Parameters.AddWithValue("Cli_Id", Cli_Id);
    //    oCmd.Parameters.AddWithValue("Cli_NomApeRazSocial", Ent_Cliente.Cli_NomApeRazSocial);
    //    oCmd.Parameters.AddWithValue("Cli_Abreviatura", Ent_Cliente.Cli_Abreviatura);
    //    oCmd.Parameters.AddWithValue("TipDoc_Nombre", Ent_Cliente.eTipo_Documento.TipDoc_Nombre);
    //    oCmd.Parameters.AddWithValue("Cli_NumDocumento", Ent_Cliente.Cli_NumDocumento);

    //    int CantidadAfectado = oCmd.ExecuteNonQuery();

    //    return CantidadAfectado;
    //    //return oCmd.ExecuteNonQuery();
    //}


    public int Actualiza_Condicion(int Cli_Id, bool Cli_Estado)
    {
        using var oCmd = CreateCommand("SP_Cliente_Actualiza_Estado");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Cli_Id", Cli_Id);
        oCmd.Parameters.AddWithValue("Cli_Estado", Cli_Estado);
        return oCmd.ExecuteNonQuery();
    }
}

