alter procedure insertar_venta_compra
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

exec insertar_venta_compra'10104705','123456','323211',2
select * from CLIENTE
select * from TIENE
select * from PRODUCTO

delete VENTA

alter procedure bus_por_far_ven
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

exec bus_por_far_ven'123456',''


create procedure buscar_cliente_ven
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

delete VENTA
delete COMPRA

select * from VENTA
select * from COMPRA