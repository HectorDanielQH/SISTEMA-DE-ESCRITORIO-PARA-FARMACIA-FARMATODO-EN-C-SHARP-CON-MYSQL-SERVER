alter procedure vista_tuyo
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

EXEC vista_tuyo'12345687'

SELECT * FROM VENTA
alter procedure vista_tuyo_suma
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



create procedure ve_vis
(
	@co int
)
as
begin
	delete VENTA
	where
		COD_VEN=@co
end

select * from VENTA