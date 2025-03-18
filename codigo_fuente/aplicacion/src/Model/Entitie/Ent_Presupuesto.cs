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
        public Ent_Ubicacion eUbicacion { get; set; } = new();
        public decimal Pre_Jornal { get; set; }
        public DateTime Pre_FecHorRegistro { get; set; }
        public bool Pre_Estado { get; set; }
    }
}
