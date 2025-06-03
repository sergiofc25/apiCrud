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
    [Authorize(Policy = "NotInvitado")]
    [HttpPost("Crea")]
    public async Task<IActionResult> Crea([FromBody] DTO_SubPresupuesto_Crea eDTO_SubPresupuesto_Crea)
    {
        try
        {
            if (eDTO_SubPresupuesto_Crea is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulo." });

            var SubPresupuesto = _mapper.Map<Ent_SubPresupuesto>(eDTO_SubPresupuesto_Crea);

            SubPresupuesto.SubPre_Id = await _SubPresupuestoService.Crea(SubPresupuesto);

            var SubPresupuestoDTO = _mapper.Map<DTO_SubPresupuesto_Obten_x_Id>(SubPresupuesto);

            return Ok(new DTO_Response<DTO_SubPresupuesto_Obten_x_Id>
            {
                Data = _mapper.Map<DTO_SubPresupuesto_Obten_x_Id>(SubPresupuesto),
                IsSuccessful = true
            });
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [Authorize(Policy = "NotInvitado")]
    [HttpPost("Crea_D/{SubPre_Padre_Id}")]
    public async Task<IActionResult> Crea_D(int SubPre_Padre_Id, [FromBody] DTO_SubPresupuesto_Crea_Dentro eDTO_SubPresupuesto_Crea_Dentro)
    {
        try
        {
            if (eDTO_SubPresupuesto_Crea_Dentro is null)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            // Verificar si el padre existe
            var padreExistente = await _SubPresupuestoService.Obten_x_Id(SubPre_Padre_Id);
            if (padreExistente is null)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "El subpresupuesto padre no existe." });

            // Mapear el DTO a la entidad
            //var SubPresupuesto = _mapper.Map<Ent_SubPresupuesto>(eDTO_SubPresupuesto_Crea_Dentro);
            var SubPresupuesto = _mapper.Map(eDTO_SubPresupuesto_Crea_Dentro, padreExistente);


            // Llamar al servicio pasando tanto el ID del padre como los datos mapeados
            SubPresupuesto.SubPre_Id = await _SubPresupuestoService.Crea_Dentro(SubPre_Padre_Id,SubPresupuesto);

            // Obtener el subpresupuesto recién creado para devolverlo
            var subPresupuestoCreado = await _SubPresupuestoService.Obten_x_Id(SubPresupuesto.SubPre_Id);
            var SubPresupuestoDTO = _mapper.Map<DTO_SubPresupuesto_Obten_x_Id>(subPresupuestoCreado);

            return Ok(new DTO_Response<DTO_SubPresupuesto_Obten_x_Id>
            {
                Data = SubPresupuestoDTO,
                IsSuccessful = true
            });
        }
        catch (Exception ex)
        {
            // Loggear el error (ex) aquí si es necesario
            return StatusCode(500, new DTO_Response<object>
            {
                ErrorMessage = "Error interno del servidor al crear el subpresupuesto."
            });
        }
    }
    [Authorize(Policy = "NotInvitado")]
    [HttpPost("Crea_Primer_Nivel/{Pre_Id}")]
    public async Task<IActionResult> Crea_Primer_Nivel(int Pre_Id, [FromBody] DTO_SubPresupuesto_Crea_Primer_Nivel eDTO_SubPresupuesto_Crea_Primer_Nivel)
    {
        try
        {
            // Validación de entrada
            if (eDTO_SubPresupuesto_Crea_Primer_Nivel == null)
            {
                return BadRequest(new DTO_Response<object>
                {
                    ErrorMessage = "Los datos del subpresupuesto no pueden ser nulos."
                });
            }

            if (Pre_Id <= 0)
            {
                return BadRequest(new DTO_Response<object>
                {
                    ErrorMessage = "El ID del presupuesto principal no es válido."
                });
            }

            // Mapear el DTO a la entidad
            var subPresupuesto = _mapper.Map<Ent_SubPresupuesto>(eDTO_SubPresupuesto_Crea_Primer_Nivel);


            // Crear el subpresupuesto de primer nivel
            var subPresupuestoId = await _SubPresupuestoService.Crea_Primer_Nivel(Pre_Id, subPresupuesto);

            // Obtener el subpresupuesto recién creado
            var subPresupuestoCreado = await _SubPresupuestoService.Obten_x_Id(subPresupuestoId);

            if (subPresupuestoCreado == null)
            {
                return StatusCode(500, new DTO_Response<object>
                {
                    ErrorMessage = "El subpresupuesto se creó pero no se pudo recuperar la información."
                });
            }

            // Mapear a DTO de respuesta
            var subPresupuestoDTO = _mapper.Map<DTO_SubPresupuesto_Obten_x_Id>(subPresupuestoCreado);

            return Ok(new DTO_Response<DTO_SubPresupuesto_Obten_x_Id>
            {
                Data = subPresupuestoDTO,
                IsSuccessful = true
            });
        }
        catch (Exception ex)
        {

            return StatusCode(500, new DTO_Response<object>
            {
                ErrorMessage = $"Error interno del servidor: {ex.Message}",
            });
        }
    }
    [Authorize(Policy = "NotInvitado")]
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
    [Authorize(Policy = "NotInvitado")]
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

