alter function detecta_admi_o_vende(@ci_id varchar(10))
returns varchar(100)
as
begin
	declare @de varchar(100)
	if exists(select CI from ADMINISTRADOR where CI=@ci_id)
		begin
			set @de = (select NOMBRE+' '+APELLIDO from ADMINISTRADOR where CI=@ci_id)
		end
	else
		begin
			if exists (select CI from VENDEDOR where CI=@ci_id)
			begin
				set @de=(select NOMBRE+' '+APELLIDOS from VENDEDOR where CI=@ci_id)
			end
		end
	return @de
end
create function detecta_admi_o_vende_ventana(@ci_id varchar(10))
returns int
as
begin
	declare @de int
	if exists(select CI from ADMINISTRADOR where CI=@ci_id)
		begin
			set @de=0
		end
	else
		begin
			if exists (select CI from VENDEDOR where CI=@ci_id)
			begin
				set @de=1
			end
		end
	return @de
end
select dbo.detecta_admi_o_vende_ventana('104705')
insert into V_TIPO
(
	ID_TIPO,
	TIPO
)
values
(1,'DIURNO'),
(2,'NOCTURNO')
insert into VENDEDOR
(
	CI,
	NOMBRE,
	APELLIDOS,
	EDAD,
	TIPO,
	COD_FAR
)
values
('1010','HECTOR','MAMANI',20,1,1)


alter procedure insertar_vendedor
(
	@ci varchar(10),
	@nombres varchar(100),
	@apellidos varchar(100),
	@Edad int,
	@tipo int,
	@Cod_far varchar(15)
)
as
begin
	declare @mio varchar(500)
	if exists(select CI from VENDEDOR where CI=@ci)
		begin
		set @mio='EL EMPLEADO CON CI: '+@ci+' YA ESTA INSERTADO'
			RAISERROR(@mio,11,1)		
		end
	else
		begin
		     declare @codigo int
			 set @codigo=(select COD_FAR from FARMACIA_N where @Cod_far=NIT)
			 insert into VENDEDOR
			 (
				CI,
				NOMBRE,
				APELLIDOS,
				EDAD,
				TIPO,
				COD_FAR
			 )
			 values
			 (
				@ci,
				@nombres,
				@apellidos,
				@Edad,
				@tipo,
				@codigo
			 )
		end
end

exec insertar_vendedor'100505','mariza','mamani',22,1,'10470502017'
select * from FARMACIA_N
select * from VENDEDOR

alter view mostrar_empleado
as
(
	select v.CI,v.NOMBRE,v.APELLIDOS,v.EDAD,t.TIPO,f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA]
	from VENDEDOR v, FARMACIA_N f, V_TIPO t
	where v.COD_FAR=f.COD_FAR and v.TIPO=t.ID_TIPO
)

select f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA] from FARMACIA_N f
alter procedure Editar_Usuario
(
	@ci varchar(10),
	@nombres varchar(100),
	@apellidos varchar(100),
	@Edad int,
	@tipo int,
	@Cod_far varchar(15)	
)
as
begin
declare @err varchar(500)
	if not exists(select CI from VENDEDOR where CI=@ci)
		begin
			set @err='EL USUARIO CON CI: '+@ci+' NO EXISTE'
			RAISERROR(@err,11,1)
		end
	else
		begin
			declare @codigo int
			set @codigo=(select COD_FAR from FARMACIA_N where @Cod_far=NIT)
			update VENDEDOR
			set
			NOMBRE=@nombres,
			APELLIDOS=@apellidos,
			EDAD=@Edad,
			TIPO=@tipo,
			COD_FAR=@codigo
			where
			CI=@ci
		end
end

exec Editar_Usuario'10105','hector','mamani',18,2,1


create procedure Eliminar_Usuario
(@ci varchar(10))
as
begin
	declare @mm varchar(500)
	if exists(select CI from VENDEDOR where CI=@ci)
	begin
		delete VENDEDOR where CI=@ci
	end
	else
	begin
		set @mm='EL USUARIO QUE DESEA ELIMINAR NO EXISTE'
		RAISERROR(@mm,11,1)
	end
end

exec Eliminar_Usuario'1010'

alter procedure buscar_empleado
(
	@ci varchar(10)
)
as
begin
	select v.CI,v.NOMBRE,v.APELLIDOS,v.EDAD,t.TIPO,f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA]
	from VENDEDOR v, FARMACIA_N f, V_TIPO t
	where v.COD_FAR=f.COD_FAR and v.TIPO=t.ID_TIPO and v.CI like('%'+@ci+'%')
end
exec buscar_empleado'9'

select * from mostrar_empleado

select * from FARMACIA_N
select * from VENDEDOR
select * from ADMINISTRADOR
select * from V_TIPO

insert into FARMACIA_N
values
(3,'ECOFARMA','1500151332','10470522')



select f.NIT+'  -   NOMBRE: '+f.NOMBRE as [NOMBRE FARMACIA] from FARMACIA_N f

select * from ADMINISTRADOR
select * from FARMACIA_N

select * from V_TIPO