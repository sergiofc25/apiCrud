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

public class PaisRepository: Repository, IPaisRepository
{
    public PaisRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }


    public IEnumerable<Ent_Pais> Obten()
    {
        var Lst_Pais = new List<Ent_Pais>();

        using var oCmd = CreateCommand("SP_Pais_Obten_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Pais.Add(new Ent_Pais
            {
                Pai_Nombre = oDR.GetString(oDR.GetOrdinal("Pai_Nombre"))
            });
        return Lst_Pais;
    }

}

