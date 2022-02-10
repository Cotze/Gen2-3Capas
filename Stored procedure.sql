--Camiones
--listar
CREATE PROC Camiones_Listar
@Disponibilidad bit = null
AS
BEGIN
	SELECT * FROM Camiones
	WHERE Disponibilidad = 
	ISNULL(@Disponibilidad, Disponibilidad)
END
GO
--insertar
CREATE PROC Camiones_Insertar
@Matricula varchar(8),
@TipoCamion varchar(25),
@Modelo int,
@Marca varchar(25),
@Capacidad int,
@Kilometraje float,
@UrlFoto varchar(MAX)
AS
BEGIN
	INSERT INTO Camiones
	(Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, Disponibilidad, UrlFoto)
	VALUES
	(@Matricula, @TipoCamion, @Modelo, @Marca, @Capacidad, @Kilometraje, 1, @UrlFoto)
END
GO
--actualizar
CREATE PROC Camiones_Actualizar
@id int,
@Matricula varchar(8) = null,
@TipoCamion varchar(25) = null,
@Modelo int = null,
@Marca varchar(25) = null,
@Capacidad int = null,
@Kilometraje float = null,
@Disponibilidad bit = null,
@UrlFoto varchar(MAX) = null
AS
BEGIN
	UPDATE Camiones
	SET Matricula = ISNULL(@Matricula, Matricula), TipoCamion = ISNULL(@TipoCamion, TipoCamion), Modelo = ISNULL(@Modelo, Modelo), Marca = ISNULL(@Marca, Marca), Capacidad = ISNULL(@Capacidad, Capacidad), Kilometraje = ISNULL(@Kilometraje, Kilometraje), Disponibilidad = ISNULL(@Disponibilidad, Disponibilidad), UrlFoto = ISNULL(@UrlFoto, UrlFoto)
	WHERE id = @id
END
GO
--eliminar
CREATE PROC Camiones_Eliminar
@id int
AS
BEGIN
	DELETE FROM Camiones
	WHERE id = @id
END
GO
--getbyid
CREATE PROC Camiones_GetByID
@id int
AS
BEGIN
	SELECT * FROM Camiones
	WHERE id = @id
END
GO

--Choferes
--listar
CREATE PROC Choferes_Listar
@Disponibilidad bit = null
AS
BEGIN
	SELECT * FROM Choferes
	WHERE Disponibilidad = 
	ISNULL(@Disponibilidad, Disponibilidad)
END
GO
--insertar
CREATE PROC Choferes_Insertar
@Nombre varchar(50),
@ApPaterno varchar(50),
@ApMaterno varchar(50),
@Telefono varchar(50),
@FechaNacimiento smalldatetime,
@Licencia varchar(7),
@UrlFoto varchar(MAX)
AS
BEGIN
	INSERT INTO Choferes
	(Nombre, ApPaterno, ApMaterno, Telefono, FechaNacimiento, Licencia, Disponibilidad, UrlFoto)
	VALUES
	(@Nombre, @ApPaterno, @ApMaterno, @Telefono, @FechaNacimiento, @Licencia, 1, @UrlFoto)
END
GO
--actualiza
CREATE PROC Choferes_Actualizar
@id int,
@Nombre varchar(50) = NULL,
@ApPaterno varchar(50) = NULL,
@ApMaterno varchar(50) = NULL,
@Telefono varchar(50) = NULL,
@FechaNacimiento smalldatetime = NULL, --yyy'-'mm'-'dd
@Licencia varchar(7) = NULL,
@UrlFoto varchar(MAX) = NULL
AS
BEGIN
	UPDATE Choferes
	SET Nombre = ISNULL(@Nombre, Nombre), ApPaterno = ISNULL(@ApPaterno, ApPaterno), ApMaterno = ISNULL(@ApMaterno, ApMaterno), Telefono = ISNULL(@Telefono, Telefono), FechaNacimiento = ISNULL(@FechaNacimiento, FechaNacimiento), Licencia = ISNULL(@Licencia, Licencia), UrlFoto = ISNULL(@UrlFoto, UrlFoto)
	WHERE id = @id
END
GO
--eliminar
CREATE PROC Choferes_Eiminar
@id int
AS 
BEGIN
	DELETE FROM Choferes
	WHERE id = @id
END
GO
--getbyid
CREATE PROC Choferes_GetByID
@id int
AS
BEGIN
	SELECT * FROM Choferes
	WHERE id = @id
END
GO

--direccion
--listar
CREATE PROC Direcciones_Listar
AS
BEGIN
	SELECT * FROM Direcciones
END
GO
--insertar
CREATE PROC Direcciones_Insertar
@Calle varchar(25),
@Numero varchar(20),
@Colonia varchar(255),
@Ciudad varchar(255),
@Estado varchar(255),
@CP varchar(5)
AS
BEGIN 
	INSERT INTO Direcciones
	(Calle, Numero, Colonia, Ciudad, Estado, CP)
	VALUES
	(@Calle, @Numero, @Colonia, @Ciudad, @Estado, @CP)

	SELECT id = SCOPE_IDENTITY() --Arroga el id del elemento que acabamos de insertar
