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
    //public IEnumerable<Ent_Partida> Obten_x_Presupuesto(int Pre_Id)
    //{
    //    var Lst_Partida = new List<Ent_Partida>();

    //    using var oCmd = CreateCommand("SP_Partida_SubPresupuesto_Obten_x_Presupuesto_v4");
    //    oCmd.CommandType = CommandType.StoredProcedure;
    //    oCmd.Parameters.AddWithValue("Pre_Id", Pre_Id);

    //    using var oDR = oCmd.ExecuteReader();

    //    while (oDR.Read())
    //    {
    //        var Partida = new Ent_Partida
    //        {
    //            eSubPresupuesto = new()
    //            {
    //                // Para SubPre_Id (int en lugar de int?)
    //                SubPre_Id = oDR.IsDBNull(oDR.GetOrdinal("SubPre_Id")) ?
    //                           0 : // Valor por defecto cuando es NULL
    //                           oDR.GetInt32(oDR.GetOrdinal("SubPre_Id")),

    //                SubPre_Nombre = oDR.IsDBNull(oDR.GetOrdinal("SubPre_Nombre")) ?
    //                               null :
    //                               oDR.GetString(oDR.GetOrdinal("SubPre_Nombre")),

    //                SubPre_Nivel = oDR.GetInt32(oDR.GetOrdinal("Nivel")),
    //                SubPre_Orden = oDR.GetInt32(oDR.GetOrdinal("Orden")),
    //                SubPre_Ruta = oDR.GetString(oDR.GetOrdinal("Ruta")),
    //                SubPre_TieneHijos = oDR.GetByte(oDR.GetOrdinal("TieneHijos")) != 0,

    //                ePresupuesto = new()
    //                {
    //                    // Para Pre_Id (int en lugar de int?)
    //                    Pre_Id = oDR.IsDBNull(oDR.GetOrdinal("Pre_Id")) ?
    //                             0 : // Valor por defecto cuando es NULL
    //                             oDR.GetInt32(oDR.GetOrdinal("Pre_Id"))
    //                },
    //            },

    //            // Para Par_Id (int en lugar de int?)
    //            Par_Id = oDR.IsDBNull(oDR.GetOrdinal("Par_Id")) ?
    //                     0 : // Valor por defecto cuando es NULL
    //                     oDR.GetInt32(oDR.GetOrdinal("Par_Id")),

    //            Par_Nombre = oDR.IsDBNull(oDR.GetOrdinal("Par_Nombre")) ?
    //                         null :
    //                         oDR.GetString(oDR.GetOrdinal("Par_Nombre")),
    //        };

    //        // Para SubPre_Padre_Id (ya que parece aceptar int?)
    //        int padreIdOrdinal = oDR.GetOrdinal("SubPre_Padre_Id");
    //        Partida.eSubPresupuesto.Padre_Id = oDR.IsDBNull(padreIdOrdinal) ?
    //                                 (int?)null :
    //                                 oDR.GetInt32(padreIdOrdinal);

    //        Lst_Partida.Add(Partida);
    //    }

    //    return Lst_Partida;
    //}

}

