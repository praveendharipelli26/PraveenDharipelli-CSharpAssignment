# Employee Time Assignment

A C# .NET console application developed by **Praveen Dharipelli** to retrieve employee time-entry data from a REST API, calculate total working hours, and generate an HTML report and pie chart.

## Features
- Fetch employee time-entry data from a REST API using HttpClient.
- Deserialize JSON data using Newtonsoft.Json.
- Calculate total working hours for each employee using LINQ.
- Sort employees based on total working hours.
- Generate an HTML employee report.
- Highlight employees who have worked less than 100 hours.
- Generate a PNG pie chart displaying each employee's percentage of total working hours.

## Technologies Used
- C#
- .NET 9
- Newtonsoft.Json
- LINQ
- HttpClient
- ScottPlot
- HTML & CSS

## How to Run

### Using Executable (Recommended)

1. Download `PraveenDharipelli_CSharpAssignment.exe`.
2. Double-click the executable to run the application.
3. The application retrieves the employee data from the API and generates the output files.
4. Open the generated HTML report in a browser to view employee working hours.

**Note:** The executable requires a compatible .NET 9 runtime if it is not published as a self-contained application.

### Using Source Code

```powershell
dotnet restore
dotnet run
```

## Generated Output

The application generates the following files:

- `EmployeeReport.html` – Employee working-hours report.
- `EmployeeWorkHours.png` – Employee working-hours pie chart.

## Author

**Praveen Dharipelli**
