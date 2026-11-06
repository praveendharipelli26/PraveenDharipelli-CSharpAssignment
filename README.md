# Employee Time Assignment

A C# .NET 9 console application developed by **Praveen Dharipelli** to retrieve employee time-entry data from a REST API, calculate total working hours, and generate an HTML report with a visual pie chart.

## Features

- Fetch employee time-entry records from a REST API using `HttpClient`.
- Deserialize JSON responses using `Newtonsoft.Json`.
- Calculate total working hours for each employee using LINQ.
- Sort employees by total working hours in descending order.
- Generate an HTML employee report.
- Highlight employees who have worked less than 100 hours.
- Generate a PNG pie chart displaying each employee's share of total working hours.

## Technologies Used

- C#
- .NET 9
- Newtonsoft.Json
- LINQ
- HttpClient
- ScottPlot
- HTML & CSS

## How to Run

1. Download `PraveenDharipelli.exe`.
2. Double-click the executable to run the application.
3. The application automatically retrieves and processes employee time-entry data.
4. The HTML report and pie chart are generated automatically.

**No installation required. Just download and run the EXE.**

## Generated Output

The application generates the following files:

| File | Description |
|---|---|
| `EmployeeReport.html` | Employee working-hours report with sorted records and highlights for employees below 100 hours. |
| `EmployeeWorkHours.png` | Pie chart displaying each employee's percentage of total working hours. |

## Author

**Praveen Dharipelli**

GitHub: [PraveenDharipelli](https://github.com/praveendharipelli26)
