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
public class DistritoController : ControllerBase
{
    private readonly IDistritoService _DistritoService;
    private readonly IMapper _mapper;

    public DistritoController(IDistritoService DistritoService, IMapper mapper)
    {
        _DistritoService = DistritoService;
        _mapper = mapper;
    }


    [HttpGet("Obten/{Prov_Nombre}")]
    public async Task<IActionResult> Obten(string Prov_Nombre)
    {
        try
        {
            var Lst_Distrito = await _DistritoService.Obten(Prov_Nombre);

            if (Lst_Distrito is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Distrito_Obten>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Distrito_Obten>>(Lst_Distrito) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
}

