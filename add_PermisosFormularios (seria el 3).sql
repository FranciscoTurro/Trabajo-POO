INSERT INTO FormularioPermiso (Formulario_Id, Permiso_Id)
values (
	(SELECT Id FROM Formularios WHERE NombreSistema = 'formGestionarUsuarios'),
	--(SELECT Id FROM Formularios WHERE NombreSistema = 'RegistrarUsuario'),
	(SELECT Id FROM Permisos WHERE Nombre = 'Eliminar')
	--(SELECT Id FROM Permisos WHERE Nombre = 'Agregar')
	--(SELECT Id FROM Permisos WHERE Nombre = 'Modificar') 
);

--DESCOMENTAR UNO A LA VEZ Y COMENTAR LOS OTROS 2 NO SEAS PAYASO