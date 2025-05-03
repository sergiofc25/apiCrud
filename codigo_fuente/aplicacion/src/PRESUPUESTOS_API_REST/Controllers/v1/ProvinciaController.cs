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
public class ProvinciaController : ControllerBase
{
    private readonly IProvinciaService _ProvinciaService;
    private readonly IMapper _mapper;

    public ProvinciaController(IProvinciaService ProvinciaService, IMapper mapper)
    {
        _ProvinciaService = ProvinciaService;
        _mapper = mapper;
    }


    [HttpGet("Obten/{Dep_Nombre}")]
    public async Task<IActionResult> Obten(string Dep_Nombre)
    {
        try
        {
            var Lst_Provincia = await _ProvinciaService.Obten(Dep_Nombre);

            if (Lst_Provincia is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Provincia_Obten>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Provincia_Obten>>(Lst_Provincia) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
}

