using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IPaisService
{
    Task<IEnumerable<Ent_Pais>> Obten();
}
public class PaisService : IPaisService
{
    private readonly IUnitOfWork _unitOfWork;

    public PaisService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Pais>> Obten()
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.PaisRepository.Obten();
        });
    }

}

