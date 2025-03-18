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

public class UbicacionRepository: Repository, IUbicacionRepository
{
    public UbicacionRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }


    public IEnumerable<Ent_Ubicacion> Obten_x_Nombre(string Ubi_Departamento, string Ubi_Provincia, string Ubi_Distrito)
    {
        var Lst_Ubicacion = new List<Ent_Ubicacion>();

        using var oCmd = CreateCommand("SP_Ubicacion_Obten_x_Nombre");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Ubi_Departamento", Ubi_Departamento);
        oCmd.Parameters.AddWithValue("Ubi_Provincia", Ubi_Provincia);
        oCmd.Parameters.AddWithValue("Ubi_Distrito", Ubi_Distrito);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Ubicacion.Add(new Ent_Ubicacion
            {
                Ubi_Departamento = oDR.GetString(oDR.GetOrdinal("Ubi_Departamento")),
                Ubi_Provincia = oDR.GetString(oDR.GetOrdinal("Ubi_Provincia")),
                Ubi_Distrito = oDR.GetString(oDR.GetOrdinal("Ubi_Distrito"))
            });
        return Lst_Ubicacion;
    }

}

