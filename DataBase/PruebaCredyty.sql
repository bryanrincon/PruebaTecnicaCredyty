USE [master]
GO
/****** Object:  Database [Credyty]    Script Date: 1/07/2022 12:41:09 a. m. ******/
CREATE DATABASE [Credyty]
Go
USE [Credyty]
GO
/****** Object:  Table [dbo].[Registro]    Script Date: 1/07/2022 12:41:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoVehiculo] [int] NOT NULL,
	[Placa] [varchar](10) NOT NULL,
	[Ingreso] [datetime] NOT NULL,
	[Salida] [datetime] NULL,
	[Factura] [varchar](100) NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[ValorDescuento] [decimal](18, 2) NULL,
	[TotalPagado] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoVehiculo]    Script Date: 1/07/2022 12:41:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVehiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Tarifa] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Registro] ON 

INSERT [dbo].[Registro] ([Id], [IdTipoVehiculo], [Placa], [Ingreso], [Salida], [Factura], [SubTotal], [ValorDescuento], [TotalPagado]) VALUES (1, 2, N'string', CAST(N'2022-07-01T04:56:02.717' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Registro] ([Id], [IdTipoVehiculo], [Placa], [Ingreso], [Salida], [Factura], [SubTotal], [ValorDescuento], [TotalPagado]) VALUES (2, 2, N'FRG77G', CAST(N'2022-07-01T05:08:03.223' AS DateTime), CAST(N'2022-07-02T05:17:24.247' AS DateTime), N'string', CAST(72000.00 AS Decimal(18, 2)), CAST(21600.00 AS Decimal(18, 2)), CAST(50400.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Registro] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoVehiculo] ON 

INSERT [dbo].[TipoVehiculo] ([Id], [Tipo], [Tarifa]) VALUES (1, N'Carro', CAST(110.00 AS Decimal(18, 2)))
INSERT [dbo].[TipoVehiculo] ([Id], [Tipo], [Tarifa]) VALUES (2, N'Moto', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[TipoVehiculo] ([Id], [Tipo], [Tarifa]) VALUES (3, N'Bicicleta', CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[TipoVehiculo] OFF
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD FOREIGN KEY([IdTipoVehiculo])
REFERENCES [dbo].[TipoVehiculo] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Credyty] SET  READ_WRITE 
GO
