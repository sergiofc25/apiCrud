using Model;
using Model.DTO.v1;

namespace BlazorAppPreWeb.Servicios.Contrato
{
    public interface IClienteServicio
    {
        Task<DTO_Response<List<DTO_Cliente_Obten_Paginado>>> Obten_Paginado(ClienteParameters parameters);
    }
}
