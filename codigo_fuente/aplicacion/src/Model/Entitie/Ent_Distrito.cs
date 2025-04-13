using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_Distrito
    {
        public int Dist_Id { get; set; }
        public string? Dist_Nombre { get; set; }
        public Ent_Provincia eProvincia { get; set; } = new();
    }
}
