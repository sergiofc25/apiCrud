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

public class ProvinciaRepository: Repository, IProvinciaRepository
{
    public ProvinciaRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public IEnumerable<Ent_Provincia> Obten(string Dep_Nombre)
    {
        var Lst_Provincia = new List<Ent_Provincia>();

        using var oCmd = CreateCommand("SP_Provincia_Obten_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Dep_Nombre", Dep_Nombre);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Provincia.Add(new Ent_Provincia
            {
                Prov_Nombre = oDR.GetString(oDR.GetOrdinal("Prov_Nombre"))
            });
        return Lst_Provincia;
    }
}

