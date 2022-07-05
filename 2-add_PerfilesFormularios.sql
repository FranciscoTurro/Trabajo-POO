INSERT INTO PerfilFormulario (Perfil_Id, Formulario_Id)
values (
	(SELECT Id FROM Perfiles WHERE Nombre = 'Admin'),
--	(SELECT Id FROM Perfiles WHERE Nombre = 'Cliente'),
	--(SELECT Id FROM Formularios WHERE NombreSistema = 'AdminAgregar')
--	(SELECT Id FROM Formularios WHERE NombreSistema = 'AdminEliminar')
--(SELECT Id FROM Formularios WHERE NombreSistema = 'AdminModificar')

	--(SELECT Id FROM Formularios WHERE NombreSistema = 'RegistrarUsuario')
);