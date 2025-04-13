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

        //CreateMap<DTO_Cliente_Crea, Ent_Cliente>()
        //    .ForPath(destino => destino.Cli_NomApeRazSocial,
        //    opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
        //    .ForPath(destino => destino.Cli_Abreviatura,
        //    opt => opt.MapFrom(origen => origen.Cli_Abreviatura))
        //    .ForPath(destino => destino.eTipo_Documento.TipDoc_Nombre,
        //    opt => opt.MapFrom(origen => origen.TipDoc_Nombre))
        //    .ForPath(destino => destino.Cli_NumDocumento,
        //    opt => opt.MapFrom(origen => origen.Cli_NumDocumento));
        CreateMap<DTO_Cliente_Crea, Ent_Cliente>()
            .ForMember(dest => dest.Cli_NomApeRazSocial, opt => opt.MapFrom(src => src.Cli_NomApeRazSocial))
            .ForMember(dest => dest.Cli_Abreviatura, opt => opt.MapFrom(src => src.Cli_Abreviatura))
            .ForMember(dest => dest.eTipo_Documento, opt => opt.MapFrom(src => src.eTipo_Documento))
            .ForMember(dest => dest.Cli_NumDocumento, opt => opt.MapFrom(src => src.Cli_NumDocumento));

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
            .ForMember(destino => destino.Pai_Nombre,
            opt => opt.MapFrom(origen => origen.ePais.Pai_Nombre))
            .ForMember(destino => destino.Dep_Nombre,
            opt => opt.MapFrom(origen => origen.eDeparatemaneto.Dep_Nombre))
            .ForMember(destino => destino.Prov_Nombre,
            opt => opt.MapFrom(origen => origen.eProvincia.Prov_Nombre))
            .ForMember(destino => destino.Dist_Nombre,
            opt => opt.MapFrom(origen => origen.eDistrito.Dist_Nombre))
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
            .ForMember(destino => destino.Pai_Nombre,
            opt => opt.MapFrom(origen => origen.ePais.Pai_Nombre))
            .ForMember(destino => destino.Dep_Nombre,
            opt => opt.MapFrom(origen => origen.eDeparatemaneto.Dep_Nombre))
            .ForMember(destino => destino.Prov_Nombre,
            opt => opt.MapFrom(origen => origen.eProvincia.Prov_Nombre))
            .ForMember(destino => destino.Dist_Nombre,
            opt => opt.MapFrom(origen => origen.eDistrito.Dist_Nombre))
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
            .ForPath(destino => destino.ePais.Pai_Nombre,
            opt => opt.MapFrom(origen => origen.Pai_Nombre))
            .ForPath(destino => destino.eDeparatemaneto.Dep_Nombre,
            opt => opt.MapFrom(origen => origen.Dep_Nombre))
            .ForPath(destino => destino.eProvincia.Prov_Nombre,
            opt => opt.MapFrom(origen => origen.Prov_Nombre))
            .ForPath(destino => destino.eDistrito.Dist_Nombre,
            opt => opt.MapFrom(origen => origen.Dist_Nombre))
            .ForPath(destino => destino.Pre_Jornal,
            opt => opt.MapFrom(origen => origen.Pre_Jornal));
        CreateMap<DTO_Presupuesto_Actualiza, Ent_Presupuesto>()
            .ForPath(destino => destino.eUsuario.Usu_NomApellidos,
            opt => opt.MapFrom(origen => origen.Usu_NomApellidos))
            .ForPath(destino => destino.Pre_Nombre,
            opt => opt.MapFrom(origen => origen.Pre_Nombre))
            .ForPath(destino => destino.eCliente.Cli_NomApeRazSocial,
            opt => opt.MapFrom(origen => origen.Cli_NomApeRazSocial))
            .ForPath(destino => destino.ePais.Pai_Nombre,
            opt => opt.MapFrom(origen => origen.Pai_Nombre))
            .ForPath(destino => destino.eDeparatemaneto.Dep_Nombre,
            opt => opt.MapFrom(origen => origen.Dep_Nombre))
            .ForPath(destino => destino.eProvincia.Prov_Nombre,
            opt => opt.MapFrom(origen => origen.Prov_Nombre))
            .ForPath(destino => destino.eDistrito.Dist_Nombre,
            opt => opt.MapFrom(origen => origen.Dist_Nombre))
            .ForPath(destino => destino.Pre_Jornal,
            opt => opt.MapFrom(origen => origen.Pre_Jornal));
        CreateMap<DTO_Presupuesto_Actualiza_Condicion, Ent_Presupuesto>()
            .ForPath(destino => destino.Pre_Estado,
            opt => opt.MapFrom(origen => origen.Pre_Estado));
    }

} 