using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IRecursoService
{
    Task<IEnumerable<Ent_Recurso>> Obten_x_Partida(int Par_Id);
    Task<int> Crea_APU(Ent_Recurso Recurso);
    Task<IEnumerable<Ent_Recurso>> Obten();
    Task<IEnumerable<Ent_Recurso>> Obten_Precio_x_Partida(int Par_Id);
    Task<(int, int, bool, bool, IEnumerable<Ent_Recurso>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre);
    Task<Ent_Recurso> Obten_x_Id(int Rec_Id);
    Task<(int, string)> Crea(Ent_Recurso Recurso);
    Task<string> Actualiza(Ent_Recurso Recurso);
    Task<bool> Actualiza_Condicion(int Rec_Id, bool Rec_Estado);
}
public class RecursoService : IRecursoService
{
    private readonly IUnitOfWork _unitOfWork;

    public RecursoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Ent_Recurso>> Obten_x_Partida(int Par_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten_x_Partida(Par_Id);
        });
    }
    public async Task<int> Crea_APU(Ent_Recurso Recurso)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var DetParRec_Id = context.Repositories.RecursoRepository.Crea_APU(Recurso);

            if (DetParRec_Id > 0)
            {
                context.SaveChanges();

                return DetParRec_Id;
            }

            return DetParRec_Id;
        });
    }
    public async Task<IEnumerable<Ent_Recurso>> Obten()
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten();
        });
    }
    public async Task<IEnumerable<Ent_Recurso>> Obten_Precio_x_Partida(int Par_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten_Precio_x_Partida(Par_Id);
        });
    }
    public async Task<(int, int, bool, bool, IEnumerable<Ent_Recurso>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten_Paginado(RegistroPagina, NumeroPagina, PorNombre);
        });
    }
    public async Task<Ent_Recurso> Obten_x_Id(int Rec_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.RecursoRepository.Obten_x_Id(Rec_Id);
        });
    }
    public async Task<(int, string)> Crea(Ent_Recurso Recurso)
    {
        using var context = _unitOfWork.Create();

        var (Rec_Id, MensajeError) = context.Repositories.RecursoRepository.Crea(Recurso);

        if (Rec_Id > 0 && MensajeError == string.Empty)
        {
            context.SaveChanges();
        }

        return (Rec_Id, MensajeError);
    }
    public async Task<string> Actualiza(Ent_Recurso Recurso)
    {
        using var context = _unitOfWork.Create();

        var MensajeError = context.Repositories.RecursoRepository.Actualiza(Recurso);

        if (MensajeError == string.Empty)
        {
            context.SaveChanges();  
        }
        return MensajeError;
    }
    public async Task<bool> Actualiza_Condicion(int Rec_Id, bool Rec_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            int CantidadAfectado = context.Repositories.RecursoRepository.Actualiza_Condicion(Rec_Id, Rec_Estado);

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

