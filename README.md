# AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2

## Project Overview

- The online application **AgriEnergy Connect** is a prototype.  In order to facilitate effective administration of agricultural goods, farmer profiles, and product monitoring, the platform links **Farmers** with **Employees**.  **ASP.NET Core Razor Pages**, **Entity Framework Core**, and **SQL Server LocalDB** are used in the system's construction.

---

## Purpose of the Project

- The system's goal is to consolidate and digitize farmer product submissions so that data handling can be done more effectively.  Employees can easily filter agricultural data and manage farmer profiles thanks to it. The system's overall goal is to help all agricultural stakeholders make well-informed decisions by increasing data visibility and traceability.
---

## Ways to Make This Prototype Function  (One step at a time)

1.	Visit the GitHub page and download the project:  GitHub AgriEnergyConnect o Select "Download ZIP" by clicking the green "Code" button, or use git clone to create a copy of it: https://github.com/debbydelport/AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.git

2.	Launch the Visual Studio project.
Launch Visual Studio 2022 or a later version.
Select Project/Solution under File > Open.
AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.sln is the file to open.

3.	Restore Dependencies
 When you open the project in Visual Studio, NuGet packages will be immediately restored.  To manage NuGet packages for Solution, go to Tools > NuGet Package Manager.
 If necessary, click Restore.

5.	Launch the App o Click the Run button (green triangle at the top) or press F5. 
By doing this, the project will be built and your browser will open the website.

6.	 What Takes Place Next? 
 The database will be automatically created by the system, and sample data (farmers and goods) will be added. 
You may now sign up as an employee or farmer. 
Farmers may add and see items on their Farmer Dashboard after logging in. 
Employees will view/filter all items and manage farmers via their Employee Dashboard.

---

## User Roles

### Farmer
- Through a customized dashboard that offers a clear picture of their contributions, farmers can register and log into their accounts, upload new items with pertinent information like category, price, and production date, and examine all of the products they have provided.

### Employee

- Workers with enhanced credentials, which provide them administrative access, can register and log in. They may browse all of the items that different farmers have submitted, add new farmer profiles to the system, and filter these products according to particular categories or time periods. A thorough list of all registered farmers is also accessible and manageable by staff, allowing for more efficient monitoring and assistance.
---

## Features

- Numerous strong features are available in the AgriEnergy Connect system to help with agricultural data management.  To guarantee that farmers and staff have safe and suitable access, it incorporates role-based authentication and authorization.  Employees have access to a farmer administration interface to manage profiles and data, and farmers may submit items using a specific form.  Additionally, the platform allows for sophisticated product filtering by date and category, which facilitates effective data analysis and decision-making.  Each user type will only see the information that is pertinent to them thanks to role-specific dashboards.  To illustrate essential features and expedite development testing, the system is pre-populated with example data using a DbInitializer class and is supported by a local SQL Server database.
---

## Technologies Used

| Layer        | Technology                     |
|--------------|--------------------------------|
| Frontend     | ASP.NET Core Razor Pages       |
| Backend      | ASP.NET Core, C#               |
| Database     | SQL Server LocalDB + EF Core   |
| Authentication | ASP.NET Identity             |
| IDE          | Visual Studio 2022             |
| Version Control | Git + GitHub                |

---

## Database Design

### Tables:
- **Farmers**: Stores name, email, and contact number.
- **Products**: Stores product details and is linked to Farmers via `FarmerID1` (foreign key).

### Relationships:
- One-to-Many: One farmer can have many products.

### Implementation:
- implemented by inserting sample farmers and products at application setup using `DbInitializer.cs`.
---

## How It Works
- In order to improve usability and expedite processes, the AgriEnergy Connect online application adheres to a structured and role-driven workflow.  Users can choose to log in as either an employee or a farmer when they first use the site.  Users are taken to their individual dashboards after authenticating. 
- Farmers may submit new items by inputting information such the product name, category, production date, and price in an easy-to-use interface.  These goods are associated with the submitting farmer and kept in a relational database.
- On the other hand, staff members have access to a thorough management dashboard that allows them to view all farmers, create new farmer profiles, and search through the whole list of items that have been submitted by category and date range.
- ASP.NET Core with Razor Pages powers the online application, which also leverages Entity Framework for database interaction and ASP.NET Identity for secure authentication. This guarantees a smooth transition between data management and login inside a tidy, role-specific interface.
---
