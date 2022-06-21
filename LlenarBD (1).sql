use EJEMPLOBD

-- Agregar Permisos
insert into Permisos values ('Agregar', 'btnAgregar')
insert into Permisos values ('Eliminar', 'btnEliminar')
insert into Permisos values ('Modificar', 'btnModificar')
insert into Permisos values ('Cancelar', 'btnCancelar')
insert into Permisos values ('Guardar', 'btnGuardar')

-- Agregar Formularios
 insert into Formularios values ('Gestionar Usuarios', 'formGestionarUsuarios')
 insert into Formularios values ('Usuario', 'formUsuario')

-- Agregar Perfiles
insert into Perfiles values ('Cliente')
insert into Perfiles values ('Super Admin')
insert into Perfiles values ('Admin')

-- Agregar ABM Gestionar Usuarios

insert into FormularioPermiso values (1, 1)
insert into FormularioPermiso values (1, 2)
insert into FormularioPermiso values (1, 3)

-- Agregar botones Guardar y Cancelar al form Usuario
 insert into FormularioPermiso values (2, 4)
 insert into FormularioPermiso values (2, 5)

-- Asignar a un perfil un formulario en especifico. Perfil 2 usa formulario 1.
 insert into PerfilFormulario values (2, 1)

insert into Usuarios values ('Mauro Falcone', 'maurofalcone.95@gmail.com', '37454893', 'Password@@01', 2)
insert into Usuarios values ('Joaquin Leimeter', 'leimeter.95@gmail.com', '40454893', 'Password@@0123', 3)
insert into Usuarios values ('Jose blua', 'jose.95@gmail.com', '20454893', 'Password@@01lala', 1)

select * from Usuarios
go
select * from Perfiles
go
select * from Formularios
go
select * from Permisos
go
select * from FormularioPermiso
go
select * from PerfilFormulario



select * from Usuarios


select u.Nombre, f.Nombre as 'Formulario' from Usuarios u
inner join Perfiles p on u.Perfil_Id = p.Id
inner join PerfilFormulario pf on pf.Perfil_Id = p.Id
inner join Formularios f on pf.Formulario_Id = f.Id where u.Nombre = 'Mauro Falcone'