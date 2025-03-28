USE [master]
GO
/****** Object:  Database [dbpresupuestos]    Script Date: 17/03/2025 07:31:40 ******/
CREATE DATABASE [dbpresupuestos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbpresupuestos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbpresupuestos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbpresupuestos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbpresupuestos_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbpresupuestos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbpresupuestos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbpresupuestos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbpresupuestos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbpresupuestos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbpresupuestos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbpresupuestos] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbpresupuestos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbpresupuestos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbpresupuestos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbpresupuestos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbpresupuestos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbpresupuestos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbpresupuestos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbpresupuestos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbpresupuestos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbpresupuestos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbpresupuestos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbpresupuestos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbpresupuestos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbpresupuestos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbpresupuestos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbpresupuestos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbpresupuestos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbpresupuestos] SET RECOVERY FULL 
GO
ALTER DATABASE [dbpresupuestos] SET  MULTI_USER 
GO
ALTER DATABASE [dbpresupuestos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbpresupuestos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbpresupuestos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbpresupuestos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbpresupuestos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbpresupuestos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbpresupuestos', N'ON'
GO
ALTER DATABASE [dbpresupuestos] SET QUERY_STORE = OFF
GO
USE [dbpresupuestos]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_AutogenerarCodigoPresupuesto]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_AutogenerarCodigoPresupuesto]()
RETURNS VARCHAR(10)
AS
BEGIN
  DECLARE @UltimoID INT
  SET @UltimoID = (SELECT MAX(Pre_Id) FROM dbo.presupuesto) + 1
  RETURN 'PRO-' + RIGHT('0000' + CAST(@UltimoID AS VARCHAR(4)), 4)
