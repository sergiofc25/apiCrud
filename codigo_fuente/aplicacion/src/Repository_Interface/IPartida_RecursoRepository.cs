using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IPartida_RecursoRepository
    {
        int Elimina_APU(int DetParRec_Id);
        Ent_Partida_Recurso Obten_x_Id_APU(int DetParRec_Id);
        int Actualiza_APU(Ent_Partida_Recurso Ent_Partida_Recurso);
    }
}
