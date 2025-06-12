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
        int Actualiza(Ent_Partida Partida);
        int Inhabilita(int Par_Id, bool Par_Estado);//Cambia estado y desvincula de subpresupuesto (actualiza a null SubPre_Id)
        int Actualiza_Metrado(int Par_Id, decimal Par_Metrado);
    }
}
