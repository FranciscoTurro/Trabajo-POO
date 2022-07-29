select * from Usuarios
go
select * from Perfiles
go
select * from Formularios
go
select * from Productos
go

select 
	PerfilFormulario.Perfil_Id,
	Perfiles.Nombre,
	PerfilFormulario.Formulario_Id,
	Formularios.NombreSistema
	from PerfilFormulario 
	INNER JOIN Perfiles ON Perfiles.Id=Perfil_Id 
	INNER JOIN Formularios ON Formularios.Id=Formulario_Id; 
