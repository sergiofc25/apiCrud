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

public class Tipo_DocumentoRepository: Repository, ITipo_DocumentoRepository
{
    public Tipo_DocumentoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }


    public IEnumerable<Ent_Tipo_Documento> Obten()
    {
        var Lst_Tipo_Documento = new List<Ent_Tipo_Documento>();

        using var oCmd = CreateCommand("SP_Tipo_Documento_Obten");

        oCmd.CommandType = CommandType.StoredProcedure;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Tipo_Documento.Add(new Ent_Tipo_Documento
            {
                TipDoc_Nombre = oDR.GetString(oDR.GetOrdinal("TipDoc_Nombre"))
            });
        return Lst_Tipo_Documento;
    }

}

