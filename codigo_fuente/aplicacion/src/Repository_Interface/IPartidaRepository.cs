using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IPartidaRepository
    {
        IEnumerable<Ent_Partida> Obten_x_SubPresupuesto(int SubPre_Id);
        Ent_Partida Obten_x_Id(int Par_Id);
        int Crea(Ent_Partida Partida);

    }
}
