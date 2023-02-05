# University-courses-registration-system-![Screenshot 2023-02-05 204522](https://user-images.githubusercontent.com/40655914/216841317-0af16e31-a87a-47de-82fe-0780aead3b72.png)

The application is built on the basis of a variety of  MVC  and Onion architectures, which are based on basic principles such as: Dependency Inversion, IoC and Separation of Concerns, with the main emphasis reducing the dependencies between the individual modules in the code, building application layers that implement dependence "from the inside out", as the outer layers communicate with the internal ones through interfaces.  
The application consists of 5 modules that implement specific functionalities and technology stack:
  1.	CourseManagement – ASP.NET Core Web App (MVC), .Net 6.0. The project contains two controllers that implement the logic for managing students, users and student courses. 

  2.	DomainLayer - ClassLibrary, .Net 6.0.  The project contains the models, DTO entities, interfaces and model configurations that are used by EF Core when generating the DB objects and their relationships. 

  3.	LoggingService - ClassLibrary, .Net 6.0. The  project contains an implementation of  Nlog that logs events from the application. The Nlog Service Configuration File (nlog. config) is located  in the root directory of  the CourseManagement project and stores the event in a folder on the local disk: c:\Logs\.

  4.	RepositoryLayer - ClassLibrary, .Net 6.0.  The project contains an implementation of Code-First approach,  Migrations, EF Core to generate database objects in SQL Server.   The project contains an implementation of  the Generic Repositoty Pattern. To create and maintain database with users and roles, a Microsoft implementation.AspNetCore.Identity.EntityFrameworkCore is used.

  5.	ServiceLayer -  ClassLibrary, .Net 6.0. This  project adds a new abstract layer, above the database layer. This layer contains all the business logic of the application. The concrete implementation of this layer demonstrates the use of the System.Lazy  class to improve application performance  and save system resources by using the Lazy loading approach  , for initialization and use of resources and objects, only at the time when they are needed.
