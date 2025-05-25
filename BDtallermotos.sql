CREATE DATABASE TallerMotos;
USE TallerMotos;

-- Tabla Cargos
CREATE TABLE Cargos (
    idCargo INT PRIMARY KEY AUTO_INCREMENT,
    cargo VARCHAR(50)
);

-- Tabla Empleado
CREATE TABLE Empleado (
    idEmpleado INT PRIMARY KEY AUTO_INCREMENT,
    nombres VARCHAR(100),
    apellidos VARCHAR(100),
    edad INT,
    DUI VARCHAR(15),
    telefono VARCHAR(20),
    idCargo INT,
    FOREIGN KEY (idCargo) REFERENCES Cargos(idCargo)
);

-- Tabla Usuario
CREATE TABLE Usuario (
    idUsuario INT PRIMARY KEY AUTO_INCREMENT,
    usuario VARCHAR(50),
    clave VARCHAR(50),
    idEmpleado INT,
    FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado)
);

-- Tabla Servicio
CREATE TABLE Servicio (
    idServicio INT PRIMARY KEY AUTO_INCREMENT,
    servicio VARCHAR(100),
    precio DECIMAL(10,2)
);

-- Tabla Clientes
CREATE TABLE Clientes (
    idCliente INT PRIMARY KEY AUTO_INCREMENT,
    nombreCompleto VARCHAR(100),
    telefono VARCHAR(20),
    correo VARCHAR(100),
    direccion VARCHAR(255)
    -- Eliminado idMotocicleta (mala normalización: una motocicleta debe pertenecer al cliente, no al revés)
);

-- Tabla Motocicleta
CREATE TABLE Motocicleta (
    idMotocicleta INT PRIMARY KEY AUTO_INCREMENT,
    marca VARCHAR(50),
    modelo VARCHAR(50),
    anio INT,
    idCliente INT,
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente)
);

-- Tabla Servicio_cliente (relación N:M)
CREATE TABLE Servicio_cliente (
    idServicio_cli INT PRIMARY KEY AUTO_INCREMENT,
    idServicio INT,
    idCliente INT,
    FOREIGN KEY (idServicio) REFERENCES Servicio(idServicio),
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente)
);

-- Tabla Factura
CREATE TABLE Factura (
    idFactura INT PRIMARY KEY AUTO_INCREMENT,
    idCliente INT,
    fecha DATE,
    total DECIMAL(10,2),
    idEmpleado INT,
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado)
);

-- Tabla Detalle_Factura
CREATE TABLE Detalle_Factura (
    idDetalle_fac INT PRIMARY KEY AUTO_INCREMENT,
    idFactura INT,
    idEmpleado INT,
    idServicio_cli INT,
    FOREIGN KEY (idFactura) REFERENCES Factura(idFactura),
    FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado),
    FOREIGN KEY (idServicio_cli) REFERENCES Servicio_cliente(idServicio_cli)
);
