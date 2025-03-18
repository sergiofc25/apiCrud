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
public class ClienteController : ControllerBase
{
    private readonly IClienteService _ClienteService;
    private readonly IMapper _mapper;

    public ClienteController(IClienteService clienteService, IMapper mapper)
    {
        _ClienteService = clienteService;
        _mapper = mapper;
    }
    //[Authorize(Roles = "Administrador")]
    [HttpGet("Obten_Paginado/{RegistroPagina}/{NumeroPagina}")]
    //[HttpGet("{RegistroPagina}/{NumeroPagina}/{PorNDocumento}", Name = "Obten_Paginado")]
    public async Task<IActionResult> Obten_Paginado(int RegistroPagina, int NumeroPagina, [FromQuery] string? PorNDocumento = null)
    {
        try
        {
            PorNDocumento ??= string.Empty;
            (int TotalPagina, int TotalRegistro, bool TienePaginaAnterior, bool TienePaginaProximo, var Lst_Cliente) = await _ClienteService.Obten_Paginado(RegistroPagina, NumeroPagina, PorNDocumento);

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

            //return Ok(_mapper.Map<IEnumerable<DTO_Cliente_Obten_Paginado>>(Lst_Cliente));
            return Ok(new DTO_ResponsePag<IEnumerable<DTO_Cliente_Obten_Paginado>>
            {
                PaginaActual = NumeroPagina,
                TotalDePagina = TotalPagina,
                ElementosPorPagina = RegistroPagina,
                TotalDeElementos = TotalRegistro,
                IsSuccessful = true,
                Data = _mapper.Map<IEnumerable<DTO_Cliente_Obten_Paginado>>(Lst_Cliente)
            });
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpGet("Obten_Nombre")]
    public async Task<IActionResult> Obten()
    {
        try
        {
            var Lst_Cliente = await _ClienteService.Obten_Nombre();

            if (Lst_Cliente is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Cliente_Obten_Nombre>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Cliente_Obten_Nombre>>(Lst_Cliente) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
    [HttpGet("Obten_x_Nombre/{Cli_NomApeRazSocial}")]
    public async Task<IActionResult> Obten_x_Nombre(string Cli_NomApeRazSocial)
    {
        try
        {
            var Lst_Cliente = await _ClienteService.Obten_x_Nombre(Cli_NomApeRazSocial);

            if (Lst_Cliente is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Cliente_Obten_x_Nombre>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Cliente_Obten_x_Nombre>>(Lst_Cliente) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpGet("Obten_x_Id/{Cli_Id}")]
    //[HttpGet("{Cli_Id}", Name = "Cliente_Obten_x_Id")]
    public async Task<IActionResult> Obten_x_Id(int Cli_Id)
    {
        try
        {
            var Cliente = await _ClienteService.Obten_x_Id(Cli_Id);

            if (Cliente is null)
                return NotFound();
            //return Ok(_mapper.Map<DTO_Cliente_Obten_x_Id>(Cliente));
            return Ok(new DTO_Response<DTO_Cliente_Obten_x_Id> { IsSuccessful = true, Data = _mapper.Map<DTO_Cliente_Obten_x_Id>(Cliente) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }

    [HttpPost("Crea")]
    public async Task<IActionResult> Crea([FromBody] DTO_Cliente_Crea eDTO_Cliente_Crea)
    {
        try
        {
            if (eDTO_Cliente_Crea is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulo." });

            //var validatorResult = new FluentValidator_Cliente_Crea().Validate(eDTO_Cliente_Crea);

            //if (!validatorResult.IsValid) return BadRequest("Datos inválidos.");

            var CantidadHabilitado = await _ClienteService.Existe(eDTO_Cliente_Crea.Cli_NumDocumento, true);
            var CantidadInhabilitado = await _ClienteService.Existe(eDTO_Cliente_Crea.Cli_NumDocumento, false);

            if (CantidadHabilitado > 0)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes." });

            if (CantidadInhabilitado > 0)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes con condición Inhabilitado." });

            var Cliente = _mapper.Map<Ent_Cliente>(eDTO_Cliente_Crea);

            Cliente.Cli_Id = await _ClienteService.Crea(Cliente);

            var ClienteDTO = _mapper.Map<DTO_Cliente_Obten_x_Id>(Cliente);

            return CreatedAtRoute("Cliente_Obten_x_Id", new { Cliente.Cli_Id }, ClienteDTO);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [HttpPut("Actualiza/{Cli_Id}")]
    public async Task<IActionResult> Actualiza(int Cli_Id, [FromBody] DTO_Cliente_Actualiza eDTO_Cliente_Actualiza)
    {
        try
        {
            if (eDTO_Cliente_Actualiza is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            //var validatorResult = new FluentValidator_Cliente_Actualiza().Validate(eDTO_Cliente_Actualiza);

            //if (!validatorResult.IsValid) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos inválidos." });

            var Cliente_Existente = await _ClienteService.Obten_x_Id(Cli_Id);

            if (Cliente_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existentes." });

            var CantidadHabilitado = await _ClienteService.Existente(Cli_Id,eDTO_Cliente_Actualiza.Cli_NumDocumento,true);
            var CantidadInhabilitado = await _ClienteService.Existente(Cli_Id,eDTO_Cliente_Actualiza.Cli_NumDocumento,false);
            

            if (CantidadHabilitado > 0) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes." });

            if (CantidadInhabilitado > 0) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes con condición inhabilitado." });

            var Cliente_Actualiza = _mapper.Map(eDTO_Cliente_Actualiza, Cliente_Existente);

            await _ClienteService.Actualiza(Cliente_Actualiza);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

    [HttpPut("Actualiza_Condicion/{Cli_Id}")]
    public async Task<IActionResult> Actualiza_Condicion(int Cli_Id, [FromBody] DTO_Cliente_Actualiza_Condicion eDTO_Cliente_Actualiza_Condicion)
    {
        try
        {
            if (eDTO_Cliente_Actualiza_Condicion is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            //var validatorResult = new FluentValidator_Cliente_Actualiza_Condicion().Validate(eDTO_Cliente_Actualiza_Condicion);

            //if (!validatorResult.IsValid) return BadRequest("Datos inválidos.");

            var Cliente_Existente = await _ClienteService.Obten_x_Id(Cli_Id);

            if (Cliente_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existes." });

            var Cliente = _mapper.Map(eDTO_Cliente_Actualiza_Condicion, Cliente_Existente);

            await _ClienteService.Actualiza_Condicion(Cliente.Cli_Id, Cliente.Cli_Estado);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

}

