SELECT * FROM VENDEDOR

create view todooooo
as
(
	select s.NOMBRE+' '+s.APELLIDOS as NOM,s.CI,t.TIPO from VENDEDOR s,V_TIPO t where s.TIPO=t.ID_TIPO
)

select * from todooooo

--------------------------------------------------


------------------------------------------------
--------------------------------------------------






select pro.COD,pro.DESCRIPCION,pro.[FECHA DE VENCIMIENTO],pro.[FECHA DE ELABORACION],pro.PRECIO,pro.[PRECIO VENTA],ima.RUTA,ti.CANTIDAD
from FARMACIA_N far,PRODUCTO pro, TIENE ti,IMAGEN ima
where
far.COD_FAR=ti.COD_FAR and
pro.COD=ti.COD_MED and
pro.IMAGEN=ima.COD_IM and
far.NIT like ('%10%')



alter procedure todo_busqueda_medi_pro
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




select * from todo_busqueda_medi

alter procedure bus_por_des
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

exec bus_por_des'123456','p'

select * from FARMACIA_N
select * from PRODUCTO
select * from TIENE
select * from VENDEDOR


UPDATE VENDEDOR
SET COD_FAR=5
WHERE CI='12345687'