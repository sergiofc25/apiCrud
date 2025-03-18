using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO.v1;
using Model;
using Service;
using System.Text.Json;
using Model.Entitie;
using PRESUPUESTOS_API_REST.TokenServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PRESUPUESTOS_API_REST.Controllers.v1;

[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("1")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]


public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _UsuarioService;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService UsuarioService, IMapper mapper)
    {
        _UsuarioService = UsuarioService;
        _mapper = mapper;
    }
    [Authorize(Roles = "Administrador")]
    [HttpGet("Obten_Paginado/{RegistroPagina}/{NumeroPagina}/{PorCorreo}")]
    public async Task<IActionResult> Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorCorreo = " ")
    {
        try
        {
            (int TotalPagina, int TotalRegistro, bool TienePaginaAnterior, bool TienePaginaProximo, var Lst_Usuario) = await _UsuarioService.Obten_Paginado(RegistroPagina, NumeroPagina, PorCorreo);

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
            return Ok(new DTO_ResponsePag<IEnumerable<DTO_Usuario_Obten_Paginado>> {
                PaginaActual = NumeroPagina,
                TotalDePagina = TotalPagina,
                ElementosPorPagina = RegistroPagina,
                TotalDeElementos = TotalRegistro,
                IsSuccessful = true, Data = _mapper.Map<IEnumerable<DTO_Usuario_Obten_Paginado>>(Lst_Usuario) });
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [Authorize(Roles = "Administrador")]
    [HttpGet("{Usu_Id}", Name = "Usuario_Obten_x_Id")]
    public async Task<IActionResult> Obten_x_Id(int Usu_Id)
    {
        try
        {
            var Usuario = await _UsuarioService.Obten_x_Id(Usu_Id);

            if (Usuario is null)
                return NotFound();
            return Ok(new DTO_Response<DTO_Usuario_Obten_x_Id> { IsSuccessful = true, Data = _mapper.Map<DTO_Usuario_Obten_x_Id>(Usuario) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [Authorize(Roles = "Administrador")]
    [HttpPost("Crea")]
    public async Task<IActionResult> Crea([FromBody] DTO_Usuario_Crea eDTO_Usuario_Crea)
    {
        try
        {
            if (eDTO_Usuario_Crea is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulo." });

            var CantidadHabilitado = await _UsuarioService.Existe(eDTO_Usuario_Crea.Usu_Correo, true);
            var CantidadInhabilitado = await _UsuarioService.Existe(eDTO_Usuario_Crea.Usu_Correo, false);

            if (CantidadHabilitado > 0)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes." });

            if (CantidadInhabilitado > 0)
                return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes con condición Inhabilitado." });

            var Usuario = _mapper.Map<Ent_Usuario>(eDTO_Usuario_Crea);

            Usuario.Usu_Id = await _UsuarioService.Crea(Usuario);

            var UsuarioDTO = _mapper.Map<DTO_Usuario_Obten_x_Id>(Usuario);

            return CreatedAtRoute("Usuario_Obten_x_Id", new { Usuario.Usu_Id }, UsuarioDTO);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("Actualiza/{Usu_Id}")]
    public async Task<IActionResult> Actualiza(int Usu_Id, [FromBody] DTO_Usuario_Actualiza eDTO_Usuario_Actualiza)
    {
        try
        {
            if (eDTO_Usuario_Actualiza is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Usuario_Existente = await _UsuarioService.Obten_x_Id(Usu_Id);

            if (Usuario_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existentes." });

            var CantidadHabilitado = await _UsuarioService.Existente(Usu_Id, eDTO_Usuario_Actualiza.Usu_Correo, true);
            var CantidadInhabilitado = await _UsuarioService.Existente(Usu_Id, eDTO_Usuario_Actualiza.Usu_Correo, false);


            if (CantidadHabilitado > 0) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes." });

            if (CantidadInhabilitado > 0) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos ya existentes con condición inhabilitado." });

            var Usuario_Actualiza = _mapper.Map(eDTO_Usuario_Actualiza, Usuario_Existente);

            await _UsuarioService.Actualiza(Usuario_Actualiza);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("Actualiza_Condicion/{Usu_Id}")]
    public async Task<IActionResult> Actualiza_Condicion(int Usu_Id, [FromBody] DTO_Usuario_Actualiza_Condicion eDTO_Usuario_Actualiza_Condicion)
    {
        try
        {
            if (eDTO_Usuario_Actualiza_Condicion is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos nulos." });

            var Usuario_Existente = await _UsuarioService.Obten_x_Id(Usu_Id);

            if (Usuario_Existente is null) return BadRequest(new DTO_Response<object> { ErrorMessage = "Datos no existes." });

            var Usuario = _mapper.Map(eDTO_Usuario_Actualiza_Condicion, Usuario_Existente);

            await _UsuarioService.Actualiza_Condicion(Usuario.Usu_Id, Usuario.Usu_Estado);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }

    [HttpGet("Obten_Usuario_Logeado")]
    public async Task<IActionResult> Obten_Usuario_Logeado()
    {
        try
        {
            var Usu_Correo = User.FindFirst(ClaimTypes.Email).Value;
            var Usuario = await _UsuarioService.Obten_x_Correo(Usu_Correo);

            if (Usuario is null)
                return NotFound();
            return Ok(new DTO_Response<DTO_Usuario_Obten_x_Correo> { IsSuccessful = true, Data = _mapper.Map<DTO_Usuario_Obten_x_Correo>(Usuario) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }

}
