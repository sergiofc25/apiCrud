using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace Service;


public interface IUsuarioService
{
    Task<int> Obten_Login(string Usu_Correo, string Usu_Clave);

    Task<Ent_Usuario> Obten_x_Correo(string Usu_Correo);
    Task<Ent_Usuario> Obten_Token_x_Correo(string Usu_Correo);

    Task<bool> Actualiza_Token(Ent_Usuario Usuario);
    Task<(int, int, bool, bool, IEnumerable<Ent_Usuario>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre);
    Task<Ent_Usuario> Obten_x_Id(int Usu_Id);
    Task<int> Existe(string Cli_NumDocumento, bool Cli_Estado);
    Task<int> Crea(Ent_Usuario Ent_Usuario);
    Task<int> Existente(int Usu_Id, string Usu_Correo, bool Usu_Estado);
    Task<int> Actualiza(Ent_Usuario Ent_Usuario);
    Task<bool> Actualiza_Condicion(int Usu_Id, bool Usu_Estado);
}
public class UsuarioService : IUsuarioService
{
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Actualiza_Token(Ent_Usuario Usuario)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            bool Afectado;

            Afectado = context.Repositories.UsuarioRepository.Actualiza_Token(Usuario);

            if (Afectado)
            {
                context.SaveChanges();

                return true;
            }

            return false;
        });
    }

    public async Task<int> Obten_Login(string Usu_Correo, string Usu_Clave)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.UsuarioRepository.Obten_Login(Usu_Correo, Usu_Clave);
        });
    }

    public async Task<Ent_Usuario> Obten_x_Correo(string Usu_Correo)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.UsuarioRepository.Obten_x_Correo(Usu_Correo);
        });
    }
    public async Task<Ent_Usuario> Obten_Token_x_Correo(string Usu_Correo)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.UsuarioRepository.Obten_Token_x_Correo(Usu_Correo);
        });
    }
    public async Task<(int, int, bool, bool, IEnumerable<Ent_Usuario>)> Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.UsuarioRepository.Obten_Paginado(RegistroPagina, NumeroPagina, PorNombre);
        });
    }
    public async Task<Ent_Usuario> Obten_x_Id(int Usu_Id)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.UsuarioRepository.Obten_x_Id(Usu_Id);
        });
    }
    public async Task<int> Existe(string Usu_Correo, bool Usu_Estado)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            return context.Repositories.UsuarioRepository.Existe(Usu_Correo, Usu_Estado);
        });
    }
    public async Task<int> Crea(Ent_Usuario Usuario)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var Usu_Id = context.Repositories.UsuarioRepository.Crea(Usuario);

            if (Usu_Id > 0)
            {
                context.SaveChanges();

                return Usu_Id;
            }

            return Usu_Id;
        });
    }
    public async Task<int> Existente(int Usu_Id, string Usu_Correo, bool Usu_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            return context.Repositories.UsuarioRepository.Existente(Usu_Id, Usu_Correo, Usu_Estado);
        });
    }

    public async Task<int> Actualiza(Ent_Usuario Usuario)
    {
        return await Task.Run(() =>
        {
            using var context = _unitOfWork.Create();

            var CantidadAfectado = context.Repositories.UsuarioRepository.Actualiza(Usuario);

            if (CantidadAfectado > 0)
            {
                context.SaveChanges();

                return CantidadAfectado;
            }

            return CantidadAfectado;
        });
    }

    public async Task<bool> Actualiza_Condicion(int Usu_Id, bool Usu_Estado)
    {
        return await Task.Run(() => {

            using var context = _unitOfWork.Create();

            int CantidadAfectado = context.Repositories.UsuarioRepository.Actualiza_Condicion(Usu_Id, Usu_Estado);

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

