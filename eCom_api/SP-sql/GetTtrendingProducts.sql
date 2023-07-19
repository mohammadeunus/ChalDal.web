CREATE PROCEDURE GetTrendingProducts 
AS
BEGIN
    SELECT TOP 10 -- You can adjust the number of trending products to return
        p.Id,
        p.Name,
        p.PopularityCount
    FROM
        product p
    ORDER BY
        PopularityCount DESC;
END;
