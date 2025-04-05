using Model;
using Model.DTO.v1;

namespace BlazorAppPreWeb.Servicios.Contrato
{
    public interface ITIpo_DocumentoServicio
    {
        Task<DTO_Response<List<DTO_Tipo_Documento_Obten>>> Obten();
    }
}
