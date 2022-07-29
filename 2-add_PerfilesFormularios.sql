INSERT INTO PerfilFormulario (Perfil_Id, Formulario_Id)
values (
(SELECT Id FROM Perfiles WHERE Nombre = 'Gerente'),
(SELECT Id FROM Formularios WHERE NombreSistema = 'GestionarClientes')
),
(
(SELECT Id FROM Perfiles WHERE Nombre = 'Gerente'),
(SELECT Id FROM Formularios WHERE NombreSistema = 'GestionarPerfil')
),
(
(SELECT Id FROM Perfiles WHERE Nombre = 'Gerente'),
(SELECT Id FROM Formularios WHERE NombreSistema = 'GestionarProductos')
),
(
(SELECT Id FROM Perfiles WHERE Nombre = 'Gerente'),
(SELECT Id FROM Formularios WHERE NombreSistema = 'Listas')
),
(
(SELECT Id FROM Perfiles WHERE Nombre = 'Empleado'),
(SELECT Id FROM Formularios WHERE NombreSistema = 'GestionarClientes')
),
(
(SELECT Id FROM Perfiles WHERE Nombre = 'Empleado'),
(SELECT Id FROM Formularios WHERE NombreSistema = 'GestionarProductos')
),
(
(SELECT Id FROM Perfiles WHERE Nombre = 'Empleado'),
(SELECT Id FROM Formularios WHERE NombreSistema = 'Listas')
)
