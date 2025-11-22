### 📘 Simple Product Management Web App

A simple CRUD (Create, Read, Update, Delete) web application built with ASP.NET Core MVC, Dapper, and MSSQL Server.
The app allows users to add, edit, delete, and view products.

### 🚀 Features

✔ View product list
✔ Create a new product
✔ Edit existing product
✔ Delete product with confirmation

### 🏗️ Database Setup

```sql
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT SYSUTCDATETIME()
);
```

### ⚙️ Configure the Connection String

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB_NAME;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 📥 1. Clone the repository

```bash
git clone https://github.com/yourname/SimpleWebApp.git
cd SimpleWebApp
```


### 🧪 Testing the App

Navigate to Products page
Click Add Product to create new product
Use Edit and Delete actions on the products
