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
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoService _DepartamentoService;
    private readonly IMapper _mapper;

    public DepartamentoController(IDepartamentoService DepartamentoService, IMapper mapper)
    {
        _DepartamentoService = DepartamentoService;
        _mapper = mapper;
    }


    [HttpGet("Obten/{Pai_Nombre}")]
    public async Task<IActionResult> Obten(string Pai_Nombre)
    {
        try
        {
            var Lst_Departamento = await _DepartamentoService.Obten(Pai_Nombre);

            if (Lst_Departamento is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Departamento_Obten>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Departamento_Obten>>(Lst_Departamento) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
}

