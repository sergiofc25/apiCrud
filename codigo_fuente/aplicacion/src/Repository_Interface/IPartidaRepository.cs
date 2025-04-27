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
        //IEnumerable<Ent_Partida> Obten_x_Presupuesto(int Pre_Id);
        IEnumerable<Ent_Partida> Obten_x_SubPresupuesto(int SubPre_Id);


    }
}
