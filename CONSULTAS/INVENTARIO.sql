alter view tiene_vista_tabla
as
(
	select far.NIT+' - '+far.NOMBRE as FARMACIA,far.UBICACION,pro.COD+' - '+pro.DESCRIPCION as [DESCRIPCION DEL PRODUCTO],t.CANTIDAD,pro.[FECHA DE ELABORACION],pro.[FECHA DE VENCIMIENTO],i.RUTA
	from FARMACIA_N far,PRODUCTO pro,TIENE t,IMAGEN i
	where
	pro.IMAGEN=i.COD_IM and
	t.COD_FAR=far.COD_FAR and
	t.COD_MED=pro.COD
)
select * from box_medicamento
create view box_farmacia
as
(
	select far.NIT+' - '+far.NOMBRE as FARMACIA
	from FARMACIA_N far
)
create view box_medicamento
as
(
	select pro.COD+' - '+pro.DESCRIPCION as [DESCRIPCION DEL PRODUCTO]
	from PRODUCTO pro
)

alter procedure insertar_tiene
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

create procedure actualizar_tiene
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

create procedure eliminar_tiene
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

alter procedure buscar_tiene
(
	@descripcion varchar(500)
)
as
begin
	select * from tiene_vista_tabla
	where [DESCRIPCION DEL PRODUCTO] like('%'+@descripcion+'%')
end

exec actualizar_tiene'123321','101010',10
exec insertar_tiene'10470502017','101010',50
exec eliminar_tiene'123321','101010'
exec buscar_tiene''

select * from tiene_vista_tabla
select * from FARMACIA_N
select * from PRODUCTO