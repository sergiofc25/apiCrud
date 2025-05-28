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

public class RecursoRepository: Repository, IRecursoRepository
{
    public RecursoRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public IEnumerable<Ent_Recurso> Obten_x_Partida(int Par_Id)
    {
        var Lst_Recurso = new List<Ent_Recurso>();

        using var oCmd = CreateCommand("SP_Recurso_Obten_x_Partida_APU");
        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("Par_Id", Par_Id);

        using var oDR = oCmd.ExecuteReader();

        while (oDR.Read())
        {
            var Recurso = new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eTipo_Recurso = new()
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
                eUnidad_Medida = new()
                {
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura"))
                },
                ePartida_Recurso = new Ent_Partida_Recurso
                {
                    DetParRec_Id = oDR.GetInt32(oDR.GetOrdinal("DetParRec_Id")),
                    Rec_Cantidad = oDR.IsDBNull(oDR.GetOrdinal("Rec_Cantidad")) ? null : oDR.GetDecimal(oDR.GetOrdinal("Rec_Cantidad")),
                    Rec_Cuadrilla = oDR.IsDBNull(oDR.GetOrdinal("Rec_Cuadrilla")) ? null : oDR.GetDecimal(oDR.GetOrdinal("Rec_Cuadrilla")),
                    DetParRec_Precio_HM = oDR.IsDBNull(oDR.GetOrdinal("DetParRec_Precio_HM")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DetParRec_Precio_HM")),
                    DetParRec_PrecioUnitario = oDR.IsDBNull(oDR.GetOrdinal("DetParRec_PrecioUnitario")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DetParRec_PrecioUnitario"))
                },

                eRecurso_Presupuesto = new Ent_Recurso_Presupuesto
                {
                    DRP_Precio = oDR.IsDBNull(oDR.GetOrdinal("DRP_Precio")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DRP_Precio"))
                }
            };

            Lst_Recurso.Add(Recurso);
        }

        return Lst_Recurso;
    }
    public int Crea_APU(Ent_Recurso Ent_Recurso)
    {
        using var oCmd = CreateCommand("SP_Recurso_Crea_APU");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Par_Id", Ent_Recurso.ePartida_Recurso.ePartida.Par_Id);
        oCmd.Parameters.AddWithValue("Rec_Id", Ent_Recurso.ePartida_Recurso.eRecurso.Rec_Id);
        if (Ent_Recurso.ePartida_Recurso.Rec_Cantidad.HasValue)
        {
            oCmd.Parameters.AddWithValue("Rec_Cantidad", Ent_Recurso.ePartida_Recurso.Rec_Cantidad);
        }
        if (Ent_Recurso.ePartida_Recurso.Rec_Cuadrilla.HasValue)
        {
            oCmd.Parameters.AddWithValue("Rec_Cuadrilla", Ent_Recurso.ePartida_Recurso.Rec_Cuadrilla);
        }
        if (Ent_Recurso.eRecurso_Presupuesto.DRP_Precio.HasValue)
        {
            oCmd.Parameters.AddWithValue("DRP_Precio", Ent_Recurso.eRecurso_Presupuesto.DRP_Precio);
        }

        var DetParRec_IdParam = new SqlParameter
        {
            ParameterName = "@DetParRec_Id",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };
        oCmd.Parameters.Add(DetParRec_IdParam);

        oCmd.ExecuteNonQuery();

        int DetParRec_Id = Convert.ToInt32(DetParRec_IdParam.Value);

        return DetParRec_Id;
    }
    public IEnumerable<Ent_Recurso> Obten()
    {
        var Lst_Recurso = new List<Ent_Recurso>();

        using var oCmd = CreateCommand("SP_Recurso_Obten");

        oCmd.CommandType = CommandType.StoredProcedure;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Recurso.Add(new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eUnidad_Medida = new Ent_Unidad_Medida
                {
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura"))
                },
                eTipo_Recurso = new Ent_Tipo_Recurso
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
            });
        return Lst_Recurso;
    }
    public IEnumerable<Ent_Recurso> Obten_Precio_x_Partida(int Par_Id)
    {
        var Lst_Recurso = new List<Ent_Recurso>();

        using var oCmd = CreateCommand("SP_Recurso_Obten_Precio_x_Partida");

        oCmd.CommandType = CommandType.StoredProcedure;
        oCmd.Parameters.AddWithValue("Par_Id", Par_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Recurso.Add(new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eUnidad_Medida = new Ent_Unidad_Medida
                {
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura"))
                },
                eTipo_Recurso = new Ent_Tipo_Recurso
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
                eRecurso_Presupuesto= new Ent_Recurso_Presupuesto
                {
                    DRP_Precio = oDR.IsDBNull(oDR.GetOrdinal("DRP_Precio")) ? null : oDR.GetDecimal(oDR.GetOrdinal("DRP_Precio"))
                }
            });
        return Lst_Recurso;
    }
    public (int, int, bool, bool, IEnumerable<Ent_Recurso>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre)
    {
        var Lst_Ent_Recurso = new List<Ent_Recurso>();

        using var oCmd = CreateCommand("SP_Recurso_Obten_Paginado");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("RegistroPagina", RegistroPagina);
        oCmd.Parameters.AddWithValue("NumeroPagina", NumeroPagina);
        oCmd.Parameters.AddWithValue("PorNombre", PorNombre != null ? (object)PorNombre : DBNull.Value);
        oCmd.Parameters.AddWithValue("TotalPagina", 0).Direction = ParameterDirection.Output;
        oCmd.Parameters.AddWithValue("TotalRegistro", 0).Direction = ParameterDirection.Output;
        oCmd.Parameters.AddWithValue("TienePaginaAnterior", 0).Direction = ParameterDirection.Output;
        oCmd.Parameters.AddWithValue("TienePaginaProximo", 0).Direction = ParameterDirection.Output;

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleResult);

        while (oDR.Read())
            Lst_Ent_Recurso.Add(new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eUnidad_Medida = new()
                {
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura")),
                    UniMed_Nombre = oDR.GetString(oDR.GetOrdinal("UniMed_Nombre")),

                },
                eTipo_Recurso = new()
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
                Rec_Estado = oDR.GetByte(oDR.GetOrdinal("Rec_Estado")) != 0 ? true : false,
            });

