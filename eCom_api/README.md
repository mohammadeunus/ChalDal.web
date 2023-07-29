## ERRORS
1. Fetch error response status is 500 https://localhost:7225/swagger/v1/swagger.json
	- solution: added [HttpGet] before a action in controller
	- the error is related to swagger so this can be resolved if we change the url.
2. added two foreign key in product table and got this error `Introducing FOREIGN KEY constraint 'FK_Products_Stocks_StockRefId' on table 'Products' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
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
    - it gave error again : because i was creating one2one relation in both table. created foreign key foreach other in both table . it caused conflict.
        - error again: but solved. 
            - solution summary: 
                - follow the dependency of fk: if u pass a value in fk, make sure that fk has a row created in that table
                - check how to create one2one and one2many relationship. the way i created the relationship were wrong.