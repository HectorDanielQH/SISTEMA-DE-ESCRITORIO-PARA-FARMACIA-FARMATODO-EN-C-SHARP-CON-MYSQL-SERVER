create procedure insertar_medicamento
(
	@cod_pro varchar(100),
	@descrip varchar(500),
	@precio money,
	@precio_venta money,
	@fecha_elab date,
	@fecha_ven date,
	@ruta varchar(500)
)
as
begin
	if not exists(select COD from PRODUCTO where COD=@cod_pro)
	begin
	    insert into IMAGEN
		(
			COD_IM,
			RUTA
		)
		values
		(
			@cod_pro,
			@ruta
		)
		insert into PRODUCTO
		(
			COD,
			DESCRIPCION,
			PRECIO,
			[PRECIO VENTA],
			[FECHA DE ELABORACION],
			[FECHA DE VENCIMIENTO],
			IMAGEN
		)
		values
		(
			@cod_pro,
			@descrip,
			@precio,
			@precio_venta,
			@fecha_elab,
			@fecha_ven,
			@cod_pro
		)
	end
	else
	begin
		declare @msm varchar(300)
		set @msm='EL MEDICAMENTO QUE USTED QUIERE INSERTAR YA EXISTE'
		RAISERROR(@msm,11,1)
	end
end

create procedure editar_medicamento
(
	@cod_pro varchar(100),
	@descrip varchar(500),
	@precio money,
	@precio_venta money,
	@fecha_elab date,
	@fecha_ven date,
	@ruta varchar(500)
)
as
begin
	if exists(select COD from PRODUCTO where COD=@cod_pro)
	begin
	    update IMAGEN
		set
			RUTA=@ruta
		where
			COD_IM=@cod_pro

		update PRODUCTO
		set
			DESCRIPCION=@descrip,
			PRECIO=@precio,
			[PRECIO VENTA]=@precio_venta,
			[FECHA DE ELABORACION]=@fecha_elab,
			[FECHA DE VENCIMIENTO]=@fecha_ven
		where
			COD=@cod_pro
	end
	else
	begin
		declare @msm varchar(300)
		set @msm='EL MEDICAMENTO QUE USTED QUIERE EDITAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end

alter procedure eliminar(@cod_pro varchar(100))
as
begin
	if exists(select COD from PRODUCTO where COD=@cod_pro)
	begin
		delete PRODUCTO
		where 
		COD=@cod_pro
		delete IMAGEN
		where
		COD_IM=@cod_pro
	end
	else
	begin
		declare @msm varchar(300)
		set @msm='EL MEDICAMENTO QUE USTED QUIERE ELIMINAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end


alter procedure buscar_produc(@cod_pro varchar(500))
as
begin
		select v.COD,v.DESCRIPCION,v.PRECIO,v.[PRECIO VENTA],v.[FECHA DE ELABORACION],v.[FECHA DE VENCIMIENTO],i.RUTA
		from PRODUCTO v, IMAGEN i
		where
		v.IMAGEN=i.COD_IM and
		v.DESCRIPCION like('%'+@cod_pro+'%');
end

exec insertar_medicamento'123456','ASPIRINA MARCA DROGERIA INTI',0.10,0.50,'28/01/2020','30/12/2020','C:'
exec editar_medicamento'123456','ASPIRINA MARCA DE FARMACORP',0.10,1.00,'28/01/2020','1/12/2020','D:\PROYECTOS C#\PROYECTO BASE II\IMAGENES DEL PROYECTO\ASPIRINA.jpg'
exec eliminar'123456'
exec buscar_produc''
select * from PRODUCTO
select * from IMAGEN

create view demostracion
as
(
	select v.COD,v.DESCRIPCION,v.PRECIO,v.[PRECIO VENTA],v.[FECHA DE ELABORACION],v.[FECHA DE VENCIMIENTO],i.RUTA
		from PRODUCTO v, IMAGEN i
		where
		v.IMAGEN=i.COD_IM
)

select * from demostracion