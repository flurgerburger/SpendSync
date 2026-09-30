# SpendSync PH 🇵🇭

**SpendSync PH** is a personal finance and budget management web application tailored for tracking Philippine Peso (₱) day-to-day expenses and recurring subscriptions. Built with .NET 10 Blazor and MudBlazor, it provides a centralized dashboard to keep your monthly cash flow clear and predictable.

---

## What the App Does

* **Daily Expense Tracking:** Log and categorize one-time purchases and everyday spending (Food & Dining, Transportation, Groceries, Utilities) with local payment methods like GCash, Maya, Cash, Credit/Debit cards, and Bank Transfers.
* **Subscription Management:** Monitor recurring charges (streaming services, internet bills, software tools). Automatically calculates normalized monthly equivalent costs (whether billed weekly, monthly, quarterly, or yearly) and tracks upcoming renewal dates so bills don't surprise you.
* **Consolidated Financial Dashboard:** Combines day-to-day out-of-pocket expenses and active subscriptions into a unified monthly spend forecast.
* **Live In-Memory State:** Instant, reactive updates across pages without manual refreshes using Blazor Server's real-time circuit.

---

## Tech Stack

* **Framework:** [.NET 10](https://dotnet.microsoft.com/) (ASP.NET Core Blazor - Interactive Server Mode)
* **Language:** C#
* **UI Component Library:** [MudBlazor](https://mudblazor.com/) (Material Design for Blazor)
* **Styling:** Vanilla CSS & MudBlazor Theme Palette

---

## Getting Started

### Prerequisites

* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Running Locally

1. Clone or open the repository:
   ```bash
   git clone <your-repo-url>
   cd SpendSync
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the development server:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to `https://localhost:7198` (or the HTTP/HTTPS port shown in your terminal).
