using Model;
using Model.DTO.v1;

namespace BlazorAppPreWeb.Servicios.Contrato
{
    public interface IUsuarioServicio
    {
        Task<DTO_Response<List<DTO_Usuario_Obten_Paginado>>> Obten_Paginado(ClienteParameters parameters);
        Task<DTO_Response<List<DTO_Usuario_Obten_x_Correo>>> Obten_x_Correo();
    }
}