END
GO
--actualizar
CREATE PROC Direcciones_Actualizar
@id int,
@Calle varchar(25) = null,
@Numero varchar(20) = null,
@Colonia varchar(255) = null,
@Ciudad varchar(255) = null,
@Estado varchar(255) = null,
@CP varchar(5) = null
AS
BEGIN
	UPDATE Direcciones
	SET Calle = ISNULL(@Calle, Calle), Numero = ISNULL(@Numero, Numero), Colonia = ISNULL(@Colonia, Colonia), Ciudad = ISNULL(@Ciudad, Ciudad), Estado = ISNULL(@Estado, Estado), CP = ISNULL(@CP, CP)
	WHERE id = @id
END
GO
--eliminar
CREATE PROC Direcciones_Eliminar
@id int
AS
BEGIN
	DELETE FROM Direcciones
	WHERE id = @id
END
GO
--getbyid
CREATE PROC Direcciones_GetByID
@id int
AS
BEGIN
	SELECT * FROM Direcciones
	WHERE id = @id
END
GO

--rutas
--listar
CREATE PROC Rutas_Listar
AS
BEGIN
	SELECT * FROM Rutas
END
GO
--insertar
CREATE PROC Rutas_Insertar
@Camion_id int,
@DireccionOrigen_id int,
@DireccionDestino_id int,
@Distancia float,
@FHSalida datetime,
@FHLlegadaEstimada datetime,
@FHLlegadaReal datetime,
@Chofer_id int
AS
BEGIN
	INSERT INTO Rutas
	(Camion_id, DireccionOrigen_id, DireccionDestino_id, Distancia, FHSalida, FHLlegadaEstimada, FHLlegadaReal, ATiempo, Chofer_id)
	VALUES
	(@Camion_id, @DireccionOrigen_id, @DireccionDestino_id, @Distancia, @FHSalida, @FHLlegadaEstimada, @FHSalida, 1, @Chofer_id)

	SELECT id = SCOPE_IDENTITY()
END
GO
--actualizar
CREATE PROC Rutas_Actualizar
@id int,
@Camion_id int = null,
@DireccionOrigen_id int = null,
@DireccionDestino_id int = null,
@Distancia float = null,
@FHSalida datetime = null,
@FHLlegadaEstimada datetime = null,
@FHLlegadaReal datetime = null,
@ATiempo bit = null,
@Chofer_id int = null
AS
BEGIN
	UPDATE Rutas
	SET Camion_id = ISNULL(@Camion_id, Camion_id), Chofer_id = ISNULL(@Chofer_id, Chofer_id), DireccionOrigen_id = ISNULL(@DireccionOrigen_id, DireccionOrigen_id), DireccionDestino_id = ISNULL(@DireccionDestino_id, DireccionDestino_id), Distancia = ISNULL(@Distancia, Distancia), FHSalida = ISNULL(@FHSalida, FHSalida), FHLlegadaReal = ISNULL(@FHLlegadaReal, FHLlegadaReal), ATiempo = ISNULL(@ATiempo, ATiempo)
	WHERE id = @id
END
GO
--eliminar
CREATE PROC Rutas_Eliminar
@id int
AS
BEGIN
	DELETE FROM Rutas
	WHERE id = @id
END
GO
--getbyid
CREATE PROC Rutas_GetByID
@id int
AS
BEGIN
	SELECT * FROM Rutas
	WHERE id = @id
END
GO

--cargamento
--listar
CREATE PROC Cargamento_Listar
@Estatus int = null
AS
BEGIN
	SELECT * FROM Cargamento
	WHERE Estatus = ISNULL(@Estatus, Estatus)
	ORDER BY Peso ASC
END
GO
--insertar
CREATE PROC Cargamento_Insertar
@Ruta_id int,
@Descripcion varchar(MAX),
@Peso float,
@Estatus int
AS
BEGIN
	INSERT INTO Cargamento
	(Ruta_id, Descripcion, Peso, Estatus)
	VALUES
	(@Ruta_id, @Descripcion, @Peso, @Estatus)
END
GO
--actualizar
CREATE PROC Cargamento_Actualizar
@id int,
@Ruta_id int,
@Descripcion varchar(MAX),
@Peso float,
@Estatus int
AS
BEGIN
	UPDATE Cargamento
	SET Ruta_id = ISNULL(@Ruta_id, Ruta_id), Descripcion = ISNULL(@Descripcion, Descripcion), Peso = ISNULL(@Peso, Peso), Estatus = ISNULL(@Estatus, Estatus)
	WHERE id = @id
