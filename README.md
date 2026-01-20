# Purchase Order Management

## Overview

This is a full-stack web application developed as part of the ConInnova Junior Software Engineer coding assessment.  
The system allows procurement staff to manage Purchase Orders (POs) with full CRUD functionality, filtering, sorting, and pagination.

---

## Tech Stack

### Backend
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (Code-First)
- SQL Server (LocalDB)

### Frontend
- Angular (Standalone Components)
- TypeScript
- HTML / CSS

---

## Features

- List all Purchase Orders in a table view
- Create, Update, and Delete Purchase Orders
- Filter by Supplier Name and Status
- Sort by PO Number, Order Date, and Total Amount
- Pagination for large data sets
- Numeric values formatted to two decimal places
- RESTful API with Swagger documentation

---

## Status Mapping

| Value | Status     |
|-------|------------|
| 0     | Draft      |
| 1     | Approved   |
| 2     | Shipped    |
| 3     | Completed  |
| 4     | Cancelled  |

---

## Assumptions

- PO Number is unique.
- Total Amount values are stored and displayed with two decimal places.
- SQL Server LocalDB is available on the local machine.
- CORS is enabled for frontend-backend communication.
- No authentication required for this assessment.

---
