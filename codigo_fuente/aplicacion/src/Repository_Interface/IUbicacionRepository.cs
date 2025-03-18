using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IUbicacionRepository
    {
        IEnumerable<Ent_Ubicacion> Obten_x_Nombre(string Ubi_Departamento, string Ubi_Provincia, string Ubi_Distrito);

    }
}
