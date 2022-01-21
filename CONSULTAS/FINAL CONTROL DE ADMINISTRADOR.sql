create procedure fecha_borrado
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

----------------------------------------------------------------------------

alter procedure arqueo
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

exec arqueo'2020-04-12'

create procedure arqueo_solo
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

exec arqueo_solo'2020-04-12'