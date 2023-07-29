## ERRORS
- Fetch error response status is 500 https://localhost:7225/swagger/v1/swagger.json
	- solution: added [HttpGet] before a action in controller
	- the error is related to swagger so this can be resolved if we change the url.
- added two foreign key in product table and got this error `Introducing FOREIGN KEY constraint 'FK_Products_Stocks_StockRefId' on table 'Products' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
Could not create constraint or index. See previous errors.`
	- solution: 
	```
	protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasOne(p => p.Stocks)
                      .WithMany()
                      .HasForeignKey(p => p.StockRefId)
                      .OnDelete(DeleteBehavior.NoAction); // Specify the cascading behavior

                entity.HasOne(p => p.Category)
                      .WithMany()
                      .HasForeignKey(p => p.CategoryRefId);
            });

            base.OnModelCreating(modelBuilder);
        }
    ```