END
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[Cli_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cli_NomApeRazSocial] [varchar](500) NOT NULL,
	[Cli_Abreviatura] [varchar](100) NOT NULL,
	[Cli_NumDocumento] [varchar](12) NOT NULL,
	[TipDoc_Id] [int] NOT NULL,
	[Cli_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[Cli_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_partida_recurso]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_partida_recurso](
	[DetParRec_Id] [int] IDENTITY(1,1) NOT NULL,
	[Par_Id] [int] NOT NULL,
	[Rec_Id] [int] NOT NULL,
 CONSTRAINT [PK_detalle_partida_recurso] PRIMARY KEY CLUSTERED 
(
	[DetParRec_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_rol_modulo]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_rol_modulo](
	[DetRolMod_Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol_Id] [int] NOT NULL,
	[Mod_Id] [int] NOT NULL,
 CONSTRAINT [PK_detalle_rol_modulo] PRIMARY KEY CLUSTERED 
(
	[DetRolMod_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupo_partida]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo_partida](
	[GruPar_Id] [int] IDENTITY(1,1) NOT NULL,
	[NomGruPar_Id] [int] NOT NULL,
	[GruPar_Total] [decimal](18, 0) NULL,
	[Pre_Id] [int] NOT NULL,
 CONSTRAINT [PK_sub_presupuesto] PRIMARY KEY CLUSTERED 
(
	[GruPar_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[modulo]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modulo](
	[Mod_Id] [int] IDENTITY(1,1) NOT NULL,
	[Mod_Nombre] [varchar](100) NOT NULL,
	[Mod_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_modulo] PRIMARY KEY CLUSTERED 
(
	[Mod_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nombre_grupo_partida]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nombre_grupo_partida](
	[NomGruPar_Id] [int] IDENTITY(1,1) NOT NULL,
	[NomGruPar_Nombre] [varchar](500) NOT NULL,
 CONSTRAINT [PK__unidad_m__3E5A5CCB499FDD75] PRIMARY KEY CLUSTERED 
(
	[NomGruPar_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[partida]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partida](
	[Par_Id] [int] IDENTITY(1,1) NOT NULL,
	[Par_Item] [varchar](50) NOT NULL,
	[Par_Nombre] [varchar](50) NOT NULL,
	[UniMedRen_Id] [int] NOT NULL,
	[Par_RenManObra] [decimal](18, 0) NOT NULL,
	[Par_RenEquipo] [decimal](18, 0) NOT NULL,
	[UniMed_Id] [int] NOT NULL,
	[Par_PreUnitario] [decimal](18, 0) NULL,
	[GruPar_Id] [int] NOT NULL,
	[Par_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_partida] PRIMARY KEY CLUSTERED 
(
	[Par_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[presupuesto]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[presupuesto](
	[Pre_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pre_Codigo] [varchar](50) NULL,
	[Usu_Id] [int] NOT NULL,
	[Pre_Nombre] [varchar](500) NOT NULL,
	[Cli_Id] [int] NOT NULL,
	[Ubi_Id] [int] NOT NULL,
	[Pre_Jornal] [decimal](18, 2) NOT NULL,
	[Pre_FecHorRegistro] [datetime] NOT NULL,
	[Pre_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_presupuesto] PRIMARY KEY CLUSTERED 
(
	[Pre_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recurso]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recurso](
	[Rec_Id] [int] IDENTITY(1,1) NOT NULL,
	[Rec_Nombre] [varchar](100) NOT NULL,
	[TipRec_Id] [int] NOT NULL,
	[UniMedRec_Id] [int] NOT NULL,
	[Rec_Cuadrilla] [decimal](18, 0) NULL,
	[Rec_Cantidad] [decimal](18, 0) NULL,
	[Rec_Precio] [decimal](18, 0) NULL,
	[Rec_Parcial] [decimal](18, 0) NULL,
	[Rec_Estado] [tinyint] NOT NULL,
	[Rec_IndUnificado] [varchar](100) NULL,
 CONSTRAINT [PK_recurso] PRIMARY KEY CLUSTERED 
(
	[Rec_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[Rol_Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol_Nombre] [varchar](50) NOT NULL,
	[Rol_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[Rol_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento](
	[TipDoc_Id] [int] IDENTITY(1,1) NOT NULL,
	[TipDoc_Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tipo_documento] PRIMARY KEY CLUSTERED 
(
	[TipDoc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_recurso]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_recurso](
	[TipRec_Id] [int] IDENTITY(1,1) NOT NULL,
	[TipRec_Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tipo_recurso] PRIMARY KEY CLUSTERED 
(
	[TipRec_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ubicacion]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ubicacion](
	[Ubi_Id] [int] NOT NULL,
	[Ubi_Departamento] [nvarchar](100) NOT NULL,
	[Ubi_Provincia] [nvarchar](100) NOT NULL,
	[Ubi_Distrito] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__ubicacio__40E1F317CBBEEB9F] PRIMARY KEY CLUSTERED 
(
	[Ubi_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[unidad_medida]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unidad_medida](
	[UniMed_Id] [int] IDENTITY(1,1) NOT NULL,
	[UniMed_Nombre] [varchar](50) NOT NULL,
	[UniMed_Abreviatura] [varchar](50) NOT NULL,
	[UniMed_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_unidad_medida] PRIMARY KEY CLUSTERED 
(
	[UniMed_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[unidad_medida_recurso]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unidad_medida_recurso](
	[UniMedRec_Id] [int] IDENTITY(1,1) NOT NULL,
	[UniMedRec_Nombre] [varchar](100) NOT NULL,
	[UniMedRec_Abreviatura] [varchar](50) NOT NULL,
	[UniMedRec_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_unidad_medida_recurso] PRIMARY KEY CLUSTERED 
(
	[UniMedRec_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[unidad_medida_rendimiento]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unidad_medida_rendimiento](
	[UniMedRen_Id] [int] IDENTITY(1,1) NOT NULL,
	[UniMedRen_Nombre] [varchar](50) NOT NULL,
	[UniMedRen_Abreviatura] [varchar](50) NOT NULL,
	[UniMedRen_Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_unidad_medida_rendimiento] PRIMARY KEY CLUSTERED 
(
	[UniMedRen_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[Usu_Id] [int] IDENTITY(1,1) NOT NULL,
	[Usu_Correo] [varchar](50) NOT NULL,
	[Usu_Clave] [varchar](50) NOT NULL,
	[Usu_NomApellidos] [varchar](500) NOT NULL,
	[Rol_Id] [int] NOT NULL,
	[Usu_FecHoraRegistro] [datetime] NOT NULL,
	[Usu_Observacion] [varchar](500) NULL,
	[Usu_Estado] [tinyint] NOT NULL,
	[Usu_TokenActualizado] [nvarchar](max) NULL,
	[Usu_FecHoraTokenActualizado] [datetime] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[Usu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente] ADD  CONSTRAINT [DF_cliente_Cli_Estado]  DEFAULT ((1)) FOR [Cli_Estado]
GO
ALTER TABLE [dbo].[modulo] ADD  CONSTRAINT [DF_modulo_Mod_Estado]  DEFAULT ((1)) FOR [Mod_Estado]
GO
ALTER TABLE [dbo].[partida] ADD  CONSTRAINT [DF_partida_Par_Estado]  DEFAULT ((1)) FOR [Par_Estado]
GO
ALTER TABLE [dbo].[presupuesto] ADD  CONSTRAINT [DF_presupuesto_Pre_FecHorRegistro]  DEFAULT (getdate()) FOR [Pre_FecHorRegistro]
GO
ALTER TABLE [dbo].[presupuesto] ADD  CONSTRAINT [DF_presupuesto_Pre_Estado]  DEFAULT ((1)) FOR [Pre_Estado]
GO
ALTER TABLE [dbo].[recurso] ADD  CONSTRAINT [DF_recurso_Rec_Estado]  DEFAULT ((1)) FOR [Rec_Estado]
GO
ALTER TABLE [dbo].[rol] ADD  CONSTRAINT [DF_rol_Rol_Estado]  DEFAULT ((1)) FOR [Rol_Estado]
GO
ALTER TABLE [dbo].[unidad_medida] ADD  CONSTRAINT [DF_unidad_medida_UniMed_Estado]  DEFAULT ((1)) FOR [UniMed_Estado]
GO
ALTER TABLE [dbo].[unidad_medida_recurso] ADD  CONSTRAINT [DF_unidad_medida_recurso_UniMedRec_Estado]  DEFAULT ((1)) FOR [UniMedRec_Estado]
GO
ALTER TABLE [dbo].[unidad_medida_rendimiento] ADD  CONSTRAINT [DF_unidad_medida_rendimiento_UniMedRen_Estado]  DEFAULT ((1)) FOR [UniMedRen_Estado]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (getdate()) FOR [Usu_FecHoraRegistro]
GO
ALTER TABLE [dbo].[usuario] ADD  CONSTRAINT [DF_usuario_Usu_Estado]  DEFAULT ((1)) FOR [Usu_Estado]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_tipo_documento] FOREIGN KEY([TipDoc_Id])
REFERENCES [dbo].[tipo_documento] ([TipDoc_Id])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_tipo_documento]
GO
ALTER TABLE [dbo].[detalle_partida_recurso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_partida_recurso_partida] FOREIGN KEY([Par_Id])
REFERENCES [dbo].[partida] ([Par_Id])
GO
ALTER TABLE [dbo].[detalle_partida_recurso] CHECK CONSTRAINT [FK_detalle_partida_recurso_partida]
GO
ALTER TABLE [dbo].[detalle_partida_recurso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_partida_recurso_recurso] FOREIGN KEY([Rec_Id])
REFERENCES [dbo].[recurso] ([Rec_Id])
GO
ALTER TABLE [dbo].[detalle_partida_recurso] CHECK CONSTRAINT [FK_detalle_partida_recurso_recurso]
GO
ALTER TABLE [dbo].[detalle_rol_modulo]  WITH CHECK ADD  CONSTRAINT [FK_detalle_rol_modulo_modulo] FOREIGN KEY([Mod_Id])
REFERENCES [dbo].[modulo] ([Mod_Id])
GO
ALTER TABLE [dbo].[detalle_rol_modulo] CHECK CONSTRAINT [FK_detalle_rol_modulo_modulo]
GO
ALTER TABLE [dbo].[detalle_rol_modulo]  WITH CHECK ADD  CONSTRAINT [FK_detalle_rol_modulo_rol] FOREIGN KEY([Rol_Id])
REFERENCES [dbo].[rol] ([Rol_Id])
GO
ALTER TABLE [dbo].[detalle_rol_modulo] CHECK CONSTRAINT [FK_detalle_rol_modulo_rol]
GO
ALTER TABLE [dbo].[grupo_partida]  WITH CHECK ADD FOREIGN KEY([NomGruPar_Id])
REFERENCES [dbo].[nombre_grupo_partida] ([NomGruPar_Id])
GO
ALTER TABLE [dbo].[grupo_partida]  WITH CHECK ADD FOREIGN KEY([Pre_Id])
REFERENCES [dbo].[presupuesto] ([Pre_Id])
GO
ALTER TABLE [dbo].[partida]  WITH CHECK ADD FOREIGN KEY([GruPar_Id])
REFERENCES [dbo].[grupo_partida] ([GruPar_Id])
GO
ALTER TABLE [dbo].[partida]  WITH CHECK ADD  CONSTRAINT [FK_partida_unidad_medida] FOREIGN KEY([UniMed_Id])
REFERENCES [dbo].[unidad_medida] ([UniMed_Id])
GO
ALTER TABLE [dbo].[partida] CHECK CONSTRAINT [FK_partida_unidad_medida]
GO
ALTER TABLE [dbo].[partida]  WITH CHECK ADD  CONSTRAINT [FK_partida_unidad_medida_rendimiento] FOREIGN KEY([UniMedRen_Id])
REFERENCES [dbo].[unidad_medida_rendimiento] ([UniMedRen_Id])
GO
ALTER TABLE [dbo].[partida] CHECK CONSTRAINT [FK_partida_unidad_medida_rendimiento]
GO
ALTER TABLE [dbo].[presupuesto]  WITH CHECK ADD  CONSTRAINT [FK__presupues__Cli_I__1A9EF37A] FOREIGN KEY([Cli_Id])
REFERENCES [dbo].[cliente] ([Cli_Id])
GO
ALTER TABLE [dbo].[presupuesto] CHECK CONSTRAINT [FK__presupues__Cli_I__1A9EF37A]
GO
ALTER TABLE [dbo].[presupuesto]  WITH CHECK ADD  CONSTRAINT [FK__presupues__Ubi_I__19AACF41] FOREIGN KEY([Ubi_Id])
REFERENCES [dbo].[ubicacion] ([Ubi_Id])
GO
ALTER TABLE [dbo].[presupuesto] CHECK CONSTRAINT [FK__presupues__Ubi_I__19AACF41]
GO
ALTER TABLE [dbo].[presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_presupuesto_usuario] FOREIGN KEY([Usu_Id])
REFERENCES [dbo].[usuario] ([Usu_Id])
GO
ALTER TABLE [dbo].[presupuesto] CHECK CONSTRAINT [FK_presupuesto_usuario]
GO
ALTER TABLE [dbo].[recurso]  WITH CHECK ADD  CONSTRAINT [FK_recurso_tipo_recurso] FOREIGN KEY([TipRec_Id])
REFERENCES [dbo].[tipo_recurso] ([TipRec_Id])
GO
ALTER TABLE [dbo].[recurso] CHECK CONSTRAINT [FK_recurso_tipo_recurso]
GO
ALTER TABLE [dbo].[recurso]  WITH CHECK ADD  CONSTRAINT [FK_recurso_unidad_medida_recurso] FOREIGN KEY([UniMedRec_Id])
REFERENCES [dbo].[unidad_medida_recurso] ([UniMedRec_Id])
GO
ALTER TABLE [dbo].[recurso] CHECK CONSTRAINT [FK_recurso_unidad_medida_recurso]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([Rol_Id])
REFERENCES [dbo].[rol] ([Rol_Id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_rol]
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Actualiza]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Actualiza]
(
    @Cli_Id int,
    @Cli_NomApeRazSocial varchar(500),
    @Cli_Abreviatura varchar(100),
    @TipDoc_Nombre varchar(50),
		@Cli_NumDocumento varchar(12)
    		
)
AS
BEGIN

    DECLARE @TipDoc_Id int;

    SELECT @TipDoc_Id = TipDoc_Id
    FROM tipo_documento
    WHERE TipDoc_Nombre = @TipDoc_Nombre;

    UPDATE cliente
    SET Cli_NomApeRazSocial = @Cli_NomApeRazSocial,
        Cli_Abreviatura = @Cli_Abreviatura,
        TipDoc_Id = @TipDoc_Id,
				Cli_NumDocumento = @Cli_NumDocumento
        
    
		WHERE Cli_Id = @Cli_Id;
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Actualiza_Estado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Actualiza_Estado]
(
    @Cli_Id int,
    @Cli_Estado tinyint
)
AS
BEGIN
    UPDATE cliente
    SET Cli_Estado = @Cli_Estado
    WHERE Cli_Id = @Cli_Id;
    
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Crea]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Crea]
(
    @Cli_NomApeRazSocial varchar(500),
    @Cli_Abreviatura varchar(100),
    @TipDoc_Nombre varchar(50),
		@Cli_NumDocumento varchar(12),
    @Cli_Id int OUTPUT
)
AS
BEGIN
    DECLARE @TipDoc_Id int;
    SELECT @TipDoc_Id = TipDoc_Id
    FROM tipo_documento
    WHERE TipDoc_Nombre = @TipDoc_Nombre;
    INSERT INTO cliente (Cli_NomApeRazSocial, Cli_Abreviatura, TipDoc_Id, Cli_NumDocumento)
    VALUES (@Cli_NomApeRazSocial, @Cli_Abreviatura, @TipDoc_Id, @Cli_NumDocumento);
    
    SET @Cli_Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Existe]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Existe]
(
  @Cli_NumDocumento VARCHAR(50),
  @Cli_Estado tinyint
)
AS
BEGIN
  DECLARE @Cantidad INT;
	SELECT @Cantidad = COUNT(cli.Cli_Id)
  FROM cliente cli
  WHERE cli.Cli_NumDocumento = @Cli_NumDocumento AND cli.Cli_Estado = @Cli_Estado;
	SELECT @Cantidad AS Cantidad;
END
-- MUESTRA LA CANTIDAD DE ELEMENTOS QUE COINCIDEN CON LOS DATOS INGRESADOS
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Existente]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Existente]
(
  @Cli_Id INT,
  @Cli_NumDocumento VARCHAR(50),
  @Cli_Estado tinyint
)
AS
BEGIN
	DECLARE @Cantidad INT;
	
	SELECT @Cantidad = COUNT(*)
	FROM cliente cli
	WHERE cli.Cli_Id <> @Cli_Id
	  AND cli.Cli_NumDocumento = @Cli_NumDocumento
	  AND cli.Cli_Estado = @Cli_Estado;
	
	SELECT @Cantidad AS Cantidad;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Obten_Nombre]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Obten_Nombre]

AS
BEGIN
    SELECT Cli_NomApeRazSocial
		FROM cliente
		WHERE Cli_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Obten_Paginado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Obten_Paginado]
(
    @RegistroPagina INT,
    @NumeroPagina INT,
    @PorNombre VARCHAR(12)= NULL,
    @TotalPagina INT OUTPUT,
    @TotalRegistro INT OUTPUT,
    @TienePaginaAnterior BIT OUTPUT,
    @TienePaginaProximo BIT OUTPUT
)
AS
BEGIN
    DECLARE @TotalCnt INT;
    DECLARE @offsets INT;

    SET @TotalPagina = 0;

    IF @RegistroPagina > 0 OR @NumeroPagina > 0
    BEGIN
        SELECT @TotalCnt = COUNT(*)
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR cli.Cli_NumDocumento LIKE '%' + @PorNombre + '%';

        IF @TotalCnt = 0
        BEGIN
            SET @TotalPagina = 0;
        END
        ELSE IF @TotalCnt % @RegistroPagina = 0
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina;
        END
        ELSE
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina + 1;
        END

        SELECT @TotalRegistro = COUNT(*)
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR cli.Cli_NumDocumento LIKE '%' + @PorNombre + '%';

        SET @offsets = @RegistroPagina * (@NumeroPagina - 1);

        IF @NumeroPagina > 1
        BEGIN
            SET @TienePaginaAnterior = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaAnterior = 0;
        END

        IF @NumeroPagina < @TotalPagina
        BEGIN
            SET @TienePaginaProximo = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaProximo = 0;
        END

        SELECT cli.Cli_Id,
               cli.Cli_NomApeRazSocial,
               cli.Cli_Abreviatura,
               tipdoc.TipDoc_Nombre,
               cli.Cli_NumDocumento,
               cli.Cli_Estado
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE (@PorNombre IS NULL OR @PorNombre = '' OR cli.Cli_NumDocumento LIKE '%' + @PorNombre + '%')
            AND cli.Cli_Estado = 1
        ORDER BY cli.Cli_NomApeRazSocial
        OFFSET @offsets ROWS
        FETCH NEXT @RegistroPagina ROWS ONLY;

        -- Asignar valores a los parámetros de salida
        SET @TotalPagina = @TotalPagina;
        SET @TotalRegistro = @TotalRegistro;
        SET @TienePaginaAnterior = @TienePaginaAnterior;
        SET @TienePaginaProximo = @TienePaginaProximo;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Obten_Paginado_v2]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Obten_Paginado_v2]
(
    @Opcion INT,
    @Valor VARCHAR(12),
    @Inicio INT,
    @Fin INT
)
AS
BEGIN
    DECLARE @limit1 INT = 0;
    DECLARE @limit2 INT = 100;
    
    SET @limit1 = @Inicio;
    SET @limit2 = @Fin;
    
    IF @Opcion = 0
    BEGIN
        SELECT cli.Cli_Id,
               cli.Cli_NomApeRazSocial,
               cli.Cli_Abreviatura,
               tipdoc.TipDoc_Nombre,
               cli.Cli_NumDocumento,
               cli.Cli_Estado
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE (@Valor IS NULL OR cli.Cli_NumDocumento LIKE '%' + @Valor + '%')
        ORDER BY cli.Cli_NomApeRazSocial
        OFFSET @limit1 ROWS
        FETCH NEXT @limit2 ROWS ONLY;
    END
    ELSE IF @Opcion = 1
    BEGIN
        SELECT cli.Cli_Id,
               cli.Cli_NomApeRazSocial,
               cli.Cli_Abreviatura,
               tipdoc.TipDoc_Nombre,
               cli.Cli_NumDocumento,
               cli.Cli_Estado
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE (@Valor IS NULL OR cli.Cli_NumDocumento LIKE '%' + @Valor + '%')
            AND (@Valor IS NULL OR (cli.Cli_Estado = 1 AND cli.Cli_NumDocumento IS NOT NULL))
        ORDER BY cli.Cli_NomApeRazSocial
        OFFSET @limit1 ROWS
        FETCH NEXT @limit2 ROWS ONLY;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Obten_x_Id]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Obten_x_Id]
(
    @Cli_Id int
)
AS
BEGIN
    SELECT cli.Cli_Id, cli.Cli_NomApeRazSocial, cli.Cli_Abreviatura, tipdoc.TipDoc_Nombre, cli.Cli_NumDocumento, cli.Cli_Estado
    FROM cliente cli
    INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
    WHERE cli.Cli_Id = @Cli_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Obten_x_Nombre]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Obten_x_Nombre]
(@Cli_NomApeRazSocial VARCHAR(500))
AS
BEGIN
    SELECT Cli_NomApeRazSocial
		FROM cliente
		WHERE (Cli_NomApeRazSocial = @Cli_NomApeRazSocial OR Cli_NomApeRazSocial LIKE '%' + @Cli_NomApeRazSocial + '%' ) AND Cli_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Cliente_Obten_x_NumDocumento]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Cliente_Obten_x_NumDocumento]
(
    @Cli_NumDocumento varchar(12)
)
AS
BEGIN
    SELECT cli.Cli_NomApeRazSocial,
					 tipdoc.TipDoc_Nombre,
					 cli.Cli_NumDocumento
		FROM cliente cli
		INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
		WHERE @Cli_NumDocumento = cli.Cli_NumDocumento AND Cli_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Grupo_Partida_Crea]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Grupo_Partida_Crea]
(
    @NomGruPar_Nombre varchar(500),
    @Pre_Codigo varchar(500),
    @GruPar_Id int OUTPUT
)
AS
BEGIN
    
		DECLARE @NomGruPar_Id int;
    SELECT @NomGruPar_Id = NomGruPar_Id
    FROM nombre_grupo_partida
    WHERE NomGruPar_Nombre = @NomGruPar_Nombre;
		
		INSERT INTO nombre_grupo_partida (NomGruPar_Nombre)
    VALUES (@NomGruPar_Nombre);
		SELECT @NomGruPar_Id = SCOPE_IDENTITY();
		
		DECLARE @Pre_Id int;
    SELECT @Pre_Id = Pre_Id
    FROM presupuesto
    WHERE Pre_Codigo = @Pre_Codigo;
		
    INSERT INTO grupo_partida (NomGruPar_Id, Pre_Id)
    VALUES (@NomGruPar_Id, @Pre_Id);
    
    SET @GruPar_Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Grupo_Partida_Crea_vAnterior]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Grupo_Partida_Crea_vAnterior]
