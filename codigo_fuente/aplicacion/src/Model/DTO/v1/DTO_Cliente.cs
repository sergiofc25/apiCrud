using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.v1;

public class DTO_Cliente_Obten_Paginado
{
    public string? Cli_Id { get; set; }
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Cli_Abreviatura { get; set; }
    public string? Cli_NumDocumento { get; set; }
    public string? TipDoc_Nombre { get; set; }
    //public bool Cli_Estado { get; set; }
}
public class DTO_Cliente_Obten_Nombre
{
    public string? Cli_NomApeRazSocial { get; set; }

}
public class DTO_Cliente_Obten_x_Nombre
{
    public string? Cli_NomApeRazSocial { get; set; }

}
public class DTO_Cliente_Obten_x_Id
{
    public string? Cli_Id { get; set; }
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Cli_Abreviatura { get; set; }
    public string? Cli_NumDocumento { get; set; }
    public string? TipDoc_Nombre { get; set; }
    public string? Cli_Estado { get; set; }
}
public class DTO_Cliente_Crea
{
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Cli_Abreviatura { get; set; }
    public string? TipDoc_Nombre { get; set; }
    public string? Cli_NumDocumento { get; set; }
};

public class DTO_Cliente_Actualiza
{
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Cli_Abreviatura { get; set; }
    public string? TipDoc_Nombre { get; set; }
    public string? Cli_NumDocumento { get; set; }
};

public class DTO_Cliente_Actualiza_Condicion
{
    public string? Cli_Estado { get; set; }

};