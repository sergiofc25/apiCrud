using Model;
using Model.DTO.v1;
using Model.Entitie;

namespace BlazorAppPreWeb.HttpRepository.Interface;
public interface IHttpPresupuestoRepository
{
    Task<PagingResponse<Ent_Presupuesto>> Obten_Paginado(ClienteParameters Parameters);
}

