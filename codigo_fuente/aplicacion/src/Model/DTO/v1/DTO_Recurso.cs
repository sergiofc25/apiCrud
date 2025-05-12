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
