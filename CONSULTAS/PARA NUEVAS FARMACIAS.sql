create procedure insertar_farmacia
(
	@cod_far int,
	@nombre varchar(100),
	@NIT varchar(100),
	@COD_DUE VARCHAR(10),
	@UBICACION varchar(200)
)
as
begin
	if not exists(select NIT from FARMACIA_N where NIT=@NIT)
	begin
		insert into FARMACIA_N
		(
			COD_FAR,
			NOMBRE,
			NIT,
			COD_DUEÑO,
			UBICACION
		)
		values
		(
			@cod_far,
			@nombre,
			@NIT,
			@COD_DUE,
			@UBICACION
		)
	end
	else
	begin
		declare @mes varchar(100)
		set @mes='LA FARMACIA CON EL NIT: '+@NIT+' YA ESTA CREADA' 
		RAISERROR(@mes,11,1)
	end
end

exec insertar_farmacia 4,'SANTISIMA TRINIDAD','10475258','10470522','CALLE JUAN MANUEL NRO 200'

alter view visualizar_farmacia
as
(
	select f.NIT,f.NOMBRE,f.UBICACION,ad.CI+' - '+ad.NOMBRE+' '+ad.APELLIDO as [NOMBRE DEL DUEÑO]  
	from FARMACIA_N f, ADMINISTRADOR ad
	where f.COD_DUEÑO=ad.CI
)
create view combo
as
(
	select CI+' - '+NOMBRE+' '+APELLIDO as nombre
	from ADMINISTRADOR
)

alter procedure editar_farmacia
(
	@cod_far int,
	@nombre varchar(100),
	@NIT varchar(100),
	@COD_DUE VARCHAR(10),
	@UBICACION varchar(200)
)
as
begin
	declare @cod_farma int
	if exists(select NIT from FARMACIA_N where @cod_far=COD_FAR)
		begin
			update FARMACIA_N
			set
				NOMBRE=@nombre,
				NIT=@NIT,
				COD_DUEÑO=@COD_DUE,
				UBICACION=@UBICACION
			where
				COD_FAR=@cod_far
		end
	else
		begin
			declare @msm varchar(300)
			set @msm='NO EXISTE LA FARMACIA QUE USTED DESEA ACTUALIZAR'
			RAISERROR(@msm,11,1)
		end
end

create procedure eliminar_farmacia
(
	@cod_far int
)
as
begin
	if exists(select COD_FAR from FARMACIA_N where COD_FAR=@cod_far)
	begin
		delete FARMACIA_N
		where
		COD_FAR=@cod_far
	end
	else
	begin
		declare @fr varchar(300)
		set @fr='EL USUARIO QUE USTED DESEA ELIMINAR NO EXISTE'
		RAISERROR(@fr,11,1);
	end
end

create procedure buca(@nit varchar(20))
as
begin
	select * from visualizar_farmacia where NIT like ('%'+@nit+'%')
end

exec buca'1'

exec eliminar_farmacia 6


select * from visualizar_farmacia
select * from ADMINISTRADOR
select * from FARMACIA_N
select * from FARMACIA_N where NIT='789987789'

select MAX(COD_FAR)
from FARMACIA_N