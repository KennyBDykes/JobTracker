# Job Tracker

A simple job application tracking system built using **ASP.NET Core** and **Entity Framework Core**. This project allows applicants to manage their job applications and admins to view them.

> ⚠️ Authentication uses **seeded users only** (Admin and Applicant). Passwords are stored in plain text for simplicity — no real hashing is implemented yet.

---

## 🛠️ Tech Stack

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQLite
- C#

---

## 📦 Features

- ✅ User authentication (Admin and Applicant)
- ✅ Admin can view all job applications
- ✅ Applicants can create, view, edit, and delete their own applications
- ✅ SQLite for local development

---

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/KennyBDykes/JobTracker.git
   cd JobTracker
Apply the database migration
dotnet ef database update
Run the application
dotnet run

Login with a seeded user
Username: admin
Password: admin123
Username: applicant
Password: app123
