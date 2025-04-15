using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IProvinciaService
{
    Task<IEnumerable<Ent_Provincia>> Obten(string Dep_Nombre);
}
public class ProvinciaService : IProvinciaService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProvinciaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Provincia>> Obten(string Dep_Nombre)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.ProvinciaRepository.Obten(Dep_Nombre);
        });
    }

}

