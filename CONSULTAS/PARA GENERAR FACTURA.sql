alter procedure FACTURA
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

---------------------------------------------------



alter procedure FACTURA_total
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




select * from COMPRA
exec FACTURA_total '123456021','123456'
exec FACTURA '123456021','123456'

