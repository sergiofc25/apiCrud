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
    Task<Ent_Partida> Obten_x_Id(int Par_Id);
    Task<int> Crea(Ent_Partida Partida);
    Task<int> Actualiza(Ent_Partida Partida);
    Task<bool> Inhabilita(int Par_Id, bool Par_Estado);
    Task<int> Actualiza_Metrado(int Par_Id, decimal Par_Metrado);

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
    public async Task<Ent_Partida> Obten_x_Id(int Par_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.PartidaRepository.Obten_x_Id(Par_Id);
        });
    }
    public async Task<int> Crea(Ent_Partida Partida)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var Par_Id = context.Repositories.PartidaRepository.Crea(Partida);

            if (Par_Id > 0)
            {
                context.SaveChanges();

                return Par_Id;
            }

            return Par_Id;
        });
    }
    public async Task<int> Actualiza(Ent_Partida Partida)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var CantidadAfectado = context.Repositories.PartidaRepository.Actualiza(Partida);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return CantidadAfectado;
            }

            return CantidadAfectado;
        });
    }
    public async Task<bool> Inhabilita(int Par_Id, bool Par_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            int CantidadAfectado = context.Repositories.PartidaRepository.Inhabilita(Par_Id, Par_Estado);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        });
    }
    public async Task<int> Actualiza_Metrado(int Par_Id, decimal Par_Metrado)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var CantidadAfectado = context.Repositories.PartidaRepository.Actualiza_Metrado(Par_Id, Par_Metrado);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return CantidadAfectado;
            }

            return CantidadAfectado;
        });
    }

}

