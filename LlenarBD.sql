use [DB-TPPOO]

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