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
public class PresupuestoController : ControllerBase
{
    private readonly IPresupuestoService _PresupuestoService;
    private readonly IMapper _mapper;

    public PresupuestoController(IPresupuestoService presupuestoService, IMapper mapper)
    {
        _PresupuestoService = presupuestoService;
        _mapper = mapper;
    }

    [HttpGet("Obten_Paginado/{RegistroPagina}/{NumeroPagina}/{PorPresupuesto}")]
    public async Task<IActionResult> Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorPresupuesto= " ")
    {
        try
        {
            (int TotalPagina, int TotalRegistro, bool TienePaginaAnterior, bool TienePaginaProximo, var Lst_Presupuesto) = await _PresupuestoService.Obten_Paginado(RegistroPagina, NumeroPagina, PorPresupuesto);

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
            return Ok(new DTO_ResponsePag<IEnumerable<DTO_Presupuesto_Obten_Paginado>> { PaginaActual = NumeroPagina, 
                TotalDePagina = TotalPagina,ElementosPorPagina = RegistroPagina,TotalDeElementos = TotalRegistro, IsSuccessful = true, 
                Data = _mapper.Map<IEnumerable<DTO_Presupuesto_Obten_Paginado>>(Lst_Presupuesto) });
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }

    [HttpGet("{Pre_Id}", Name = "Presupuesto_Obten_x_Id")]
    public async Task<IActionResult> Obten_x_Id(int Pre_Id)
    {
        try
        {
            var Presupuesto = await _PresupuestoService.Obten_x_Id(Pre_Id);

            if (Presupuesto is null)
                return NotFound();
            return Ok(new DTO_Response<DTO_Presupuesto_Obten_x_Id> { IsSuccessful = true, Data = _mapper.Map<DTO_Presupuesto_Obten_x_Id>(Presupuesto) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }

    [HttpPost("Crea")]
    public async Task<IActionResult> Crea([FromBody] DTO_Presupuesto_Crea eDTO_Presupuesto_Crea)
    {
        try
        {
            if (eDTO_Presupuesto_Crea is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulo." });

            var CantidadHabilitado = await _PresupuestoService.Existe(eDTO_Presupuesto_Crea.Pre_Nombre, true);
            var CantidadInhabilitado = await _PresupuestoService.Existe(eDTO_Presupuesto_Crea.Pre_Nombre, false);

            if (CantidadHabilitado > 0)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes." });

            if (CantidadInhabilitado > 0)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes con condición Inhabilitado." });

            var Presupuesto = _mapper.Map<Ent_Presupuesto>(eDTO_Presupuesto_Crea);

            Presupuesto.Pre_Id = await _PresupuestoService.Crea(Presupuesto);

            var PresupuestoDTO = _mapper.Map<DTO_Presupuesto_Obten_x_Id>(Presupuesto);

            return CreatedAtRoute("Presupuesto_Obten_x_Id", new { Presupuesto.Pre_Id }, PresupuestoDTO);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpPut("Actualiza/{Pre_Id}")]
    public async Task<IActionResult> Actualiza(int Pre_Id, [FromBody] DTO_Presupuesto_Actualiza eDTO_Presupuesto_Actualiza)
    {
        try
        {
            if (eDTO_Presupuesto_Actualiza is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Presupuesto_Existente = await _PresupuestoService.Obten_x_Id(Pre_Id);

            if (Presupuesto_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existentes." });

            var CantidadHabilitado = await _PresupuestoService.Existente(Pre_Id, eDTO_Presupuesto_Actualiza.Pre_Nombre,true);
            var CantidadInhabilitado = await _PresupuestoService.Existente(Pre_Id, eDTO_Presupuesto_Actualiza.Pre_Nombre, false);
            

            if (CantidadHabilitado > 0) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes." });

            if (CantidadInhabilitado > 0) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes con condición inhabilitado." });

            var Presupuesto_Actualiza = _mapper.Map(eDTO_Presupuesto_Actualiza, Presupuesto_Existente);

            await _PresupuestoService.Actualiza(Presupuesto_Actualiza);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

    [HttpPut("Actualiza_Condicion/{Pre_Id}")]
    public async Task<IActionResult> Actualiza_Condicion(int Pre_Id, [FromBody] DTO_Presupuesto_Actualiza_Condicion eDTO_Presupuesto_Actualiza_Condicion)
    {
        try
        {
            if (eDTO_Presupuesto_Actualiza_Condicion is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Presupuesto_Existente = await _PresupuestoService.Obten_x_Id(Pre_Id);

            if (Presupuesto_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existes." });

            var Presupuesto = _mapper.Map(eDTO_Presupuesto_Actualiza_Condicion, Presupuesto_Existente);

            await _PresupuestoService.Actualiza_Condicion(Presupuesto.Pre_Id, Presupuesto.Pre_Estado);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

}

