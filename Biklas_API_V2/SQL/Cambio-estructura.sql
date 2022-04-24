CREATE PROCEDURE #EsTipoDeColumna
   @tabla nvarchar(max), @columna nvarchar(max), @nuevoTipo nvarchar(max)
AS
   if (select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @tabla and COLUMN_NAME = @columna) = @nuevoTipo
   begin
     return 1; -- el tipo de dato coincide
   end

   return 0;
GO

IF NOT EXISTS (select * from INFORMATION_SCHEMA.KEY_COLUMN_USAGE where CONSTRAINT_NAME = 'PK_Amigos')
BEGIN 
    ALTER TABLE dbo.Amigos with nocheck
    ADD CONSTRAINT PK_Amigos PRIMARY KEY (IdUsuario, IdAmigo)
END

-- Moficamos la escala y la precisión de este campo para prepararlo para almacenar coordenadas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionInicioX' AND NUMERIC_PRECISION = 9 AND NUMERIC_SCALE = 6)
BEGIN 
	ALTER TABLE dbo.Rutas
	ALTER COLUMN PosicionInicioX DECIMAL(9,6) NULL
END

-- Moficamos la escala y la precisión de este campo para prepararlo para almacenar coordenadas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionInicioY' AND NUMERIC_PRECISION = 9 AND NUMERIC_SCALE = 6)
BEGIN 
	ALTER TABLE dbo.Rutas
	ALTER COLUMN PosicionInicioY DECIMAL(9,6) NULL
END

-- Moficamos la escala y la precisión de este campo para prepararlo para almacenar coordenadas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionFinX' AND NUMERIC_PRECISION = 9 AND NUMERIC_SCALE = 6)
BEGIN 
	ALTER TABLE dbo.Rutas
	ALTER COLUMN PosicionFinX DECIMAL(9,6) NULL
END

-- Moficamos la escala y la precisión de este campo para prepararlo para almacenar coordenadas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionFinY' AND NUMERIC_PRECISION = 9 AND NUMERIC_SCALE = 6)
BEGIN 
	ALTER TABLE dbo.Rutas
	ALTER COLUMN PosicionFinY DECIMAL(9,6) NULL
END

-- Moficamos la escala y la precisión de este campo para prepararlo para almacenar coordenadas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Vertices' 
	AND COLUMN_NAME = 'PosicionX' AND NUMERIC_PRECISION = 9 AND NUMERIC_SCALE = 6)
BEGIN 
	ALTER TABLE dbo.Vertices
	ALTER COLUMN PosicionX DECIMAL(9,6) NOT NULL
END

-- Moficamos la escala y la precisión de este campo para prepararlo para almacenar coordenadas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Vertices' 
	AND COLUMN_NAME = 'PosicionY' AND NUMERIC_PRECISION = 9 AND NUMERIC_SCALE = 6)
BEGIN 
	ALTER TABLE dbo.Vertices
	ALTER COLUMN PosicionY DECIMAL(9,6) NOT NULL
END

-- No almacenaremos posición de inicio y fin en tabla de rutas, en lugar de eso, utilizamos
-- referencia a vértice de inicio y vértice de fin
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionInicioX')
BEGIN 
	ALTER TABLE dbo.Rutas
	DROP COLUMN PosicionInicioX
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionInicioY')
BEGIN 
	ALTER TABLE dbo.Rutas
	DROP COLUMN PosicionInicioY
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionFinX')
BEGIN 
	ALTER TABLE dbo.Rutas
	DROP COLUMN PosicionFinX
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'PosicionFinY')
BEGIN 
	ALTER TABLE dbo.Rutas
	DROP COLUMN PosicionFinY
END

-- Agregamos referencia a vértice inicial
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'IdVerticeInicial')
BEGIN 
	ALTER TABLE dbo.Rutas
	ADD IdVerticeInicial INT NOT NULL FOREIGN KEY REFERENCES Vertices(IdVertice)
END

-- Agregamos referencia a vértice final
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'IdVerticeFinal')
BEGIN 
	ALTER TABLE dbo.Rutas
	ADD IdVerticeFinal INT NOT NULL FOREIGN KEY REFERENCES Vertices(IdVertice)
END

-- Agregamos referencia a usuario creador de ruta
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'IdUsuario')
BEGIN 
	ALTER TABLE dbo.Rutas
	ADD IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios(IdUsuario)
END

-- Aumentamos el tamaño del campo para poder almacenar la contraseña encriptada de 128 bytes
IF NOT EXISTS (SELECT COL_LENGTH('Usuarios','Contraseña')
	HAVING COL_LENGTH('Usuarios','Contraseña') = 128)
	BEGIN
	ALTER TABLE dbo.Usuarios
	ALTER COLUMN Contraseña VARCHAR(128)
	END

-- Agregamos fecha de creación de ruta
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Rutas' 
	AND COLUMN_NAME = 'FechaCreacion')
BEGIN 
	ALTER TABLE dbo.Rutas
	ADD FechaCreacion DATE NOT NULL 
END

---------------------------------------------------------------------
-- Limpiamos procedimientos almacenados. Insertar scripts nuevos arriba de esta línea
DROP PROCEDURE #EsTipoDeColumna