USE [master]
GO
/****** Object:  Database [CustomerDB]    Script Date: 07/09/2021 12:55:14 ******/
CREATE DATABASE [CustomerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerDB', FILENAME = N'C:\Users\sahit\CustomerDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CustomerDB_log', FILENAME = N'C:\Users\sahit\CustomerDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CustomerDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CustomerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CustomerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerDB] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CustomerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CustomerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CustomerDB] SET QUERY_STORE = OFF
GO
USE [CustomerDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VAT] [char](16) NOT NULL,
	[Address] [varchar](50) NULL,
	[AnnualRevenue] [decimal](18, 0) NULL,
	[Name] [varchar](25) NULL,
	[City] [varchar](20) NULL,
	[Phone] [varchar](13) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE CLUSTERED 
(
	[VAT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](255) NOT NULL,
	[FileExt] [varchar](255) NOT NULL,
	[OrderID] [int] NULL,
	[FileBinary] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrders]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[DateOrder] [datetime] NULL,
	[Payment] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrdersRows]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrdersRows](
	[OrderID] [int] NOT NULL,
	[ProductCode] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[TotalRowPrice] [decimal](18, 2) NOT NULL,
	[RowID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrdersTails]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrdersTails](
	[OrderID] [int] NOT NULL,
	[ShippingAddress] [varchar](50) NOT NULL,
	[DiscountAmount] [decimal](18, 2) NOT NULL,
	[ShippingCost] [decimal](18, 2) NOT NULL,
	[TotalCost] [decimal](18, 2) NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[TailsID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_SalesRows] FOREIGN KEY([OrderID])
REFERENCES [dbo].[SalesOrders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_SalesRows]
GO
ALTER TABLE [dbo].[SalesOrders]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[SalesOrdersRows]  WITH CHECK ADD  CONSTRAINT [FK__SalesOrde__Order__4E53A1AA] FOREIGN KEY([OrderID])
REFERENCES [dbo].[SalesOrders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesOrdersRows] CHECK CONSTRAINT [FK__SalesOrde__Order__4E53A1AA]
GO
ALTER TABLE [dbo].[SalesOrdersTails]  WITH CHECK ADD  CONSTRAINT [FK__SalesOrde__Order__634EBE90] FOREIGN KEY([OrderID])
REFERENCES [dbo].[SalesOrders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesOrdersTails] CHECK CONSTRAINT [FK__SalesOrde__Order__634EBE90]
GO
/****** Object:  StoredProcedure [dbo].[GET_ORDERID]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE INSERT_SALESORDERS (@CustomerID INT, @DateOrder DATETIME, @Payment VARCHAR(255)) 
--AS INSERT INTO SalesOrders(CustomerID,DateOrder,Payment) VALUES(@CustomerID,@DateOrder,@Payment)
--BEGIN
--EXEC 
--END

--CREATE PROCEDURE INSERT_SalesOrdersRows (@OrderID INT , @RowID INT, @ProductCode VARCHAR, @Description VARCHAR, @Qty DECIMAL, @UnitPrice DECIMAL, @TotalRowPrice DECIMAL) AS INSERT INTO SalesOrdersRows(OrderID, RowID, ProductCode,Description,Qty,UnitPrice,TotalRowPrice) Values(@OrderID, @RowID, @ProductCode, @Description, @Qty, @UnitPrice, @TotalRowPrice);

--CREATE PROCEDURE INSERT_SalesOrdersTails (@OrderID INT, @ShippingAddress VARCHAR, @ShippingCost DECIMAL, @DeliveryDate DATETIME, @DiscountAmount DECIMAL, @TotalCost DECIMAL) AS Insert into SalesOrdersTails(OrderID,ShippingAddress,ShippingCost,DeliveryDate,DiscountAmount,TotalCost) Values (@OrderID, @ShippingAddress, @ShippingCost, @DeliveryDate, @DiscountAmount, @TotalCost);

CREATE PROCEDURE [dbo].[GET_ORDERID] AS SELECT IDENT_CURRENT('SalesOrders') as OrderID
--EXEC GET_ORDERID;
GO
/****** Object:  StoredProcedure [dbo].[Insert_OrderRows]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_OrderRows](
 @RowID INT,
 @ProductCode VARCHAR,
 @Description VARCHAR, 
 @Qty DECIMAL, 
 @UnitPrice DECIMAL,
 @TotalRowPrice DECIMAL) 
AS
BEGIN
	DECLARE @OrderID AS INT
	EXEC  @OrderID = GET_ORDERID
	EXEC dbo.INSERT_SalesOrdersRows @OrderID = @OrderID, @RowID = @RowID, @ProductCode =@ProductCode , @Description = @Description, @Qty = @Qty, @UnitPrice = @UnitPrice, @TotalRowPrice = @TotalRowPrice
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_SALESORDERS]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_SALESORDERS] (@CustomerID INT, @DateOrder DATETIME, @Payment VARCHAR(255)) 
AS INSERT INTO SalesOrders(CustomerID,DateOrder,Payment) VALUES(@CustomerID,@DateOrder,@Payment)
GO
/****** Object:  StoredProcedure [dbo].[INSERT_SalesOrdersRows]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_SalesOrdersRows] (@OrderID INT , @RowID INT, @ProductCode VARCHAR, @Description VARCHAR, @Qty DECIMAL, @UnitPrice DECIMAL, @TotalRowPrice DECIMAL) AS INSERT INTO SalesOrdersRows(OrderID, RowID, ProductCode,Description,Qty,UnitPrice,TotalRowPrice) Values(@OrderID, @RowID, @ProductCode, @Description, @Qty, @UnitPrice, @TotalRowPrice);
GO
/****** Object:  StoredProcedure [dbo].[INSERT_SalesOrdersTails]    Script Date: 07/09/2021 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_SalesOrdersTails] (@OrderID INT, @ShippingAddress VARCHAR, @ShippingCost DECIMAL, @DeliveryDate DATETIME, @DiscountAmount DECIMAL, @TotalCost DECIMAL) AS Insert into SalesOrdersTails(OrderID,ShippingAddress,ShippingCost,DeliveryDate,DiscountAmount,TotalCost) Values (@OrderID, @ShippingAddress, @ShippingCost, @DeliveryDate, @DiscountAmount, @TotalCost);
GO
USE [master]
GO
ALTER DATABASE [CustomerDB] SET  READ_WRITE 
GO
