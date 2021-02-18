-- exec MonthlySaleComparisonSalesReport '2021-01-15 10:00:00','2021-02-16 10:00:00'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Shradha Boralkar>
-- Create date: <16-02-2021>
-- Description:	<Profit/loss report in comparison with the previous timeline and consider the discounts given on each purchase>
-- =============================================
CREATE OR ALTER PROCEDURE MonthlySaleComparisonSalesReport
	@FromDate DATETIME,
	@ToDate DATETIME
AS
BEGIN

DELETE [dbo].[MobileSaleComparisonDetails]

INSERT INTO [dbo].[MobileSaleComparisonDetails] (MobileID,MobileBrand,MobileName,CurrentSaleCount,PrevSaleCount,
                                                 CurrentProfitLoss,PrevProfitLoss,CurrentProfitLossPercent,PrevProfitLossPercent,
												 CurrentDiscountPercent,PrevDiscountPercent)
(SELECT 
curr.MobileID,
curr.MobileBrand,
curr.MobileName,
curr.CurrentSaleCount,
prev.PrevSaleCount,
curr.CurrentProfitLoss,
prev.PrevProfitLoss,
curr.CurrentProfitLossPercent,
prev.PrevProfitLossPercent,
curr.CurrentDiscountPercent,
prev.PrevDiscountPercent
from
(SELECT 
MD.Id AS MobileID,
MD.MobileBrand,
MD.MobileName
, count(MSD.Id) AS CurrentSaleCount
,SUM(MSD.SalePrice-MD.PurchASePrice) AS CurrentProfitLoss,
CAST(ROUND(SUM(MSD.SalePrice-MD.PurchASePrice)*100/SUM(MD.PurchASePrice),2) AS NUMERIC(36,2)) AS CurrentProfitLossPercent,
CAST(ROUND(SUM(MD.MRPrice-MSD.SalePrice)*100/SUM(MD.MRPrice),2) AS NUMERIC(36,2)) AS CurrentDiscountPercent
FROM MobileDetails MD,MobileSalesDetails MSD 
WHERE MD.Id=MSD.MobileId and MSD.SalesDate>=@FromDate and MSD.SalesDate<@ToDate 
GROUP BY MD.MobileBrand, MD.MobileName, MD.Id) curr
,
(SELECT 
MD.Id AS MobileID,
MD.MobileBrand
, MD.MobileName
, count(MSD.Id) AS PrevSaleCount
,SUM(MSD.SalePrice-MD.PurchASePrice) AS PrevProfitLoss,
CAST(ROUND(SUM(MSD.SalePrice-MD.PurchASePrice)*100/SUM(MD.PurchASePrice),2) AS NUMERIC(36,2)) AS PrevProfitLossPercent,
CAST(ROUND(SUM(MD.MRPrice-MSD.SalePrice)*100/SUM(MD.MRPrice),2) AS NUMERIC(36,2)) AS PrevDiscountPercent
FROM MobileDetails MD,MobileSalesDetails MSD 
WHERE MD.Id=MSD.MobileId and MSD.SalesDate>=@FromDate - (@ToDate- @FromDate) and MSD.SalesDate<@FromDate
GROUP BY MD.MobileBrand, MD.MobileName, MD.Id) prev
WHERE curr.MobileID=prev.MobileID);

SELECT * FROM [dbo].[MobileSaleComparisonDetails]

END
GO


