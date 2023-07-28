# a eCommerce web API
##Database design
 
![UML_eCom](/assests/UML_eCom.drawio.png)

### Relationships between Models

1. **Product and Review**: One-to-Many relationship. The `ProductId` in the `Review` table is a Foreign Key referencing the `ProductId` in the `Product` table.

2. **Product and Stock**: One-to-One relationship. The `ProductId` in the `Stock` table is a Foreign Key referencing the `ProductId` in the `Product` table.

3. **CartItem and Product**: Many-to-One relationship. Both the `ProductId` and `UserId` in the `CartItem` table are Foreign Keys referencing the `ProductId` and `UserId` in the `Product` table.

4. **Order and CartItem**: One-to-Many relationship. The `OrderId` in the `CartItem` table is a Foreign Key referencing the `OrderId` in the `Order` table.

5. **Order and Payment**: One-to-Many relationship. The `OrderId` in the `Payment` table is a Foreign Key referencing the `OrderId` in the `Order` table.

6. **Wishlist and Product**: Many-to-Many relationship. The `Wishlist` table has both `ProductId` and `UserId` as Foreign Keys referencing the `ProductId` and `UserId` in the `Product` table.

 
