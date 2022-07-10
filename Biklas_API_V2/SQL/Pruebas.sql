select * from Usuarios

-- Creamos nuevo usuario
INSERT INTO Usuarios (IdUsuario, Nombre, Contraseña, KmRecorridos,
	Apellidos, NombreUsuario, FechaNacimiento, FechaRegistro,
	CorreoElectronico, IdRol)
	VALUES (5, 'Paco', 'Contra5', 32, 'Perez Lopez', 'PacoPerez', '1990-11-01',
	'2019-12-12', 'paco@gmail.com', 1)

--DELETE Usuarios where IdUsuario = 5

select u1.IdUsuario as Id_usuario, u1.NombreUsuario as Nombre_usuario, u2.idusuario as Id_amigo, u2.NombreUsuario as Nombre_amigo,
 a.FechaRelacion from Amigos AS a
	INNER JOIN Usuarios AS u1 ON u1.IdUsuario = a.IdUsuario
	INNER JOIN Usuarios AS u2 ON u2.IdUsuario = a.IdAmigo
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
INSERT INTO Vertices VALUES (5, 20.699848, -103.331281)
INSERT INTO Vertices VALUES (4, 20.809582, -103.256821)
-- DELETE Vertices WHERE IdVertice IN (1, 2)

-- Insertamos vias
INSERT INTO Vias VALUES (3, 'Monte Calvario')

-- Insertamos aristas
INSERT INTO Aristas VALUES (3, 1, 1, 0, 2, 5, 3)
-- DELETE Aristas WHERE IdArista = 1

-- Insertamos ruta
INSERT INTO Rutas VALUES(2, 'Ruta de prueba 2', 3, 4, 1, '02-18-2021')
-- DELETE Rutas WHERE IdRuta = 1

-- Insertamos segmentos de ruta
INSERT INTO Segmentos VALUES (3, 2, 3, 1)
-- DELETE Segmentos WHERE IdSegmento = 1

SELECT ru.IdRuta, ru.Nombre, us.NombreUsuario, se.Posicion, ar.Bidireccional, ar.NumeroCarriles1, 
	ar.NumeroCarriles2, vi.Nombre as Nombre_Via, verI.IdVertice as Id_V_Inicial, 
	verI.PosicionX as X_Inicial, verI.PosicionY as Y_Inicial, verF.IdVertice as Id_V_Final, 
	verF.PosicionX as X_Final, verF.PosicionY as Y_Final 
	FROM Rutas AS ru
	inner join Segmentos AS se on se.IdRuta = ru.IdRuta
	inner join Aristas AS ar on ar.IdArista = se.IdArista
	inner join Vias as vi on vi.IdVia = ar.IdVia
	inner join Vertices as verI on verI.IdVertice = ar.IdVerticeInicial
	inner join Vertices as verF on verF.IdVertice = ar.IdVerticeFinal
	inner join Usuarios as us on us.IdUsuario = ru.IdUsuario
	ORDER BY ru.IdRuta

SELECT * FROM Vertices