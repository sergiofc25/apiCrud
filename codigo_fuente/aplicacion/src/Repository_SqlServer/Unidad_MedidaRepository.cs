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

public class Unidad_MedidaRepository: Repository, IUnidad_MedidaRepository
{
    public Unidad_MedidaRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }


    public IEnumerable<Ent_Unidad_Medida> Obten()
    {
        var Lst_Unidad_Medida = new List<Ent_Unidad_Medida>();

        using var oCmd = CreateCommand("SP_Unidad_Medida_Obten_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Unidad_Medida.Add(new Ent_Unidad_Medida
            {
                UniMed_Nombre = oDR.GetString(oDR.GetOrdinal("UniMed_Nombre")),
                UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura"))
            });
        return Lst_Unidad_Medida;
    }

}

