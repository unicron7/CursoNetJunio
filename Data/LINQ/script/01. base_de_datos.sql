/****** Object:  Database [CursosVirtuales] ******/
CREATE DATABASE [CursosVirtuales]

ALTER DATABASE [CursosVirtuales] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CursosVirtuales].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CursosVirtuales] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CursosVirtuales] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CursosVirtuales] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CursosVirtuales] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CursosVirtuales] SET ARITHABORT OFF 
GO
ALTER DATABASE [CursosVirtuales] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CursosVirtuales] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CursosVirtuales] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CursosVirtuales] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CursosVirtuales] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CursosVirtuales] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CursosVirtuales] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CursosVirtuales] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CursosVirtuales] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CursosVirtuales] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CursosVirtuales] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CursosVirtuales] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CursosVirtuales] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CursosVirtuales] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CursosVirtuales] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CursosVirtuales] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CursosVirtuales] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CursosVirtuales] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CursosVirtuales] SET  MULTI_USER 
GO
ALTER DATABASE [CursosVirtuales] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CursosVirtuales] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CursosVirtuales] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CursosVirtuales] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CursosVirtuales] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CursosVirtuales] SET QUERY_STORE = OFF
GO
USE [CursosVirtuales]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CursosVirtuales]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/10/2020 15:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Continentes]    Script Date: 6/10/2020 15:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continentes](
	[ContinenteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Continentes] PRIMARY KEY CLUSTERED 
(
	[ContinenteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoPersona]    Script Date: 6/10/2020 15:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoPersona](
	[Curso_CursoId] [int] NOT NULL,
	[Persona_PersonaId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CursoPersona] PRIMARY KEY CLUSTERED 
(
	[Curso_CursoId] ASC,
	[Persona_PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 6/10/2020 15:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Idioma] [nvarchar](max) NULL,
	[Precio] [float] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Cursos] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 6/10/2020 15:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[PaisId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Capital] [nvarchar](max) NULL,
	[Poblacion] [int] NOT NULL,
	[Establecido] [int] NOT NULL,
	[ContinenteId] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Paises] PRIMARY KEY CLUSTERED 
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 6/10/2020 15:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[Genero] [nvarchar](max) NULL,
	[CorreoElectronico] [nvarchar](max) NULL,
	[Identificador] [nvarchar](max) NULL,
	[TipoPersona] [nvarchar](25) NULL,
	[PaisId] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Personas] PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Curso_CursoId]    Script Date: 6/10/2020 15:06:14 ******/
CREATE NONCLUSTERED INDEX [IX_Curso_CursoId] ON [dbo].[CursoPersona]
(
	[Curso_CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Persona_PersonaId]    Script Date: 6/10/2020 15:06:14 ******/
CREATE NONCLUSTERED INDEX [IX_Persona_PersonaId] ON [dbo].[CursoPersona]
(
	[Persona_PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContinenteId]    Script Date: 6/10/2020 15:06:14 ******/
CREATE NONCLUSTERED INDEX [IX_ContinenteId] ON [dbo].[Paises]
(
	[ContinenteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaisId]    Script Date: 6/10/2020 15:06:14 ******/
CREATE NONCLUSTERED INDEX [IX_PaisId] ON [dbo].[Personas]
(
	[PaisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CursoPersona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CursoPersona_dbo.Cursos_Curso_CursoId] FOREIGN KEY([Curso_CursoId])
REFERENCES [dbo].[Cursos] ([CursoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursoPersona] CHECK CONSTRAINT [FK_dbo.CursoPersona_dbo.Cursos_Curso_CursoId]
GO
ALTER TABLE [dbo].[CursoPersona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CursoPersona_dbo.Personas_Persona_PersonaId] FOREIGN KEY([Persona_PersonaId])
REFERENCES [dbo].[Personas] ([PersonaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursoPersona] CHECK CONSTRAINT [FK_dbo.CursoPersona_dbo.Personas_Persona_PersonaId]
GO
ALTER TABLE [dbo].[Paises]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Paises_dbo.Continentes_ContinenteId] FOREIGN KEY([ContinenteId])
REFERENCES [dbo].[Continentes] ([ContinenteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Paises] CHECK CONSTRAINT [FK_dbo.Paises_dbo.Continentes_ContinenteId]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Personas_dbo.Paises_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Paises] ([PaisId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_dbo.Personas_dbo.Paises_PaisId]
GO
USE [master]
GO
ALTER DATABASE [CursosVirtuales] SET  READ_WRITE 
GO
