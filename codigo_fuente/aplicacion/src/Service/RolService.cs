using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IRolService
{
    Task<IEnumerable<Ent_Rol>> Obten();
}
public class RolService : IRolService
{
    private readonly IUnitOfWork _unitOfWork;

    public RolService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Rol>> Obten()
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RolRepository.Obten();
        });
    }

}

