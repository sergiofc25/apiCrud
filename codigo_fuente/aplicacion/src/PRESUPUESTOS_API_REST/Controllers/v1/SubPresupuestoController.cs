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
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class SubPresupuestoController : ControllerBase
{
    private readonly ISubPresupuestoService _SubPresupuestoService;
    private readonly IMapper _mapper;

    public SubPresupuestoController(ISubPresupuestoService SubPresupuestoService, IMapper mapper)
    {
        _SubPresupuestoService = SubPresupuestoService;
        _mapper = mapper;
    }
    
    [HttpGet("Obten_x_Presupuesto/{Pre_Id}")]
    public async Task<IActionResult> Obten_x_Nombre(int Pre_Id)
    {
        try
        {
            var Lst_SubPresupuesto = await _SubPresupuestoService.Obten_x_Presupuesto(Pre_Id);

            if (Lst_SubPresupuesto is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_SubPresupuesto_Obten_x_Presupuesto>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_SubPresupuesto_Obten_x_Presupuesto>>(Lst_SubPresupuesto) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpGet("Obten_x_Id/{SubPre_Id}")]
    public async Task<IActionResult> Obten_x_Id(int SubPre_Id)
    {
        try
        {
            var SubPresupuesto = await _SubPresupuestoService.Obten_x_Id(SubPre_Id);

            if (SubPresupuesto is null)
                return NotFound();
            return Ok(new DTO_Response<DTO_SubPresupuesto_Obten_x_Id> { IsSuccessful = true, Data = _mapper.Map<DTO_SubPresupuesto_Obten_x_Id>(SubPresupuesto) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpPut("Actualiza/{SubPre_Id}")]
    public async Task<IActionResult> Actualiza(int SubPre_Id, [FromBody] DTO_SubPresupuesto_Actualiza_Nombre eDTO_SubPresupuesto_Actualiza_Nombre)
    {
        try
        {
            if (eDTO_SubPresupuesto_Actualiza_Nombre is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var SubPresupuesto_Existente = await _SubPresupuestoService.Obten_x_Id(SubPre_Id);

            if (SubPresupuesto_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existentes." });

            var SubPresupuesto_Actualiza = _mapper.Map(eDTO_SubPresupuesto_Actualiza_Nombre, SubPresupuesto_Existente);

            await _SubPresupuestoService.Actualiza_Nombre(SubPresupuesto_Actualiza);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
    [HttpDelete("Elimina/{SubPre_Id}")]
    public async Task<IActionResult> Elimina(int SubPre_Id)
    {
        try
        {
            var SubPresupuesto_Existente = await _SubPresupuestoService.Obten_x_Id(SubPre_Id);
            if (SubPresupuesto_Existente is null)
                return NotFound(new DTO_Response<object>
                {
                    IsSuccessful = false,
                    ErrorMessage = "El subpresupuesto no existe."
                });

            var registrosAfectados = await _SubPresupuestoService.Elimina(SubPre_Id);

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

}

