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

public class DistritoRepository: Repository, IDistritoRepository
{
    public DistritoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public IEnumerable<Ent_Distrito> Obten(string Prov_Nombre)
    {
        var Lst_Distrito = new List<Ent_Distrito>();

        using var oCmd = CreateCommand("SP_Distrito_Obten_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Prov_Nombre", Prov_Nombre);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Distrito.Add(new Ent_Distrito
            {
                Dist_Nombre = oDR.GetString(oDR.GetOrdinal("Dist_Nombre"))
            });
        return Lst_Distrito;
    }
}