END
GO
--eliminar
CREATE PROC Cargamento_Eliminar
@id int
AS
BEGIN
	DELETE FROM Cargamento
	WHERE id = @id
END
GO
--getbyid
CREATE PROC Cargamento_GetByID
@id int
AS
BEGIN
	SELECT * FROM Cargamento
	WHERE id = @id
END


--Query del procedimiento almacenado para el ejemplo
GO
CREATE PROC obtenerRutas
@Estatus int
AS
BEGIN
	IF (@Estatus = 0) -- RUTAS EN PROCESO
	BEGIN
		SELECT R.id, R.FHSalida, FHLlegada = R.FHLlegadaEstimada, R.Distancia, R.ATiempo, CH.Nombre, CH.Licencia, FotChofer = CH.UrlFoto, C.Matricula, FotoCamion = C.UrlFoto, 
		Origen = DD.Calle + ' ' + DO.Numero + ' ' + DO.Colonia + ' ' + DO.CP, 
		Destino = DD.Calle + ' ' + DD.Numero + ' ' + DD.Colonia + ' ' + DD.CP 
		FROM Rutas R INNER JOIN Camiones C
		ON R.Camion_id = C.id INNER JOIN Choferes CH
		ON R.Chofer_id = CH.id INNER JOIN Direcciones DO
		ON R.DireccionOrigen_id = DO.id INNER JOIN Direcciones DD
		ON R.DireccionDestino_id = DD.id
		WHERE R.FHSalida = R.FHLlegadaReal
	END
	ELSE -- RUTAS TERMINADAS
	BEGIN
		SELECT R.id, R.FHSalida, FHLlegada = R.FHLlegadaEstimada, R.Distancia, R.ATiempo, CH.Nombre, CH.Licencia, FotChofer = CH.UrlFoto, C.Matricula, FotoCamion = C.UrlFoto, 
		Origen = DD.Calle + ' ' + DO.Numero + ' ' + DO.Colonia + ' ' + DO.CP, 
		Destino = DD.Calle + ' ' + DD.Numero + ' ' + DD.Colonia + ' ' + DD.CP 
		FROM Rutas R INNER JOIN Camiones C
		ON R.Camion_id = C.id INNER JOIN Choferes CH
		ON R.Chofer_id = CH.id INNER JOIN Direcciones DO
		ON R.DireccionOrigen_id = DO.id INNER JOIN Direcciones DD
		ON R.DireccionDestino_id = DD.id
		WHERE R.FHSalida < R.FHLlegadaReal
	END
END
GO

CREATE PROC buscaDireccion
@Prefijo varchar(MAX)
AS
BEGIN
	SELECT direccioncompleta = CONVERT(varchar(MAX), id) + '.' + Calle + ' ' + Numero + ' ' + Colonia + ' ' + Ciudad + ' ' + Estado + ' ' + CP 
	FROM Direcciones 
	WHERE Calle LIKE '%' + @Prefijo + '%' OR 
	Numero LIKE '%' + @Prefijo + '%' OR
	Colonia LIKE '%' + @Prefijo + '%' OR
	Ciudad LIKE '%' + @Prefijo + '%' OR
	Estado LIKE '%' + @Prefijo + '%' OR
	CP LIKE '%' + @Prefijo + '%'
END
GO

--Creacion de BD mediantwe el diseñador
--relacion entre dos tablas
--creacion de store Procedure
--creacion de triggers

--Temario Triggers
--Elimina espacios
CREATE TRIGGER eliminaEspacios
ON Choferes 
INSTEAD OF INSERT  
AS
BEGIN
	DECLARE @NombreNuevo varchar(50)
	DECLARE @ApPatNuevo varchar(50)
	DECLARE @ApMatNuevo varchar(50)
	SELECT @NombreNuevo = TRIM(Nombre) FROM inserted
	SELECT @ApPatNuevo = TRIM(ApPaterno) FROM inserted
	SELECT @ApMatNuevo = TRIM(ApMaterno) FROM inserted

	INSERT INTO Choferes(Nombre, ApPaterno, ApMaterno, Telefono, FechaNacimiento, Licencia, UrlFoto, Disponibilidad) 
	VALUES(@NombreNuevo, @ApPatNuevo, @ApMatNuevo, 
	(SELECT Telefono FROM inserted), 
	(SELECT FechaNacimiento FROM inserted), 
	(SELECT Licencia FROM inserted), 
	(SELECT UrlFoto FROM inserted), 
	1)
END
GO

--crear un trigge que inserte en la tabla log despues de actualizar un usuario
CREATE TRIGGER tablaLog
ON Usuario
AFTER UPDATE 
AS
BEGIN 
	INSERT INTO Log....
END
GO

--Crear un trigger que haga algo despues de insertar en la tabla LOg
CREATE TRIGGER tablaLog
ON Log
AFTER UPDATE 
AS
BEGIN 
	INSERT INTO Log....
END