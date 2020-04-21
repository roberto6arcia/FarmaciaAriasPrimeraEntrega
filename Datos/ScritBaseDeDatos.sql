CREATE DATABASE [FarmaciaArias];

USE [FarmaciaArias]

CREATE TABLE [dbo].[Producto](
[CodigoP] [nvarchar](12) NOT NULL PRIMARY KEY,
[NombreP] [nvarchar](25) NULL,
[LaboratorioP] [nvarchar](25) NULL,
[Fechadevencimiento] [nvarchar](25) NULL,
[CantidadP] [int] NULL,
)

GO

COMMIT