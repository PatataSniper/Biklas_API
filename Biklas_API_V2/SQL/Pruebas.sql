select * from Usuarios

-- Creamos nuevo usuario
INSERT INTO Usuarios (IdUsuario, Nombre, Contraseña, KmRecorridos,
	Apellidos, NombreUsuario, FechaNacimiento, FechaRegistro,
	CorreoElectronico, IdRol)
	VALUES (4, 'Oswaldo', 'Contra4', 1390, 'Castillo', 'OswCas', '1992-11-23',
	'2021-05-02', 'oswcas@gmail.com', 1)

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