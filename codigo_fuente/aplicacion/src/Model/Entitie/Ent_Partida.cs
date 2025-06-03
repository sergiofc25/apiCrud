using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_Partida
    {
        public int Par_Id { get; set; }
        public string? Par_Ruta { get; set; }
        public string? Par_Nombre { get; set; }
        public decimal? Par_RenManObra { get; set; }
        public decimal? Par_RenEquipo { get; set; }
        public Ent_Unidad_Medida eUnidad_Medida { get; set; } = new();
        public decimal? Par_PreUnitario { get; set; }
        public bool Par_Estado { get; set; }
        public decimal? Par_Metrado { get; set; }
        public decimal? Par_PreUnitarioFinal { get; set; }
        public Ent_SubPresupuesto eSubPresupuesto { get; set; } = new();
    }
}
