alter procedure bus_por_far
(
	@ci varchar(15),
	@descrip varchar(500)
)
as
begin
	select far.NOMBRE,far.UBICACION,pro.DESCRIPCION,tie.CANTIDAD,imagen.RUTA
	from FARMACIA_N far, TIENE tie, PRODUCTO pro,IMAGEN imagen,VENDEDOR ven
	where
		far.COD_FAR=tie.COD_FAR and
		pro.COD=tie.COD_MED and
		pro.IMAGEN=imagen.COD_IM and
		ven.COD_FAR=far.COD_FAR and
		tie.CANTIDAD!=0 and
		ven.CI!=@ci and
		DESCRIPCION like('%'+@descrip+'%')
end

exec bus_por_far'123456',''