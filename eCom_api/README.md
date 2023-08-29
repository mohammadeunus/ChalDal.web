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

3. Unable to resolve service for type 'ExpenseTracker.Repository.IEachCategoryRepository' while attempting to activate 'ExpenseTracker.Controllers.EachCategoriesController'.
    - solution: added 'ExpenseTracker.Repository.IEachCategoryRepository' in IOC

4. TokenService > CreateToken > : Unable to create KeyedHashAlgorithm for algorithm, the key size must be greater than: '512' bits, key has '504' bits. (Parameter 'keyBytes')
    - solution: increased the tokenKey size in appsetting file 
        ```
        {
            "TokenKey": "ThisIsAStrongAndLongTokenKeyWithAtLeast512BitsOrMore"
        }
        ```


## DI 
AddScoped vs Transient vs Singleton
- It means that a new instance of the service will be created each time it is requested
    builder.RegisterType<MyService>().InstancePerDependency(); 
- It means that a single instance of the service is created per lifetime scope.
    builder.RegisterType<MyScopedService>().InstancePerLifetimeScope(); 
- It means that only one instance of the service is created and shared throughout the application.
    builder.RegisterType<MySingletonService>().SingleInstance(); 

- builder.RegisterType<IndexModel>().AsSelf(); //if wish to pass a model throgh DI
    RegisterType<IndexModel>(), it registers the IndexModel class as a dependency with Autofac.
    * .AsSelf(), it specifies that, Autofac will provide an instance of IndexModel when requested.


## JWT- Jeson Web Token
is used to securely transfer information over the web(between two parties). 
It can be used for an authentication system and can also be used for information exchange.
The token is mainly composed of 
    - header, 
    - payload, 
    - signature. These three parts are separated by dots(.)
JWT defines the structure of information we are sending from one party to the another, and it comes in two forms 
    – Serialized, 
    - Deserialized. 
>HTTP protocol is stateless, this means a new request (e.g. GET /order/42) won’t know anything about the previous one.

### why use jwt or benefits
- Once issued, JWTs contain information about the user, roles, and permissions. Servers can validate the integrity of the token using a cryptographic signature without querying the database for each request. This enhances performance.
- JWTs follow the JSON Web Token standard (RFC 7519), making them widely accepted and easily implementable across different programming languages and platforms.
- JWTs do not rely on browser cookies, making them compatible with mobile applications. They can be stored in local storage or mobile app storage mechanisms.



