DROP DATABASE IF EXISTS GestionSalchipapas;

CREATE DATABASE GestionSalchipapas;

USE GestionSalchipapas;

CREATE TABLE Usuario(
    id_usuario varchar(30) UNIQUE PRIMARY KEY,
    Password varchar(30) NOT NULL
);

INSERT INTO Usuario VALUES 
('Joaquin Augusto', 'joaquin_augusto'),
('usuario', 'password');

CREATE TABLE Productos(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion TEXT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL
);

INSERT INTO Productos (Nombre, Descripcion, Precio) VALUES 
('Salchipapa Gratinada', 'Salchipapa personal con salchicha, papa criolla, salsas y queso', 5000),
('Salchipapa Especial', 'Salchipapa para 2 con salchicha americana, papa criolla, pollo, maduro y queso', 20000),
('Salchipapa Callejera', 'Salchipapa para 1 con salchicha, papa criolla, carne y queso', 15000);


CREATE TABLE Mercancia(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Categoria varchar(50) NOT NULL,
    Descripcion TEXT NOT NULL,
    Cantidad INT NOT NULL
);

INSERT INTO Mercancia (Categoria, Descripcion, Cantidad) VALUES
('Plato', 'C1', 40),
('Plato', 'K1', 20),
('Plato', 'J1', 15);


CREATE TABLE Ventas (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario varchar(30) NOT NULL,
    fecha_venta DATE DEFAULT NOW() NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

INSERT INTO Ventas (id_usuario) VALUES
('Joaquin Augusto'),
('Joaquin Augusto');


CREATE TABLE Ventas_Productos (
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    PRIMARY KEY (id_venta, id_producto),
    FOREIGN KEY (id_venta) REFERENCES Ventas(Id),
    FOREIGN KEY (id_producto) REFERENCES Productos(Id)
);

INSERT INTO Ventas_Productos (id_venta, id_producto, cantidad) VALUES
(1, 1, 1),
(1, 2, 1),
(1, 3, 1),
(2, 2, 3),
(2, 1, 2);
