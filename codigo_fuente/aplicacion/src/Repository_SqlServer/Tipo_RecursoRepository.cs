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

public class Tipo_RecursoRepository: Repository, ITipo_RecursoRepository
{
    public Tipo_RecursoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }


    public IEnumerable<Ent_Tipo_Recurso> Obten()
    {
        var Lst_Tipo_Recurso = new List<Ent_Tipo_Recurso>();

        using var oCmd = CreateCommand("SP_Tipo_Recurso_Obten");

        oCmd.CommandType = CommandType.StoredProcedure;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Tipo_Recurso.Add(new Ent_Tipo_Recurso
            {
                TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
            });
        return Lst_Tipo_Recurso;
    }

}

