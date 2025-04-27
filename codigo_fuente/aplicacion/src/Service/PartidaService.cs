using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IPartidaService
{
    Task<IEnumerable<Ent_Partida>> Obten_x_SubPresupuesto(int SubPre_id);

}
public class PartidaService : IPartidaService
{
    private readonly IUnitOfWork _unitOfWork;

    public PartidaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Ent_Partida>> Obten_x_SubPresupuesto(int SubPre_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.PartidaRepository.Obten_x_SubPresupuesto(SubPre_Id);
        });
    }


}

