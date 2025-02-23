erDiagram
      
"dbo.Towns" {
    int TownID "PK"
          varchar(50) Name ""
          
}
"dbo.Addresses" {
    int AddressID "PK"
          varchar(100) AddressText ""
          int TownID "FK"
          
}
"dbo.Projects" {
    int ProjectID "PK"
          varchar(50) Name ""
          ntext(1073741823) Description ""
          smalldatetime StartDate ""
          smalldatetime EndDate ""
          
}
"dbo.EmployeesProjects" {
    int EmployeeID "FK, PK"
          int ProjectID "FK, PK"
          
}
"dbo.Departments" {
    int DepartmentID "PK"
          varchar(50) Name ""
          int ManagerID "FK"
          
}
"dbo.Employees" {
    int EmployeeID "PK"
          varchar(50) FirstName ""
          varchar(50) LastName ""
          varchar(50) MiddleName ""
          varchar(50) JobTitle ""
          int DepartmentID "FK"
          int ManagerID "FK"
          smalldatetime HireDate ""
          money Salary ""
          int AddressID "FK"
          
}
"View: dbo.V_EmployeesHiredAfter2000" {
    dbo_Employees FirstName ""
          dbo_Employees LastName ""
          dbo_Employees HireDate ""
          
}
      "dbo.Addresses" |o--|{ "dbo.Towns": "TownID"
"dbo.EmployeesProjects" ||--|{ "dbo.Employees": "EmployeeID"
"dbo.EmployeesProjects" ||--|{ "dbo.Projects": "ProjectID"
"dbo.Departments" ||--|{ "dbo.Employees": "EmployeeID"
"dbo.Employees" ||--|{ "dbo.Departments": "DepartmentID"
"dbo.Employees" |o--|{ "dbo.Employees": "EmployeeID"
"dbo.Employees" |o--|{ "dbo.Addresses": "AddressID"
"View: dbo.V_EmployeesHiredAfter2000" ||--|| "dbo.Employees": "V_EmployeesHiredAfter2000 => Employees"
"View: dbo.V_EmployeesHiredAfter2000" ||--|| "dbo.Employees": "V_EmployeesHiredAfter2000 => Employees"
"View: dbo.V_EmployeesHiredAfter2000" ||--|| "dbo.Employees": "V_EmployeesHiredAfter2000 => Employees"
