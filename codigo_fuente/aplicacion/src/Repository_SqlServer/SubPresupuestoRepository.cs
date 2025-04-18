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


    //public IEnumerable<Ent_SubPresupuesto> Obten_x_Presupuesto(int Pre_Id)
    //{
    //    var Lst_SubPresupuesto = new List<Ent_SubPresupuesto>();

    //    using var oCmd = CreateCommand("SP_SubPresupuesto_Obten_x_Presupuesto");

    //    oCmd.CommandType = CommandType.StoredProcedure;

    //    oCmd.Parameters.AddWithValue("Pre_Id", Pre_Id);

    //    using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

    //    while (oDR.Read())
    //        Lst_SubPresupuesto.Add(new Ent_SubPresupuesto
    //        {
    //            SubPre_Id = oDR.GetInt32(oDR.GetOrdinal("SubPre_Id")),
    //            ePresupuesto = new()
    //            {
    //                Pre_Id = oDR.GetInt32(oDR.GetOrdinal("Pre_Id"))

    //            },
    //            Padre_Id = oDR.GetInt32(oDR.GetOrdinal("Padre_Id")),
    //            SubPre_Nombre = oDR.GetString(oDR.GetOrdinal("SubPre_Nombre")),
    //            SubPre_Nivel = oDR.GetInt32(oDR.GetOrdinal("SubPre_Nivel")),
    //            SubPre_Orden = oDR.GetInt32(oDR.GetOrdinal("SubPre_Orden")),
    //            SubPre_Ruta = oDR.GetString(oDR.GetOrdinal("SubPre_Ruta"))
    //        });
    //    return Lst_SubPresupuesto;
    //}
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
                SubPre_Ruta = oDR.GetString(oDR.GetOrdinal("SubPre_Ruta"))
            };

            // Manejo de Padre_Id nulo
            int padreIdOrdinal = oDR.GetOrdinal("Padre_Id");
            subPresupuesto.Padre_Id = oDR.IsDBNull(padreIdOrdinal) ?
                                     (int?)null :
                                     oDR.GetInt32(padreIdOrdinal);

            Lst_SubPresupuesto.Add(subPresupuesto);
        }

        return Lst_SubPresupuesto;
    }
}

