/*-----------------------------------------------------------------------------------------------------------------------------------------
* Procedimiento			: spComprasUsuario
* Descripción			: Consulta compras usuario
*---------------------------------------------------------------------------------------------------------------------------------------*/
create procedure [dbo].[spComprasUsuario]
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
