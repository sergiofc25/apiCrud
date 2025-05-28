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

public class Partida_RecursoRepository: Repository, IPartida_RecursoRepository
{
    public Partida_RecursoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }
    public int Elimina_APU(int DetParRec_Id)
    {
        using var oCmd = CreateCommand("SP_Partida_Recurso_Elimina_APU");
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("DetParRec_Id", DetParRec_Id);

        var returnParam = oCmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
        returnParam.Direction = ParameterDirection.ReturnValue;

        try
        {
            oCmd.ExecuteNonQuery();
            return (int)returnParam.Value;
        }
        catch (SqlException ex)
        {
            throw new Exception("Error al eliminar Partida_Recurso_APU: " + ex.Message);
        }
    }
    public Ent_Partida_Recurso Obten_x_Id_APU(int DetParRec_Id)
    {
        using var oCmd = CreateCommand("SP_Partida_Recurso_Obten_x_Id_APU");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("DetParRec_Id", DetParRec_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Partida_Recurso
            {
                DetParRec_Id = oDR.GetInt32(oDR.GetOrdinal("DetParRec_Id")),
                Rec_Cantidad = oDR.IsDBNull(oDR.GetOrdinal("Rec_Cantidad")) ? null : oDR.GetDecimal(oDR.GetOrdinal("Rec_Cantidad")),
                Rec_Cuadrilla = oDR.IsDBNull(oDR.GetOrdinal("Rec_Cuadrilla")) ? null : oDR.GetDecimal(oDR.GetOrdinal("Rec_Cuadrilla")),
                eRecurso = new Ent_Recurso
                {
                    eRecurso_Presupuesto = new Ent_Recurso_Presupuesto
                    {
                        DRP_Precio = oDR.IsDBNull(oDR.GetOrdinal("DRP_Precio")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DRP_Precio")),
                    },
                    Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                    eTipo_Recurso = new Ent_Tipo_Recurso
                    {
                        TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre")),
                    },
                },
            };
        }
        return null;
    }
    public int Actualiza_APU(Ent_Partida_Recurso Ent_Partida_Recurso)
    {
        using var oCmd = CreateCommand("SP_Recurso_Actualiza_APU");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("DetParRec_Id", Ent_Partida_Recurso.DetParRec_Id);
        if (Ent_Partida_Recurso.Rec_Cantidad.HasValue)
        {
            oCmd.Parameters.AddWithValue("Rec_Cantidad", Ent_Partida_Recurso.Rec_Cantidad);
        }
        if (Ent_Partida_Recurso.Rec_Cuadrilla.HasValue)
        {
            oCmd.Parameters.AddWithValue("Rec_Cuadrilla", Ent_Partida_Recurso.Rec_Cuadrilla);
        }
        if (Ent_Partida_Recurso.eRecurso.eRecurso_Presupuesto.DRP_Precio.HasValue)
        {
            oCmd.Parameters.AddWithValue("DRP_Precio", Ent_Partida_Recurso.eRecurso.eRecurso_Presupuesto.DRP_Precio);
        }

        return oCmd.ExecuteNonQuery();
    }
}

