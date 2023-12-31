USE [SuperShopDb]
GO
/****** Object:  StoredProcedure [dbo].[GetTopProducts]    Script Date: 7/19/2023 2:11:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetTopProducts] 
AS
BEGIN
    SELECT TOP 10 -- You can adjust the number of trending products to return
        p.Id,
        p.Name,
        p.PopularityCount,
		NULL AS CreatedBy, UpdatedBy, vat,Description,ImageUrl,Quantity,ExpirationDate,LastUpdated,CreatedDate,CategoryId,Price
    FROM
        product p
    ORDER BY
        PopularityCount DESC;
END;
