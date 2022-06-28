INSERT INTO FormularioPermiso (Formulario_Id, Permiso_Id)
values (
	(SELECT Id FROM Formularios WHERE NombreSistema = 'formGestionarUsuarios'),
	(SELECT Id FROM Permisos WHERE Nombre = 'Agregar')
);