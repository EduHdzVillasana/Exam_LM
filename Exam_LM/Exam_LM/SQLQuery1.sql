use tienda;

SELECT * FROM articulo WHERE nombre = 'Vivioptal';

CREATE TABLE usuario(
id_usuario INT IDENTITY(1,1),
email VARCHAR(50) UNIQUE NOT NULL,
password VARCHAR(50) NOT NULL, 
nombre VARCHAR(100) NOT NULL,
CONSTRAINT PK_IU PRIMARY KEY(id_usuario) ,
);

INSERT INTO usuario VALUES ('admin@company.com','powerpass','Admin Godinez');
INSERT INTO usuario VALUES ('dueño@company.com','jefedejefes','Jorge Hernandez');
INSERT INTO usuario VALUES ('gerente@company.com','bestbossever','Michael Scott');
INSERT INTO usuario VALUES ('macondo@company.com','cienaños','Aureliano Buendia');
INSERT INTO usuario VALUES ('comala@company.com','MediaLuna','Pedro Paramo');
SELECT * FROM usuario;

