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
public class RecursoController : ControllerBase
{
    private readonly IRecursoService _RecursoService;
    private readonly IMapper _mapper;

    public RecursoController(IRecursoService RecursoService, IMapper mapper)
    {
        _RecursoService = RecursoService;
        _mapper = mapper;
    }
    
    [HttpGet("Obten_x_Partida/{Par_Id}")]
    public async Task<IActionResult> Obten_x_Partida(int Par_Id)
    {
        try
        {
            var Lst_Recurso = await _RecursoService.Obten_x_Partida(Par_Id);

            if (Lst_Recurso is null) return NotFound(new DTO_Response<object> { ErrorMessage = "Datos no encontrados." });

            return Ok(new DTO_Response<List<DTO_Recurso_Obten_x_Partida>> { IsSuccessful = true, Data = _mapper.Map<List<DTO_Recurso_Obten_x_Partida>>(Lst_Recurso) });

        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor.");
        }
    }

}

