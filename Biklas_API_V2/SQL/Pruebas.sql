select * from Usuarios

-- Creamos nuevo usuario
INSERT INTO Usuarios (IdUsuario, Nombre, Contraseña, KmRecorridos,
	Apellidos, NombreUsuario, FechaNacimiento, FechaRegistro,
	CorreoElectronico, IdRol)
	VALUES (3, 'Andres', 'Contra3', 568, 'De la peña', 'Sgt0pimienta', '1999-11-23',
	'2020-05-18', 'andres@gmail.com', 1)

select * from Amigos
-- Creamos relaciones de amigos entre usuarios, una relación de amistad debe
-- de crearse en ambos sentidos
INSERT INTO Amigos (IdUsuario, IdAmigo, FechaRelacion)
	VALUES (1, 3, '2021-11-24')
INSERT INTO Amigos (IdUsuario, IdAmigo, FechaRelacion)
	VALUES (3, 1, '2021-11-24')

INSERT INTO Roles (IdRol, Nombre)
	VALUES (1, 'Administrador')

select * from Roles
select * from Permisos