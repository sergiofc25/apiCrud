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
public class PartidaController : ControllerBase
{
    private readonly IPartidaService _PartidaService;
    private readonly IMapper _mapper;

    public PartidaController(IPartidaService PartidaService, IMapper mapper)
    {
        _PartidaService = PartidaService;
        _mapper = mapper;
    }
    
    [HttpGet("Obten_x_SubPresupuesto/{SubPre_Id}")]
    public async Task<IActionResult> Obten_x_SubPresupuesto(int SubPre_Id)
    {
        try
        {
            var Lst_Partida = await _PartidaService.Obten_x_SubPresupuesto(SubPre_Id);

            if (Lst_Partida is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Partida_Obten_x_SubPresupuesto>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Partida_Obten_x_SubPresupuesto>>(Lst_Partida) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpGet("Obten_x_Id/{Par_Id}")]
    public async Task<IActionResult> Obten_x_Id(int Par_Id)
    {
        try
        {
            var Partida = await _PartidaService.Obten_x_Id(Par_Id);

            if (Partida is null)
                return NotFound();
            return Ok(new DTO_Response<DTO_Partida_Obten_x_Id> { IsSuccessful = true, Data = _mapper.Map<DTO_Partida_Obten_x_Id>(Partida) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpPost("Crea")]
    public async Task<IActionResult> Crea([FromBody] DTO_Partida_Crea eDTO_Partida_Crea)
    {
        try
        {
            if (eDTO_Partida_Crea is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulo." });

            var Partida = _mapper.Map<Ent_Partida>(eDTO_Partida_Crea);

            Partida.Par_Id = await _PartidaService.Crea(Partida);

            var PartidaDTO = _mapper.Map<DTO_Partida_Obten_x_Id>(Partida);

            return Ok(new DTO_Response<DTO_Partida_Obten_x_Id>
            {
                Data = _mapper.Map<DTO_Partida_Obten_x_Id>(Partida),
                IsSuccessful = true
            });
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpPut("Actualiza/{Par_Id}")]
    public async Task<IActionResult> Actualiza(int Par_Id, [FromBody] DTO_Partida_Actualiza eDTO_Partida_Actualiza)
    {
        try
        {
            if (eDTO_Partida_Actualiza is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Partida_Existente = await _PartidaService.Obten_x_Id(Par_Id);

            var Partida_Actualiza = _mapper.Map(eDTO_Partida_Actualiza, Partida_Existente);

            await _PartidaService.Actualiza(Partida_Actualiza);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
    [HttpPut("Inhabilita/{Par_Id}")]
    public async Task<IActionResult> Inhabilita(int Par_Id, [FromBody] DTO_Partida_Inhabilita eDTO_Partida_Inhabilita)
    {
        try
        {
            if (eDTO_Partida_Inhabilita is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Partida_Existente = await _PartidaService.Obten_x_Id(Par_Id);

            if (Partida_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existes." });

            var Partida = _mapper.Map(eDTO_Partida_Inhabilita, Partida_Existente);

            await _PartidaService.Inhabilita(Partida.Par_Id, Partida.Par_Estado);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

}

