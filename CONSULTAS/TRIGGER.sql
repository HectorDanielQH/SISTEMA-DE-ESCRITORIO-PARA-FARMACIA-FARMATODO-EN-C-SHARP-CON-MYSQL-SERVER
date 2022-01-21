alter trigger actualizar_venta
on VENTA
after insert
as
begin
	declare @ca int
	set @ca=(select F.CANTIDAD from inserted F)
	declare @ven varchar(15)
	set @ven=(select F.COD_VENDEDOR from inserted F)
	declare @far varchar(15)
	set @far=(select far.COD_FAR from FARMACIA_N far,VENDEDOR vende where far.COD_FAR=vende.COD_FAR and vende.CI=@ven)
	declare @pro varchar(100)
	set @pro=(select F.COD_PRO from inserted F)

	update TIENE
	set
		CANTIDAD=CANTIDAD-@ca
	where
		COD_FAR=@far and
		COD_MED=@pro
end

select * from TIENE
select * from VENTA


-------------------------------------------------------------------------------

create trigger controlar_vencimiento
on VENTA
after insert
as
begin
	declare @datos date
	set @datos=GETDATE()
	declare @codi_pro varchar(100)
	set @codi_pro=(select f.COD_PRO from inserted f)
	declare @dat_med date
	set @dat_med=(select pro.[FECHA DE VENCIMIENTO] from PRODUCTO pro where @codi_pro=pro.COD)
	update TIENE
	set
	CANTIDAD=0
	where
	COD_MED=@codi_pro and
	@datos>@dat_med
end




alter trigger borrar_Venta
on VENTA
after delete
as
begin
	declare @dato datetime
	set @dato=GETDATE()
	declare @cod_ve int
	declare @cod_pro varchar(100)
	declare @cod_ven varchar(10)
	declare @fecha_ven date
	declare @canti int
	set @cod_ve = (select ven.COD_VEN from deleted ven)
	set @cod_pro = (select ven.COD_PRO from deleted ven)
	set @cod_ven = (select ven.COD_VENDEDOR from deleted ven)
	set @fecha_ven = (select ven.[FECHA VENTA] from deleted ven)
	set @canti= (select ven.CANTIDAD from deleted ven)
	insert into [VENTA BORRADA]
	(
		COD_VE,
		COD_PRO,
		COD_VEN,
		[FECHA VENTA],
		CANTIDAD,
		[FECHA DE BORRADO]
	)
	values
	(
		@cod_ve,
		@cod_pro,
		@cod_ven,
		@fecha_ven,
		@canti,
		@dato
	)
end





select * from CLIENTE
select * from VENTA