(
    @NomGruPar_Nombre varchar(500),
    @GruParPadre_Nombre varchar(500),
    @Pre_Nombre varchar(500),
    @GruPar_Id int OUTPUT
)
AS
BEGIN
    
    --validar si existe PrupoPartida Superior
    IF @GruParPadre_Nombre IS NOT NULL
    BEGIN
        SELECT DISTINCT GruPar_Id
        FROM grupo_partida
        JOIN presupuesto ON grupo_partida.Pre_Id = presupuesto.Pre_Id
        JOIN nombre_grupo_partida ON grupo_partida.NomGruPar_Id = nombre_grupo_partida.NomGruPar_Id
        WHERE nombre_grupo_partida.NomGruPar_Nombre = @GruParPadre_Nombre
        AND presupuesto.Pre_Nombre = @Pre_Nombre;
    END;
    
    -- Insertar
    DECLARE @Pre_Id int;
    SELECT @Pre_Id = Pre_Id
    FROM presupuesto
    WHERE Pre_Nombre = @Pre_Nombre;
    
    -- Verificar si el valor ingresado para @NomGruPar_Nombre existe
    IF NOT EXISTS (
        SELECT *
        FROM nombre_grupo_partida
        WHERE NomGruPar_Nombre = @NomGruPar_Nombre
    )
    BEGIN
        -- Crear el nuevo valor
        INSERT INTO nombre_grupo_partida (NomGruPar_Nombre)
        VALUES (@NomGruPar_Nombre);
        
        -- Obtener el ID del nuevo valor
        DECLARE @NomGruPar_Id int;
				SELECT @NomGruPar_Id = NomGruPar_Id
        FROM nombre_grupo_partida
        WHERE NomGruPar_Nombre = @NomGruPar_Nombre;
    END
    
    INSERT INTO grupo_partida (NomGruPar_Id, GruParPadre_Id, Pre_Id)
    VALUES (@NomGruPar_Id,
            (SELECT TOP 1 GruPar_Id
             FROM grupo_partida
             JOIN presupuesto ON grupo_partida.Pre_Id = presupuesto.Pre_Id
             JOIN nombre_grupo_partida ON grupo_partida.NomGruPar_Id = nombre_grupo_partida.NomGruPar_Id
             WHERE nombre_grupo_partida.NomGruPar_Nombre = @GruParPadre_Nombre
             AND presupuesto.Pre_Nombre = @Pre_Nombre
             ORDER BY GruPar_Id DESC),
            @Pre_Id);
    
    SET @GruPar_Id = SCOPE_IDENTITY();
    
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Grupo_Partida_Obten_Paginado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Grupo_Partida_Obten_Paginado]
(
    @RegistroPagina INT,
    @NumeroPagina INT,
    @PorNombre VARCHAR(12)= NULL,
    @TotalPagina INT OUTPUT,
    @TotalRegistro INT OUTPUT,
    @TienePaginaAnterior BIT OUTPUT,
    @TienePaginaProximo BIT OUTPUT
)
AS
BEGIN
    DECLARE @TotalCnt INT;
    DECLARE @offsets INT;

    SET @TotalPagina = 0;

    IF @RegistroPagina > 0 OR @NumeroPagina > 0
    BEGIN
        SELECT @TotalCnt = COUNT(*)
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR cli.Cli_NumDocumento LIKE '%' + @PorNombre + '%';

        IF @TotalCnt = 0
        BEGIN
            SET @TotalPagina = 0;
        END
        ELSE IF @TotalCnt % @RegistroPagina = 0
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina;
        END
        ELSE
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina + 1;
        END

        SELECT @TotalRegistro = COUNT(*)
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR cli.Cli_NumDocumento LIKE '%' + @PorNombre + '%';

        SET @offsets = @RegistroPagina * (@NumeroPagina - 1);

        IF @NumeroPagina > 1
        BEGIN
            SET @TienePaginaAnterior = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaAnterior = 0;
        END

        IF @NumeroPagina < @TotalPagina
        BEGIN
            SET @TienePaginaProximo = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaProximo = 0;
        END

        SELECT cli.Cli_Id,
               cli.Cli_NomApeRazSocial,
               cli.Cli_Abreviatura,
               tipdoc.TipDoc_Nombre,
               cli.Cli_NumDocumento,
               cli.Cli_Estado
        FROM cliente cli
        INNER JOIN tipo_documento tipdoc ON cli.TipDoc_Id = tipdoc.TipDoc_Id
        WHERE (@PorNombre IS NULL OR @PorNombre = '' OR cli.Cli_NumDocumento LIKE '%' + @PorNombre + '%')
            AND cli.Cli_Estado = 1
        ORDER BY cli.Cli_NomApeRazSocial
        OFFSET @offsets ROWS
        FETCH NEXT @RegistroPagina ROWS ONLY;

        -- Asignar valores a los parámetros de salida
        SET @TotalPagina = @TotalPagina;
        SET @TotalRegistro = @TotalRegistro;
        SET @TienePaginaAnterior = @TienePaginaAnterior;
        SET @TienePaginaProximo = @TienePaginaProximo;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Grupo_Partida_Obten_SubGrupos_VAnterior]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Grupo_Partida_Obten_SubGrupos_VAnterior]
