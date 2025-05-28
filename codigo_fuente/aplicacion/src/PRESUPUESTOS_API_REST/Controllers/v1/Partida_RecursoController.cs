using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO.v1;
using Model;
using Service;
using System.Text.Json;
using Model.Entitie;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PRESUPUESTOS_API_REST.Controllers.v1;

[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("1")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class Partida_RecursoController : ControllerBase
{
    private readonly IPartida_RecursoService _Partida_RecursoService;
    private readonly IMapper _mapper;

    public Partida_RecursoController(IPartida_RecursoService Partida_RecursoService, IMapper mapper)
    {
        _Partida_RecursoService = Partida_RecursoService;
        _mapper = mapper;
    }
    
    
    [HttpDelete("Elimina_APU/{DetParRec_Id}")]
    public async Task<IActionResult> Elimina_APU(int DetParRec_Id)
    {
        try
        {
            //var Partida_Recurso_Existente = await _Partida_RecursoService.Obten_x_Id(DetParRec_Id);
            //if (Partida_Recurso_Existente is null)
            //    return NotFound(new DTO_Response<object>
            //    {
            //        IsSuccessful = false,
            //        ErrorMessage = "El Partida_Recurso no existe."
            //    });

            var registrosAfectados = await _Partida_RecursoService.Elimina_APU(DetParRec_Id);

            if (registrosAfectados > 0)
                return NoContent(); // 204 No Content (éxito sin datos)
            else
                return StatusCode(500, new DTO_Response<object>
                {
                    IsSuccessful = false,
                    ErrorMessage = "No se pudo eliminar el registro."
                });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new DTO_Response<object>
            {
                IsSuccessful = false,
                ErrorMessage = "Error interno del servidor."
            });
        }
    }
    [HttpGet("Obten_x_Id_APU/{DetParRec_Id}")]
    public async Task<IActionResult> Obten_x_Id_APU(int DetParRec_Id)
    {
        try
        {
            var Partida_Recurso = await _Partida_RecursoService.Obten_x_Id_APU(DetParRec_Id);

            if (Partida_Recurso is null)
                return NotFound();
            return Ok(new DTO_Response<DTO_Partida_Recurso_Obten_x_Id_APU> { IsSuccessful = true, Data = _mapper.Map<DTO_Partida_Recurso_Obten_x_Id_APU>(Partida_Recurso) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpPut("Actualiza_APU/{DetParRec_Id}")]
    public async Task<IActionResult> Actualiza_APU(int DetParRec_Id, [FromBody] DTO_Partida_Recurso_Actualiza_APU eDTO_Partida_Recurso_Actualiza_APU)
    {
        try
        {
            if (eDTO_Partida_Recurso_Actualiza_APU is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Partida_Recurso_Existente = await _Partida_RecursoService.Obten_x_Id_APU(DetParRec_Id);

            var Partida_Recurso_Actualiza = _mapper.Map(eDTO_Partida_Recurso_Actualiza_APU, Partida_Recurso_Existente);

            await _Partida_RecursoService.Actualiza_APU(Partida_Recurso_Actualiza);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

}

