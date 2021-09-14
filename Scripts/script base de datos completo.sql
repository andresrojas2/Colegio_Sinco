create database Colegio
GO
USE [Colegio]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 13/09/2021 22:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [bigint] NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Edad] [int] NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [bigint] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 13/09/2021 22:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatriculaMateria]    Script Date: 13/09/2021 22:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatriculaMateria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MateriaId] [int] NULL,
	[AlumnoId] [int] NULL,
	[Periodo] [int] NULL,
	[Nota] [float] NULL,
 CONSTRAINT [PK_MatriculaMateria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 13/09/2021 22:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [bigint] NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Edad] [int] NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [bigint] NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfesorAsignatura]    Script Date: 13/09/2021 22:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesorAsignatura](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MateriaId] [int] NULL,
	[ProfesorId] [int] NULL,
 CONSTRAINT [PK_ProfesorAsignatura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 
GO
INSERT [dbo].[Alumno] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (3, 11855195, N'Diego', N'Gutierrez', 29, N'av 87-4', 1234567)
GO
INSERT [dbo].[Alumno] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (4, 15155874, N'Laura', N'Ordoñez', 27, N'calle nore #71-4', 8574592)
GO
INSERT [dbo].[Alumno] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (5, 51515665, N'Pedro', N'Antoni', 44, N'cra 521 avenida 3', 1515151)
GO
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 
GO
INSERT [dbo].[Materia] ([Id], [Codigo], [Nombre]) VALUES (1, 1, N'Ciencias')
GO
INSERT [dbo].[Materia] ([Id], [Codigo], [Nombre]) VALUES (2, 2, N'Matemáticas')
GO
INSERT [dbo].[Materia] ([Id], [Codigo], [Nombre]) VALUES (3, 3, N'Música')
GO
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[MatriculaMateria] ON 
GO
INSERT [dbo].[MatriculaMateria] ([Id], [MateriaId], [AlumnoId], [Periodo], [Nota]) VALUES (1, 1, NULL, 1, 5)
GO
INSERT [dbo].[MatriculaMateria] ([Id], [MateriaId], [AlumnoId], [Periodo], [Nota]) VALUES (11, 3, 4, 2020, 3.1)
GO
INSERT [dbo].[MatriculaMateria] ([Id], [MateriaId], [AlumnoId], [Periodo], [Nota]) VALUES (13, 2, 3, 2021, 3)
GO
INSERT [dbo].[MatriculaMateria] ([Id], [MateriaId], [AlumnoId], [Periodo], [Nota]) VALUES (14, 3, 3, 2021, 2.9)
GO
INSERT [dbo].[MatriculaMateria] ([Id], [MateriaId], [AlumnoId], [Periodo], [Nota]) VALUES (15, 2, 3, 2020, 1)
GO
INSERT [dbo].[MatriculaMateria] ([Id], [MateriaId], [AlumnoId], [Periodo], [Nota]) VALUES (18, 1, 5, 2021, 5)
GO
INSERT [dbo].[MatriculaMateria] ([Id], [MateriaId], [AlumnoId], [Periodo], [Nota]) VALUES (19, 1, 3, 2019, 4)
GO
SET IDENTITY_INSERT [dbo].[MatriculaMateria] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesor] ON 
GO
INSERT [dbo].[Profesor] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (2, 15564811, N'Wilson', N'Rubio', 38, N'av 52 # 39', 4211475)
GO
INSERT [dbo].[Profesor] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (10, 1578111, N'John', N'Hoyos', 35, N'cra', 1515111)
GO
SET IDENTITY_INSERT [dbo].[Profesor] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfesorAsignatura] ON 
GO
INSERT [dbo].[ProfesorAsignatura] ([Id], [MateriaId], [ProfesorId]) VALUES (9, 3, 2)
GO
INSERT [dbo].[ProfesorAsignatura] ([Id], [MateriaId], [ProfesorId]) VALUES (10, 1, 10)
GO
INSERT [dbo].[ProfesorAsignatura] ([Id], [MateriaId], [ProfesorId]) VALUES (14, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[ProfesorAsignatura] OFF
GO
ALTER TABLE [dbo].[MatriculaMateria]  WITH CHECK ADD  CONSTRAINT [FK_MatriculaMateria_Alumno] FOREIGN KEY([AlumnoId])
REFERENCES [dbo].[Alumno] ([Id])
GO
ALTER TABLE [dbo].[MatriculaMateria] CHECK CONSTRAINT [FK_MatriculaMateria_Alumno]
GO
ALTER TABLE [dbo].[MatriculaMateria]  WITH CHECK ADD  CONSTRAINT [FK_MatriculaMateria_Materia] FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materia] ([Id])
GO
ALTER TABLE [dbo].[MatriculaMateria] CHECK CONSTRAINT [FK_MatriculaMateria_Materia]
GO
ALTER TABLE [dbo].[ProfesorAsignatura]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorAsignatura_Materia] FOREIGN KEY([MateriaId])
REFERENCES [dbo].[Materia] ([Id])
GO
ALTER TABLE [dbo].[ProfesorAsignatura] CHECK CONSTRAINT [FK_ProfesorAsignatura_Materia]
GO
ALTER TABLE [dbo].[ProfesorAsignatura]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorAsignatura_Profesor] FOREIGN KEY([ProfesorId])
REFERENCES [dbo].[Profesor] ([Id])
GO
ALTER TABLE [dbo].[ProfesorAsignatura] CHECK CONSTRAINT [FK_ProfesorAsignatura_Profesor]
GO
/****** Object:  StoredProcedure [dbo].[spComprasUsuario]    Script Date: 13/09/2021 22:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*-----------------------------------------------------------------------------------------------------------------------------------------
* Procedimiento			: spComprasUsuario
* Descripción			: Consulta compras usuario
*---------------------------------------------------------------------------------------------------------------------------------------*/
CREATE procedure [dbo].[spComprasUsuario]
@xml_usuarios XML,
@xml_compras XML,
@xml_itemsIva XML
as
set nocount on
set lock_timeout 3000


