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

public class DepartamentoRepository: Repository, IDepartamentoRepository
{
    public DepartamentoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public IEnumerable<Ent_Departamento> Obten(string Pai_Nombre)
    {
        var Lst_Departamento = new List<Ent_Departamento>();

        using var oCmd = CreateCommand("SP_Departamento_Obten_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Pai_Nombre", Pai_Nombre);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Departamento.Add(new Ent_Departamento
            {
                Dep_Nombre = oDR.GetString(oDR.GetOrdinal("Dep_Nombre"))
            });
        return Lst_Departamento;
    }
}

