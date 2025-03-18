using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.v1;

public class DTO_Usuario_Obten_Login
{
    public string? Usu_Correo { get; set; }
    public string? Usu_Clave { get; set; }
}

public class DTO_Usuario_Obten_Paginado
{
    public string? Usu_Id { get; set; }
    public string? Usu_Correo { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Rol_Nombre { get; set; }
    public string? Usu_FecHoraRegistro { get; set; }
    public string? Usu_Observacion { get; set; }
}
public class DTO_Usuario_Obten_x_Id
{
    public string? Usu_Id { get; set; }
    public string? Usu_Correo { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Rol_Nombre { get; set; }
    public string? Usu_FecHoraRegistro { get; set; }
    public string? Usu_Estado { get; set; }
}
public class DTO_Usuario_Crea
{
    public string? Usu_Correo { get; set; }
    public string? Usu_Clave { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Rol_Nombre { get; set; }
}
public class DTO_Usuario_Actualiza
{
    public string? Usu_Correo { get; set; }
    public string? Usu_Clave { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Rol_Nombre { get; set; }
    public string? Usu_Observacion { get; set; }
}
public class DTO_Usuario_Actualiza_Condicion
{
    public string? Usu_Estado { get; set; }
}
public class DTO_Usuario_Obten_x_Correo
{
    public string? Usu_Correo { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Rol_Nombre { get; set; }
    public string? Usu_FecHoraRegistro { get; set; }
    public string? Usu_Estado { get; set; }
}
public class DTO_Usuario_Obten_Token_x_Correo
{
    public string? Usu_Correo { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Rol_Nombre { get; set; }
    public string? Usu_FecHoraRegistro { get; set; }
    public string? Usu_Estado { get; set; }
    public string? Usu_TokenActualizado { get; set; }
    public string? Usu_FecHoraTokenActualizado { get; set; }

}