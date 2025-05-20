using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface ITipo_RecursoService
{
    Task<IEnumerable<Ent_Tipo_Recurso>> Obten();
}
public class Tipo_RecursoService : ITipo_RecursoService
{
    private readonly IUnitOfWork _unitOfWork;

    public Tipo_RecursoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Tipo_Recurso>> Obten()
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.Tipo_RecursoRepository.Obten();
        });
    }

}

