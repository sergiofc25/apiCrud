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
public class PartidaController : ControllerBase
{
    private readonly IPartidaService _PartidaService;
    private readonly IMapper _mapper;

    public PartidaController(IPartidaService PartidaService, IMapper mapper)
    {
        _PartidaService = PartidaService;
        _mapper = mapper;
    }
    
    [HttpGet("Obten_x_SubPresupuesto/{SubPre_Id}")]
    public async Task<IActionResult> Obten_x_SubPresupuesto(int SubPre_Id)
    {
        try
        {
            var Lst_Partida = await _PartidaService.Obten_x_SubPresupuesto(SubPre_Id);

            if (Lst_Partida is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Partida_Obten_x_SubPresupuesto>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Partida_Obten_x_SubPresupuesto>>(Lst_Partida) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }

}

