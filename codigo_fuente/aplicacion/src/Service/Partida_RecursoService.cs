using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IPartida_RecursoService
{
    Task<int> Elimina_APU(int DetParRec_Id);
    Task<Ent_Partida_Recurso> Obten_x_Id_APU(int DetParRec_Id);
    Task<int> Actualiza_APU(Ent_Partida_Recurso Partida_Recurso);

}
public class Partida_RecursoService : IPartida_RecursoService
{
    private readonly IUnitOfWork _unitOfWork;

    public Partida_RecursoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Elimina_APU(int DetParRec_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            //var existe = context.Repositories.Partida_RecursoRepository.Obten_x_Id(DetParRec_Id);
            //if (existe == null)
            //    return 0;

            var registrosAfectados = context.Repositories.Partida_RecursoRepository.Elimina_APU(DetParRec_Id);

            if (registrosAfectados > 0)
            {
                context.SaveChanges();
            }

            return registrosAfectados;
        });
    }
    public async Task<Ent_Partida_Recurso> Obten_x_Id_APU(int DetParRec_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.Partida_RecursoRepository.Obten_x_Id_APU(DetParRec_Id);
        });
    }
    public async Task<int> Actualiza_APU(Ent_Partida_Recurso Partida_Recurso)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var CantidadAfectado = context.Repositories.Partida_RecursoRepository.Actualiza_APU(Partida_Recurso);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return CantidadAfectado;
            }

            return CantidadAfectado;
        });
    }
}

