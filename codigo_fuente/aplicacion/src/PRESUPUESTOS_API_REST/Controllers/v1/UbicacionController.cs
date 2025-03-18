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
public class UbicacionController : ControllerBase
{
    private readonly IUbicacionService _UbicacionService;
    private readonly IMapper _mapper;

    public UbicacionController(IUbicacionService UbicacionService, IMapper mapper)
    {
        _UbicacionService = UbicacionService;
        _mapper = mapper;
    }


    [HttpGet("Obten_x_Nombre/{Ubi_Departamento}/{Ubi_Provincia}/{Ubi_Distrito}")]
    public async Task<IActionResult> Obten_x_Nombre(string Ubi_Departamento = " ", string Ubi_Provincia=" ", string Ubi_Distrito = " ")
    {
        try
        {
            var Lst_Ubicacion = await _UbicacionService.Obten_x_Nombre(Ubi_Departamento, Ubi_Provincia, Ubi_Distrito);

            if (Lst_Ubicacion is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Ubicacion_Obten_x_Nombre>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Ubicacion_Obten_x_Nombre>>(Lst_Ubicacion) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
}

