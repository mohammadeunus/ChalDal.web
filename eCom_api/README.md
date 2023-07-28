##Database design
![UML_eCom](asset/UML_eCom.png)

### Relationships between Models

1. **Product and Review**: One-to-Many relationship. The `ProductId` in the `Review` table is a Foreign Key referencing the `ProductId` in the `Product` table.

2. **Product and Stock**: One-to-One relationship. The `ProductId` in the `Stock` table is a Foreign Key referencing the `ProductId` in the `Product` table.

3. **CartItem and Product**: Many-to-One relationship. Both the `ProductId` and `UserId` in the `CartItem` table are Foreign Keys referencing the `ProductId` and `UserId` in the `Product` table.

4. **Order and CartItem**: One-to-Many relationship. The `OrderId` in the `CartItem` table is a Foreign Key referencing the `OrderId` in the `Order` table.

5. **Order and Payment**: One-to-Many relationship. The `OrderId` in the `Payment` table is a Foreign Key referencing the `OrderId` in the `Order` table.

6. **Wishlist and Product**: Many-to-Many relationship. The `Wishlist` table has both `ProductId` and `UserId` as Foreign Keys referencing the `ProductId` and `UserId` in the `Product` table.



In summary, these relationships define how different entities in the e-commerce application are associated with each other, allowing for efficient data retrieval and management.
## ERRORS
- Fetch error response status is 500 https://localhost:7225/swagger/v1/swagger.json
	- solution: added [HttpGet] before a action in controller
	- the error is related to swagger so this can be resolved if we change the url.

