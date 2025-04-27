using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.v1;


public class DTO_Partida_Obten_x_SubPresupuesto
{
    public string? Par_Id { get; set; }
    public string? Par_Ruta { get; set; }
    public string? SubPre_Id { get; set; }
    public string? Par_Nombre { get; set; }
    public string? Par_RenManObra { get; set; }
    public string? Par_RenEquipo { get; set; }
    public string? UniMed_Nombre { get; set; }
    public string? Par_Estado { get; set; }
}
