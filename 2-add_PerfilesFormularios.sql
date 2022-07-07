INSERT INTO PerfilFormulario (Perfil_Id, Formulario_Id)
values (
(SELECT Id FROM Perfiles WHERE Nombre = 'Gerente'),
--(SELECT Id FROM Perfiles WHERE Nombre = 'Empleado'),
	--(SELECT Id FROM Formularios WHERE NombreSistema = 'AgregarCliente')
--(SELECT Id FROM Formularios WHERE NombreSistema = 'EliminarCliente')
(SELECT Id FROM Formularios WHERE NombreSistema = 'ModificarCliente')

);