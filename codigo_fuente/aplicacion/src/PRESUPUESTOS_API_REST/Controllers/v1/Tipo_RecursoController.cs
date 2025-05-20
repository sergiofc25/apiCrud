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
public class Tipo_RecursoController : ControllerBase
{
    private readonly ITipo_RecursoService _Tipo_RecursoService;
    private readonly IMapper _mapper;

    public Tipo_RecursoController(ITipo_RecursoService Tipo_RecursoService, IMapper mapper)
    {
        _Tipo_RecursoService = Tipo_RecursoService;
        _mapper = mapper;
    }


    [HttpGet("Obten")]
    public async Task<IActionResult> Obten()
    {
        try
        {
            var Lst_Tipo_Recurso = await _Tipo_RecursoService.Obten();

            if (Lst_Tipo_Recurso is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Tipo_Recurso_Obten>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Tipo_Recurso_Obten>>(Lst_Tipo_Recurso) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
}

