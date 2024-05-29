# Project Name: LabProject API

## Description:
This project is a Web API for managing a product catalog and user reviews, developed in C# using .NET Web API. It features a robust architecture, following best practices of RESTful API development to ensure scalability and maintainability.

![Project Architecture](Images/.Net-Web-API.png)

## 📌 Features:
- **CRUD Operations**: Manage products and reviews.
- **Authentication & Authorization**: Secure API endpoints with JWT authentication and role-based access control.
- **Swagger Documentation**: Automatically generated API documentation.
- **Logging & Monitoring**: Detailed logging for monitoring and debugging.
- **Pagination**: Efficient handling of large datasets.

## 🚀 Getting Started:
### Prerequisites:
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation:
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/LabProjectAPI.git
    ```
2. Navigate to the project directory:
    ```bash
    cd LabProjectAPI
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```

### Configuration:
1. Update the connection string in `ProjectDbContext` to match your SQL Server configuration:
    ```csharp
    optionsBuilder
        .UseSqlServer("Server=your_server;Database=Project;User Id=your_user;Password=your_password;TrustServerCertificate=True")
        .LogTo(Console.WriteLine);
    ```

### Usage:
1. Build the project:
    ```bash
    dotnet build
    ```
2. Run the project:
    ```bash
    dotnet run
    ```

## 📊 API Endpoints:
### Product Endpoints:
#### Get All Products
- **URL**: `/api/produs/get-products`
- **Method**: `POST`
- **Description**: Retrieve a list of all products
- **Request Body**: `GetProduseRequest`
- **Response**: `GetProduseResponse`

#### Get Product by ID
- **URL**: `/api/produs/{produsId}/get-details`
- **Method**: `GET`
- **Description**: Retrieve a product by its ID
- **Parameters**: `produsId` (required)
- **Response**: `GetProdusResponse`

### Review Endpoints:
#### Get Reviews by Product ID
- **URL**: `/api/review/produs/{produsId}/reviews`
- **Method**: `GET`
- **Description**: Retrieve reviews for a specific product
- **Parameters**: `produsId` (required)
- **Response**: List of reviews

#### Add Review
- **URL**: `/api/review/add`
- **Method**: `POST`
- **Description**: Add a new review
- **Request Body**: `AddReviewRequest`
- **Response**: Success message

#### Update Review
- **URL**: `/api/review/{reviewId}/edit-review`
- **Method**: `PUT`
- **Description**: Update an existing review
- **Parameters**: `reviewId` (required)
- **Request Body**: `UpdateReviewRequest`
- **Response**: Success message

#### Delete Review
- **URL**: `/api/review/delete-review`
- **Method**: `DELETE`
- **Description**: Delete an existing review
- **Parameters**: `reviewId` (required)
- **Response**: Success message

### User Endpoints:
#### Register
- **URL**: `/register`
- **Method**: `POST`
- **Description**: Register a new user
- **Request Body**: `RegisterRequest`
- **Response**: Success message

#### Login
- **URL**: `/login`
- **Method**: `POST`
- **Description**: Authenticate a user and return a JWT token
- **Request Body**: `LoginRequest`
- **Response**: JWT token

## 💾 Data Models:
### Product Model
- **Properties**:
  - `Id`: `int` - Unique identifier for the product
  - `Name`: `string` - Name of the product
  - `Category`: `string` - Category the product belongs to
  - `Price`: `decimal` - Price of the product

### Review Model
- **Properties**:
  - `Id`: `int` - Unique identifier for the review
  - `Title`: `string` - Title of the review
  - `Description`: `string` - Detailed description of the review
  - `Rating`: `int` - Rating score of the review
  - `ProductId`: `int` - ID of the associated product

### User Model
- **Properties**:
  - `Id`: `int` - Unique identifier for the user
  - `Email`: `string` - Email address of the user
  - `PasswordHash`: `string` - Hashed password of the user
  - `Role`: `string` - Role of the user (e.g., Admin, User)

## 🛠️ Technologies Used:
- **.NET 6**
- **Entity Framework Core**
- **SQL Server**
- **Swagger** for API documentation
- **JWT Authentication**

## 🤝 Contributing:
1. Fork the repository
2. Create a new branch (`git checkout -b feature-branch`)
3. Make your changes
4. Commit your changes (`git commit -m 'Add some feature'`)
5. Push to the branch (`git push origin feature-branch`)
6. Open a Pull Request

## 📄 License:
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📝 Acknowledgements:
- Special thanks to [Person or resource] for [reason].
- Another acknowledgment.

---

Feel free to replace the placeholders with actual details from your project. This structure ensures that your README is comprehensive and helpful for anyone who might use or contribute to your repository.
