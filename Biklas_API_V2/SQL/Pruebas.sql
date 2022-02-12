select * from Usuarios

-- Creamos nuevo usuario
INSERT INTO Usuarios (IdUsuario, Nombre, Contraseña, KmRecorridos,
	Apellidos, NombreUsuario, FechaNacimiento, FechaRegistro,
	CorreoElectronico, IdRol)
	VALUES (5, 'Paco', 'Contra5', 32, 'Perez Lopez', 'PacoPerez', '1990-11-01',
	'2019-12-12', 'paco@gmail.com', 1)

--DELETE Usuarios where IdUsuario = 5

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
select * from Usuarios

-- Generamos la primera ruta de prueba manualmente
-- Insertamos vértices
INSERT INTO Vertices VALUES (1, 20.700346, -103.330336)
INSERT INTO Vertices VALUES (2, 20.699594, -103.330786)

-- Insertamos vias
INSERT INTO Vias VALUES (1, 'Monte Atlas')

-- Insertamos aristas
INSERT INTO Aristas VALUES (1, 1, NULL, 0, 1, 2, 1)

-- Insertamos ruta
INSERT INTO Rutas VALUES(1, 'Ruta de prueba', '05-02-2021', '05-02-2021', 1, 2, 1)
-- DELETE Rutas WHERE IdRuta = 1

-- Insertamos segmentos de ruta
INSERT INTO Segmentos VALUES (1, 1, 1, 1)
-- DELETE Segmentos WHERE IdSegmento = 1

SELECT ru.Nombre, ar.Bidireccional, ar.NumeroCarriles1, ar.NumeroCarriles2, vi.Nombre as Nombre_Via, verI.PosicionX as X_Inicial,
	verI.PosicionY as Y_Final, verF.PosicionX as X_Final, verF.PosicionY as Y_Final FROM Rutas AS ru
	inner join Segmentos AS se on se.IdRuta = ru.IdRuta
	inner join Aristas AS ar on ar.IdArista = se.IdArista
	inner join Vias as vi on vi.IdVia = ar.IdVia
	inner join Vertices as verI on verI.IdVertice = ar.IdVerticeInicial
	inner join Vertices as verF on verF.IdVertice = ar.IdVerticeFinal