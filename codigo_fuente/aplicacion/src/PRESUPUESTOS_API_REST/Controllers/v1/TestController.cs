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
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace PRESUPUESTOS_API_REST.Controllers.v1;

[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("1")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    [AllowAnonymous]
    public IActionResult Test()
    {
        return Ok("Funciona correctamente");
    }
    [HttpGet("db-test")]
    [AllowAnonymous]
    public IActionResult TestDb()
    {
        string connectionString = "Server=db16225.databaseasp.net; Database=db16225; User Id=db16225; Password=d-3QY9s+7h!N; Encrypt=False; MultipleActiveResultSets=True;";

        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return Ok("✅ DB conectada");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"❌ Error: {ex.Message}");
        }
    }
}

