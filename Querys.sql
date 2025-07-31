CREATE DATABASE CRUD_API_REST;
USE CRUD_API_REST;

CREATE TABLE Productos(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre VARCHAR(100),
    Precio DECIMAL(12,2),
    Descripcion VARCHAR(255)
)

CREATE PROCEDURE InsertarProducto
    @Nombre VARCHAR(100),
    @Precio DECIMAL(12,2),
    @Descripcion VARCHAR(255)
    AS BEGIN

    INSERT INTO Productos VALUES(@Nombre, @Precio, @Descripcion)
END

CREATE PROCEDURE EliminarProducto
@Id INT
AS BEGIN
DELETE FROM Productos WHERE Id=@Id
END

CREATE PROCEDURE ObtenerProductos
AS BEGIN 
SELECT * FROM Productos 
END

CREATE PROCEDURE ActualizarProducto
@Id INT,
@Nombre VARCHAR(100),
@Precio DECIMAL(12,2),
@Descripcion VARCHAR(255)
AS BEGIN
    UPDATE Productos SET Nombre=@Nombre, Precio=@Precio, Descripcion=@Descripcion WHERE Id=@Id
END

CREATE PROCEDURE BuscarPorPrecio
@Precio DECIMAL(18,2)
AS BEGIN
SELECT * FROM Productos WHERE Precio >= @Precio;
END

