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
    Task<int> Crea_APU(Ent_Recurso Recurso);
    Task<IEnumerable<Ent_Recurso>> Obten();
    Task<IEnumerable<Ent_Recurso>> Obten_Precio_x_Partida(int Par_Id);


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
    public async Task<int> Crea_APU(Ent_Recurso Recurso)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var DetParRec_Id = context.Repositories.RecursoRepository.Crea_APU(Recurso);

            if (DetParRec_Id > 0)
            {
                context.SaveChanges();

                return DetParRec_Id;
            }

            return DetParRec_Id;
        });
    }
    public async Task<IEnumerable<Ent_Recurso>> Obten()
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten();
        });
    }
    public async Task<IEnumerable<Ent_Recurso>> Obten_Precio_x_Partida(int Par_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten_Precio_x_Partida(Par_Id);
        });
    }
}

