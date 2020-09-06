CREATE DATABASE IF NOT EXISTS biblioteca;

USE biblioteca;

CREATE TABLE IF NOT EXISTS libros(
	id_libro INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(45) NOT NULL,
    anio INT NOT NULL,
    categoria VARCHAR(45) NOT NULL,
    en_biblioteca BOOLEAN NOT NULL,
    en_reparacion BOOLEAN NOT NULL,
    en_prestamo BOOLEAN NOT NULL,
    PRIMARY KEY(id_libro),
    id_autor INT NOT NULL
);

CREATE TABLE IF NOT EXISTS autores(
	id_autor INT NOT NULL AUTO_INCREMENT,
    fecha_nacimiento INT NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    PRIMARY KEY (id_autor)
);

ALTER TABLE libros ADD CONSTRAINT fk_autor FOREIGN KEY(id_autor) REFERENCES autores(id_autor);

CREATE TABLE IF NOT EXISTS lectores(
	id_lector INT NOT NULL AUTO_INCREMENT,
    multado BOOLEAN NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    PRIMARY KEY (id_lector)
);

CREATE TABLE IF NOT EXISTS prestamos(
	id_prestamo INT NOT NULL AUTO_INCREMENT, 
    fecha INT NOT NULL,
    id_lector INT NOT NULL,
    id_libro INT NOT NULL,
    PRIMARY KEY(id_prestamo),
    
	CONSTRAINT fk_lector FOREIGN KEY(id_lector) REFERENCES lectores(id_lector),
    CONSTRAINT fk_libro FOREIGN KEY(id_libro) REFERENCES libros(id_libro)
);