--Base de datos con las tablas usadas de momento:
CREATE DATABASE db_Patas_Finas;
USE db_Patas_Finas;
-- drop database db_patas_finas;

-- Tabla Persona
CREATE TABLE Persona (
    ID_Persona INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
	Correo VARCHAR(50),
    Contraseña VARCHAR(50),
	DNI VARCHAR(8),
    Telefono VARCHAR(15),
	Estado BIT
);

-- Tabla Categoría
CREATE TABLE Categoria (
    ID_Categoria INT PRIMARY KEY IDENTITY,
    Nombre_Categoria NVARCHAR(50)
);

-- Tabla Productos
CREATE TABLE Productos (
    ID_Producto INT PRIMARY KEY IDENTITY,
    Nombre_Producto NVARCHAR(100),
    Descripcion NVARCHAR(max),
	stock INT,
    Precio DECIMAL(10,2),
	imagen NVARCHAR(max),
    ID_Categoria INT,
    FOREIGN KEY (ID_Categoria) REFERENCES Categoria(ID_Categoria)
);

USE db_Patas_Finas;

insert into categoria values('Comida')
insert into categoria values('Aseo')

Select * from Categoria

insert into Productos values('LOCION CANINA', 'Para el cuidado del pelague y lapiel',70,18.89,'locion canino.jfif',2)
insert into Productos values('CROQUETAS DIETETICAS', 'Comida especial para perros con ciertas dificultades',42,62.19,'Croquetas dietita.jfif',1)
insert into Productos values('SHAMPOO LOCION', 'Shampoo amigable con el pelage de yu mascota , previene caida y mantiene suave el pelaje',80,25.56,'https://mercury.vtexassets.com/arquivos/ids/941723-800-800?v=637139226547130000&width=800&height=800&aspect=true',2)

select * from Productos

insert into Persona values('Clamardo','Tentakulos Ob.','calamar@idat.edu.pe','12345','87654321','987654321',1)
insert into Persona values('Clark','Kent Sm.','kent@gmaiñ.com','123','76543218','876543219',0)

select * from Persona
