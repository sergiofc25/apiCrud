using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.v1;


public class DTO_Recurso_Obten_x_Partida
{
    public string? Rec_Id { get; set; }
    public string? Rec_IndUnificado { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? TipRec_Nombre { get; set; }
    public string? UniMed_Abreviatura { get; set; }
    public decimal? Rec_Cuadrilla { get; set; }
    public decimal? Rec_Cantidad { get; set; }
    public decimal? DRP_Precio { get; set; }
    public decimal? DetParRec_Precio_HM { get; set; }
    public decimal? DetParRec_PrecioUnitario { get; set; }
}
public class DTO_Recurso_Crea_APU
{
    public string? Par_Id { get; set; }
    public string? Rec_Id { get; set; }
    public string? Rec_Cantidad { get; set; }
    public string? Rec_Cuadrilla { get; set; }
    public string? DRP_Precio { get; set; }
}
public class DTO_Recurso_Obten
{
    public string? Rec_Id { get; set; }
    public string? Rec_IndUnificado { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? UniMed_Abreviatura { get; set; }
    public string? TipRec_Nombre { get; set; }
}
public class DTO_Recurso_Obten_Precio_x_Partida
{
    public string? Rec_Id { get; set; }
    public string? Rec_IndUnificado { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? UniMed_Abreviatura { get; set; }
    public string? TipRec_Nombre { get; set; }
    public string? DRP_Precio { get; set; }
}
public class DTO_Recurso_Obten_Paginado
{
    public string? Rec_Id { get; set; }
    public string? Rec_IndUnificado { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? UniMed_Abreviatura { get; set; }
    public string? UniMed_Nombre { get; set; }
    public string? TipRec_Nombre { get; set; }
    public string? Rec_Estado { get; set; }
}
public class DTO_Recurso_Obten_x_Id
{
    public string? Rec_Id { get; set; }
    public string? Rec_IndUnificado { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? UniMed_Nombre { get; set; }
    public string? UniMed_Abreviatura { get; set; }
    public string? TipRec_Nombre { get; set; }
    public string? Rec_Estado { get; set; }
}
public class DTO_Recurso_Crea
{
    public string? Rec_IndUnificado { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? UniMed_Nombre { get; set; }
    public string? TipRec_Nombre { get; set; }
}
public class DTO_Recurso_Actualiza
{
    public string? Rec_IndUnificado { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? UniMed_Nombre { get; set; }
    public string? TipRec_Nombre { get; set; }
}
public class DTO_Recurso_Actualiza_Condicion
{
    public string? Rec_Estado { get; set; }
}