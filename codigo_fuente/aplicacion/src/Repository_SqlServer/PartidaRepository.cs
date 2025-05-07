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

public class PartidaRepository: Repository, IPartidaRepository
{
    public PartidaRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public IEnumerable<Ent_Partida> Obten_x_SubPresupuesto(int SubPre_Id)
    {
        var Lst_Partida = new List<Ent_Partida>();

        using var oCmd = CreateCommand("SP_Partida_Obten_x_SubPresupuesto");
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("SubPre_Id", SubPre_Id);

        using var oDR = oCmd.ExecuteReader();

        while (oDR.Read())
        {
            var partida = new Ent_Partida
            {
                Par_Id = oDR.GetInt32(oDR.GetOrdinal("Par_Id")),
                Par_Ruta = oDR.GetString(oDR.GetOrdinal("Par_Ruta")),
                eSubPresupuesto = new()
                {
                    SubPre_Id = oDR.GetInt32(oDR.GetOrdinal("SubPre_Id")),
                },

                Par_Nombre = oDR.GetString(oDR.GetOrdinal("Par_Nombre")),
                Par_RenManObra = oDR.GetDecimal(oDR.GetOrdinal("Par_RenManObra")),
                Par_RenEquipo = oDR.GetDecimal(oDR.GetOrdinal("Par_RenEquipo")),
                eUnidad_Medida = new()
                {
                    UniMed_Nombre = oDR.GetString(oDR.GetOrdinal("UniMed_Nombre"))
                },
                Par_Estado = oDR.GetByte(oDR.GetOrdinal("Par_Estado")) != 0 ? true : false
            };

            Lst_Partida.Add(partida);
        }

        return Lst_Partida;
    }
    public Ent_Partida Obten_x_Id(int Par_Id)
    {
        using var oCmd = CreateCommand("SP_Partida_Obten_x_Id");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Par_Id", Par_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Partida
            {
                Par_Id = oDR.GetInt32(oDR.GetOrdinal("Par_Id")),
                Par_Nombre = oDR.GetString(oDR.GetOrdinal("Par_Nombre")),
                Par_RenEquipo = oDR.GetDecimal(oDR.GetOrdinal("Par_RenEquipo")),
                Par_RenManObra = oDR.GetDecimal(oDR.GetOrdinal("Par_RenManObra")),
                eUnidad_Medida = new()
                {
                    UniMed_Nombre = oDR.GetString(oDR.GetOrdinal("UniMed_Nombre")),
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura")),
                },
                eSubPresupuesto = new()
                {
                    SubPre_Id = oDR.GetInt32(oDR.GetOrdinal("SubPre_Id")),
                },
                Par_Estado = oDR.GetByte(oDR.GetOrdinal("Par_Estado")) != 0 ? true : false,
            };
        }

        return null;
    }
    public int Crea(Ent_Partida Ent_Partida)
    {
        using var oCmd = CreateCommand("SP_Partida_Crea");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Par_Nombre", Ent_Partida.Par_Nombre);
        oCmd.Parameters.AddWithValue("Par_RenManObra", Ent_Partida.Par_RenManObra);
        oCmd.Parameters.AddWithValue("Par_RenEquipo", Ent_Partida.Par_RenEquipo);
        oCmd.Parameters.AddWithValue("UniMed_Nombre", Ent_Partida.eUnidad_Medida.UniMed_Nombre);
        oCmd.Parameters.AddWithValue("SubPre_Id", Ent_Partida.eSubPresupuesto.SubPre_Id);

        var parIdParam = new SqlParameter
        {
            ParameterName = "@Par_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(parIdParam);

        oCmd.ExecuteNonQuery();

        int parId = Convert.ToInt32(parIdParam.Value);

        return parId;
    }
    public int Actualiza(Ent_Partida Ent_Partida)
    {
        using var oCmd = CreateCommand("SP_Partida_Actualiza");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Par_Id", Ent_Partida.Par_Id);
        oCmd.Parameters.AddWithValue("Par_Nombre", Ent_Partida.Par_Nombre);
        oCmd.Parameters.AddWithValue("Par_RenManObra", Ent_Partida.Par_RenManObra);
        oCmd.Parameters.AddWithValue("Par_RenEquipo", Ent_Partida.Par_RenEquipo);
        oCmd.Parameters.AddWithValue("UniMed_Nombre", Ent_Partida.eUnidad_Medida.UniMed_Nombre);
        oCmd.Parameters.AddWithValue("Par_Estado", Ent_Partida.Par_Estado);
        return oCmd.ExecuteNonQuery();
    }
    public int Inhabilita(int Par_Id, bool Par_Estado)
    {
        using var oCmd = CreateCommand("SP_Partida_Inhabilita");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Par_Id", Par_Id);
        oCmd.Parameters.AddWithValue("Par_Estado", Par_Estado);
        return oCmd.ExecuteNonQuery();
    }
}

