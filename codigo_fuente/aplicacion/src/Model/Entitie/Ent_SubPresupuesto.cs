using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_SubPresupuesto
    {
        public int SubPre_Id { get; set; }
        public Ent_Presupuesto ePresupuesto { get; set; } = new();
        public int? Padre_Id { get; set; }
        public string SubPre_Nombre { get; set; }
        public int SubPre_Nivel { get; set; }
        public int SubPre_Orden { get; set; }
        public string SubPre_Ruta { get; set; }
        public bool SubPre_TieneHijos { get; set; }
    }
}
