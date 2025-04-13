using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_Provincia
    {
        public int Prov_Id { get; set; }
        public string? Prov_Nombre { get; set; }
        public Ent_Departamento eDepartamento { get; set; } = new();
    }
}
