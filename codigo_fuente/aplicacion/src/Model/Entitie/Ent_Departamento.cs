using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_Departamento
    {
        public int Dep_Id { get; set; }
        public string? Dep_Nombre { get; set; }
        public Ent_Pais ePais { get; set; } = new();
    }
}
