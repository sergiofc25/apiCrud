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

public class SubPresupuestoRepository: Repository, ISubPresupuestoRepository
{
    public SubPresupuestoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public IEnumerable<Ent_SubPresupuesto> Obten_x_Presupuesto(int Pre_Id)
    {
        var Lst_SubPresupuesto = new List<Ent_SubPresupuesto>();

        using var oCmd = CreateCommand("SP_SubPresupuesto_Obten_x_Presupuesto");
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("Pre_Id", Pre_Id);

        using var oDR = oCmd.ExecuteReader();

        while (oDR.Read())
        {
            var subPresupuesto = new Ent_SubPresupuesto
            {
                SubPre_Id = oDR.GetInt32(oDR.GetOrdinal("SubPre_Id")),
                ePresupuesto = new()
                {
                    Pre_Id = oDR.GetInt32(oDR.GetOrdinal("Pre_Id"))
                },
                SubPre_Nombre = oDR.GetString(oDR.GetOrdinal("SubPre_Nombre")),
                SubPre_Nivel = oDR.GetInt32(oDR.GetOrdinal("SubPre_Nivel")),
                SubPre_Orden = oDR.GetInt32(oDR.GetOrdinal("SubPre_Orden")),
                SubPre_Ruta = oDR.GetString(oDR.GetOrdinal("SubPre_Ruta")),
                SubPre_TieneHijos = oDR.GetByte(oDR.GetOrdinal("SubPre_TieneHijos")) != 0 ? true : false
            };
            int padreIdOrdinal = oDR.GetOrdinal("Padre_Id");
            subPresupuesto.Padre_Id = oDR.IsDBNull(padreIdOrdinal) ?
                                     (int?)null :
                                     oDR.GetInt32(padreIdOrdinal);

            Lst_SubPresupuesto.Add(subPresupuesto);
        }

        return Lst_SubPresupuesto;
    }
    public Ent_SubPresupuesto Obten_x_Id(int SubPre_Id)
    {
        using var oCmd = CreateCommand("SP_SubPresupuesto_Obten_x_Id");

        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("SubPre_Id", SubPre_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_SubPresupuesto
            {
                SubPre_Id = oDR.GetInt32(oDR.GetOrdinal("SubPre_Id")),
                
                ePresupuesto = new()
                {
                    Pre_Id = oDR.GetInt32(oDR.GetOrdinal("Pre_Id")),
                    Pre_Nombre = oDR.GetString(oDR.GetOrdinal("Pre_Nombre")),
                },
                // Modificación para manejar valores nulos
                Padre_Id = oDR.IsDBNull(oDR.GetOrdinal("Padre_Id")) ?
                          null :
                          (int?)oDR.GetInt32(oDR.GetOrdinal("Padre_Id")),
                SubPre_Nombre = oDR.GetString(oDR.GetOrdinal("SubPre_Nombre")),
                SubPre_Nivel = oDR.GetInt32(oDR.GetOrdinal("SubPre_Nivel")),
                SubPre_Orden = oDR.GetInt32(oDR.GetOrdinal("SubPre_Orden")),
                SubPre_Ruta = oDR.GetString(oDR.GetOrdinal("SubPre_Ruta")),
                SubPre_TieneHijos = oDR.GetByte(oDR.GetOrdinal("SubPre_TieneHijos")) != 0 ? true : false,
            };
        }

        return null;
    }
    public int Crea(Ent_SubPresupuesto Ent_SubPresupuesto)
    {
        using var oCmd = CreateCommand("SP_SubPresupuesto_Crea");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pre_Id", Ent_SubPresupuesto.ePresupuesto.Pre_Id);
        oCmd.Parameters.AddWithValue("Padre_Id", Ent_SubPresupuesto.Padre_Id);
        oCmd.Parameters.AddWithValue("SubPre_Nombre", Ent_SubPresupuesto.SubPre_Nombre);
        oCmd.Parameters.AddWithValue("SubPre_Nivel", Ent_SubPresupuesto.SubPre_Nivel);
        oCmd.Parameters.AddWithValue("SubPre_Orden", Ent_SubPresupuesto.SubPre_Orden);

        var subPreIdParam = new SqlParameter
        {
            ParameterName = "@SubPre_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(subPreIdParam);

        oCmd.ExecuteNonQuery();

        int subpreId = Convert.ToInt32(subPreIdParam.Value);

        return subpreId;
    }
    public int Crea_Dentro(int SubPre_Padre_Id, Ent_SubPresupuesto Ent_SubPresupuesto)
    {
        using var oCmd = CreateCommand("SP_SubPresupuesto_Crea_D");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("SubPre_Padre_Id", SubPre_Padre_Id);
        oCmd.Parameters.AddWithValue("SubPre_Nombre", Ent_SubPresupuesto.SubPre_Nombre);

        var subPreIdParam = new SqlParameter
        {
            ParameterName = "@SubPre_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(subPreIdParam);

        oCmd.ExecuteNonQuery();

        int subpreId = Convert.ToInt32(subPreIdParam.Value);

        return subpreId;
    }
    public int Crea_Primer_Nivel(int Pre_Id, Ent_SubPresupuesto Ent_SubPresupuesto)
    {
        using var oCmd = CreateCommand("SP_SubPresupuesto_Crea_Primer_Nivel");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pre_Id", Pre_Id);
        oCmd.Parameters.AddWithValue("SubPre_Nombre", Ent_SubPresupuesto.SubPre_Nombre);

        var subPreIdParam = new SqlParameter
        {
            ParameterName = "@SubPre_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(subPreIdParam);

        oCmd.ExecuteNonQuery();

        int subpreId = Convert.ToInt32(subPreIdParam.Value);

        return subpreId;
    }
    public int Actualiza_Nombre(Ent_SubPresupuesto Ent_SubPresupuesto)
    {
        using var oCmd = CreateCommand("SP_SubPresupuesto_Actualiza_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("SubPre_Id", Ent_SubPresupuesto.SubPre_Id);
        oCmd.Parameters.AddWithValue("SubPre_Nombre", Ent_SubPresupuesto.SubPre_Nombre);

        return oCmd.ExecuteNonQuery();
    }
    public int Elimina(int SubPre_Id)
    {
        using var oCmd = CreateCommand("SP_SubPresupuesto_Elimina_Seguro_v3");
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("SubPre_Id", SubPre_Id);

        var returnParam = oCmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
        returnParam.Direction = ParameterDirection.ReturnValue;

        try
        {
            oCmd.ExecuteNonQuery();
            return (int)returnParam.Value;
        }
        catch (SqlException ex)
        {
            throw new Exception("Error al eliminar subpresupuesto: " + ex.Message);
        }
    }
}

