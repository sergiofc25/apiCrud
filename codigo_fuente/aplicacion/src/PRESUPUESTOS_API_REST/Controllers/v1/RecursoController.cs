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
public class RecursoController : ControllerBase
{
    private readonly IRecursoService _RecursoService;
    private readonly IMapper _mapper;

    public RecursoController(IRecursoService RecursoService, IMapper mapper)
    {
        _RecursoService = RecursoService;
        _mapper = mapper;
    }
    
    [HttpGet("Obten_x_Partida/{Par_Id}")]
    public async Task<IActionResult> Obten_x_Partida(int Par_Id)
    {
        try
        {
            var Lst_Recurso = await _RecursoService.Obten_x_Partida(Par_Id);

            if (Lst_Recurso is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Recurso_Obten_x_Partida>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Recurso_Obten_x_Partida>>(Lst_Recurso) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    //[HttpPost("Crea_APU")]
    //public async Task<IActionResult> Crea_APU([FromBody] DTO_Recurso_Crea_APU eDTO_Recurso_Crea_APU)
    //{
    //    try
    //    {
    //        if (eDTO_Recurso_Crea_APU is null)
    //            return BadRequest(new { ErrorMessage = "Datos nulo." });

    //        var Recurso = _mapper.Map<Ent_Recurso>(eDTO_Recurso_Crea_APU);
    //        var detParRecId = await _RecursoService.Crea_APU(Recurso);

    //        return Ok(new
    //        {
    //            DetParRec_Id = detParRecId,
    //            IsSuccessful = true
    //        });
    //    }
    //    catch (Exception)
    //    {
    //        return StatusCode(500, "Error interno del servidor.");
    //    }
    //}
    [HttpPost("Crea_APU")]
    public async Task<IActionResult> Crea_APU([FromBody] APURequestWrapper request)
    {
        try
        {
            // 1. Validación del request
            if (request?.eDTO_Recurso_Crea_APU == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Estructura de datos incorrecta. Se esperaba { eDTO_Recurso_Crea_APU: {...} }"
                });
            }

            // 2. Logging para diagnóstico (opcional pero recomendado)
            Console.WriteLine($"Datos recibidos: {JsonSerializer.Serialize(request)}");

            // 3. Mapeo y procesamiento
            var recurso = _mapper.Map<Ent_Recurso>(request.eDTO_Recurso_Crea_APU);
            var detParRecId = await _RecursoService.Crea_APU(recurso);

            return Ok(new
            {
                DetParRec_Id = detParRecId,
                IsSuccessful = true
            });
        }
        catch (Exception ex)
        {
            // Log del error completo
            Console.WriteLine($"Error en Crea_APU: {ex.ToString()}");
            return StatusCode(500, new { ErrorMessage = "Error interno del servidor." });
        }
    }

    // Clase auxiliar para el wrapper del request
    public class APURequestWrapper
    {
        public DTO_Recurso_Crea_APU eDTO_Recurso_Crea_APU { get; set; }
    }
    [HttpGet("Obten")]
    public async Task<IActionResult> Obten()
    {
        try
        {
            var Lst_Recurso = await _RecursoService.Obten();

            if (Lst_Recurso is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Recurso_Obten>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Recurso_Obten>>(Lst_Recurso) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
    [HttpGet("Obten_Precio_x_Partida/{Par_Id}")]
    public async Task<IActionResult> Obten_Precio_x_Partida(int Par_Id)
    {
        try
        {
            var Lst_Recurso = await _RecursoService.Obten_Precio_x_Partida(Par_Id);

            if (Lst_Recurso is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Recurso_Obten_Precio_x_Partida>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Recurso_Obten_Precio_x_Partida>>(Lst_Recurso) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
}