(
    @Pre_Nombre varchar(500),
    @NomGruPar_Nombre varchar(500)
)
AS
BEGIN
    
    --Crear tabla temporal para almacenar id de subgrupos y sus nombres
    CREATE TABLE #TablaSubGrupos
    (
        GruPar_Id int,
        NomGruPar_Nombre varchar(500)
    )

    --Insertar id de subgrupo y su nombre en la tabla temporal
    INSERT INTO #TablaSubGrupos
    (
        GruPar_Id,
        NomGruPar_Nombre
    )
    SELECT grupar.GruPar_Id, nomgrupar.NomGruPar_Nombre
    FROM grupo_partida grupar
    INNER JOIN presupuesto pre ON grupar.Pre_Id = pre.Pre_Id
    INNER JOIN nombre_grupo_partida nomgrupar ON grupar.NomGruPar_Id = nomgrupar.NomGruPar_Id
    WHERE grupar.GruParPadre_Id IS NULL AND pre.Pre_Nombre = @Pre_Nombre AND nomgrupar.NomGruPar_Nombre = @NomGruPar_Nombre;

    --Realizar consulta para obtener todos los subgrupos dentro del subgrupo ingresado
    SELECT nomgrupar.NomGruPar_Nombre,
					 grupar.GruPar_Total					 
		FROM grupo_partida grupar 
		INNER JOIN presupuesto pre ON grupar.Pre_Id = pre.Pre_Id
		INNER JOIN nombre_grupo_partida nomgrupar ON grupar.NomGruPar_Id = nomgrupar.NomGruPar_Id
		WHERE grupar.GruParPadre_Id IN (SELECT GruPar_Id FROM #TablaSubGrupos)
		AND pre.Pre_Nombre = @Pre_Nombre;

    --Eliminar tabla temporal
    DROP TABLE #TablaSubGrupos;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Grupo_Partida_Obten_x_Nombre]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Grupo_Partida_Obten_x_Nombre]
(@NomGruPar_Nombre VARCHAR(500))
AS
BEGIN
    SELECT NomGruPar_Nombre
		FROM nombre_grupo_partida
		WHERE (NomGruPar_Nombre = @NomGruPar_Nombre OR NomGruPar_Nombre LIKE '%' + @NomGruPar_Nombre + '%' );
		--(para dropdown cuando se cree un grupo partida)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Grupo_Partida_Obten_x_Presupuesto_VAnterior]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Grupo_Partida_Obten_x_Presupuesto_VAnterior]
