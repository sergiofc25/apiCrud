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

}

