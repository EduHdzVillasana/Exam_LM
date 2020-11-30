CREATE DATABASE [tienda]

GO

/****** Object:  Table [dbo].[usuario]    Script Date: 29/11/2020 07:04:45 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_IU] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


GO

/****** Object:  Table [dbo].[articulo]    Script Date: 29/11/2020 07:06:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[articulo](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[precio] [float] NOT NULL,
	[iva] [float] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_IA] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[articulo] ADD  DEFAULT ('0') FOR [cantidad]
GO







INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Chocolate - Feathers',2738.93,12.26, 144);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Pasta - Angel Hair',4391.73,959.51, 503);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Soup Campbells - Tomato Bisque',2991.35,587.59, 604);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Wine - Valpolicella Masi',2625.2,770.1, 575);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Mousse - Banana Chocolate',3701.62,893.46, 248);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Yeast Dry - Fleischman',923.18,524.08, 818);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Nantucket - Kiwi Berry Cktl.',5579.47,1012.33, 527);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Wine - Fontanafredda Barolo',2684.64,327.16, 682);
INSERT INTO articulo (nombre, precio, iva, cantidad) VALUES ('Lotus Rootlets - Canned',1996.46,324.72, 636);


INSERT INTO usuario (email, password, nombre) VALUES ('admin@company.com','powerpass','Admin Godinez');
INSERT INTO usuario (email, password, nombre) VALUES ('dueño@company.com','jefedejefes','Jorge Hernandez');
INSERT INTO usuario (email, password, nombre) VALUES ('gerente@company.com','bestbossever','Michael Scott');
INSERT INTO usuario (email, password, nombre) VALUES ('coronel@company.com','macondo','Aureliano Buendia');
INSERT INTO usuario (email, password, nombre) VALUES ('comala@company.com','MediaLuna','Pedro Paramo');