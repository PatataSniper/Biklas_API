select * from Usuarios
INSERT INTO Usuarios (IdUsuario, Nombre, Contraseña, KmRecorridos,
	Apellidos, NombreUsuario, FechaNacimiento, FechaRegistro,
	CorreoElectronico, IdRol)
	VALUES (2, 'Carlos', 'Contra2', 0, 'Arias', 'CaA', '1996-06-12',
	'2021-08-08', 'carlos@alumnos.udg.mx', 1)

INSERT INTO Roles (IdRol, Nombre)
	VALUES (1, 'Administrador')

select * from Roles
select * from Permisos