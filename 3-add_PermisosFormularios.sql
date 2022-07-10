INSERT INTO FormularioPermiso (Formulario_Id, Permiso_Id)
values (
	(SELECT Id FROM Formularios WHERE NombreSistema = 'GestionarClientes'),
	(SELECT Id FROM Permisos WHERE Nombre = 'Modificar')
),
(
(SELECT Id FROM Formularios WHERE NombreSistema = 'CrearPerfil'),
(SELECT Id FROM Permisos WHERE Nombre = 'Eliminar')
),
(
(SELECT Id FROM Formularios WHERE NombreSistema = 'CrearPerfil'),
(SELECT Id FROM Permisos WHERE Nombre = 'Modificar')
);