(
    @Pre_Nombre varchar(500)
)
AS
BEGIN
    SELECT nomgrupar.NomGruPar_Nombre,
					 grupar.GruPar_Total					 
		FROM grupo_partida grupar 
		INNER JOIN presupuesto pre ON grupar.Pre_Id = pre.Pre_Id
		INNER JOIN nombre_grupo_partida nomgrupar ON grupar.NomGruPar_Id = nomgrupar.NomGruPar_Id
		WHERE grupar.GruParPadre_Id IS NULL AND pre.Pre_Nombre = @Pre_Nombre;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Nombre_Grupo_Partida_Actualiza]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Nombre_Grupo_Partida_Actualiza]
(
    @NomGruPar_Id int,
    @NomGruPar_Nombre varchar(500)
    		
)
AS
BEGIN

    UPDATE nombre_grupo_partida
    SET NomGruPar_Nombre = @NomGruPar_Nombre
		WHERE NomGruPar_Id = @NomGruPar_Id;
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Partida_Actualiza]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Partida_Actualiza]
(
    @Par_Id int,
    @Par_Nombre varchar(500),
		@UniMed_Abreviatura varchar(50)
	
)
AS
BEGIN

		DECLARE @UniMed_Id int;
		SELECT @UniMed_Id = UniMed_Id
    FROM unidad_medida
    WHERE UniMed_Abreviatura = @UniMed_Abreviatura;

    UPDATE partida
    
		SET Par_Nombre = @Par_Nombre,
				UniMed_Id = @UniMed_Id
    
		WHERE Par_Id = @Par_Id;
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Partida_Crea]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Partida_Crea]
(
    @Pre_Codigo varchar(500),
    @NomGruPar_Nombre varchar(500),
    @Par_Nombre varchar(500),
    @Par_RenManObra DECIMAL(18,2),
    @Par_RenEquipo DECIMAL(18,2),
    @UniMed_Nombre varchar(50),
		@Par_PreUnitario DECIMAL(18,2),
    
		@Par_Id int OUTPUT
)
AS
BEGIN
    
		DECLARE @GruPar_Id int;
		DECLARE @NomGruPar_Id int;
    DECLARE @UniMed_Id int;
    DECLARE @Pre_Id int;

    SELECT @GruPar_Id = GruPar_Id
		FROM grupo_partida grupar
		JOIN nombre_grupo_partida nomgrupar ON grupar.NomGruPar_Id = nomgrupar.NomGruPar_Id
		JOIN presupuesto pre ON grupar.Pre_Id = pre.Pre_Id
		WHERE nomgrupar.NomGruPar_Nombre = @NomGruPar_Nombre AND pre.Pre_Codigo = @Pre_Codigo
		
    SELECT @UniMed_Id = UniMed_Id
    FROM unidad_medida
    WHERE UniMed_Nombre = @UniMed_Nombre;    

    INSERT INTO partida (Par_Nombre, Par_RenManObra, Par_RenEquipo, UniMed_Id, Par_PreUnitario, GruPar_Id)
    VALUES (@Par_Nombre, @Par_RenManObra, @Par_RenEquipo, @UniMed_Id, @Par_PreUnitario, @GruPar_Id);

    SET @Par_Id = SCOPE_IDENTITY();
END
--AL CREAR UNA PARTIDA ESTA DEBE SER ASIGNADA A UN GRUPO PARTIDA Y A UN PRESUPUESTO
--PUEDEN EXISTIR PARTIDAS CON EL MISMO NOMBRE EN DISTINTOS PRESUPUESTOS PERO NO NECESARIAMENTE TENER LOS MISMOS DATOS,
--LOS COSTOS PUEDEN CAMBIAR DEPENDIENDO DEL PRESUPUESTO/PROYECTO
GO
/****** Object:  StoredProcedure [dbo].[SP_Partida_Obten]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Partida_Obten]
(@Pre_Codigo VARCHAR(500),
 @NomGruPar_Nombre VARCHAR(500))
AS
BEGIN
    
		DECLARE @GruPar_Id int;
		DECLARE @NomGruPar_Id int;
    DECLARE @UniMed_Id int;
    DECLARE @Pre_Id int;
/*
    SELECT @GruPar_Id = GruPar_Id
		FROM grupo_partida grupar
		JOIN nombre_grupo_partida nomgrupar ON grupar.NomGruPar_Id = nomgrupar.NomGruPar_Id
		JOIN presupuesto pre ON grupar.Pre_Id = pre.Pre_Id
		WHERE nomgrupar.NomGruPar_Nombre = @NomGruPar_Nombre AND pre.Pre_Codigo = @Pre_Codigo
		
*/		
		SELECT Par_Nombre,
					 Par_RenManObra,
					 Par_RenEquipo,
					 UniMed_Abreviatura,
					 Par_PreUnitario
 		FROM partida par
		INNER JOIN unidad_medida unimed ON par.UniMed_Id = unimed.UniMed_Id
		INNER JOIN grupo_partida grupar ON par.GruPar_Id = grupar.GruPar_Id
		INNER JOIN presupuesto pre ON grupar.Pre_Id = pre.Pre_Id
		INNER JOIN nombre_grupo_partida nomgrupar ON grupar.NomGruPar_Id = nomgrupar.NomGruPar_Id
		WHERE nomgrupar.NomGruPar_Nombre = @NomGruPar_Nombre AND pre.Pre_Codigo = @Pre_Codigo

		
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Partida_Obten_x_Id]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Partida_Obten_x_Id]
(
    @Par_Id int
)
AS
BEGIN
    SELECT par.Par_Nombre,
					 unimed.UniMed_Abreviatura
    FROM partida par
    INNER JOIN unidad_medida unimed ON par.UniMed_Id = unimed.UniMed_Id
    WHERE par.Par_Id= @Par_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Actualiza]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Actualiza]
