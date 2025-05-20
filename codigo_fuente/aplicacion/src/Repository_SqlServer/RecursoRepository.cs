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

public class RecursoRepository: Repository, IRecursoRepository
{
    public RecursoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public IEnumerable<Ent_Recurso> Obten_x_Partida(int Par_Id)
    {
        var Lst_Recurso = new List<Ent_Recurso>();

        using var oCmd = CreateCommand("SP_Recurso_Obten_x_Partida");
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("Par_Id", Par_Id);

        using var oDR = oCmd.ExecuteReader();

        while (oDR.Read())
        {
            var Recurso = new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eTipo_Recurso = new()
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
                eUnidad_Medida = new()
                {
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura"))
                },
                // Asignar PartidaRecurso sólo si hay datos
                ePartida_Recurso = new Ent_Partida_Recurso
                {
                    Rec_Cantidad = oDR.IsDBNull(oDR.GetOrdinal("Rec_Cantidad")) ? null : oDR.GetDecimal(oDR.GetOrdinal("Rec_Cantidad")),
                    Rec_Cuadrilla = oDR.IsDBNull(oDR.GetOrdinal("Rec_Cuadrilla")) ? null : oDR.GetDecimal(oDR.GetOrdinal("Rec_Cuadrilla")),
                    DetParRec_Precio_HM = oDR.IsDBNull(oDR.GetOrdinal("DetParRec_Precio_HM")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DetParRec_Precio_HM")),
                    DetParRec_PrecioUnitario = oDR.IsDBNull(oDR.GetOrdinal("DetParRec_PrecioUnitario")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DetParRec_PrecioUnitario"))
                },

                // Asignar RecursoPresupuesto sólo si hay datos
                eRecurso_Presupuesto = new Ent_Recurso_Presupuesto
                {
                    DRP_Precio = oDR.IsDBNull(oDR.GetOrdinal("DRP_Precio")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DRP_Precio"))
                }
            };

            Lst_Recurso.Add(Recurso);
        }

        return Lst_Recurso;
    }
    public int Crea_APU(Ent_Recurso Ent_Recurso)
    {
        using var oCmd = CreateCommand("SP_Recurso_Crea_APU");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Par_Id", Ent_Recurso.ePartida_Recurso.ePartida.Par_Id);
        oCmd.Parameters.AddWithValue("Rec_Id", Ent_Recurso.ePartida_Recurso.eRecurso.Rec_Id);
        if (Ent_Recurso.ePartida_Recurso.Rec_Cantidad.HasValue)
        {
            oCmd.Parameters.AddWithValue("Rec_Cantidad", Ent_Recurso.ePartida_Recurso.Rec_Cantidad);
        }
        if (Ent_Recurso.ePartida_Recurso.Rec_Cuadrilla.HasValue)
        {
            oCmd.Parameters.AddWithValue("@Rec_Cuadrilla", Ent_Recurso.ePartida_Recurso.Rec_Cuadrilla);
        }
        if (Ent_Recurso.eRecurso_Presupuesto.DRP_Precio.HasValue)
        {
            oCmd.Parameters.AddWithValue("DRP_Precio", Ent_Recurso.eRecurso_Presupuesto.DRP_Precio);
        }

        var DetParRec_IdParam = new SqlParameter
        {
            ParameterName = "@DetParRec_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(DetParRec_IdParam);

        oCmd.ExecuteNonQuery();

        int DetParRec_Id = Convert.ToInt32(DetParRec_IdParam.Value);

        return DetParRec_Id;
    }
    public IEnumerable<Ent_Recurso> Obten()
    {
        var Lst_Recurso = new List<Ent_Recurso>();

        using var oCmd = CreateCommand("SP_Recurso_Obten");

        oCmd.CommandType = CommandType.StoredProcedure;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Recurso.Add(new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eUnidad_Medida = new Ent_Unidad_Medida
                {
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura"))
                },
                eTipo_Recurso = new Ent_Tipo_Recurso
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
            });
        return Lst_Recurso;
    }
    public IEnumerable<Ent_Recurso> Obten_Precio_x_Partida(int Par_Id)
    {
        var Lst_Recurso = new List<Ent_Recurso>();

        using var oCmd = CreateCommand("SP_Recurso_Obten_Precio_x_Partida");

        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("Par_Id", Par_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Recurso.Add(new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eUnidad_Medida = new Ent_Unidad_Medida
                {
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura"))
                },
                eTipo_Recurso = new Ent_Tipo_Recurso
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
                eRecurso_Presupuesto= new Ent_Recurso_Presupuesto
                {
                    DRP_Precio = oDR.IsDBNull(oDR.GetOrdinal("DRP_Precio")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DRP_Precio"))
                }
            });
        return Lst_Recurso;
    }
}

