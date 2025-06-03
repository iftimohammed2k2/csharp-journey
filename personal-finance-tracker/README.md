# 💸 Personal Finance Tracker (C# Console App)

A lightweight command-line app to track income and expenses using basic C#. It stores transactions in a local `.csv` file and calculates your total balance, income, and expense history.

---

## 📌 Features

- Add income and expense entries
- View transaction history in a clean format
- See total balance, income, and expenses
- Persistent storage using `.csv` files (no database required)
- Fully works without .NET SDK or Visual Studio

---

## 🧰 Tech Stack

- **C# (Mono-compatible)**
- **CSV File I/O**
- **Command-line interface**

---

## 💡 Why No `dotnet` or `System.Text.Json`?

This project was built under the following real-world constraints:

### ❌ No `dotnet` CLI or SDK
- My development environment only allows classic C# compilation using `mcs` and `mono` — not the newer `dotnet` toolchain.
- This means I can’t use ASP.NET, NuGet packages, or features that require `dotnet new` or `dotnet run`.

### ❌ No `System.Text.Json`
- `System.Text.Json` is a relatively newer namespace that isn’t supported by older Mono installations.
- Instead, I used **manual file writing and CSV formatting**, which keeps it simple and compatible with low-resource environments.

This constraint made me think creatively about how to persist data using just core C#.

---

## 📦 How to Run

### 1. Clone or download this repo

```bash
git clone https://github.com/yourusername/personal-finance-tracker.git
cd personal-finance-tracker
