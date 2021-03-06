USE [master]
GO
/****** Object:  Database [FARMACIA]    Script Date: 21/10/2020 15:11:48 ******/
CREATE DATABASE [FARMACIA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FARMACIA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FARMACIA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FARMACIA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FARMACIA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FARMACIA] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FARMACIA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FARMACIA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FARMACIA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FARMACIA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FARMACIA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FARMACIA] SET ARITHABORT OFF 
GO
ALTER DATABASE [FARMACIA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FARMACIA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FARMACIA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FARMACIA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FARMACIA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FARMACIA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FARMACIA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FARMACIA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FARMACIA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FARMACIA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FARMACIA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FARMACIA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FARMACIA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FARMACIA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FARMACIA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FARMACIA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FARMACIA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FARMACIA] SET RECOVERY FULL 
GO
ALTER DATABASE [FARMACIA] SET  MULTI_USER 
GO
ALTER DATABASE [FARMACIA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FARMACIA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FARMACIA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FARMACIA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FARMACIA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FARMACIA', N'ON'
GO
ALTER DATABASE [FARMACIA] SET QUERY_STORE = OFF
GO
USE [FARMACIA]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [FARMACIA]
GO
/****** Object:  User [JOSE]    Script Date: 21/10/2020 15:11:49 ******/
CREATE USER [JOSE] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [HECTOR QUISPE]    Script Date: 21/10/2020 15:11:49 ******/
CREATE USER [HECTOR QUISPE] FOR LOGIN [HECTOR QUISPE] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [BIG MAMA]    Script Date: 21/10/2020 15:11:49 ******/
CREATE USER [BIG MAMA] FOR LOGIN [BIG MAMA] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ADRIAN QUISPE]    Script Date: 21/10/2020 15:11:49 ******/
CREATE USER [ADRIAN QUISPE] FOR LOGIN [ADRIAN QUISPE] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [JOSE]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [JOSE]
GO
ALTER ROLE [db_owner] ADD MEMBER [HECTOR QUISPE]
GO
ALTER ROLE [db_owner] ADD MEMBER [BIG MAMA]
GO
ALTER ROLE [db_owner] ADD MEMBER [ADRIAN QUISPE]
GO
/****** Object:  UserDefinedFunction [dbo].[detecta_admi_o_vende]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[detecta_admi_o_vende](@ci_id varchar(10))
returns varchar(100)
as
begin
	declare @de varchar(100)
	if exists(select CI from ADMINISTRADOR where CI=@ci_id)
		begin
			set @de = (select NOMBRE+' '+APELLIDO from ADMINISTRADOR where CI=@ci_id)
		end
	else
		begin
			if exists (select CI from VENDEDOR where CI=@ci_id)
			begin
				set @de=(select NOMBRE+' '+APELLIDOS from VENDEDOR where CI=@ci_id)
			end
		end
	return @de
end
GO
/****** Object:  UserDefinedFunction [dbo].[detecta_admi_o_vende_ventana]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[detecta_admi_o_vende_ventana](@ci_id varchar(10))
returns int
as
begin
	declare @de int
	if exists(select CI from ADMINISTRADOR where CI=@ci_id)
		begin
			set @de=0
		end
	else
		begin
			if exists (select CI from VENDEDOR where CI=@ci_id)
			begin
				set @de=1
			end
		end
	return @de
end
GO
/****** Object:  Table [dbo].[ADMINISTRADOR]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMINISTRADOR](
	[CI] [varchar](10) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[APELLIDO] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ADMINISTRADOR_1] PRIMARY KEY CLUSTERED 
(
	[CI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FARMACIA_N]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FARMACIA_N](
	[COD_FAR] [int] NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[NIT] [varchar](100) NOT NULL,
	[COD_DUEÑO] [varchar](10) NOT NULL,
	[UBICACION] [varchar](200) NULL,
 CONSTRAINT [PK_FARMACIA_N] PRIMARY KEY CLUSTERED 
(
	[COD_FAR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[visualizar_farmacia]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[visualizar_farmacia]
as
(
	select f.NIT,f.NOMBRE,f.UBICACION,ad.CI+' - '+ad.NOMBRE+' '+ad.APELLIDO as [NOMBRE DEL DUEÑO]  
	from FARMACIA_N f, ADMINISTRADOR ad
	where f.COD_DUEÑO=ad.CI
)
GO
/****** Object:  View [dbo].[combo]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[combo]
as
(
	select CI+' - '+NOMBRE+' '+APELLIDO as nombre
	from ADMINISTRADOR
)
GO
/****** Object:  Table [dbo].[IMAGEN]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMAGEN](
	[COD_IM] [varchar](500) NOT NULL,
	[RUTA] [varchar](500) NULL,
 CONSTRAINT [PK_IMAGEN_1] PRIMARY KEY CLUSTERED 
(
	[COD_IM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[COD] [varchar](100) NOT NULL,
	[DESCRIPCION] [varchar](500) NOT NULL,
	[PRECIO] [money] NOT NULL,
	[PRECIO VENTA] [money] NOT NULL,
	[FECHA DE ELABORACION] [date] NOT NULL,
	[FECHA DE VENCIMIENTO] [date] NOT NULL,
	[IMAGEN] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PRODUCTO_1] PRIMARY KEY CLUSTERED 
(
	[COD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[demostracion]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[demostracion]
as
(
	select v.COD,v.DESCRIPCION,v.PRECIO,v.[PRECIO VENTA],v.[FECHA DE ELABORACION],v.[FECHA DE VENCIMIENTO],i.RUTA
		from PRODUCTO v, IMAGEN i
		where
		v.IMAGEN=i.COD_IM
)
GO
/****** Object:  Table [dbo].[TIENE]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIENE](
	[COD_FAR] [int] NOT NULL,
	[COD_MED] [varchar](100) NOT NULL,
	[CANTIDAD] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[tiene_vista_tabla]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[tiene_vista_tabla]
as
(
	select far.NIT+' - '+far.NOMBRE as FARMACIA,far.UBICACION,pro.COD+' - '+pro.DESCRIPCION as [DESCRIPCION DEL PRODUCTO],t.CANTIDAD,pro.[FECHA DE ELABORACION],pro.[FECHA DE VENCIMIENTO],i.RUTA
	from FARMACIA_N far,PRODUCTO pro,TIENE t,IMAGEN i
	where
	pro.IMAGEN=i.COD_IM and
	t.COD_FAR=far.COD_FAR and
	t.COD_MED=pro.COD
)
GO
/****** Object:  View [dbo].[box_farmacia]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[box_farmacia]
as
(
	select far.NIT+' - '+far.NOMBRE as FARMACIA
	from FARMACIA_N far
)
GO
/****** Object:  View [dbo].[box_medicamento]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[box_medicamento]
as
(
	select pro.COD+' - '+pro.DESCRIPCION as [DESCRIPCION DEL PRODUCTO]
	from PRODUCTO pro
)
GO
/****** Object:  Table [dbo].[VENDEDOR]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENDEDOR](
	[CI] [varchar](10) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[APELLIDOS] [varchar](100) NOT NULL,
	[EDAD] [int] NOT NULL,
	[TIPO] [int] NOT NULL,
	[COD_FAR] [int] NOT NULL,
 CONSTRAINT [PK_VENDEDOR] PRIMARY KEY CLUSTERED 
(
	[CI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[V_TIPO]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[V_TIPO](
	[ID_TIPO] [int] NOT NULL,
	[TIPO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_V_TIPO_1] PRIMARY KEY CLUSTERED 
(
	[ID_TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[todooooo]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[todooooo]
as
(
	select s.NOMBRE+' '+s.APELLIDOS as NOM,s.CI,t.TIPO from VENDEDOR s,V_TIPO t where s.TIPO=t.ID_TIPO
)
GO
/****** Object:  View [dbo].[todo_busqueda_medi]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[todo_busqueda_medi]
as
(
select pro.COD,pro.DESCRIPCION,pro.[FECHA DE VENCIMIENTO],pro.[FECHA DE ELABORACION],ti.CANTIDAD,pro.[PRECIO VENTA],ima.RUTA
from FARMACIA_N far,PRODUCTO pro, TIENE ti,IMAGEN ima,VENDEDOR vende
where
far.COD_FAR=ti.COD_FAR and
vende.COD_FAR=far.COD_FAR and
pro.COD=ti.COD_MED and
pro.IMAGEN=ima.COD_IM and
vende.CI='123456'
)
GO
/****** Object:  Table [dbo].[FACTURA_GENERADA]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURA_GENERADA](
	[NUME] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FACTURA_GEN]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[FACTURA_GEN]
as
(
	select MAX(NUME) as MAXIMO
	FROM FACTURA_GENERADA
)
GO
/****** Object:  View [dbo].[mostrar_empleado]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[mostrar_empleado]
as
(
	select v.CI,v.NOMBRE,v.APELLIDOS,v.EDAD,t.TIPO,f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA]
	from VENDEDOR v, FARMACIA_N f, V_TIPO t
	where v.COD_FAR=f.COD_FAR and v.TIPO=t.ID_TIPO
)
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[CI] [varchar](15) NOT NULL,
	[NOMBRE] [varchar](150) NOT NULL,
	[APELLIDOS] [varchar](150) NOT NULL,
 CONSTRAINT [PK_CLIENTE_1] PRIMARY KEY CLUSTERED 
(
	[CI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPRA]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPRA](
	[COD_COMPRA] [int] NOT NULL,
	[F_COMPRA] [date] NOT NULL,
	[CANTIDAD] [int] NOT NULL,
	[CI_CLIENTE] [varchar](15) NOT NULL,
	[COD_PROD] [varchar](100) NOT NULL,
 CONSTRAINT [PK_COMPRA] PRIMARY KEY CLUSTERED 
(
	[COD_COMPRA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA](
	[COD_VEN] [int] NOT NULL,
	[COD_PRO] [varchar](100) NOT NULL,
	[COD_VENDEDOR] [varchar](10) NOT NULL,
	[FECHA VENTA] [date] NOT NULL,
	[CANTIDAD] [int] NULL,
 CONSTRAINT [PK_VENTA] PRIMARY KEY CLUSTERED 
(
	[COD_VEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA BORRADA]    Script Date: 21/10/2020 15:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA BORRADA](
	[COD_VE] [int] NOT NULL,
	[COD_PRO] [varchar](100) NOT NULL,
	[COD_VEN] [varchar](10) NOT NULL,
	[FECHA VENTA] [date] NOT NULL,
	[CANTIDAD] [int] NOT NULL,
	[FECHA DE BORRADO] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PRODUCTO_1]    Script Date: 21/10/2020 15:11:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PRODUCTO_1] ON [dbo].[PRODUCTO]
(
	[IMAGEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_COMPRA_CLIENTE1] FOREIGN KEY([CI_CLIENTE])
REFERENCES [dbo].[CLIENTE] ([CI])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[COMPRA] CHECK CONSTRAINT [FK_COMPRA_CLIENTE1]
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_COMPRA_PRODUCTO1] FOREIGN KEY([COD_PROD])
REFERENCES [dbo].[PRODUCTO] ([COD])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[COMPRA] CHECK CONSTRAINT [FK_COMPRA_PRODUCTO1]
GO
ALTER TABLE [dbo].[FARMACIA_N]  WITH CHECK ADD  CONSTRAINT [FK_FARMACIA_N_ADMINISTRADOR1] FOREIGN KEY([COD_DUEÑO])
REFERENCES [dbo].[ADMINISTRADOR] ([CI])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FARMACIA_N] CHECK CONSTRAINT [FK_FARMACIA_N_ADMINISTRADOR1]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_IMAGEN1] FOREIGN KEY([IMAGEN])
REFERENCES [dbo].[IMAGEN] ([COD_IM])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_IMAGEN1]
GO
ALTER TABLE [dbo].[TIENE]  WITH CHECK ADD  CONSTRAINT [FK_TIENE_FARMACIA_N] FOREIGN KEY([COD_FAR])
REFERENCES [dbo].[FARMACIA_N] ([COD_FAR])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TIENE] CHECK CONSTRAINT [FK_TIENE_FARMACIA_N]
GO
ALTER TABLE [dbo].[TIENE]  WITH CHECK ADD  CONSTRAINT [FK_TIENE_PRODUCTO1] FOREIGN KEY([COD_MED])
REFERENCES [dbo].[PRODUCTO] ([COD])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TIENE] CHECK CONSTRAINT [FK_TIENE_PRODUCTO1]
GO
ALTER TABLE [dbo].[VENDEDOR]  WITH CHECK ADD  CONSTRAINT [FK_VENDEDOR_FARMACIA_N] FOREIGN KEY([COD_FAR])
REFERENCES [dbo].[FARMACIA_N] ([COD_FAR])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VENDEDOR] CHECK CONSTRAINT [FK_VENDEDOR_FARMACIA_N]
GO
ALTER TABLE [dbo].[VENDEDOR]  WITH CHECK ADD  CONSTRAINT [FK_VENDEDOR_V_TIPO1] FOREIGN KEY([TIPO])
REFERENCES [dbo].[V_TIPO] ([ID_TIPO])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VENDEDOR] CHECK CONSTRAINT [FK_VENDEDOR_V_TIPO1]
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_PRODUCTO1] FOREIGN KEY([COD_PRO])
REFERENCES [dbo].[PRODUCTO] ([COD])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [FK_VENTA_PRODUCTO1]
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_VENDEDOR] FOREIGN KEY([COD_VENDEDOR])
REFERENCES [dbo].[VENDEDOR] ([CI])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [FK_VENTA_VENDEDOR]
GO
/****** Object:  StoredProcedure [dbo].[actualizar_cliente]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[actualizar_cliente]
(
	@ci varchar(15),
	@nombre varchar(150),
	@apellido varchar(150)
)
as
begin
	if exists(select CI from CLIENTE where CI=@ci)
	begin
		update CLIENTE
		set
			NOMBRE=@nombre,
			APELLIDOS=@apellido
		where
			CI=@ci
	end
	else
	begin
		declare @msm varchar(200)
		set @msm = 'EL CLIENTE QUE USTED DESEA ACTUALIZAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[actualizar_tiene]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[actualizar_tiene]
(
	@nit varchar(100),
	@cod_pro varchar(100),
	@canti int
)
as
begin
	declare @cod_far int
	set @cod_far=(select COD_FAR from FARMACIA_N where NIT=@nit)
	update TIENE
	set
		COD_FAR = @cod_far,
		COD_MED = @cod_pro,
		CANTIDAD = @canti
	where
		COD_FAR = @cod_far and
		COD_MED = @cod_pro
end
GO
/****** Object:  StoredProcedure [dbo].[arqueo]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[arqueo]
(
	@da date
)
as
begin
	select far.NIT,far.NOMBRE,far.UBICACION,pro.COD,pro.DESCRIPCION,pro.[PRECIO VENTA],SUM(venta.CANTIDAD) as CANTIDAD, SUM(venta.CANTIDAD*pro.[PRECIO VENTA]) as TOTAL
	from FARMACIA_N far,VENDEDOR ve, VENTA venta,PRODUCTO pro
	where
		far.COD_FAR=ve.COD_FAR and
		ve.CI=venta.COD_VENDEDOR and
		venta.COD_PRO=pro.COD and
		venta.[FECHA VENTA]=@da
	group by far.NIT,far.NOMBRE,far.UBICACION,pro.COD,pro.DESCRIPCION,pro.[PRECIO VENTA]
end
GO
/****** Object:  StoredProcedure [dbo].[arqueo_solo]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[arqueo_solo]
(
	@da date
)
as
begin
	select SUM(venta.CANTIDAD*pro.[PRECIO VENTA]) as TOTAL
	from FARMACIA_N far,VENDEDOR ve, VENTA venta,PRODUCTO pro
	where
		far.COD_FAR=ve.COD_FAR and
		ve.CI=venta.COD_VENDEDOR and
		venta.COD_PRO=pro.COD and
		venta.[FECHA VENTA]=@da
end
GO
/****** Object:  StoredProcedure [dbo].[buca]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buca](@nit varchar(20))
as
begin
	select * from visualizar_farmacia where NIT like ('%'+@nit+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[bus_por_des]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bus_por_des]
(
	@ci varchar(10),
	@to varchar(500)
)
as
begin
	select pro.COD,pro.DESCRIPCION,pro.[FECHA DE VENCIMIENTO],pro.[FECHA DE ELABORACION],ti.CANTIDAD,pro.[PRECIO VENTA],ima.RUTA
from FARMACIA_N far,PRODUCTO pro, TIENE ti,IMAGEN ima,VENDEDOR vende
where
far.COD_FAR=ti.COD_FAR and
vende.COD_FAR=far.COD_FAR and
pro.COD=ti.COD_MED and
pro.IMAGEN=ima.COD_IM and
vende.CI = @ci and
pro.DESCRIPCION like('%'+@to+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[bus_por_far]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bus_por_far]
(
	@ci varchar(15),
	@descrip varchar(500)
)
as
begin
	select far.NOMBRE,far.UBICACION,pro.DESCRIPCION,tie.CANTIDAD,imagen.RUTA
	from FARMACIA_N far, TIENE tie, PRODUCTO pro,IMAGEN imagen,VENDEDOR ven
	where
		far.COD_FAR=tie.COD_FAR and
		pro.COD=tie.COD_MED and
		pro.IMAGEN=imagen.COD_IM and
		ven.COD_FAR=far.COD_FAR and
		tie.CANTIDAD!=0 and
		ven.CI!=@ci and
		DESCRIPCION like('%'+@descrip+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[bus_por_far_ven]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bus_por_far_ven]
(
	@ci varchar(15),
	@descrip varchar(500)
)
as
begin
	select pro.COD, pro.DESCRIPCION,tie.CANTIDAD,pro.[PRECIO VENTA],imagen.RUTA
	from FARMACIA_N far, TIENE tie, PRODUCTO pro,IMAGEN imagen,VENDEDOR ven
	where
		far.COD_FAR=tie.COD_FAR and
		pro.COD=tie.COD_MED and
		pro.IMAGEN=imagen.COD_IM and
		ven.COD_FAR=far.COD_FAR and
		tie.CANTIDAD!=0 and
		ven.CI=@ci and
		DESCRIPCION like('%'+@descrip+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_cliente]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buscar_cliente]
(
	@ci varchar(15)
)
as
begin
	select CI,NOMBRE,APELLIDOS
	from CLIENTE
	where
	CI like('%'+@ci+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_cliente_ven]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buscar_cliente_ven]
(
	@ci varchar(15)
)
as
begin
	select CI,NOMBRE,APELLIDOS
	from CLIENTE
	where
	CI like('%'+@ci+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_empleado]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[buscar_empleado]
(
	@ci varchar(10)
)
as
begin
	select v.CI,v.NOMBRE,v.APELLIDOS,v.EDAD,t.TIPO,f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA]
	from VENDEDOR v, FARMACIA_N f, V_TIPO t
	where v.COD_FAR=f.COD_FAR and v.TIPO=t.ID_TIPO and v.CI like('%'+@ci+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_produc]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[buscar_produc](@cod_pro varchar(500))
as
begin
		select v.COD,v.DESCRIPCION,v.PRECIO,v.[PRECIO VENTA],v.[FECHA DE ELABORACION],v.[FECHA DE VENCIMIENTO],i.RUTA
		from PRODUCTO v, IMAGEN i
		where
		v.IMAGEN=i.COD_IM and
		v.DESCRIPCION like('%'+@cod_pro+'%');
end
GO
/****** Object:  StoredProcedure [dbo].[buscar_tiene]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[buscar_tiene]
(
	@descripcion varchar(500)
)
as
begin
	select * from tiene_vista_tabla
	where [DESCRIPCION DEL PRODUCTO] like('%'+@descripcion+'%')
end
GO
/****** Object:  StoredProcedure [dbo].[editar_farmacia]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editar_farmacia]
(
	@cod_far int,
	@nombre varchar(100),
	@NIT varchar(100),
	@COD_DUE VARCHAR(10),
	@UBICACION varchar(200)
)
as
begin
	declare @cod_farma int
	if exists(select NIT from FARMACIA_N where @cod_far=COD_FAR)
		begin
			update FARMACIA_N
			set
				NOMBRE=@nombre,
				NIT=@NIT,
				COD_DUEÑO=@COD_DUE,
				UBICACION=@UBICACION
			where
				COD_FAR=@cod_far
		end
	else
		begin
			declare @msm varchar(300)
			set @msm='NO EXISTE LA FARMACIA QUE USTED DESEA ACTUALIZAR'
			RAISERROR(@msm,11,1)
		end
end
GO
/****** Object:  StoredProcedure [dbo].[editar_medicamento]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[editar_medicamento]
(
	@cod_pro varchar(100),
	@descrip varchar(500),
	@precio money,
	@precio_venta money,
	@fecha_elab date,
	@fecha_ven date,
	@ruta varchar(500)
)
as
begin
	if exists(select COD from PRODUCTO where COD=@cod_pro)
	begin
	    update IMAGEN
		set
			RUTA=@ruta
		where
			COD_IM=@cod_pro

		update PRODUCTO
		set
			DESCRIPCION=@descrip,
			PRECIO=@precio,
			[PRECIO VENTA]=@precio_venta,
			[FECHA DE ELABORACION]=@fecha_elab,
			[FECHA DE VENCIMIENTO]=@fecha_ven
		where
			COD=@cod_pro
	end
	else
	begin
		declare @msm varchar(300)
		set @msm='EL MEDICAMENTO QUE USTED QUIERE EDITAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[Editar_Usuario]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Editar_Usuario]
(
	@ci varchar(10),
	@nombres varchar(100),
	@apellidos varchar(100),
	@Edad int,
	@tipo int,
	@Cod_far varchar(15)	
)
as
begin
declare @err varchar(500)
	if not exists(select CI from VENDEDOR where CI=@ci)
		begin
			set @err='EL USUARIO CON CI: '+@ci+' NO EXISTE'
			RAISERROR(@err,11,1)
		end
	else
		begin
			declare @codigo int
			set @codigo=(select COD_FAR from FARMACIA_N where @Cod_far=NIT)
			update VENDEDOR
			set
			NOMBRE=@nombres,
			APELLIDOS=@apellidos,
			EDAD=@Edad,
			TIPO=@tipo,
			COD_FAR=@codigo
			where
			CI=@ci
		end
end
GO
/****** Object:  StoredProcedure [dbo].[eliminar]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[eliminar](@cod_pro varchar(100))
as
begin
	if exists(select COD from PRODUCTO where COD=@cod_pro)
	begin
		delete PRODUCTO
		where 
		COD=@cod_pro
		delete IMAGEN
		where
		COD_IM=@cod_pro
	end
	else
	begin
		declare @msm varchar(300)
		set @msm='EL MEDICAMENTO QUE USTED QUIERE ELIMINAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[eliminar_cliente]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[eliminar_cliente]
(
	@ci varchar(15)
)
as 
begin
	if exists(select CI from CLIENTE where CI=@ci)
	begin
		delete CLIENTE
		where
			CI=@ci
	end
	else
	begin
		declare @msm varchar(200)
		set @msm = 'EL CLIENTE QUE USTED DESEA ELIMINAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[eliminar_farmacia]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[eliminar_farmacia]
(
	@cod_far int
)
as
begin
	if exists(select COD_FAR from FARMACIA_N where COD_FAR=@cod_far)
	begin
		delete FARMACIA_N
		where
		COD_FAR=@cod_far
	end
	else
	begin
		declare @fr varchar(300)
		set @fr='EL USUARIO QUE USTED DESEA ELIMINAR NO EXISTE'
		RAISERROR(@fr,11,1);
	end
end
GO
/****** Object:  StoredProcedure [dbo].[eliminar_tiene]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[eliminar_tiene]
(
	@nit varchar(100),
	@cod_pro varchar(100)
)
as
begin
	declare @cod_far int
	set @cod_far=(select COD_FAR from FARMACIA_N where NIT=@nit)
	delete TIENE
	where COD_FAR=@cod_far and COD_MED=@cod_pro
end
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_Usuario]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eliminar_Usuario]
(@ci varchar(10))
as
begin
	declare @mm varchar(500)
	if exists(select CI from VENDEDOR where CI=@ci)
	begin
		delete VENDEDOR where CI=@ci
	end
	else
	begin
		set @mm='EL USUARIO QUE DESEA ELIMINAR NO EXISTE'
		RAISERROR(@mm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[FACTURA]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[FACTURA]
(
	@ci_cli varchar(15),
	@ci_vende varchar(15)
)
as
begin
	declare @fe_ac date
	set @fe_ac = GETDATE();
	select far.NOMBRE,far.UBICACION,far.NIT,pro.DESCRIPCION,pro.[PRECIO VENTA],cli.CI,
		   cli.NOMBRE+' '+cli.APELLIDOS as [NOMBRE CLIENTE],comp.CANTIDAD,pro.[PRECIO VENTA],
		   comp.CANTIDAD*pro.[PRECIO VENTA] as [PRE TOTAL]
	from FARMACIA_N far,TIENE tiene, COMPRA comp, PRODUCTO pro,CLIENTE cli,VENDEDOR vende
	where
	comp.CI_CLIENTE=cli.CI and
	comp.COD_PROD=pro.COD and
	far.COD_FAR=tiene.COD_FAR and
	pro.COD=tiene.COD_MED and
	vende.COD_FAR=far.COD_FAR and
	vende.CI=@ci_vende and
	comp.CI_CLIENTE=@ci_cli and
	comp.F_COMPRA=@fe_ac
end
GO
/****** Object:  StoredProcedure [dbo].[FACTURA_total]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[FACTURA_total]
(
	@ci_cli varchar(15),
	@ci_vende varchar(15)
)
as
begin
	declare @fe_ac date
	set @fe_ac = GETDATE();
	select SUM(comp.CANTIDAD*pro.[PRECIO VENTA]) as [TOTAL]
	from FARMACIA_N far,TIENE tiene, COMPRA comp, PRODUCTO pro,CLIENTE cli,VENDEDOR vende
	where
	comp.CI_CLIENTE=cli.CI and
	comp.COD_PROD=pro.COD and
	far.COD_FAR=tiene.COD_FAR and
	pro.COD=tiene.COD_MED and
	vende.COD_FAR=far.COD_FAR and
	vende.CI=@ci_vende and
	comp.CI_CLIENTE=@ci_cli and
	comp.F_COMPRA=@fe_ac
end

GO
/****** Object:  StoredProcedure [dbo].[fecha_borrado]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[fecha_borrado]
(
	@da date
)
as
begin
	select vendedor.CI,vendedor.NOMBRE,vendedor.APELLIDOS,pro.COD,pro.DESCRIPCION,pro.[PRECIO VENTA],ven.CANTIDAD,(pro.[PRECIO VENTA]*ven.CANTIDAD)as SUB_TOTAL,ven.[FECHA VENTA],ven.[FECHA DE BORRADO]
	from [VENTA BORRADA] ven,VENDEDOR vendedor,PRODUCTO pro
	where
		ven.COD_PRO=pro.COD and
		ven.COD_VEN=vendedor.CI and
		ven.[FECHA VENTA]=@da
end
GO
/****** Object:  StoredProcedure [dbo].[insertar_cliente]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertar_cliente]
(
	@ci varchar(15),
	@nombre varchar(150),
	@apellido varchar(150)
)
as
begin
	if not exists(select CI from CLIENTE where CI=@ci)
	begin
		insert into CLIENTE
		(
			CI,
			NOMBRE,
			APELLIDOS
		)
		values
		(
			@ci,
			@nombre,
			@apellido
		)
	end
	else
	begin
		declare @msm varchar(200)
		set @msm = 'EL CLIENTE QUE USTED DESEA INSERTAR YA FUE INSTERTADO'
		RAISERROR(@msm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[insertar_farmacia]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertar_farmacia]
(
	@cod_far int,
	@nombre varchar(100),
	@NIT varchar(100),
	@COD_DUE VARCHAR(10),
	@UBICACION varchar(200)
)
as
begin
	if not exists(select NIT from FARMACIA_N where NIT=@NIT)
	begin
		insert into FARMACIA_N
		(
			COD_FAR,
			NOMBRE,
			NIT,
			COD_DUEÑO,
			UBICACION
		)
		values
		(
			@cod_far,
			@nombre,
			@NIT,
			@COD_DUE,
			@UBICACION
		)
	end
	else
	begin
		declare @mes varchar(100)
		set @mes='LA FARMACIA CON EL NIT: '+@NIT+' YA ESTA CREADA' 
		RAISERROR(@mes,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[insertar_medicamento]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertar_medicamento]
(
	@cod_pro varchar(100),
	@descrip varchar(500),
	@precio money,
	@precio_venta money,
	@fecha_elab date,
	@fecha_ven date,
	@ruta varchar(500)
)
as
begin
	if not exists(select COD from PRODUCTO where COD=@cod_pro)
	begin
	    insert into IMAGEN
		(
			COD_IM,
			RUTA
		)
		values
		(
			@cod_pro,
			@ruta
		)
		insert into PRODUCTO
		(
			COD,
			DESCRIPCION,
			PRECIO,
			[PRECIO VENTA],
			[FECHA DE ELABORACION],
			[FECHA DE VENCIMIENTO],
			IMAGEN
		)
		values
		(
			@cod_pro,
			@descrip,
			@precio,
			@precio_venta,
			@fecha_elab,
			@fecha_ven,
			@cod_pro
		)
	end
	else
	begin
		declare @msm varchar(300)
		set @msm='EL MEDICAMENTO QUE USTED QUIERE INSERTAR YA EXISTE'
		RAISERROR(@msm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[insertar_tiene]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertar_tiene]
(
	@nit varchar(100),
	@cod_pro varchar(100),
	@canti int
)
as
begin
	declare @cod_far int
	set @cod_far=(select COD_FAR from FARMACIA_N where NIT=@nit)
	if not exists(select COD_FAR,COD_MED from TIENE where COD_FAR=@cod_far and COD_MED=@cod_pro)
	begin
		insert into TIENE
		(
			COD_FAR,
			COD_MED,
			CANTIDAD
		)
		values
		(
			@cod_far,
			@cod_pro,
			@canti
		)
	end
	else
	begin
		declare @msm varchar(100)
		set @msm='EL VALOR QUE DESEA INSRTAR YA EXISTE'
		RAISERROR(@msm,11,1)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[insertar_vendedor]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertar_vendedor]
(
	@ci varchar(10),
	@nombres varchar(100),
	@apellidos varchar(100),
	@Edad int,
	@tipo int,
	@Cod_far varchar(15)
)
as
begin
	declare @mio varchar(500)
	if exists(select CI from VENDEDOR where CI=@ci)
		begin
		set @mio='EL EMPLEADO CON CI: '+@ci+' YA ESTA INSERTADO'
			RAISERROR(@mio,11,1)		
		end
	else
		begin
		     declare @codigo int
			 set @codigo=(select COD_FAR from FARMACIA_N where @Cod_far=NIT)
			 insert into VENDEDOR
			 (
				CI,
				NOMBRE,
				APELLIDOS,
				EDAD,
				TIPO,
				COD_FAR
			 )
			 values
			 (
				@ci,
				@nombres,
				@apellidos,
				@Edad,
				@tipo,
				@codigo
			 )
		end
end
GO
/****** Object:  StoredProcedure [dbo].[insertar_venta_compra]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertar_venta_compra]
(
	@ci_cli varchar(15),
	@cod_ven varchar(10),
	@cod_pro varchar(100),
	@canti int
)
as
begin
	declare @valor int
	set @valor=(select MAX(c.COD_VEN) from VENTA c)
	set @valor=@valor+1
	declare @fecha date
	set @fecha=GETDATE()
	insert into VENTA
	(
		COD_VEN,
		COD_PRO,
		COD_VENDEDOR,
		[FECHA VENTA],
		CANTIDAD
	)
	values
	(
		@valor,
		@cod_pro,
		@cod_ven,
		@fecha,
		@canti
	)

	---------------------


	set @valor=(select count(c.COD_COMPRA) from COMPRA c)
	set @valor=@valor+1
	insert into COMPRA
	(
		COD_COMPRA,
		F_COMPRA,
		CANTIDAD,
		CI_CLIENTE,
		COD_PROD
	)
	values
	(
		@valor,
		@fecha,
		@canti,
		@ci_cli,
		@cod_pro
	) 
end
GO
/****** Object:  StoredProcedure [dbo].[todo_busqueda_medi_pro]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[todo_busqueda_medi_pro]
(
	@ci varchar(10)
)
as
begin
select pro.COD,pro.DESCRIPCION,pro.[FECHA DE VENCIMIENTO],pro.[FECHA DE ELABORACION],ti.CANTIDAD,pro.[PRECIO VENTA],ima.RUTA
from FARMACIA_N far,PRODUCTO pro, TIENE ti,IMAGEN ima,VENDEDOR vende
where
far.COD_FAR=ti.COD_FAR and
vende.COD_FAR=far.COD_FAR and
pro.COD=ti.COD_MED and
pro.IMAGEN=ima.COD_IM and
vende.CI=@ci
end
GO
/****** Object:  StoredProcedure [dbo].[toma]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[toma]
as
begin
	declare @num int
	set @num=(select COUNT(NUME) from FACTURA_GENERADA f)
	set @num=@num+1
	insert into FACTURA_GENERADA
	(
		NUME
	)
	values
	(
		@num
	)
end
GO
/****** Object:  StoredProcedure [dbo].[ve_vis]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ve_vis]
(
	@co int
)
as
begin
	delete VENTA
	where
		COD_VEN=@co
end
GO
/****** Object:  StoredProcedure [dbo].[vista_tuyo]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[vista_tuyo]
(
	@ci_ve varchar(10)
)
as
begin
	declare @date date
	set @date=GETDATE()
	select venta.COD_VEN,prod.COD as [COD PRODUCTO],prod.DESCRIPCION,venta.CANTIDAD,prod.[PRECIO VENTA],venta.[FECHA VENTA]
	from VENTA venta,PRODUCTO prod, VENDEDOR vendedor
	where
		vendedor.CI=venta.COD_VENDEDOR and
		venta.COD_PRO=prod.COD and
		venta.COD_VENDEDOR=@ci_ve and
		venta.[FECHA VENTA]=@date
end
GO
/****** Object:  StoredProcedure [dbo].[vista_tuyo_suma]    Script Date: 21/10/2020 15:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[vista_tuyo_suma]
(
	@ci_ve varchar(10)
)
as
begin
	declare @date date
	set @date=GETDATE()
	select SUM(venta.CANTIDAD*prod.[PRECIO VENTA])
	from VENTA venta,PRODUCTO prod, VENDEDOR vendedor
	where
		vendedor.CI=venta.COD_VENDEDOR and
		venta.COD_PRO=prod.COD and
		vendedor.CI=@ci_ve and
		venta.[FECHA VENTA]=@date
end
GO
USE [master]
GO
ALTER DATABASE [FARMACIA] SET  READ_WRITE 
GO
