using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface ISubPresupuestoService
{
    Task<IEnumerable<Ent_SubPresupuesto>> Obten_x_Presupuesto(int Pre_id);
    Task<Ent_SubPresupuesto> Obten_x_Id(int SubPre_Id);
    Task<int> Actualiza_Nombre(Ent_SubPresupuesto SubPresupuesto);
    Task<int> Elimina(int SubPre_Id);
}
public class SubPresupuestoService : ISubPresupuestoService
{
    private readonly IUnitOfWork _unitOfWork;

    public SubPresupuestoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_SubPresupuesto>> Obten_x_Presupuesto(int Pre_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.SubPresupuestoRepository.Obten_x_Presupuesto(Pre_Id);
        });
    }
    public async Task<Ent_SubPresupuesto> Obten_x_Id(int SubPre_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.SubPresupuestoRepository.Obten_x_Id(SubPre_Id);
        });
    }
    public async Task<int> Actualiza_Nombre(Ent_SubPresupuesto SubPresupuesto)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var CantidadAfectado = context.Repositories.SubPresupuestoRepository.Actualiza_Nombre(SubPresupuesto);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return CantidadAfectado;
            }
            return CantidadAfectado;
        });
    }
    public async Task<int> Elimina(int SubPre_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            //Validar si el registro existe antes de eliminarlo
            var existe = context.Repositories.SubPresupuestoRepository.Obten_x_Id(SubPre_Id);
            if (existe == null)
                return 0;

            var registrosAfectados = context.Repositories.SubPresupuestoRepository.Elimina(SubPre_Id);

            if (registrosAfectados > 0)
            {
                context.SaveChanges();
            }

            return registrosAfectados;
        });
    }
}

