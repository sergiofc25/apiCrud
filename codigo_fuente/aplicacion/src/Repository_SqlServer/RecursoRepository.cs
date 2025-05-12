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
                //ePartida_Recurso = new()
                //{
                //    Rec_Cuadrilla = oDR.GetDecimal(oDR.GetOrdinal("Rec_Cuadrilla")),
                //    Rec_Cantidad = oDR.GetDecimal(oDR.GetOrdinal("Rec_Cantidad")),
                //    DetParRec_Precio_HM = oDR.GetDecimal(oDR.GetOrdinal("DetParRec_Precio_HM")),
                //    DetParRec_PrecioUnitario = oDR.GetDecimal(oDR.GetOrdinal("DetParRec_PrecioUnitario")),
                //},
                //eRecurso_Presupuesto = new()
                //{
                //    DRP_Precio = oDR.GetDecimal(oDR.GetOrdinal("DRP_Precio")),
                //}
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
    
}