(
    @Pre_Id int,
    @Usu_NomApellidos varchar(500),
    @Pre_Nombre varchar(500),
    @Cli_NomApeRazSocial varchar(500),
    @Ubi_Departamento varchar(100),
    @Ubi_Provincia varchar(100),
    @Ubi_Distrito varchar(100),
    @Pre_Jornal DECIMAL(18,2)    		
)
AS
BEGIN

    DECLARE @Usu_Id int;
    SELECT @Usu_Id = Usu_Id
    FROM usuario
    WHERE Usu_NomApellidos = @Usu_NomApellidos;
		
		DECLARE @Cli_Id int;
    SELECT @Cli_Id = Cli_Id
    FROM cliente
    WHERE Cli_NomApeRazSocial = @Cli_NomApeRazSocial;
		
		DECLARE @Ubi_Id int;
    SELECT @Ubi_Id = Ubi_Id
    FROM ubicacion
    WHERE Ubi_Departamento = @Ubi_Departamento AND Ubi_Provincia = @Ubi_Provincia AND Ubi_Distrito = @Ubi_Distrito;

    UPDATE presupuesto
    
		SET Usu_Id = @Usu_Id,
				Pre_Nombre = @Pre_Nombre,
				Cli_Id = @Cli_Id,
				Ubi_Id = @Ubi_Id,
				Pre_Jornal = @Pre_Jornal
    
		WHERE Pre_Id = @Pre_Id;
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Actualiza_Estado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Actualiza_Estado]
(
    @Pre_Id int,
    @Pre_Estado tinyint
)
AS
BEGIN
    UPDATE presupuesto
    SET Pre_Estado = @Pre_Estado
    WHERE Pre_Id = @Pre_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Crea]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Crea]
(
    @Usu_NomApellidos varchar(500),
    @Pre_Nombre varchar(500),
    @Cli_NomApeRazSocial varchar(500),
    @Ubi_Departamento varchar(100),
    @Ubi_Provincia varchar(100),
    @Ubi_Distrito varchar(100),
    @Pre_Jornal DECIMAL(18,2),
    @Pre_Id int OUTPUT
)
AS
BEGIN
    DECLARE @Usu_Id int;
    SELECT @Usu_Id = Usu_Id
    FROM usuario
    WHERE Usu_NomApellidos = @Usu_NomApellidos;
		
		DECLARE @Cli_Id int;
    SELECT @Cli_Id = Cli_Id
    FROM cliente
    WHERE Cli_NomApeRazSocial = @Cli_NomApeRazSocial;
		
		DECLARE @Ubi_Id int;
    SELECT @Ubi_Id = Ubi_Id
    FROM ubicacion
    WHERE Ubi_Departamento = @Ubi_Departamento AND Ubi_Provincia = @Ubi_Provincia AND Ubi_Distrito = @Ubi_Distrito;
		
    INSERT INTO presupuesto (Usu_Id,Pre_Codigo, Pre_Nombre, Cli_Id, Ubi_Id, Pre_Jornal)
    VALUES (@Usu_Id, dbo.fn_AutogenerarCodigoPresupuesto(),@Pre_Nombre, @Cli_Id, @Ubi_Id, @Pre_Jornal);
    
    SET @Pre_Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Existe]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Existe]
(
  @Pre_Nombre VARCHAR(50),
  @Pre_Estado tinyint
)
AS
BEGIN
  DECLARE @Cantidad INT;
	SELECT @Cantidad = COUNT(pre.Pre_Id)
  FROM presupuesto pre
  WHERE pre.Pre_Nombre = @Pre_Nombre AND pre.Pre_Estado = @Pre_Estado;
	SELECT @Cantidad AS Cantidad;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Existente]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Existente]
(
  @Pre_Id INT,
  @Pre_Nombre VARCHAR(500),
  @Pre_Estado tinyint
)
AS
BEGIN
	DECLARE @Cantidad INT;
	
	SELECT @Cantidad = COUNT(*)
	FROM presupuesto pre
	WHERE pre.Pre_Id <> @Pre_Id
	  AND pre.Pre_Nombre = @Pre_Nombre
	  AND pre.Pre_Estado = @Pre_Estado;
	
	SELECT @Cantidad AS Cantidad;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Obten]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Obten]
AS
BEGIN
    SELECT Pre_Nombre
 		FROM presupuesto
		WHERE Pre_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Obten_Paginado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Obten_Paginado]
(
    @RegistroPagina INT,
    @NumeroPagina INT,
    @PorNombre VARCHAR(12),
    @TotalPagina INT OUTPUT,
    @TotalRegistro INT OUTPUT,
    @TienePaginaAnterior BIT OUTPUT,
    @TienePaginaProximo BIT OUTPUT
)
AS
BEGIN
    DECLARE @TotalCnt INT;
    DECLARE @offsets INT;

    SET @TotalPagina = 0;

    IF @RegistroPagina > 0 OR @NumeroPagina > 0
    BEGIN
        SELECT @TotalCnt = COUNT(*)
        FROM presupuesto pre
        INNER JOIN usuario usu ON pre.Usu_Id = usu.Usu_Id
				INNER JOIN cliente cli ON pre.Cli_Id = cli.Cli_Id
				INNER JOIN ubicacion ubi ON pre.Ubi_Id = ubi.Ubi_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR pre.Pre_Nombre LIKE '%' + @PorNombre + '%';

        IF @TotalCnt = 0
        BEGIN
            SET @TotalPagina = 0;
        END
        ELSE IF @TotalCnt % @RegistroPagina = 0
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina;
        END
        ELSE
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina + 1;
        END

        SELECT @TotalRegistro = COUNT(*)
        FROM presupuesto pre
        INNER JOIN usuario usu ON pre.Usu_Id = usu.Usu_Id
				INNER JOIN cliente cli ON pre.Cli_Id = cli.Cli_Id
				INNER JOIN ubicacion ubi ON pre.Ubi_Id = ubi.Ubi_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR pre.Pre_Nombre LIKE '%' + @PorNombre + '%';

        SET @offsets = @RegistroPagina * (@NumeroPagina - 1);

        IF @NumeroPagina > 1
        BEGIN
            SET @TienePaginaAnterior = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaAnterior = 0;
        END

        IF @NumeroPagina < @TotalPagina
        BEGIN
            SET @TienePaginaProximo = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaProximo = 0;
        END

        SELECT pre.Pre_Id,
							 pre.Pre_Codigo,
							 usu.Usu_NomApellidos,
							 pre.Pre_Nombre,
							 cli.Cli_NomApeRazSocial,
							 ubi.Ubi_Departamento,
							 ubi.Ubi_Provincia,
							 ubi.Ubi_Distrito,
							 pre.Pre_Jornal,
							 pre.Pre_FecHorRegistro,
							 pre.Pre_Estado
        FROM presupuesto pre
        INNER JOIN usuario usu ON pre.Usu_Id = usu.Usu_Id
				INNER JOIN cliente cli ON pre.Cli_Id = cli.Cli_Id
				INNER JOIN ubicacion ubi ON pre.Ubi_Id = ubi.Ubi_Id
        WHERE (@PorNombre IS NULL OR @PorNombre = '' OR pre.Pre_Nombre LIKE '%' + @PorNombre + '%')
            AND pre.Pre_Estado = 1
        ORDER BY pre.Pre_Nombre
        OFFSET @offsets ROWS
        FETCH NEXT @RegistroPagina ROWS ONLY;

        -- Asignar valores a los parámetros de salida
        SET @TotalPagina = @TotalPagina;
        SET @TotalRegistro = @TotalRegistro;
        SET @TienePaginaAnterior = @TienePaginaAnterior;
        SET @TienePaginaProximo = @TienePaginaProximo;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Presupuesto_Obten_x_Id]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Presupuesto_Obten_x_Id]
