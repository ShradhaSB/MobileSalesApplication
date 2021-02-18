--Exec MonthlySalesReport '2021-01-16 16:43:34.857', '2021-04-16 16:43:34.857'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shradha Boralkar>
-- Create date: <16-02-2021>
-- Description:	<Stored Procedure to view monthly sales report (should accept from and to date) >
-- =============================================
CREATE OR ALTER PROCEDURE MonthlySalesReport 
	@FromDate DATETIME,
	@ToDate DATETIME
AS
BEGIN

DELETE [dbo].[MonthlyMobileDetails]

INSERT INTO [dbo].[MonthlyMobileDetails] (ProfitLoss,ProfitLossPercent,SalesMonth)
(SELECT SUM(MSD.SalePrice-MD.PurchASePrice) AS ProfitLoss,
CAST(ROUND(SUM(MSD.SalePrice-MD.PurchASePrice)*100/SUM(MD.PurchASePrice),2) AS NUMERIC(36,2)) AS ProfitLossPercent ,
MONTH(MSD.SalesDate) AS SalesMonth
FROM MobileDetails MD,MobileSalesDetails MSD 
WHERE MD.Id=MSD.MobileId and MSD.SalesDate >= @FromDate and MSD.SalesDate < @ToDate
GROUP BY MONTH(MSD.SalesDate));

SELECT * FROM [dbo].[MonthlyMobileDetails]

END
GO



