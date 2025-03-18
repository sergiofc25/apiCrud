using Model;
using Model.DTO.v1;
using Model.Entitie;

namespace PRESUPUESTOS_BlazorApp.HttpRepository;
public interface IHttpClienteRepository
{
    Task<PagingResponse<Ent_Cliente>> Obten_Paginado(ClienteParameters Parameters);
}

