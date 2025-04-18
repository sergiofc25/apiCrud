
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PRESUPUESTOS_API_REST.TokenServices;
using Service;
using System.Text;
using UnitOfWork_Interface;
using UnitOfWork_SqlServer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowAllOrigins", opt => opt
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("X-Pagination"));
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontend",
//        builder =>
//        {
//            builder.WithOrigins("https://apipruebaweb.runasp.net", "https://apiprueba.runasp.net")
//                   .AllowAnyHeader()
//                   .AllowAnyMethod()
//                   .WithExposedHeaders("X-Pagination");
//        });
//});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddTransient<IUnitOfWork, UnitOfWorkSqlServer>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<ITipo_DocumentoService, Tipo_DocumentoService>();
builder.Services.AddTransient<IPaisService, PaisService>();
builder.Services.AddTransient<IDepartamentoService, DepartamentoService>();
builder.Services.AddTransient<IProvinciaService, ProvinciaService>();
builder.Services.AddTransient<IDistritoService, DistritoService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IPresupuestoService, PresupuestoService>();
builder.Services.AddTransient<ISubPresupuestoService, SubPresupuestoService>();
builder.Services.AddTransient<ITokenService, TokenService>();

//var jwtSettings = builder.Configuration.GetSection("JWTSettings");


//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,

//        ValidIssuer = jwtSettings["validIssuer"],
//        ValidAudience = jwtSettings["validAudience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
//    };
//});
var jwtSettings = builder.Configuration.GetSection("JWTSettings");

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:validIssuer"],
        ValidAudience = builder.Configuration["JwtSettings:validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:securityKey"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine($"❌ Error de autenticación: {context.Exception.Message}");
            return Task.CompletedTask;
        }
    };
});




builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpClient();
builder.Services.AddApiVersioning();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema API de Analisis de Precios Unitarios", Version = "1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

//Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        // Asegúrate de agregar el header en caso de error
        if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "https://apipruebaweb.runasp.net");
        }
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Error interno");
    }
});
app.UseHttpsRedirection();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (error != null)
        {
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
            {
                error = error.Error.Message,
                stackTrace = error.Error.StackTrace
            }));
        }
    });
});

app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