declare @nId int

declare @tUsuarios table
(
	Id int,
	Nombre varchar(50)
)
declare @tCompras table
(
	Usuario int,
	Producto int,
	Valor float
)

declare @tIva table
(
	IdProducto int,
	Porcentaje decimal(10,2)
)


exec sp_xml_preparedocument @nId output, @xml_usuarios

	insert into @tUsuarios (Id,Nombre)
	select	usu.Id,
			usu.Nombre
	from openxml(@nId, 'Data/Usuario', 2)
		with(Id int,
			Nombre varchar(50)) usu

exec sp_xml_preparedocument @nId output, @xml_compras
	
	insert into @tCompras (Usuario,Producto,Valor)
	select x.Usuario,
			x.Producto,
			x.Valor
			from openxml(@nId, 'Data/Item', 2)
			with(Usuario int,
				 Producto int,
				 Valor decimal(10,2)) x

exec sp_xml_preparedocument @nId output, @xml_itemsIva

	insert into @tIva (IdProducto,Porcentaje)
	select  x.IdProducto,
			x.Porcentaje
	from openxml(@nId, 'Data/Producto', 2)
	with(IdProducto int,
		 Porcentaje float) x

exec sp_xml_removedocument @nId

select usu.Id,
	   usu.Nombre,
	   cast(coalesce(sum(com.Valor),'0.00') as decimal(10,2)) as Valor_Total,
	   cast(coalesce(sum(com.Valor*coalesce(iva.Porcentaje,0)),0) as decimal(10,2)) Iva
from @tUsuarios usu
left join @tCompras com on usu.Id = com.Usuario
left join @tIva iva on iva.IdProducto = com.Producto
group by usu.Id,
	     usu.Nombre
order by 1
GO
/****** Object:  StoredProcedure [dbo].[spReporteCalificacion]    Script Date: 13/09/2021 22:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*-----------------------------------------------------------------------------------------------------------------------------------------
* Procedimiento			: spReporteCalificacion
* Descripción			: Consultar reporte calificacion
*---------------------------------------------------------------------------------------------------------------------------------------*/
CREATE procedure [dbo].[spReporteCalificacion]
@cMensaje varchar (1000) output

as
set nocount on
set lock_timeout 3000

begin try

SELECT mm.[Id]
      ,mm.[MateriaId]
      ,mm.[AlumnoId]
      ,mm.[Periodo]
      ,mm.[Nota]
	  ,m.Codigo as CodigoMateria
	  ,m.Nombre as NombreMateria
	  ,a.Identificacion as IdentificacionAlumno
	  ,a.Nombre + ' ' + a.Apellido as NombreCompletoAlumno
	  ,p.Identificacion as IdentificacionProfesor
	  ,p.Nombre + ' ' + p.Apellido as NombreCompletoProfesor
	  ,case when mm.nota >= 3 then 'SI' else 'NO' end as Aprueba
  FROM [dbo].[MatriculaMateria] mm
  join Materia m on m.Id = mm.MateriaId
  join Alumno a on a.Id = mm.AlumnoId
  left join ProfesorAsignatura pa on pa.MateriaId = m.Id
  left join Profesor p on p.Id = pa.ProfesorId

end try
begin catch
	set @cMensaje = 'Se produjo el siguiente error ' + error_message() +
					'\n Procedimiento ' + error_procedure() +
					'\n Linea ' + cast(error_line() as varchar)
end catch
GO
