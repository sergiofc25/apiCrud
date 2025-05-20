using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IRecursoRepository
    {
        IEnumerable<Ent_Recurso> Obten_x_Partida(int Par_Id);
        int Crea_APU(Ent_Recurso Ent_Recurso);
        IEnumerable<Ent_Recurso> Obten();
        IEnumerable<Ent_Recurso> Obten_Precio_x_Partida(int Par_Id);

    }
}
