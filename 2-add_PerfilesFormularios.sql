INSERT INTO PerfilFormulario (Perfil_Id, Formulario_Id)
values (
--(SELECT Id FROM Perfiles WHERE Nombre = 'Gerente'),
(SELECT Id FROM Perfiles WHERE Nombre = 'Empleado'),
	(SELECT Id FROM Formularios WHERE NombreSistema = 'GestionarClientes')
--(SELECT Id FROM Formularios WHERE NombreSistema = 'CrearPerfil')
--(SELECT Id FROM Formularios WHERE NombreSistema = 'ModificarCliente')
);