DROP DATABASE IF EXISTS 5to_Biblioteca; 
CREATE DATABASE 5to_Biblioteca;
USE 5to_Biblioteca;

CREATE TABLE Usuario (
    IdUsuario INT AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario)
);

CREATE TABLE Autor (
    Nombre VARCHAR(45) NOT NULL,
    Apellido VARCHAR(45) NOT NULL,
    IdAutor INT AUTO_INCREMENT,
    CONSTRAINT PK_Autor PRIMARY KEY (IdAutor)
);

CREATE TABLE Libro (
    ISBN BIGINT NOT NULL,
    Titulo VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Libro PRIMARY KEY (ISBN)
);

CREATE TABLE AutorLibro (
    IdAutor INT NOT NULL,
    ISBN BIGINT NOT NULL,
    CONSTRAINT PK_AutorLibro_Autor_Libro PRIMARY KEY (IdAutor, ISBN),
    CONSTRAINT FK_AutorLibro_Autor FOREIGN KEY (IdAutor)
        REFERENCES Autor (IdAutor),
    CONSTRAINT FK_AutorLibro_Libro FOREIGN KEY (ISBN) 
        REFERENCES Libro(ISBN)
);

CREATE TABLE Prestamo (
    IdPrestamo INT AUTO_INCREMENT,
    IdUsuario INT NOT NULL,
    ISBN BIGINT NOT NULL,
    FechaPrestamo DATE NOT NULL,
    CONSTRAINT PK_Prestamo PRIMARY KEY (IdPrestamo),
    CONSTRAINT FK_Prestamo_Usuario FOREIGN KEY (IdUsuario) 
        REFERENCES Usuario(IdUsuario),
    CONSTRAINT FK_Prestamo_Libro FOREIGN KEY (ISBN) 
        REFERENCES Libro(ISBN)
);

SELECT 'Creando SPs' Estado;
DELIMITER $$
CREATE PROCEDURE AltaUsuario (IN unNombre VARCHAR(50),
                              IN unEmail VARCHAR(100),
                              OUT unIdUsuario INT)
BEGIN
    INSERT INTO Usuario (Nombre, Email)
        VALUES  (unNombre, unEmail);
    SET unIdUsuario = LAST_INSERT_ID();
END 
$$

DELIMITER $$
CREATE PROCEDURE AltaAutor (IN unNombre VARCHAR(45),
                            IN unApellido VARCHAR(45),
                            OUT unIdAutor INT)
BEGIN
    INSERT INTO Autor (Nombre, Apellido)
        VALUES (unNombre, unApellido);
    SET unIdAutor = LAST_INSERT_ID();
END
$$

DELIMITER $$
CREATE PROCEDURE AltaLibro (IN unISBN BIGINT,
                            IN unTitulo VARCHAR(100))
BEGIN
    INSERT INTO Libro (ISBN , Titulo)
        VALUES (unISBN ,unTitulo);
END
$$

DELIMITER $$
CREATE PROCEDURE AltaAutorLibro (IN unIdAutor INT,
                                 IN unISBN BIGINT)
BEGIN
    INSERT INTO AutorLibro (IdAutor, ISBN)
        VALUES  (unIdAutor, unISBN);
END
$$

DELIMITER $$
CREATE PROCEDURE AltaPrestamo (IN unIdUsuario INT,
                               IN unISBN BIGINT,
                               OUT unIdPrestamo INT)
BEGIN
    INSERT INTO Prestamo (IdUsuario, ISBN, FechaPrestamo)
        VALUES (unIdUsuario, unISBN, NOW());
    SET unIdPrestamo = LAST_INSERT_ID();
END
$$

SELECT 'Creando TRIGGERs' Estado;
DELIMITER $$
CREATE TRIGGER brfPrestamo BEFORE INSERT ON Prestamo FOR EACH ROW
BEGIN
    IF EXISTS (SELECT 1
               FROM Prestamo
               WHERE ISBN = NEW.ISBN) THEN
        SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Error, el libro no esta disponible';
	END IF;
END
$$

CALL AltaUsuario('Anonimo', 'anonimo12@gnail.com', @usuario1);
CALL AltaAutor('Gabriel', 'Garcia Márquez', @autor1);
CALL AltaLibro(9788437, 'Cien años de soledad');
CALL AltaAutorLibro(@autor1, 9788437);
CALL AltaPrestamo (@usuario1, 9788437, @prestamo1);
-- DROP PROCEDURE IF EXISTS AltaLibro;
-- DROP TABLE IF EXISTS AutorLibro;
