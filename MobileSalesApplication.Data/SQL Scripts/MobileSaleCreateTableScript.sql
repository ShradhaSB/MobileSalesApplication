--Mobile MonthlyMobileDetails
---------------------------------------------------------------------------------------------------------------------------------------------
USE [MobileSales]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthlyMobileDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfitLoss] [int] NOT NULL,
	[ProfitLossPercent] [decimal](9, 2) NOT NULL,
	[SalesMonth] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--------------------------------------------------------------------------------------------------------------------------------------------
--MonthlyBrandWiseMobileDetails
--------------------------------------------------------------------------------------------------------------------------------------------
USE [MobileSales]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthlyBrandWiseMobileDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MobileBrand] [varchar](255) NOT NULL,
	[ProfitLoss] [int] NOT NULL,
	[ProfitLossPercent] [decimal](9, 2) NOT NULL,
	[SalesMonth] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

---------------------------------------------------------------------------------------------------------------------------------------------
--MobileSalesDetails
----------------------------------------------------------------------------------------------------------------------------------------------
USE [MobileSales]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobileSalesDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MobileId] [int] NOT NULL,
	[SalePrice] [decimal](9, 2) NOT NULL,
	[SalesDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MobileSalesDetails]  WITH CHECK ADD  CONSTRAINT [FK_MobileDetailsMobileSalesDetails] FOREIGN KEY([MobileId])
REFERENCES [dbo].[MobileDetails] ([Id])
GO

ALTER TABLE [dbo].[MobileSalesDetails] CHECK CONSTRAINT [FK_MobileDetailsMobileSalesDetails]
GO

--------------------------------------------------------------------------------------------------------------------------------------------
--MobileDetails
--------------------------------------------------------------------------------------------------------------------------------------------
USE [MobileSales]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobileDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MobileBrand] [varchar](255) NOT NULL,
	[MobileName] [varchar](255) NOT NULL,
	[PurchasePrice] [decimal](9, 2) NOT NULL,
	[MRPrice] [decimal](9, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


