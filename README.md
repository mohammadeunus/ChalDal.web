# a eCommerce web API
##Database design
 
![UML_eCom](/assests/UML_eCom.drawio.png)

### Relationships between Models

The provided diagram is a Unified Modeling Language (UML) class diagram representing the relationships between various entities in a sample e-commerce application. Let's describe the relationships:

1. **Inheritance Relationships:**

   - `UserBase` inherits from `BaseEntity`: `UserBase` class inherits the properties of `BaseEntity` class, which includes properties like `IsDeleted`, `CreatedBy`, `CreatedDate`, `UpdatedBy`, and `UpdatedDate`. This allows `UserBase`, `Admin`, and `Customer` to have those common properties.

   - `Admin` inherits from `UserBase`: `Admin` class is a specialization of `UserBase` and inherits the properties `Username`, `PasswordHash`, and `Email`, along with the common properties from `BaseEntity`.

   - `Customer` inherits from `UserBase`: `Customer` class is another specialization of `UserBase` and inherits the properties `Username`, `PasswordHash`, and `Email`, along with the common properties from `BaseEntity`.

2. **Association Relationships:**

   - `Customer` "1" -- "N" `Review`: A `Customer` can have multiple `Review`s (one-to-many relationship), while a `Review` is associated with only one `Customer`.

   - `Product` "1" -- "N" `Review`: A `Product` can have multiple `Review`s (one-to-many relationship), while a `Review` is associated with only one `Product`.

   - `Product` "1" -- "N" `Stock`: A `Product` can have multiple `Stock` entries (one-to-many relationship), while a `Stock` entry is associated with only one `Product`.

   - `Product` "N" -- "1" `Category`: A `Product` belongs to one `Category`, while a `Category` can have multiple `Product`s (many-to-one relationship).

   - `CartItem` "1" -- "1" `Product`: A `CartItem` is associated with one `Product`, and a `Product` can be associated with only one `CartItem` (one-to-one relationship).

   - `CartItem` "1" -- "1" `Customer`: A `CartItem` is associated with one `Customer`, and a `Customer` can have only one `CartItem` (one-to-one relationship).

   - `Order` "1" -- "1" `Customer`: An `Order` is associated with one `Customer`, and a `Customer` can have only one `Order` (one-to-one relationship).

   - `Order` "1" -- "N" `CartItem`: An `Order` can have multiple `CartItem`s (one-to-many relationship), while a `CartItem` is associated with only one `Order`.

   - `Order` "1" -- "N" `Payment`: An `Order` can have multiple `Payment`s (one-to-many relationship), while a `Payment` is associated with only one `Order`.

   - `Wishlist` "1" -- "N" `Product`: A `Wishlist` can have multiple `Product`s (one-to-many relationship), while a `Product` is associated with only one `Wishlist`.

   - `Wishlist` "N" -- "1" `Customer`: A `Wishlist` belongs to one `Customer`, while a `Customer` can have multiple `Wishlist`s (many-to-one relationship).

These relationships help to define how various entities in the application are connected and how they interact with each other.