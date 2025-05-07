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
        //PAIS
        CreateMap<Ent_Pais, DTO_Pais_Obten>()
            .ForMember(destino => destino.Pai_Nombre,
            opt => opt.MapFrom(origen => origen.Pai_Nombre));
        //DEPARTAMENTO
        CreateMap<Ent_Departamento, DTO_Departamento_Obten>()
            .ForMember(destino => destino.Dep_Nombre,
            opt => opt.MapFrom(origen => origen.Dep_Nombre));
        //PROVINCIA
        CreateMap<Ent_Provincia, DTO_Provincia_Obten>()
            .ForMember(destino => destino.Prov_Nombre,
            opt => opt.MapFrom(origen => origen.Prov_Nombre));
        //DISTRITO
        CreateMap<Ent_Distrito, DTO_Distrito_Obten>()
            .ForMember(destino => destino.Dist_Nombre,
            opt => opt.MapFrom(origen => origen.Dist_Nombre));
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
        //SUB_PRESUPUESTO
        CreateMap<Ent_SubPresupuesto, DTO_SubPresupuesto_Obten_x_Presupuesto>()
            .ForMember(destino => destino.SubPre_Id,
            opt => opt.MapFrom(origen => origen.SubPre_Id))
            .ForMember(destino => destino.Pre_Id,
            opt => opt.MapFrom(origen => origen.ePresupuesto.Pre_Id))
            .ForMember(destino => destino.Padre_Id,
            opt => opt.MapFrom(origen => origen.Padre_Id))
            .ForMember(destino => destino.SubPre_Nombre,
            opt => opt.MapFrom(origen => origen.SubPre_Nombre))
            .ForMember(destino => destino.SubPre_Nivel,
            opt => opt.MapFrom(origen => origen.SubPre_Nivel))
            .ForMember(destino => destino.SubPre_Orden,
            opt => opt.MapFrom(origen => origen.SubPre_Orden))
            .ForMember(destino => destino.SubPre_Ruta,
            opt => opt.MapFrom(origen => origen.SubPre_Ruta));
        CreateMap<Ent_SubPresupuesto, DTO_SubPresupuesto_Obten_x_Id>()
            .ForMember(destino => destino.SubPre_Id,
            opt => opt.MapFrom(origen => origen.SubPre_Id))
            .ForMember(destino => destino.Pre_Id,
            opt => opt.MapFrom(origen => origen.ePresupuesto.Pre_Id))
            .ForMember(destino => destino.Pre_Nombre,
            opt => opt.MapFrom(origen => origen.ePresupuesto.Pre_Nombre))
            .ForMember(destino => destino.Padre_Id,
            opt => opt.MapFrom(origen => origen.Padre_Id))
            .ForMember(destino => destino.SubPre_Nombre,
            opt => opt.MapFrom(origen => origen.SubPre_Nombre))
            .ForMember(destino => destino.SubPre_Nivel,
            opt => opt.MapFrom(origen => origen.SubPre_Nivel))
            .ForMember(destino => destino.SubPre_Orden,
            opt => opt.MapFrom(origen => origen.SubPre_Orden))
            .ForMember(destino => destino.SubPre_Ruta,
            opt => opt.MapFrom(origen => origen.SubPre_Ruta))
            .ForMember(destino => destino.SubPre_TieneHijos,
            opt => opt.MapFrom(origen => origen.SubPre_TieneHijos));
        CreateMap<DTO_SubPresupuesto_Crea, Ent_SubPresupuesto>()
            .ForPath(destino => destino.ePresupuesto.Pre_Id,
            opt => opt.MapFrom(origen => origen.Pre_Id))
            .ForPath(destino => destino.SubPre_Nombre,
            opt => opt.MapFrom(origen => origen.SubPre_Nombre))
            .ForPath(destino => destino.SubPre_Nivel,
            opt => opt.MapFrom(origen => origen.SubPre_Nivel))
            .ForPath(destino => destino.SubPre_Orden,
            opt => opt.MapFrom(origen => origen.SubPre_Orden));
        CreateMap<DTO_SubPresupuesto_Crea_Dentro, Ent_SubPresupuesto>()
            .ForPath(destino => destino.SubPre_Nombre,
            opt => opt.MapFrom(origen => origen.SubPre_Nombre));
        CreateMap<DTO_SubPresupuesto_Crea_Primer_Nivel, Ent_SubPresupuesto>()
            .ForPath(destino => destino.SubPre_Nombre,
            opt => opt.MapFrom(origen => origen.SubPre_Nombre));
        CreateMap<DTO_SubPresupuesto_Actualiza_Nombre, Ent_SubPresupuesto>()
            .ForPath(destino => destino.SubPre_Nombre,
            opt => opt.MapFrom(origen => origen.SubPre_Nombre));
        //PARTIDA
        CreateMap<Ent_Partida, DTO_Partida_Obten_x_SubPresupuesto>()
           .ForMember(destino => destino.Par_Id,
           opt => opt.MapFrom(origen => origen.Par_Id))
           .ForMember(destino => destino.Par_Ruta,
           opt => opt.MapFrom(origen => origen.Par_Ruta))
           .ForMember(destino => destino.SubPre_Id,
           opt => opt.MapFrom(origen => origen.eSubPresupuesto.SubPre_Id))
           .ForMember(destino => destino.Par_Nombre,
           opt => opt.MapFrom(origen => origen.Par_Nombre))
           .ForMember(destino => destino.Par_RenManObra,
           opt => opt.MapFrom(origen => origen.Par_RenManObra))
           .ForMember(destino => destino.Par_RenEquipo,
           opt => opt.MapFrom(origen => origen.Par_RenEquipo))
           .ForMember(destino => destino.UniMed_Nombre,
           opt => opt.MapFrom(origen => origen.eUnidad_Medida.UniMed_Nombre))
           .ForMember(destino => destino.Par_Estado,
           opt => opt.MapFrom(origen => origen.Par_Estado));
        CreateMap<Ent_Partida, DTO_Partida_Obten_x_Id>()
            .ForMember(destino => destino.Par_Id,
            opt => opt.MapFrom(origen => origen.Par_Id))
            .ForMember(destino => destino.Par_Nombre,
            opt => opt.MapFrom(origen => origen.Par_Nombre))
            .ForMember(destino => destino.Par_RenEquipo,
            opt => opt.MapFrom(origen => origen.Par_RenEquipo))
            .ForMember(destino => destino.Par_RenManObra,
            opt => opt.MapFrom(origen => origen.Par_RenManObra))
            .ForMember(destino => destino.UniMed_Nombre,
            opt => opt.MapFrom(origen => origen.eUnidad_Medida.UniMed_Nombre))
            .ForMember(destino => destino.UniMed_Abreviatura,
            opt => opt.MapFrom(origen => origen.eUnidad_Medida.UniMed_Abreviatura))
            .ForMember(destino => destino.SubPre_Id,
            opt => opt.MapFrom(origen => origen.eSubPresupuesto.SubPre_Id))
            .ForMember(destino => destino.Par_Estado,
            opt => opt.MapFrom(origen => origen.Par_Estado));
        CreateMap<DTO_Partida_Crea, Ent_Partida>()
            .ForPath(destino => destino.Par_Nombre,
            opt => opt.MapFrom(origen => origen.Par_Nombre))
            .ForPath(destino => destino.Par_RenManObra,
            opt => opt.MapFrom(origen => origen.Par_RenManObra))
            .ForPath(destino => destino.Par_RenEquipo,
            opt => opt.MapFrom(origen => origen.Par_RenEquipo))
            .ForPath(destino => destino.eUnidad_Medida.UniMed_Nombre,
            opt => opt.MapFrom(origen => origen.UniMed_Nombre))
            .ForPath(destino => destino.eSubPresupuesto.SubPre_Id,
            opt => opt.MapFrom(origen => origen.SubPre_Id));
        CreateMap<DTO_Partida_Actualiza, Ent_Partida>()
            .ForPath(destino => destino.Par_Nombre,
            opt => opt.MapFrom(origen => origen.Par_Nombre))
            .ForPath(destino => destino.Par_RenManObra,
            opt => opt.MapFrom(origen => origen.Par_RenManObra))
            .ForPath(destino => destino.Par_RenEquipo,
            opt => opt.MapFrom(origen => origen.Par_RenEquipo))
            .ForPath(destino => destino.eUnidad_Medida.UniMed_Nombre,
            opt => opt.MapFrom(origen => origen.UniMed_Nombre))
            .ForPath(destino => destino.Par_Estado,
            opt => opt.MapFrom(origen => origen.Par_Estado));
        CreateMap<DTO_Partida_Inhabilita, Ent_Partida>()
            .ForPath(destino => destino.Par_Estado,
            opt => opt.MapFrom(origen => origen.Par_Estado));

        //UNIDAD_MEDIDA
        CreateMap<Ent_Unidad_Medida, DTO_Unidad_Medida_Obten>()
            .ForMember(destino => destino.UniMed_Nombre,
            opt => opt.MapFrom(origen => origen.UniMed_Nombre))
            .ForMember(destino => destino.UniMed_Abreviatura,
            opt => opt.MapFrom(origen => origen.UniMed_Abreviatura));
    }

} 