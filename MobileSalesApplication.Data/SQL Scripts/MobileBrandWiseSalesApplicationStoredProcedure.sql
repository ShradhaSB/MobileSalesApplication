--exec MonthlyBrandWiseSalesReport '2021-01-16 16:43:34.857', '2021-04-16 16:43:34.857'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shradha Boralkar>
-- Create date: <16-02-2021>
-- Description:	<Monthly mobile brand-wise sales report (should accept from-to date)>
-- =============================================
CREATE OR ALTER PROCEDURE MonthlyBrandWiseSalesReport 
	@FromDate DATETIME,
	@ToDate DATETIME
AS
BEGIN

DELETE [dbo].[MonthlyBrandWiseMobileDetails]

INSERT INTO [dbo].[MonthlyBrandWiseMobileDetails] (MobileBrand,ProfitLoss,ProfitLossPercent,SalesMonth)
(SELECT MD.MobileBrand,SUM(MSD.SalePrice-MD.PurchASePrice) AS ProfitLoss,
CAST(ROUND(SUM(MSD.SalePrice-MD.PurchASePrice)*100/SUM(MD.PurchASePrice),2) AS NUMERIC(36,2)) AS ProfitLossPercent ,
MONTH(MSD.SalesDate) AS SalesMonth
FROM MobileDetails MD,MobileSalesDetails MSD 
WHERE MD.Id=MSD.MobileId and MSD.SalesDate>=@FromDate and MSD.SalesDate<@ToDate
GROUP BY MONTH(MSD.SalesDate),MD.MobileBrand
);

SELECT * FROM [dbo].[MonthlyBrandWiseMobileDetails]

END
GO