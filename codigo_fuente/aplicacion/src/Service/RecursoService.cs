using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IRecursoService
{
    Task<IEnumerable<Ent_Recurso>> Obten_x_Partida(int Par_Id);


}
public class RecursoService : IRecursoService
{
    private readonly IUnitOfWork _unitOfWork;

    public RecursoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Ent_Recurso>> Obten_x_Partida(int Par_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten_x_Partida(Par_Id);
        });
    }
}

