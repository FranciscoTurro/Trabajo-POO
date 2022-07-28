insert into Usuarios (Nombre, Email, Dni, Contraseña, Perfil_Id)
values (
	('admin'),
	('a@a.com'),
	('12345678'),
	('8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'),
	(SELECT Id from Perfiles WHERE Perfiles.Nombre='Gerente')
)