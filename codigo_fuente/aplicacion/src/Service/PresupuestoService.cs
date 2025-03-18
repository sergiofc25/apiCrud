using Model.Entitie;
using UnitOfWork_Interface;

namespace Service;


public interface IPresupuestoService
{
    Task<(int, int, bool, bool, IEnumerable<Ent_Presupuesto>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre);
    Task<Ent_Presupuesto> Obten_x_Id(int Pre_Id);
    Task<int> Existe(string Pre_Nombre, bool Pre_Estado);
    Task<int> Crea(Ent_Presupuesto Presupuesto);
    Task<int> Existente(int Pre_Id, string Pre_Nombre, bool Pre_Estado);
    Task<int> Actualiza(Ent_Presupuesto Presupuesto);
    Task<bool> Actualiza_Condicion(int Pre_Id, bool Pre_Estado);
}
public class PresupuestoService : IPresupuestoService
{
    private readonly IUnitOfWork _unitOfWork;

    public PresupuestoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<(int, int, bool, bool, IEnumerable<Ent_Presupuesto>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.PresupuestoRepository.Obten_Paginado(RegistroPagina, NumeroPagina, PorNombre);
        });
    }

    public async Task<Ent_Presupuesto> Obten_x_Id(int Pre_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.PresupuestoRepository.Obten_x_Id(Pre_Id);
        });
    }
    public async Task<int> Existe(string Pre_Nombre, bool Pre_Estado)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.PresupuestoRepository.Existe(Pre_Nombre, Pre_Estado);
        });
    }
    public async Task<int> Crea(Ent_Presupuesto Presupuesto)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var Pre_Id = context.Repositories.PresupuestoRepository.Crea(Presupuesto);

            if (Pre_Id > 0)
            {
                context.SaveChanges();

                return Pre_Id;
            }

            return Pre_Id;
        });
    }
    public async Task<int> Existente(int Pre_Id, string Pre_Nombre, bool Pre_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            return context.Repositories.PresupuestoRepository.Existente(Pre_Id, Pre_Nombre, Pre_Estado);
        });
    }

    public async Task<int> Actualiza(Ent_Presupuesto Presupuesto)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var CantidadAfectado = context.Repositories.PresupuestoRepository.Actualiza(Presupuesto);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return CantidadAfectado;
            }

            return CantidadAfectado;
        });
    }

    public async Task<bool> Actualiza_Condicion(int Pre_Id,  bool Pre_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            int CantidadAfectado = context.Repositories.PresupuestoRepository.Actualiza_Condicion(Pre_Id, Pre_Estado);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        });
    }

}

