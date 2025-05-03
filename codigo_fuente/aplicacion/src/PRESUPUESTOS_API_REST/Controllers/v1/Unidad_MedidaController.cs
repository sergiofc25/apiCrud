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
public class Unidad_MedidaController : ControllerBase
{
    private readonly IUnidad_MedidaService _Unidad_MedidaService;
    private readonly IMapper _mapper;

    public Unidad_MedidaController(IUnidad_MedidaService Unidad_MedidaService, IMapper mapper)
    {
        _Unidad_MedidaService = Unidad_MedidaService;
        _mapper = mapper;
    }


    [HttpGet("Obten")]
    public async Task<IActionResult> Obten()
    {
        try
        {
            var Lst_Unidad_Medida = await _Unidad_MedidaService.Obten();

            if (Lst_Unidad_Medida is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Unidad_Medida_Obten>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Unidad_Medida_Obten>>(Lst_Unidad_Medida) });
        }
        catch (Exception)
        {
            return StatusCode(500, new DTO_Response<object> { ErrorMessage = "Error interno del servidor." });
        }
    }
}

