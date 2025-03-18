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

namespace PRESUPUESTOS_API_REST.Controllers.v1;

[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("1")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;
    private readonly ITokenService _tokenService;
    private readonly IUsuarioService UsuarioService;
    private IMapper _mapper;

    public AccountsController(IConfiguration configuration, IUsuarioService UsuarioService, IMapper mapper, ITokenService tokenService)
    {
        this.UsuarioService = UsuarioService;
        _mapper = mapper;
        _configuration = configuration;
        _jwtSettings = _configuration.GetSection("JwtSettings");

        _tokenService = tokenService;
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] DTO_Usuario_Obten_Login eDTO_Usuario_Obten_Login)
    {
        var Usuario = await UsuarioService.Obten_x_Correo(eDTO_Usuario_Obten_Login.Usu_Correo);

        if (Usuario == null || await UsuarioService.Obten_Login(eDTO_Usuario_Obten_Login.Usu_Correo, eDTO_Usuario_Obten_Login.Usu_Clave) == 0)
            return Unauthorized(new DTO_AuthResponse { ErrorMessage = "Autenticación no válida." });

        var signingCredentials = _tokenService.GetSigningCredentials();
        var claims = _tokenService.GetClaims(Usuario);
        var tokenOptions = _tokenService.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        Usuario.Usu_TokenActualizado = _tokenService.GenerateRefreshToken();
        Usuario.Usu_FecHoraTokenActualizado= DateTime.Now.AddDays(3);

        var expirationTime = tokenOptions.ValidTo.ToLocalTime();

        // Crear DateTimeOffset para Perú
        //var peruTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
        //DateTimeOffset expirationTime = TimeZoneInfo.ConvertTime(tokenOptions.ValidTo, peruTimeZone);

        await UsuarioService.Actualiza_Token(Usuario);

        return Ok(new DTO_AuthResponse { IsAuthSuccessful = true, Token = token, RefreshToken = Usuario.Usu_TokenActualizado, Expires = expirationTime });
    }

}

