DECLARE @xml_usuarios XML, @xml_compras XML, @xml_itemsIva XML 
SET @xml_usuarios = ' <Data> <Usuario><Id>14</Id><Nombre>Juan</Nombre></Usuario> <Usuario><Id>17</Id><Nombre>Maria</Nombre></Usuario> <Usuario><Id>25</Id><Nombre>Carlos</Nombre></Usuario> <Usuario><Id>15</Id><Nombre>Fernanda</Nombre></Usuario> </Data>' SET @xml_compras = ' <Data> <Item><Usuario>14</Usuario><Producto>78</Producto><Valor>300</Valor></Item> <Item><Usuario>17</Usuario><Producto>23</Producto><Valor>568</Valor></Item> <Item><Usuario>17</Usuario><Producto>99</Producto><Valor>350</Valor></Item> <Item><Usuario>14</Usuario><Producto>99</Producto><Valor>107</Valor></Item> <Item><Usuario>25</Usuario><Producto>23</Producto><Valor>425</Valor></Item> </Data>' SET @xml_itemsIva = ' <Data> <Producto><IdProducto>23</IdProducto><Porcentaje>0.16</Porcentaje></Producto> <Producto><IdProducto>99</IdProducto><Porcentaje>0.19</Porcentaje></Producto> </Data>'

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
	   coalesce(sum(com.Valor),'0.00') as Valor_Total,
	   sum(com.Valor*coalesce(iva.Porcentaje,0)) Iva
from @tUsuarios usu
left join @tCompras com on usu.Id = com.Usuario
left join @tIva iva on iva.IdProducto = com.Producto


group by usu.Id,
	     usu.Nombre
order by 1
