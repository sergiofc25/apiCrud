using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IUbicacionService
{
    Task<IEnumerable<Ent_Ubicacion>> Obten_x_Nombre(string Ubi_Departamento, string Ubi_Provincia, string Ubi_Distrito);
}
public class UbicacionService : IUbicacionService
{
    private readonly IUnitOfWork _unitOfWork;

    public UbicacionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Ent_Ubicacion>> Obten_x_Nombre(string Ubi_Departamento, string Ubi_Provincia, string Ubi_Distrito)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.UbicacionRepository.Obten_x_Nombre( Ubi_Departamento, Ubi_Provincia, Ubi_Distrito);
        });
    }

}

