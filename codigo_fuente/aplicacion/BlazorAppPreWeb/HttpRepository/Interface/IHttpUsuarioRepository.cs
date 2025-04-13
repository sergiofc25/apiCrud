using Model;
using Model.DTO.v1;
using Model.Entitie;

namespace BlazorAppPreWeb.HttpRepository.Interface;
public interface IHttpUsuarioRepository
{
    Task<PagingResponse<Ent_Usuario>> Obten_Paginado(ClienteParameters Parameters);
}

