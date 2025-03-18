using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IClienteService
{
    Task<(int, int, bool, bool, IEnumerable<Ent_Cliente>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre);
    Task<IEnumerable<Ent_Cliente>> Obten_Nombre();
    Task<IEnumerable<Ent_Cliente>> Obten_x_Nombre(string Cli_NomApeRazSocial);
    Task<Ent_Cliente> Obten_x_Id(int Cli_Id);
    Task<int> Existe(string Cli_NumDocumento, bool Cli_Estado);
    Task<int> Crea(Ent_Cliente Cliente);
    Task<int> Existente(int Cli_Id, string Cli_NumDocumento, bool Cli_Estado);
    Task<int> Actualiza(Ent_Cliente Cliente);
    Task<bool> Actualiza_Condicion(int Cli_Id, bool Cli_Estado);
}
public class ClienteService : IClienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<(int, int, bool, bool, IEnumerable<Ent_Cliente>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.ClienteRepository.Obten_Paginado(RegistroPagina, NumeroPagina, PorNombre);
        });
    }
    public async Task<IEnumerable<Ent_Cliente>> Obten_Nombre()
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.ClienteRepository.Obten_Nombre();
        });
    }
    public async Task<IEnumerable<Ent_Cliente>> Obten_x_Nombre(string Cli_NomApeRazSocial)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.ClienteRepository.Obten_x_Nombre(Cli_NomApeRazSocial);
        });
    }

    public async Task<Ent_Cliente> Obten_x_Id(int Cli_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.ClienteRepository.Obten_x_Id(Cli_Id);
        });
    }
    public async Task<int> Existe(string Cli_NumDocumento, bool Cli_Estado)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.ClienteRepository.Existe(Cli_NumDocumento, Cli_Estado);
        });
    }
    public async Task<int> Crea(Ent_Cliente Cliente)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var Cli_Id = context.Repositories.ClienteRepository.Crea(Cliente);

            if (Cli_Id > 0)
            {
                context.SaveChanges();

                return Cli_Id;
            }

            return Cli_Id;
        });
    }
    public async Task<int> Existente(int Cli_Id, string Cli_NumDocumento, bool Cli_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            return context.Repositories.ClienteRepository.Existente(Cli_Id, Cli_NumDocumento, Cli_Estado);
        });
    }

    public async Task<int> Actualiza(Ent_Cliente Cliente)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var CantidadAfectado = context.Repositories.ClienteRepository.Actualiza(Cliente);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return CantidadAfectado;
            }

            return CantidadAfectado;
        });
    }

    public async Task<bool> Actualiza_Condicion(int Cli_Id,  bool Cli_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            int CantidadAfectado = context.Repositories.ClienteRepository.Actualiza_Condicion(Cli_Id, Cli_Estado);

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

