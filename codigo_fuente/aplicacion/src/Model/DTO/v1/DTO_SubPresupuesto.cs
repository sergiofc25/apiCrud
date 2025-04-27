using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.v1;


public class DTO_SubPresupuesto_Obten_x_Presupuesto
{
    public string? SubPre_Id { get; set; }
    public string? Pre_Id { get; set; }
    public string? Padre_Id { get; set; }
    public string? SubPre_Nombre { get; set; }
    public string? SubPre_Nivel { get; set; }
    public string? SubPre_Orden { get; set; }
    public string? SubPre_Ruta { get; set; }
    public string? SubPre_TieneHijos { get; set; }
}
public class DTO_SubPresupuesto_Obten_x_Id
{
    public string? SubPre_Id { get; set; }
    public string? Pre_Id { get; set; }
    public string? Pre_Nombre { get; set; }
    public string? Padre_Id { get; set; }
    public string? SubPre_Nombre { get; set; }
    public string? SubPre_Nivel { get; set; }
    public string? SubPre_Orden { get; set; }
    public string? SubPre_Ruta { get; set; }
    public string? SubPre_TieneHijos { get; set; }
}
public class DTO_SubPresupuesto_Crea
{
    public string? Pre_Id { get; set; }
    public string? Padre_Id { get; set; }
    public string? SubPre_Nombre { get; set; }
    public string? SubPre_Nivel { get; set; }
    public string? SubPre_Orden { get; set; }
}
public class DTO_SubPresupuesto_Crea_Dentro
{
    public string? SubPre_Nombre { get; set; }
}
public class DTO_SubPresupuesto_Crea_Primer_Nivel
{
    public string? SubPre_Nombre { get; set; }
}
public class DTO_SubPresupuesto_Actualiza_Nombre
{
    public string? SubPre_Nombre { get; set; }

};