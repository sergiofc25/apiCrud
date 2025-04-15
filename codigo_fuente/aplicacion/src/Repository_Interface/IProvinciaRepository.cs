using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IProvinciaRepository
    {
        IEnumerable<Ent_Provincia> Obten(string Dep_Nombre);

    }
}