(
    @Pre_Id int
)
AS
BEGIN
    SELECT pre.Pre_Id,
					 pre.Pre_Codigo,
					 usu.Usu_NomApellidos,
					 pre.Pre_Nombre,
					 cli.Cli_NomApeRazSocial,
					 ubi.Ubi_Departamento,
					 ubi.Ubi_Provincia,
					 ubi.Ubi_Distrito,
					 pre.Pre_Jornal,
					 pre.Pre_Estado
					 
    FROM presupuesto pre
		INNER JOIN usuario usu ON pre.Usu_Id = usu.Usu_Id
		INNER JOIN ubicacion ubi ON pre.Ubi_Id = ubi.Ubi_Id
		INNER JOIN cliente cli ON pre.Cli_Id = cli.Cli_Id
    WHERE pre.Pre_Id = @Pre_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Recurso_Actualiza_Estado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Recurso_Actualiza_Estado]
(
    @Rec_Id int,
    @Rec_Estado tinyint
)
AS
BEGIN
    UPDATE recurso
    SET Rec_Estado = @Rec_Estado
    WHERE Rec_Id = @Rec_Id;
    
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Recurso_Crea]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Recurso_Crea]
(
    @Rec_Nombre varchar(500),
    @TipRec_Nombre varchar(100),
    @UniMedRec_Nombre varchar(100),
		@Rec_Cuadrilla DECIMAL(18,2),
		@Rec_Cantidad DECIMAL(18,2),
		@Rec_Precio DECIMAL(18,2),
		@Rec_Parcial DECIMAL(18,2),
		
    @Rec_Id int OUTPUT
)
AS
BEGIN
    DECLARE @TipRec_Id int;
    SELECT @TipRec_Id = TipRec_Id
    FROM tipo_recurso
    WHERE TipRec_Nombre = @TipRec_Nombre;
		
		DECLARE @UniMedRec_Id int;
    SELECT @UniMedRec_Id = UniMedRec_Id
    FROM unidad_medida_recurso
    WHERE UniMedRec_Nombre = @UniMedRec_Nombre;
    
		INSERT INTO recurso (Rec_Nombre, TipRec_Id, UniMedRec_Id, Rec_Cuadrilla,Rec_Cantidad,Rec_Precio,Rec_Parcial)
    VALUES (@Rec_Nombre, @TipRec_Id, @UniMedRec_Id, @Rec_Cuadrilla, @Rec_Cantidad, @Rec_Precio, @Rec_Parcial);
    
    SET @Rec_Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Recurso_Obten_x_Nombre]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Recurso_Obten_x_Nombre]
(@Rec_Nombre VARCHAR(500))
AS
BEGIN
    SELECT Rec_Nombre,
					 Rec_Precio,
					 UniMedRec_Abreviatura,
					 Rec_Cantidad,
					 Rec_Cuadrilla,
					 Rec_Parcial
		FROM recurso rec
		INNER JOIN unidad_medida_recurso uniMedRec ON rec.UniMedRec_Id = uniMedRec.UniMedRec_Id
		WHERE (Rec_Nombre = @Rec_Nombre OR Rec_Nombre LIKE '%' + @Rec_Nombre + '%' ) AND Rec_Estado = 1;
