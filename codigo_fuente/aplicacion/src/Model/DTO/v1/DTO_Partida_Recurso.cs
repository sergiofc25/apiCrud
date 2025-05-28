using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.v1;


public class DTO_Partida_Recurso_Obten_x_Id_APU
{
    public string? DetParRec_Id { get; set; }
    public string? Rec_Cantidad { get; set; }
    public string? Rec_Cuadrilla { get; set; }
    public string? DRP_Precio { get; set; }
    public string? Rec_Nombre { get; set; }
    public string? TipRec_Nombre { get; set; }
}
public class DTO_Partida_Recurso_Actualiza_APU
{
    public string? Rec_Cantidad { get; set; }
    public string? Rec_Cuadrilla { get; set; }
    public string? DRP_Precio { get; set; }
}