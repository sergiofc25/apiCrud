using Model;
using Model.DTO.v1;

namespace BlazorAppPreWeb.Servicios.Contrato
{
    public interface IPresupuestoServicio
    {
        Task<DTO_Response<List<DTO_Presupuesto_Obten_Paginado>>> Obten_Paginado(ClienteParameters parameters);
    }
}
