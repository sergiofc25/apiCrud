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
public class SubPresupuestoController : ControllerBase
{
    private readonly ISubPresupuestoService _SubPresupuestoService;
    private readonly IMapper _mapper;

    public SubPresupuestoController(ISubPresupuestoService SubPresupuestoService, IMapper mapper)
    {
        _SubPresupuestoService = SubPresupuestoService;
        _mapper = mapper;
    }
    
    [HttpGet("Obten_x_Presupuesto/{Pre_Id}")]
    public async Task<IActionResult> Obten_x_Nombre(int Pre_Id)
    {
        try
        {
            var Lst_SubPresupuesto = await _SubPresupuestoService.Obten_x_Presupuesto(Pre_Id);

            if (Lst_SubPresupuesto is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_SubPresupuesto_Obten_x_Presupuesto>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_SubPresupuesto_Obten_x_Presupuesto>>(Lst_SubPresupuesto) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }
    

}

