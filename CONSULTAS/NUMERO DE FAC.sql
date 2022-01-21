create procedure toma
as
begin
	declare @num int
	set @num=(select COUNT(NUME) from FACTURA_GENERADA f)
	set @num=@num+1
	insert into FACTURA_GENERADA
	(
		NUME
	)
	values
	(
		@num
	)
end

exec toma

alter view FACTURA_GEN
as
(
	select MAX(NUME) as MAXIMO
	FROM FACTURA_GENERADA
)

select * from VENTA
select * from COMPRA