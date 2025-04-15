using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IDistritoRepository
    {
        IEnumerable<Ent_Distrito> Obten(string Prov_Nombre);
    }
}
