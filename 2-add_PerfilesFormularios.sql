INSERT INTO PerfilFormulario (Perfil_Id, Formulario_Id)
values (
	(SELECT Id FROM Perfiles WHERE Nombre = 'Admin'),
--	(SELECT Id FROM Perfiles WHERE Nombre = 'Cliente'),
	--(SELECT Id FROM Formularios WHERE NombreSistema = 'Agregar')
--	(SELECT Id FROM Formularios WHERE NombreSistema = 'Eliminar')
--(SELECT Id FROM Formularios WHERE NombreSistema = 'Modificar')

);