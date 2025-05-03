using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IUnidad_MedidaService
{
    Task<IEnumerable<Ent_Unidad_Medida>> Obten();
}
public class Unidad_MedidaService : IUnidad_MedidaService
{
    private readonly IUnitOfWork _unitOfWork;

    public Unidad_MedidaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Unidad_Medida>> Obten()
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.Unidad_MedidaRepository.Obten();
        });
    }

}

