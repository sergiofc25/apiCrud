using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IDistritoService
{
    Task<IEnumerable<Ent_Distrito>> Obten(string Prov_Nombre);
}
public class DistritoService : IDistritoService
{
    private readonly IUnitOfWork _unitOfWork;

    public DistritoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Distrito>> Obten(string Prov_Nombre)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.DistritoRepository.Obten(Prov_Nombre);
        });
    }

}

