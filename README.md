# 🏨 Hotel Management System

A full-stack hotel management system built with **ASP.NET Core**, following a **layered (N-tier) architecture**.  
The project includes a RESTful API, **RapidAPI integration**, an MVC-based UI, and JWT authentication.

---

## 🚀 Overview

This project is designed to manage hotel operations such as room management, bookings, guest tracking, and messaging.

It provides:

- 👨‍💼 Admin panel for management operations  
- 🌐 Customer-facing interface  
- 🔗 API-driven communication between layers  

The architecture focuses on **clean code**, **scalability**, and **separation of concerns**.

---

## 🏗️ Architecture

The solution follows a classic **N-Tier Architecture**:

- 📦 Entity Layer → Database entities  
- 🗄️ Data Access Layer → EF Core & repositories  
- 🧠 Business Layer → Business logic & services  
- 🌐 API Layer → RESTful services  
- 💻 UI Layer (MVC) → Consumes API via HttpClient  

---

## 👨‍💻 My Contributions

- 🏗️ Designed and implemented layered architecture  
- 🔗 Developed RESTful APIs using ASP.NET Core Web API  
- 🌐 Integrated external services using RapidAPI  
- 💻 Built MVC UI consuming API via HttpClientFactory  
- 🔐 Implemented authentication using ASP.NET Identity & JWT  
- 🗄️ Created database models with Entity Framework Core (Code First)  
- 🔄 Used AutoMapper for DTO transformations  
- ✔️ Applied FluentValidation for request validation  

---

## ⚙️ Features

- 🏨 Room management  
- 📅 Booking system  
- 👥 Guest management  
- 📩 Contact & messaging system  
- 📬 Sent / Inbox message structure  
- 📧 Newsletter subscription  
- 🔐 User registration & login  
- 👤 User listing  

---

## 🛠️ Technologies

- ⚡ ASP.NET Core MVC  
- 🌐 ASP.NET Core Web API  
- 🌍 RapidAPI (External API Integration)  
- 🗄️ Entity Framework Core  
- 🔐 ASP.NET Core Identity  
- 🎯 JWT Authentication  
- 🔄 AutoMapper  
- ✔️ FluentValidation  
- 📦 Newtonsoft.Json  
- 💾 SQL Server  

---

## 🔗 Project Structure

```
HotelProject
│
├── API/
│   ├── EntityLayer
│   ├── DataAccessLayer
│   ├── BusinessLayer
│   ├── DtoLayer
│   └── API (Controllers)
│
├── WEB/
│   └── WEB.UI (MVC)
│
└── JWT/
    └── Token generation & testing
```

---

## ▶️ Getting Started

### 1️⃣ Clone the repository

```bash
git clone <your-repo-url>
cd HotelProject
```

---

### 2️⃣ Configure Database

Update connection string in:

```json
API/API.Consume/appsettings.json
```

Example:

```json
"DefaultConnection": "Server=YOUR_SERVER;Database=HotelsProject;Integrated Security=True;TrustServerCertificate=True;"
```

---

### 3️⃣ Apply Migrations

```bash
dotnet ef database update --project API/API.DataAccessLayer --startup-project API/API.Consume
```

---

### 4️⃣ Run API

```bash
dotnet run --project API/API.Consume
```

Swagger:  
https://localhost:7227/swagger  

---

### 5️⃣ Run UI

```bash
dotnet run --project WEB/WEB.UI
```

UI:  
https://localhost:7086  

---

### 6️⃣ (Optional) Run JWT Service

```bash
dotnet run --project JWT
```

---

## 📡 API Endpoints

Includes controllers such as:

- RoomController  
- BookingController  
- ContactController  
- SubscribeController  
- TeamController  
- UserListController  

---

## 🧠 Key Concepts

- 🏗️ N-Tier Architecture  
- 🔗 RESTful API Design  
- 🌐 External API Integration (RapidAPI)  
- 🔐 Authentication & Authorization  
- 🔄 DTO & Mapping  
- 📦 Dependency Injection  

---

## ⭐ Highlight

Built a full-stack hotel management system with ASP.NET Core using N-tier architecture, RESTful APIs, RapidAPI integration, and JWT-based authentication.

---

## 📚 Reference & Inspiration

This project was inspired by the following repository and training:

- https://github.com/MuratYucedag/MyUdemyProject

The original project helped me understand layered architecture, API consumption, and RapidAPI integration.  
I extended and customized the project by implementing additional features, improving structure, and applying my own development approach.