# 📋 Service Order Management API with JWT Authentication & SQLite

This project is a RESTful API built with **ASP.NET Core**, **Entity Framework Core**, and **SQLite**. It implements **JWT Authentication** for secure access, managing **Service Orders** along with associated **Client** details. The API supports operations such as creating, listing, updating, and deleting service orders, and follows best practices like Domain-Driven Design (DDD) and the Repository pattern.

---

## 🚀 Features

- ✅ **Service Order Management:**  
  Create, list, update, and delete service orders with complete client information.
- 🔐 **JWT Authentication:**  
  Secure endpoints using token-based authentication.
- 📋 **CRUD Operations:**  
  Perform full CRUD operations on service orders.
- 🏗️ **DDD & Repository Pattern:**  
  Well-organized project structure for better maintainability.
- 📊 **SQLite Database:**  
  Persist data using Entity Framework Core with SQLite.
- 📚 **Swagger Documentation:**  
  Interactive API documentation for easy testing and integration.

---

## 🏗️ Tech Stack

- **.NET 6+** (ASP.NET Core Web API)
- **Entity Framework Core** (ORM)
- **SQLite** (Database)
- **JWT (JSON Web Tokens)** (Authentication)
- **Swagger** (API documentation)

---

## ⚙️ Setup Instructions


### 1️⃣ Clone the Repository

```bash
git clone https://github.com/yourusername/ServiceOrderManagement.git
cd ServiceOrderManagement
```
### 2️⃣ Install Dependencies
```bash
dotnet restore
```

3️⃣ Update Configuration
In appsettings.json, configure your connection string and JWT settings:


```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=serviceorders.db"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyHere",
    "Issuer": "ServiceOrderManagement",
    "Audience": "ServiceOrderManagementUsers",
    "ExpiryInMinutes": 60
  }
}
```

4️⃣ Run Database Migrations
```bash
dotnet ef migrations add InitialCreate --project ServiceOrderManagement.Infrastructure
dotnet ef database update --project ServiceOrderManagement.Infrastructure
```

5️⃣ Run the API
```bash
dotnet run --project ServiceOrderManagement.API
```
---

## 🔑 JWT Authentication

1. Login to receive a **JWT Token**.
2. Add the token in the request header:

```
Authorization: Bearer <your_token_here>
```

---

## 🚀 Future Improvements

- Password hashing with BCrypt
- Refresh Token mechanism
- Role-based access control (RBAC)
- API versioning

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---

## 👨‍💻 Author

Developed by **João Danilo Zucolotto Diedrich**
