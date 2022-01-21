create procedure insertar_cliente
(
	@ci varchar(15),
	@nombre varchar(150),
	@apellido varchar(150)
)
as
begin
	if not exists(select CI from CLIENTE where CI=@ci)
	begin
		insert into CLIENTE
		(
			CI,
			NOMBRE,
			APELLIDOS
		)
		values
		(
			@ci,
			@nombre,
			@apellido
		)
	end
	else
	begin
		declare @msm varchar(200)
		set @msm = 'EL CLIENTE QUE USTED DESEA INSERTAR YA FUE INSTERTADO'
		RAISERROR(@msm,11,1)
	end
end

select * from CLIENTE

create procedure actualizar_cliente
(
	@ci varchar(15),
	@nombre varchar(150),
	@apellido varchar(150)
)
as
begin
	if exists(select CI from CLIENTE where CI=@ci)
	begin
		update CLIENTE
		set
			NOMBRE=@nombre,
			APELLIDOS=@apellido
		where
			CI=@ci
	end
	else
	begin
		declare @msm varchar(200)
		set @msm = 'EL CLIENTE QUE USTED DESEA ACTUALIZAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end

create procedure eliminar_cliente
(
	@ci varchar(15)
)
as 
begin
	if exists(select CI from CLIENTE where CI=@ci)
	begin
		delete CLIENTE
		where
			CI=@ci
	end
	else
	begin
		declare @msm varchar(200)
		set @msm = 'EL CLIENTE QUE USTED DESEA ELIMINAR NO EXISTE'
		RAISERROR(@msm,11,1)
	end
end


create procedure buscar_cliente
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