END
/*
CREA RECURSO SIN ASOCIAR A UNA PARTIDA O PRESUPUESTO
*/
GO
/****** Object:  StoredProcedure [dbo].[SP_Rol_Obten]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Rol_Obten]

AS
BEGIN
    SELECT Rol_Nombre
		FROM rol
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Tipo_Documento_Obten]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Tipo_Documento_Obten]

AS
BEGIN
    SELECT TipDoc_Nombre
		FROM tipo_documento
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Ubicacion_Obten]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Ubicacion_Obten]

AS
BEGIN
		SELECT Ubi_Departamento,Ubi_Provincia, Ubi_Distrito
		FROM ubicacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Ubicacion_Obten_x_Nombre]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Ubicacion_Obten_x_Nombre]
(
    @Ubi_Departamento varchar(100),
    @Ubi_Provincia varchar(100),
    @Ubi_Distrito varchar(100)
)
AS
BEGIN
    SELECT ubi.Ubi_Departamento,
					 ubi.Ubi_Provincia,
					 ubi.Ubi_Distrito
		FROM ubicacion ubi
		WHERE ((@Ubi_Departamento IS NULL OR @Ubi_Departamento = '') OR ubi.Ubi_Departamento = @Ubi_Departamento)
		AND ((@Ubi_Provincia IS NULL OR @Ubi_Provincia = '') OR ubi.Ubi_Provincia = @Ubi_Provincia)
		AND ((@Ubi_Distrito IS NULL OR @Ubi_Distrito = '') OR ubi.Ubi_Distrito = @Ubi_Distrito)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Actualiza]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Actualiza]
(
    @Usu_Id int,
    @Usu_Correo varchar(50),
    @Usu_Clave varchar(50),
    @Usu_NomApellidos varchar(500),
		@Rol_Nombre varchar(50),
		@Usu_Observacion varchar(500)
    		
)
AS
BEGIN

    DECLARE @Rol_Id int;

    SELECT @Rol_Id = Rol_Id
    FROM rol
    WHERE Rol_Nombre = @Rol_Nombre;

    UPDATE usuario
    SET Usu_Correo = @Usu_Correo,
        Usu_Clave = @Usu_Clave,
        Usu_NomApellidos = @Usu_NomApellidos,
				Rol_Id = @Rol_Id,
				Usu_Observacion = @Usu_Observacion
    
		WHERE Usu_Id = @Usu_Id;
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Actualiza_Estado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Actualiza_Estado]
(
    @Usu_Id int,
    @Usu_Estado tinyint
)
AS
BEGIN
    UPDATE usuario
    SET Usu_Estado = @Usu_Estado
    WHERE Usu_Id = @Usu_Id;
    
    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Actualiza_Token]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Actualiza_Token]
(
    @Usu_Correo varchar(50),
		@Usu_TokenActualizado nvarchar(MAX),
		@Usu_FecHoraTokenActualizado datetime
)
AS
BEGIN
    UPDATE usuario
		SET Usu_TokenActualizado = @Usu_TokenActualizado,
				Usu_FecHoraTokenActualizado = @Usu_FecHoraTokenActualizado
		WHERE Usu_Correo = @Usu_Correo AND Usu_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Crea]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Crea]
(
    @Usu_Correo varchar(50),
    @Usu_Clave varchar(50),
    @Usu_NomApellidos varchar(500),
		@Rol_Nombre varchar(50),
    @Usu_Id int OUTPUT
)
AS
BEGIN
    DECLARE @Rol_Id int;
    SELECT @Rol_Id = Rol_Id
    FROM rol
    WHERE Rol_Nombre = @Rol_Nombre;
    INSERT INTO usuario (Usu_Correo, Usu_Clave, Usu_NomApellidos, Rol_Id)
    VALUES (@Usu_Correo, @Usu_Clave, @Usu_NomApellidos, @Rol_Id);
    
    SET @Usu_Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Existe]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Existe]
(
  @Usu_Correo VARCHAR(50),
  @Usu_Estado tinyint
)
AS
BEGIN
  DECLARE @Cantidad INT;
	SELECT @Cantidad = COUNT(usu.Usu_Id)
  FROM usuario usu
  WHERE usu.Usu_Correo = @Usu_Correo AND usu.Usu_Estado = @Usu_Estado;
	SELECT @Cantidad AS Cantidad;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Existente]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Existente]
(
  @Usu_Id INT,
  @Usu_Correo VARCHAR(50),
  @Usu_Estado tinyint
)
AS
BEGIN
	DECLARE @Cantidad INT;
	
	SELECT @Cantidad = COUNT(*)
	FROM usuario usu
	WHERE usu.Usu_Id <> @Usu_Id
	  AND usu.Usu_Correo = @Usu_Correo
	  AND usu.Usu_Estado = @Usu_Estado;
	
	SELECT @Cantidad AS Cantidad;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Obten]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Obten]

AS
BEGIN
    SELECT Usu_NomApellidos
		FROM usuario
		WHERE Usu_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Obten_Login]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Obten_Login]
(
    @Usu_Correo varchar(50),
		@Usu_Clave varchar(50)
)
AS
BEGIN
    DECLARE @Cantidad INT;
		SELECT @Cantidad = COUNT(usu.Usu_Id) 
		FROM usuario usu
		WHERE usu.Usu_Correo = @Usu_Correo AND usu.Usu_Clave = @Usu_Clave
		AND usu.Usu_Estado = 1;
		SELECT @Cantidad AS Cantidad;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Obten_Paginado]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Obten_Paginado]
(
    @RegistroPagina INT,
    @NumeroPagina INT,
    @PorNombre VARCHAR(12),
    @TotalPagina INT OUTPUT,
    @TotalRegistro INT OUTPUT,
    @TienePaginaAnterior BIT OUTPUT,
    @TienePaginaProximo BIT OUTPUT
)
AS
BEGIN
    DECLARE @TotalCnt INT;
    DECLARE @offsets INT;

    SET @TotalPagina = 0;

    IF @RegistroPagina > 0 OR @NumeroPagina > 0
    BEGIN
        SELECT @TotalCnt = COUNT(*)
        FROM usuario usu
        INNER JOIN rol ro ON usu.Rol_Id = ro.Rol_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR usu.Usu_Correo LIKE '%' + @PorNombre + '%';

        IF @TotalCnt = 0
        BEGIN
            SET @TotalPagina = 0;
        END
        ELSE IF @TotalCnt % @RegistroPagina = 0
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina;
        END
        ELSE
        BEGIN
            SET @TotalPagina = @TotalCnt / @RegistroPagina + 1;
        END

        SELECT @TotalRegistro = COUNT(*)
        FROM usuario usu
        INNER JOIN rol ro ON usu.Rol_Id = ro.Rol_Id
        WHERE @PorNombre IS NULL OR @PorNombre = '' OR usu.Usu_Correo LIKE '%' + @PorNombre + '%';

        SET @offsets = @RegistroPagina * (@NumeroPagina - 1);

        IF @NumeroPagina > 1
        BEGIN
            SET @TienePaginaAnterior = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaAnterior = 0;
        END

        IF @NumeroPagina < @TotalPagina
        BEGIN
            SET @TienePaginaProximo = 1;
        END
        ELSE
        BEGIN
            SET @TienePaginaProximo = 0;
        END

        SELECT usu.Usu_Id,
							 usu.Usu_Correo,
							 usu.Usu_NomApellidos,
							 ro.Rol_Nombre,
							 usu.Usu_FecHoraRegistro,
							 usu.Usu_Observacion,
							 usu.Usu_Estado
        FROM usuario usu
        INNER JOIN rol ro ON usu.Rol_Id = ro.Rol_Id
        WHERE (@PorNombre IS NULL OR @PorNombre = '' OR usu.Usu_Correo LIKE '%' + @PorNombre + '%')
            AND usu.Usu_Estado = 1
        ORDER BY usu.Usu_NomApellidos
        OFFSET @offsets ROWS
        FETCH NEXT @RegistroPagina ROWS ONLY;

        -- Asignar valores a los parámetros de salida
        SET @TotalPagina = @TotalPagina;
        SET @TotalRegistro = @TotalRegistro;
        SET @TienePaginaAnterior = @TienePaginaAnterior;
        SET @TienePaginaProximo = @TienePaginaProximo;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Obten_Paginado_v2]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Obten_Paginado_v2]
(
    @Pagina INT,
    @RegistroPag INT,
    @Opcion INT,
    @Valor VARCHAR(50)
)
AS
BEGIN
	DECLARE @limit1 INT = 0;
	DECLARE @limit2 INT = 100;
	
	SET @limit1 = @Pagina;
	SET @limit2 = @RegistroPag;

	IF @Opcion = 0
	BEGIN
		SELECT *
		FROM (
			SELECT usu.Usu_Id,
					 usu.Usu_UserName,
					 usu.Usu_NomApellidos,
					 usu.Usu_Observacion,
					 rol.Rol_Nombre,
					 usu.Usu_FecHoraRegistro,
					 usu.Usu_Estado,
					 ROW_NUMBER() OVER (ORDER BY usu.Usu_UserName) AS RowNumber
			FROM usuario usu
			INNER JOIN rol rol ON usu.Rol_Id = rol.Rol_Id
			WHERE (@Valor IS NULL OR usu.Usu_UserName LIKE '%' + @Valor + '%')
		) AS T
		WHERE RowNumber BETWEEN @limit1 AND @limit2;
	END
	ELSE IF @Opcion = 1
	BEGIN
		SELECT *
		FROM (
			SELECT usu.Usu_Id,
					 usu.Usu_UserName,
					 usu.Usu_NomApellidos,
					 usu.Usu_Observacion,
					 rol.Rol_Nombre,
					 usu.Usu_FecHoraRegistro,
					 usu.Usu_Estado,
					 ROW_NUMBER() OVER (ORDER BY usu.Usu_UserName) AS RowNumber
			FROM usuario usu
			INNER JOIN rol rol ON usu.Rol_Id = rol.Rol_Id
			WHERE (@Valor IS NULL OR usu.Usu_UserName LIKE '%' + @Valor + '%') AND usu.Usu_Estado = 1
		) AS T
		WHERE RowNumber BETWEEN @limit1 AND @limit2;
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Obten_Token_x_Correo]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Obten_Token_x_Correo]
(
    @Usu_Correo varchar(50)
)
AS
BEGIN
    SELECT usu.Usu_Correo,
					 usu.Usu_NomApellidos,
					 ro.Rol_Nombre,
					 usu.Usu_FecHoraRegistro,
					 usu.Usu_Estado,
					 usu.Usu_TokenActualizado,
					 usu.Usu_FecHoraTokenActualizado
					 
	FROM usuario usu INNER JOIN rol ro ON usu.Rol_Id = ro.Rol_Id
	WHERE usu.Usu_Correo = @Usu_Correo AND usu.Usu_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Obten_x_Correo]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Obten_x_Correo]
(
    @Usu_Correo varchar(50)
)
AS
BEGIN
    SELECT usu.Usu_Correo,
					 usu.Usu_NomApellidos,
					 ro.Rol_Nombre,
					 usu.Usu_FecHoraRegistro,
					 usu.Usu_Estado
	FROM usuario usu INNER JOIN rol ro ON usu.Rol_Id = ro.Rol_Id
	WHERE usu.Usu_Correo = @Usu_Correo AND usu.Usu_Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuario_Obten_x_Id]    Script Date: 17/03/2025 07:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Usuario_Obten_x_Id]
(
    @Usu_Id int
)
AS
BEGIN
    SELECT usu.Usu_Id, usu.Usu_Correo, usu.Usu_NomApellidos, ro.Rol_Nombre, usu.Usu_FecHoraRegistro, usu.Usu_Estado
    FROM usuario usu
    INNER JOIN rol ro ON usu.Rol_Id = ro.Rol_Id
    WHERE usu.Usu_Id = @Usu_Id;
END
GO
USE [master]
GO
ALTER DATABASE [dbpresupuestos] SET  READ_WRITE 
GO
