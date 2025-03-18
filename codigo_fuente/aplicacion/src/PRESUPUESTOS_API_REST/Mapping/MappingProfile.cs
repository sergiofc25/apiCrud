using AutoMapper;
using Model.Entitie;
using Model.DTO.v1;
namespace PRESUPUESTOS_API_REST.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CLIENTE
        CreateMap<Ent_Cliente, DTO_Cliente_Obten_Paginado>()
            //.ForMember(destino => destino.Cli_Id,
            //opt => opt.MapFrom(origen => origen.Cli_Id))
            .ForMember(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
            .ForMember(destino => destino.Cli_Abreviatura,
            opt => opt.MapFrom(origen => origen.Cli_Abreviatura))
            .ForMember(destino => destino.Cli_NumDocumento,
            opt => opt.MapFrom(origen => origen.Cli_NumDocumento))
            .ForMember(destino => destino.TipDoc_Nombre,
            opt => opt.MapFrom(origen => origen.eTipo_Documento.TipDoc_Nombre));
        //.ForMember(destino => destino.Cli_Estado,
        //opt => opt.MapFrom(origen => origen.Cli_Estado));

        CreateMap<Ent_Cliente, DTO_Cliente_Obten_Nombre>()
            .ForMember(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial));

        CreateMap<Ent_Cliente, DTO_Cliente_Obten_x_Nombre>()
            .ForMember(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial));


        CreateMap<Ent_Cliente, DTO_Cliente_Obten_x_Id>()
            .ForMember(destino => destino.Cli_Id,
            opt => opt.MapFrom(origen => origen.Cli_Id))
            .ForMember(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
            .ForMember(destino => destino.Cli_Abreviatura,
            opt => opt.MapFrom(origen => origen.Cli_Abreviatura))
            .ForMember(destino => destino.Cli_NumDocumento,
            opt => opt.MapFrom(origen => origen.Cli_NumDocumento))
            .ForMember(destino => destino.TipDoc_Nombre,
            opt => opt.MapFrom(origen => origen.eTipo_Documento.TipDoc_Nombre))
            .ForMember(destino => destino.Cli_Estado,
            opt => opt.MapFrom(origen => origen.Cli_Estado));

        CreateMap<DTO_Cliente_Crea, Ent_Cliente>()
            .ForPath(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
            .ForPath(destino => destino.Cli_Abreviatura,
            opt => opt.MapFrom(origen => origen.Cli_Abreviatura))
            .ForPath(destino => destino.eTipo_Documento.TipDoc_Nombre,
            opt => opt.MapFrom(origen => origen.TipDoc_Nombre))
            .ForPath(destino => destino.Cli_NumDocumento,
            opt => opt.MapFrom(origen => origen.Cli_NumDocumento));

        CreateMap<DTO_Cliente_Actualiza, Ent_Cliente>()
            .ForPath(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
            .ForPath(destino => destino.Cli_Abreviatura,
            opt => opt.MapFrom(origen => origen.Cli_Abreviatura))
            .ForPath(destino => destino.eTipo_Documento.TipDoc_Nombre,
            opt => opt.MapFrom(origen => origen.TipDoc_Nombre))
            .ForPath(destino => destino.Cli_NumDocumento,
            opt => opt.MapFrom(origen => origen.Cli_NumDocumento));
        CreateMap<DTO_Cliente_Actualiza_Condicion, Ent_Cliente>()
            .ForPath(destino => destino.Cli_Estado,
            opt => opt.MapFrom(origen => origen.Cli_Estado));

        //TIPO_DOCUMENTO
        CreateMap<Ent_Tipo_Documento, DTO_Tipo_Documento_Obten>()
            .ForMember(destino => destino.TipDoc_Nombre,
            opt => opt.MapFrom(origen => origen.TipDoc_Nombre));
        //USUARIO
        CreateMap<Ent_Usuario, DTO_Usuario_Obten_Paginado>()
            .ForMember(destino => destino.Usu_Correo,
            opt => opt.MapFrom(origen => origen.Usu_Correo))
            .ForMember(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForMember(destino => destino.Rol_Nombre,
            opt => opt.MapFrom(origen => origen.eRol.Rol_Nombre))
            .ForMember(destino => destino.Usu_FecHoraRegistro,
            opt => opt.MapFrom(origen => origen.Usu_FecHoraRegistro))
            .ForMember(destino => destino.Usu_Observacion,
            opt => opt.MapFrom(origen => origen.Usu_Observacion));

        CreateMap<Ent_Usuario, DTO_Usuario_Obten_x_Id>()
            .ForMember(destino => destino.Usu_Id,
            opt => opt.MapFrom(origen => origen.Usu_Id))
            .ForMember(destino => destino.Usu_Correo,
            opt => opt.MapFrom(origen => origen.Usu_Correo))
            .ForMember(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForMember(destino => destino.Rol_Nombre,
            opt => opt.MapFrom(origen => origen.eRol.Rol_Nombre))
            .ForMember(destino => destino.Usu_FecHoraRegistro,
            opt => opt.MapFrom(origen => origen.Usu_FecHoraRegistro))
            .ForMember(destino => destino.Usu_Estado,
            opt => opt.MapFrom(origen => origen.Usu_Estado));
        CreateMap<DTO_Usuario_Crea, Ent_Usuario>()
            .ForPath(destino => destino.Usu_Correo,
            opt => opt.MapFrom(origen => origen.Usu_Correo))
            .ForPath(destino => destino.Usu_Clave,
            opt => opt.MapFrom(origen => origen.Usu_Clave))
            .ForPath(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForPath(destino => destino.eRol.Rol_Nombre,
            opt => opt.MapFrom(origen => origen.Rol_Nombre));

        CreateMap<DTO_Usuario_Actualiza, Ent_Usuario>()
            .ForPath(destino => destino.Usu_Correo,
            opt => opt.MapFrom(origen => origen.Usu_Correo))
            .ForPath(destino => destino.Usu_Clave,
            opt => opt.MapFrom(origen => origen.Usu_Clave))
            .ForPath(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForPath(destino => destino.eRol.Rol_Nombre,
            opt => opt.MapFrom(origen => origen.Rol_Nombre))
            .ForPath(destino => destino.Usu_Observacion,
            opt => opt.MapFrom(origen => origen.Usu_Observacion));
        CreateMap<DTO_Usuario_Actualiza_Condicion, Ent_Usuario>()
            .ForPath(destino => destino.Usu_Estado,
            opt => opt.MapFrom(origen => origen.Usu_Estado));
        CreateMap<Ent_Usuario, DTO_Usuario_Obten_x_Correo>()
            .ForMember(destino => destino.Usu_Correo,
            opt => opt.MapFrom(origen => origen.Usu_Correo))
            .ForMember(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForMember(destino => destino.Rol_Nombre,
            opt => opt.MapFrom(origen => origen.eRol.Rol_Nombre))
            .ForMember(destino => destino.Usu_FecHoraRegistro,
            opt => opt.MapFrom(origen => origen.Usu_FecHoraRegistro))
            .ForMember(destino => destino.Usu_Estado,
            opt => opt.MapFrom(origen => origen.Usu_Estado));
        CreateMap<Ent_Usuario, DTO_Usuario_Obten_Token_x_Correo>()
            .ForMember(destino => destino.Usu_Correo,
            opt => opt.MapFrom(origen => origen.Usu_Correo))
            .ForMember(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForMember(destino => destino.Rol_Nombre,
            opt => opt.MapFrom(origen => origen.eRol.Rol_Nombre))
            .ForMember(destino => destino.Usu_FecHoraRegistro,
            opt => opt.MapFrom(origen => origen.Usu_FecHoraRegistro))
            .ForMember(destino => destino.Usu_Estado,
            opt => opt.MapFrom(origen => origen.Usu_Estado))
            .ForMember(destino => destino.Usu_TokenActualizado,
            opt => opt.MapFrom(origen => origen.Usu_TokenActualizado))
            .ForMember(destino => destino.Usu_FecHoraTokenActualizado,
            opt => opt.MapFrom(origen => origen.Usu_FecHoraTokenActualizado));

        //PRESUPUESTO
        CreateMap<Ent_Presupuesto, DTO_Presupuesto_Obten_Paginado>()
            .ForMember(destino => destino.Pre_Codigo,
            opt => opt.MapFrom(origen => origen.Pre_Codigo))
            .ForMember(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.eUsuario.Usu_NomApellidos))
            .ForMember(destino => destino.Pre_Nombre,
            opt => opt.MapFrom(origen => origen.Pre_Nombre))
            .ForMember(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.eCliente.Cli_NomApeRazSocial))
            .ForMember(destino => destino.Ubi_Departamento,
            opt => opt.MapFrom(origen => origen.eUbicacion.Ubi_Departamento))
            .ForMember(destino => destino.Ubi_Provincia,
            opt => opt.MapFrom(origen => origen.eUbicacion.Ubi_Provincia))
            .ForMember(destino => destino.Ubi_Distrito,
            opt => opt.MapFrom(origen => origen.eUbicacion.Ubi_Distrito))
            .ForMember(destino => destino.Pre_Jornal,
            opt => opt.MapFrom(origen => origen.Pre_Jornal))
            .ForMember(destino => destino.Pre_FecHorRegistro,
            opt => opt.MapFrom(origen => origen.Pre_FecHorRegistro));
        CreateMap<Ent_Presupuesto, DTO_Presupuesto_Obten_x_Id>()
            .ForMember(destino => destino.Pre_Id,
            opt => opt.MapFrom(origen => origen.Pre_Id))
            .ForMember(destino => destino.Pre_Codigo,
            opt => opt.MapFrom(origen => origen.Pre_Codigo))
            .ForMember(destino => destino.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.eUsuario.Usu_NomApellidos))
            .ForMember(destino => destino.Pre_Nombre,
            opt => opt.MapFrom(origen => origen.Pre_Nombre))
            .ForMember(destino => destino.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.eCliente.Cli_NomApeRazSocial))
            .ForMember(destino => destino.Ubi_Departamento,
            opt => opt.MapFrom(origen => origen.eUbicacion.Ubi_Departamento))
            .ForMember(destino => destino.Ubi_Provincia,
            opt => opt.MapFrom(origen => origen.eUbicacion.Ubi_Provincia))
            .ForMember(destino => destino.Ubi_Distrito,
            opt => opt.MapFrom(origen => origen.eUbicacion.Ubi_Distrito))
            .ForMember(destino => destino.Pre_Jornal,
            opt => opt.MapFrom(origen => origen.Pre_Jornal))
            .ForMember(destino => destino.Pre_Estado,
            opt => opt.MapFrom(origen => origen.Pre_Estado));
        CreateMap<DTO_Presupuesto_Crea, Ent_Presupuesto>()
            .ForPath(destino => destino.eUsuario.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForPath(destino => destino.Pre_Nombre,
            opt => opt.MapFrom(origen => origen.Pre_Nombre))
            .ForPath(destino => destino.eCliente.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
            .ForPath(destino => destino.eUbicacion.Ubi_Departamento,
            opt => opt.MapFrom(origen => origen.Ubi_Departamento))
            .ForPath(destino => destino.eUbicacion.Ubi_Provincia,
            opt => opt.MapFrom(origen => origen.Ubi_Provincia))
            .ForPath(destino => destino.eUbicacion.Ubi_Distrito,
            opt => opt.MapFrom(origen => origen.Ubi_Distrito))
            .ForPath(destino => destino.Pre_Jornal,
            opt => opt.MapFrom(origen => origen.Pre_Jornal));
        CreateMap<DTO_Presupuesto_Actualiza, Ent_Presupuesto>()
            .ForPath(destino => destino.eUsuario.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForPath(destino => destino.Pre_Nombre,
            opt => opt.MapFrom(origen => origen.Pre_Nombre))
            .ForPath(destino => destino.eCliente.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
            .ForPath(destino => destino.eUbicacion.Ubi_Departamento,
            opt => opt.MapFrom(origen => origen.Ubi_Departamento))
            .ForPath(destino => destino.eUbicacion.Ubi_Provincia,
            opt => opt.MapFrom(origen => origen.Ubi_Provincia))
            .ForPath(destino => destino.eUbicacion.Ubi_Distrito,
            opt => opt.MapFrom(origen => origen.Ubi_Distrito))
            .ForPath(destino => destino.Pre_Jornal,
            opt => opt.MapFrom(origen => origen.Pre_Jornal));
        CreateMap<DTO_Presupuesto_Actualiza_Condicion, Ent_Presupuesto>()
            .ForPath(destino => destino.Pre_Estado,
            opt => opt.MapFrom(origen => origen.Pre_Estado));
        //UBICACION
        CreateMap<Ent_Ubicacion, DTO_Ubicacion_Obten_x_Nombre>()
            .ForMember(destino => destino.Ubi_Departamento,
            opt => opt.MapFrom(origen => origen.Ubi_Departamento))
            .ForMember(destino => destino.Ubi_Provincia,
            opt => opt.MapFrom(origen => origen.Ubi_Provincia))
            .ForMember(destino => destino.Ubi_Distrito,
            opt => opt.MapFrom(origen => origen.Ubi_Distrito));
    }

} 