        oDR.NextResult();

        return (Convert.ToInt32(oCmd.Parameters["TotalPagina"].Value),
            Convert.ToInt32(oCmd.Parameters["TotalRegistro"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaAnterior"].Value),
            Convert.ToBoolean(oCmd.Parameters["TienePaginaProximo"].Value),
            Lst_Ent_Recurso);
    }
    public Ent_Recurso Obten_x_Id(int Rec_Id)
    {
        using var oCmd = CreateCommand("SP_Recurso_Obten_x_Id");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Rec_Id", Rec_Id);

        using var oDR = oCmd.ExecuteReader(CommandBehavior.SingleRow);

        if (oDR.HasRows)
        {
            oDR.Read();

            return new Ent_Recurso
            {
                Rec_Id = oDR.GetInt32(oDR.GetOrdinal("Rec_Id")),
                Rec_IndUnificado = oDR.GetString(oDR.GetOrdinal("Rec_IndUnificado")),
                Rec_Nombre = oDR.GetString(oDR.GetOrdinal("Rec_Nombre")),
                eUnidad_Medida = new()
                {
                    UniMed_Nombre = oDR.GetString(oDR.GetOrdinal("UniMed_Nombre")),
                    UniMed_Abreviatura = oDR.GetString(oDR.GetOrdinal("UniMed_Abreviatura")),
                },
                eTipo_Recurso = new()
                {
                    TipRec_Nombre = oDR.GetString(oDR.GetOrdinal("TipRec_Nombre"))
                },
                Rec_Estado = oDR.GetByte(oDR.GetOrdinal("Rec_Estado")) != 0 ? true : false,
            };
        }

        return null;
    }
    public (int, string) Crea(Ent_Recurso Recurso)
    {
        using var oCmd = CreateCommand("SP_Recurso_Crea");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Rec_IndUnificado", Recurso.Rec_IndUnificado);
        oCmd.Parameters.AddWithValue("Rec_Nombre", Recurso.Rec_Nombre);
        oCmd.Parameters.AddWithValue("UniMed_Nombre", Recurso.eUnidad_Medida.UniMed_Nombre);
        oCmd.Parameters.AddWithValue("TipRec_Nombre", Recurso.eTipo_Recurso.TipRec_Nombre);

        oCmd.Parameters.AddWithValue("Rec_Id", 0).Direction = ParameterDirection.Output;
        oCmd.Parameters.AddWithValue("MensajeError", string.Empty).Direction = ParameterDirection.Output;

        oCmd.ExecuteNonQuery();

        return ((int)oCmd.Parameters["Rec_Id"].Value, oCmd.Parameters["MensajeError"].Value.ToString());
    }

    public string Actualiza(Ent_Recurso Recurso)
    {
        using var oCmd = CreateCommand("SP_Recurso_Actualiza");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Rec_Id", Recurso.Rec_Id);
        oCmd.Parameters.AddWithValue("Rec_IndUnificado", Recurso.Rec_IndUnificado);
        oCmd.Parameters.AddWithValue("Rec_Nombre", Recurso.Rec_Nombre);
        oCmd.Parameters.AddWithValue("UniMed_Nombre", Recurso.eUnidad_Medida.UniMed_Nombre);
        oCmd.Parameters.AddWithValue("TipRec_Nombre", Recurso.eTipo_Recurso.TipRec_Nombre);

        oCmd.Parameters.AddWithValue("MensajeError", 0).Direction = ParameterDirection.Output;

        oCmd.ExecuteNonQuery();

        return oCmd.Parameters["MensajeError"].Value.ToString();
    }
    public int Actualiza_Condicion(int Rec_Id, bool Rec_Estado)
    {
        using var oCmd = CreateCommand("SP_Recurso_Actualiza_Estado");

        oCmd.CommandType = CommandType.StoredProcedure;

        oCmd.Parameters.AddWithValue("Rec_Id", Rec_Id);
        oCmd.Parameters.AddWithValue("Rec_Estado", Rec_Estado);
        return oCmd.ExecuteNonQuery();
    }
    //public int Actualiza_APU(Ent_Recurso Ent_Recurso)
    //{
    //    using var oCmd = CreateCommand("SP_Recurso_Actualiza_APU");

    //    oCmd.CommandType = CommandType.StoredProcedure;

    //    oCmd.Parameters.AddWithValue("DetParRec_Id", Ent_Recurso.ePartida_Recurso.DetParRec_Id);
    //    //oCmd.Parameters.AddWithValue("Rec_Cantidad", Ent_Recurso.ePartida_Recurso.Rec_Cantidad);
    //    //oCmd.Parameters.AddWithValue("Rec_Cuadrilla", Ent_Recurso.ePartida_Recurso.Rec_Cuadrilla);
    //    //oCmd.Parameters.AddWithValue("DRP_Precio", Ent_Recurso.eRecurso_Presupuesto.DRP_Precio);
    //    if (Ent_Recurso.ePartida_Recurso.Rec_Cantidad.HasValue)
    //    {
    //        oCmd.Parameters.AddWithValue("Rec_Cantidad", Ent_Recurso.ePartida_Recurso.Rec_Cantidad);
    //    }
    //    if (Ent_Recurso.ePartida_Recurso.Rec_Cuadrilla.HasValue)
    //    {
    //        oCmd.Parameters.AddWithValue("Rec_Cuadrilla", Ent_Recurso.ePartida_Recurso.Rec_Cuadrilla);
    //    }
    //    if (Ent_Recurso.eRecurso_Presupuesto.DRP_Precio.HasValue)
    //    {
    //        oCmd.Parameters.AddWithValue("DRP_Precio", Ent_Recurso.eRecurso_Presupuesto.DRP_Precio);
    //    }

    //    return oCmd.ExecuteNonQuery();
    //}
}

