using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_Presupuesto
    {
        public int Pre_Id { get; set; }
        public string? Pre_Codigo { get; set; }
        public Ent_Usuario eUsuario { get; set; } = new();
        public string? Pre_Nombre { get; set; }
        public Ent_Cliente eCliente { get; set; } = new();
        public decimal Pre_Jornal { get; set; }
        public DateTime Pre_FecHorRegistro { get; set; }
        public bool Pre_Estado { get; set; }
        public Ent_Pais ePais { get; set; } = new();
        public Ent_Departamento eDeparatemaneto { get; set; } = new();
        public Ent_Provincia eProvincia { get; set; } = new();
        public Ent_Distrito eDistrito { get; set; } = new();
        public decimal? Pre_CostoDirecto { get; set; }
        public int? Pre_PGastosGenerales { get; set; }
        public int? Pre_PUtilidad { get; set; }
        public decimal? Pre_SubTotal { get; set; }
        public int? Pre_PIGV { get; set; }
        public decimal? Pre_TotalPresupuesto { get; set; }
        public decimal? Pre_GastosGenerales { get; set; }
        public decimal? Pre_Utilidad { get; set; }
        public decimal? Pre_IGV { get; set; }
    }
}
