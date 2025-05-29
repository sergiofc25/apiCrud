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
public class RolController : ControllerBase
{
    private readonly IRolService _RolService;
    private readonly IMapper _mapper;

    public RolController(IRolService RolService, IMapper mapper)
    {
        _RolService = RolService;
        _mapper = mapper;
    }


    [HttpGet("Obten")]
    public async Task<IActionResult> Obten()
    {
        try
        {
            var Lst_Rol = await _RolService.Obten();

            if (Lst_Rol is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Rol_Obten>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Rol_Obten>>(Lst_Rol) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
}

