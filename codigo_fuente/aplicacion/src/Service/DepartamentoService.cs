using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IDepartamentoService
{
    Task<IEnumerable<Ent_Departamento>> Obten(string Pai_Nombre);
}
public class DepartamentoService : IDepartamentoService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartamentoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Departamento>> Obten(string Pai_Nombre)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.DepartamentoRepository.Obten(Pai_Nombre);
        });
    }

}

