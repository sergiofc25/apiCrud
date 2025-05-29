using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IRolRepository
    {
        IEnumerable<Ent_Rol> Obten();
    }
}
