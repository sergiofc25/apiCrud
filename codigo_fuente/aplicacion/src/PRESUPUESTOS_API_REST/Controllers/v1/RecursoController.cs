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
    [HttpGet("Obten_x_Id/{Rec_Id}")]
    public async Task<IActionResult> Obten_x_Id(int Rec_Id)
    {
        try
        {
            var Recurso = await _RecursoService.Obten_x_Id(Rec_Id);

            if (Recurso is null)
                return NotFound();
            return Ok(new DTO_Response<DTO_Recurso_Obten_x_Id> { IsSuccessful = true, Data = _mapper.Map<DTO_Recurso_Obten_x_Id>(Recurso) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpGet("Obten_Paginado/{RegistroPagina}/{NumeroPagina}")]
    public async Task<IActionResult> Obten_Paginado(int RegistroPagina, int NumeroPagina, [FromQuery] string? PorNombre = null)
    {
        try
        {
            (int TotalPagina, int TotalRegistro, bool TienePaginaAnterior, bool TienePaginaProximo, var Lst_Recurso) = await _RecursoService.Obten_Paginado(RegistroPagina, NumeroPagina, PorNombre);

            var metadata = new
            {
                RegistroPagina,
                NumeroPagina,
                TotalPagina,
                TotalRegistro,
                TienePaginaAnterior,
                TienePaginaProximo
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(new DTO_ResponsePag<IEnumerable<DTO_Recurso_Obten_Paginado>>
            {
                PaginaActual = NumeroPagina,
                TotalDePagina = TotalPagina,
                ElementosPorPagina = RegistroPagina,
                TotalDeElementos = TotalRegistro,
                IsSuccessful = true,
                Data = _mapper.Map<IEnumerable<DTO_Recurso_Obten_Paginado>>(Lst_Recurso)
            });
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }

    [HttpPost("Crea")]
    public async Task<IActionResult> Crea([FromBody] DTO_Recurso_Crea eDTO_Recurso_Crea)
    {
        try
        {
            if (eDTO_Recurso_Crea == null)
            {
                return BadRequest(new DTO_Response<object>
                {
                    IsSuccessful = false,
                    ErrorMessage = "Los datos del recurso no pueden ser nulos."
                });
            }

            // Mapear DTO a entidad
            var recurso = _mapper.Map<Ent_Recurso>(eDTO_Recurso_Crea);

            // Crear el recurso
            var (Rec_Id, mensajeError) = await _RecursoService.Crea(recurso);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                return BadRequest(new DTO_Response<object>
                {
                    IsSuccessful = false,
                    ErrorMessage = mensajeError
                });
            }

            // Obtener el recurso completo recién creado
            var recursoCompleto = await _RecursoService.Obten_x_Id(Rec_Id);

            if (recursoCompleto == null)
            {
                return StatusCode(500, new DTO_Response<object>
                {
                    IsSuccessful = false,
                    ErrorMessage = "El recurso se creó pero no se pudo recuperar la información completa."
                });
            }

            // Mapear a DTO de respuesta
            var recursoCreadoDTO = _mapper.Map<DTO_Recurso_Obten_x_Id>(recursoCompleto);

            return Ok(new DTO_Response<DTO_Recurso_Obten_x_Id>
            {
                Data = recursoCreadoDTO,
                IsSuccessful = true,
                ErrorMessage = "Recurso creado exitosamente."
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new DTO_Response<object>
            {
                IsSuccessful = false,
                ErrorMessage = $"Error interno del servidor: {ex.Message}"
            });
        }
    }
    
    [HttpPut("Actualiza/{Rec_Id}")]
    public async Task<IActionResult> Actualiza(int Rec_Id, [FromBody] DTO_Recurso_Actualiza eDTO_Recurso_Actualiza)
    {
        try
        {
            // Validación de datos nulos
            if (eDTO_Recurso_Actualiza is null)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            // Verificar existencia del recurso
            var RecursoExiste = await _RecursoService.Obten_x_Id(Rec_Id);
            if (RecursoExiste is null)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos inexistentes." });

            // Mapear y actualizar
            _mapper.Map(eDTO_Recurso_Actualiza, RecursoExiste);
            var mensajeError = await _RecursoService.Actualiza(RecursoExiste);

            // Manejar respuesta
            if (mensajeError == string.Empty)
                return Ok(new DTO_Response<object>
                {
                    IsSuccessful = true
                });

            return BadRequest(new DTO_Response<object> { ErrorMessage = mensajeError });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

    [HttpPut("Actualiza_Condicion/{Rec_Id}")]
    public async Task<IActionResult> Actualiza_Condicion(int Rec_Id, [FromBody] DTO_Recurso_Actualiza_Condicion eDTO_Recurso_Actualiza_Condicion)
    {
        try
        {
            if (eDTO_Recurso_Actualiza_Condicion is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Recurso_Existente = await _RecursoService.Obten_x_Id(Rec_Id);

            if (Recurso_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existes." });

            var Recurso = _mapper.Map(eDTO_Recurso_Actualiza_Condicion, Recurso_Existente);

            await _RecursoService.Actualiza_Condicion(Recurso.Rec_Id, Recurso.Rec_Estado);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
}

