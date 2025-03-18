namespace Model.DTO.v1;

public class DTO_Presupuesto_Obten_Paginado
{
    public string? Pre_Id { get; set; }
    public string? Pre_Codigo { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Pre_Nombre { get; set; }
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Ubi_Departamento { get; set; }
    public string? Ubi_Provincia { get; set; }
    public string? Ubi_Distrito { get; set; }
    public string? Pre_Jornal { get; set; }
    public string? Pre_FecHorRegistro { get; set; }

}
public class DTO_Presupuesto_Obten_x_Id
{
    public string? Pre_Id { get; set; }
    public string? Pre_Codigo { get; set; }
    public string? Usu_NomApellidos { get; set; }
    public string? Pre_Nombre { get; set; }
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Ubi_Departamento { get; set; }
    public string? Ubi_Provincia { get; set; }
    public string? Ubi_Distrito { get; set; }
    public string? Pre_Jornal { get; set; }
    public string? Pre_Estado { get; set; }

}
public class DTO_Presupuesto_Crea
{
    public string? Usu_NomApellidos { get; set; }
    public string? Pre_Nombre { get; set; }
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Ubi_Departamento { get; set; }
    public string? Ubi_Provincia { get; set; }
    public string? Ubi_Distrito { get; set; }
    public string? Pre_Jornal { get; set; }
};

public class DTO_Presupuesto_Actualiza
{
    public string? Usu_NomApellidos { get; set; }
    public string? Pre_Nombre { get; set; }
    public string? Cli_NomApeRazSocial { get; set; }
    public string? Ubi_Departamento { get; set; }
    public string? Ubi_Provincia { get; set; }
    public string? Ubi_Distrito { get; set; }
    public string? Pre_Jornal { get; set; }
};

public class DTO_Presupuesto_Actualiza_Condicion
{
    public string? Pre_Estado { get; set; }

};